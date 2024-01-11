using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> animalsPrefabs; // List of different object prefabs
    public float spawnInterval = 1f;
    public List<GameObject> locations;
    private readonly Dictionary<GameObject, bool> locationOccupancy = new();
    private List<GameObject> spawnedAnimals = new List<GameObject>(); // List to track spawned animals
    private GameObject hammer;
    public GameObject player;
    public float disappearanceDuration = 6.0f; // Duration after which the object disappears
    public List<AudioClip> spawnSounds;

    void Start()
    {
        // Initialize all cubes as unoccupied
        foreach (var cube in locations)
        {
            locationOccupancy[cube] = false;
        }

        hammer = GameObject.FindWithTag("Hammer");
        TurnSpawnerOn();
        TimeLimit.Instance.TimerEnded += TurnSpawnerOff;
    }

    void TurnSpawnerOn()
    {
        StartCoroutine(SpawnObjects());
    }

    void TurnSpawnerOff()
    {
        StopAllCoroutines();
        // Destroy all spawned animals
        foreach (var animal in spawnedAnimals)
        {
            if (animal != null)
            {
                Destroy(animal);
            }
        }
        spawnedAnimals.Clear(); // Clear the list after destroying the animals
    }

    IEnumerator SpawnObjects()
    {
        while (true) // Infinite loop to keep spawning objects
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObject()
    {
        GameObject randomLocation = GetRandomUnoccupiedLocation();
        if (randomLocation == null) return; // Exit if no unoccupied cube is found

        // Get the Renderer component to access the bounds
        if (!randomLocation.TryGetComponent<Renderer>(out var cubeRenderer))
        {
            Debug.LogError("No Renderer found on the cube GameObject!");
            return;
        }

        // Use the center of the bounds as the spawn position
        Vector3 centerPosition = cubeRenderer.bounds.center;
        GameObject animalToSpawn = animalsPrefabs[Random.Range(0, animalsPrefabs.Count)]; // Selects a random prefab
        animalToSpawn.GetComponent<AnimalController>().hammer = hammer;

        GameObject spawnedAnimal = Instantiate(animalToSpawn, centerPosition, animalToSpawn.transform.rotation); // Spawn the object
        spawnedAnimals.Add(spawnedAnimal); // Add the spawned animal to the list
        spawnedAnimal.transform.LookAt(player.transform); // Look at the player

        AudioSource audioSource = spawnedAnimal.GetComponent<AudioSource>();
        // Play a sound when animal is spawned
        if (audioSource != null && spawnSounds.Count > 0) {
            AudioClip randomClip = spawnSounds[Random.Range(0, spawnSounds.Count)];
            audioSource.clip = randomClip;
            audioSource.Play();
        }
        
        UpdatePunctuation.Instance.subscribe(spawnedAnimal); // Add the animal to the list of animals
        locationOccupancy[randomLocation] = true; // Mark the location as occupied

        // Attach a script to the spawned object to track when it is destroyed
        SpawnedObjectTracker tracker = spawnedAnimal.AddComponent<SpawnedObjectTracker>();
        tracker.Initialize(this, randomLocation);

        StartCoroutine(AnimateSpawn(spawnedAnimal));
        StartCoroutine(HandleDisappearance(spawnedAnimal));
    }

    IEnumerator AnimateSpawn(GameObject obj)
    {
        float duration = 0.5f; // Duration of the animation in seconds
        float height = 1.0f; // How high the object will move
        Vector3 startPosition = obj.transform.position;
        startPosition.y -= 1.0f; // Start the animation 2 units below the spawn position
        Vector3 endPosition = startPosition + new Vector3(0, height, 0);

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            obj.transform.position = Vector3.Lerp(startPosition, endPosition, t / duration);
            yield return null;
        }

        obj.transform.position = endPosition;
    }

    IEnumerator HandleDisappearance(GameObject obj)
    {
        yield return new WaitForSeconds(disappearanceDuration);
        Destroy(obj);
    }

    GameObject GetRandomUnoccupiedLocation()
    {
        List<GameObject> unoccupiedLocation = new();
        foreach (var pair in locationOccupancy)
        {
            if (!pair.Value) unoccupiedLocation.Add(pair.Key);
        }

        if (unoccupiedLocation.Count == 0) return null;
        return unoccupiedLocation[Random.Range(0, unoccupiedLocation.Count)];
    }

    public void MarkLocationAsUnoccupied(GameObject location)
    {
        if (locationOccupancy.ContainsKey(location))
        {
            locationOccupancy[location] = false;
            spawnedAnimals.Remove(location); // Remove the animal from the list when the location is marked unoccupied
        }
    }
}