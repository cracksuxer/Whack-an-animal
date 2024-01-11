using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The script is used for managing all the topics related with spawn new animals
/// </summary>
public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> animalsPrefabs; // List of different object prefabs
    public float spawnInterval = 1f;
    public List<GameObject> locations;
    private readonly Dictionary<GameObject, bool> locationOccupancy = new();
    private GameObject hammer;
    public GameObject player;
    public float disappearanceDuration = 6.0f; // Duration after which the object disappears

    /// <summary>
    /// The function is called at the begging and is used
    /// </summary>
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

    /// <summary>
    /// The function starts the spawner
    /// </summary>
    void TurnSpawnerOn()
    {
        StartCoroutine(SpawnObjects());
    }

    /// <summary>
    /// The function stop the spawner
    /// </summary>
    void TurnSpawnerOff()
    {
        StopAllCoroutines();
        
    }

    /// <summary>
    /// The function is used for spawn new objects along the game
    /// </summary>
    IEnumerator SpawnObjects()
    {
        while (true) // Infinite loop to keep spawning objects
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    /// <summary>
    /// The function provides the possibility of spawn a new object
    /// </summary>
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
        spawnedAnimal.transform.LookAt(player.transform); // Look at the player
        UpdatePunctuation.Instance.subscribe(spawnedAnimal); // Add the animal to the list of animals
        locationOccupancy[randomLocation] = true; // Mark the location as occupied

        // Attach a script to the spawned object to track when it is destroyed
        SpawnedObjectTracker tracker = spawnedAnimal.AddComponent<SpawnedObjectTracker>();
        tracker.Initialize(this, randomLocation);

        StartCoroutine(AnimateSpawn(spawnedAnimal));
        StartCoroutine(HandleDisappearance(spawnedAnimal));
    }

    /// <summary>
    /// The function make possible to animate the animal when it is spawned
    /// </summary>
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

    /// <summary>
    /// Is on charge of handle the destrucction of an object
    /// </summary>
    IEnumerator HandleDisappearance(GameObject obj)
    {
        yield return new WaitForSeconds(disappearanceDuration);
        Destroy(obj);
    }

    /// <summary>
    /// This function is used for get a random spot that is unoccupied
    /// </summary>
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

    /// <summary>
    /// Update the state of a locations as occupied
    /// </summary>
    public void MarkLocationAsUnoccupied(GameObject location)
    {
        if (locationOccupancy.ContainsKey(location))
        {
            locationOccupancy[location] = false;
        }
    }
}