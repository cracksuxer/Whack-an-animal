using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objectPrefabs; // List of different object prefabs
    public float spawnInterval = 1f;
    public List<GameObject> cubes;
    private Dictionary<GameObject, bool> cubeOccupancy = new Dictionary<GameObject, bool>();
    private GameObject hammer;

    void Start()
    {
        // Initialize all cubes as unoccupied
        foreach (var cube in cubes)
        {
            cubeOccupancy[cube] = false;
        }

        hammer = GameObject.FindWithTag("Hammer");

        StartCoroutine(SpawnObjects());
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
        GameObject randomCube = GetRandomUnoccupiedCube();
        if(randomCube == null) return; // Exit if no unoccupied cube is found

        GameObject prefabToSpawn = objectPrefabs[Random.Range(0, objectPrefabs.Count)]; // Selects a random prefab
        prefabToSpawn.GetComponent<AnimalController>().hammer = hammer;
        BoxCollider boxCollider = randomCube.transform.Find("Cube").GetComponent<BoxCollider>();

        Vector3 randomPosition = new Vector3(
            Random.Range(-boxCollider.size.x / 2, boxCollider.size.x / 2),
            Random.Range(-boxCollider.size.y / 2, boxCollider.size.y / 2),
            Random.Range(-boxCollider.size.z / 2, boxCollider.size.z / 2)
        ) + boxCollider.center;

        GameObject spawnedObject = Instantiate(prefabToSpawn, randomCube.transform.TransformPoint(randomPosition), Quaternion.identity);
        cubeOccupancy[randomCube] = true; // Mark the cube as occupied

        // Attach a script to the spawned object to track when it is destroyed
        SpawnedObjectTracker tracker = spawnedObject.AddComponent<SpawnedObjectTracker>();
        tracker.Initialize(this, randomCube);
    }

    GameObject GetRandomUnoccupiedCube()
    {
        List<GameObject> unoccupiedCubes = new List<GameObject>();
        foreach (var pair in cubeOccupancy)
        {
            if (!pair.Value) unoccupiedCubes.Add(pair.Key);
        }

        if (unoccupiedCubes.Count == 0) return null;
        return unoccupiedCubes[Random.Range(0, unoccupiedCubes.Count)];
    }

    public void MarkCubeAsUnoccupied(GameObject cube)
    {
        if (cubeOccupancy.ContainsKey(cube))
        {
            cubeOccupancy[cube] = false;
        }
    }
}