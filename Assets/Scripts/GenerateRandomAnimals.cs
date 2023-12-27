using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateRandomAnimals : MonoBehaviour
{
    public List<GameObject> object_list;
    public float spawn_distance = 1.0f;
    public bool spawn_on_start = true;
    public string elevate_script_direcction;

    // Start is called before the first frame update
    void Start()
    {
        if (spawn_on_start == true) {
            SpawnRandomObjectBelow();
        }
    }

    public void SpawnRandomObjectBelow() {
        if (object_list.Count == 0) {
            Debug.LogWarning("No hay objetos prefabricados en la lista.");
            return;
        }
        GameObject object_selected = object_list[UnityEngine.Random.Range(0, object_list.Count)];
        Vector3 position = transform.position - transform.up * spawn_distance;
        GameObject new_object = Instantiate(object_selected, position, Quaternion.identity);
        if (!string.IsNullOrEmpty(elevate_script_direcction)) {
            Type scriptType = Type.GetType(elevate_script_direcction);
            if (scriptType != null) {
                new_object.AddComponent(scriptType);
            } else {
                Debug.LogError("No se pudo encontrar el script con el nombre: " + elevate_script_direcction);
            }
        }
    }
}
