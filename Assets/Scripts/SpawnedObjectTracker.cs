using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This script identifies when an occupation is free or not
/// </summary>
public class SpawnedObjectTracker : MonoBehaviour
{
    private ObjectSpawner spawner;
    private GameObject myCube;

    /// <summary>
    /// The function is called at the begging of the script and update the information about if is the object is free or no
    /// </summary>
    public void Initialize(ObjectSpawner spawner, GameObject cube)
    {
        this.spawner = spawner;
        myCube = cube;
    }

    /// <summary>
    /// This function allows to make as unoccupied the object when the animal related to is destroyed
    /// </summary>
    void OnDestroy()
    {
        spawner.MarkLocationAsUnoccupied(myCube);
    }
}