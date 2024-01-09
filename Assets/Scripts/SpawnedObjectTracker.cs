using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnedObjectTracker : MonoBehaviour
{
    private ObjectSpawner spawner;
    private GameObject myCube;

    public void Initialize(ObjectSpawner spawner, GameObject cube)
    {
        this.spawner = spawner;
        this.myCube = cube;
    }

    void OnDestroy()
    {
        spawner.MarkCubeAsUnoccupied(myCube);
    }
}