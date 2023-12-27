using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevateAnimal : MonoBehaviour
{
    public float inf_limit = 1;
    public float sup_limit = 10;
    public float max_height = 5;
    public float speed = 3;
    private bool activate_method = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ActualizeFlag", Random.Range(inf_limit, sup_limit));    
    }

    void Update() {
        if (activate_method == true) {
            Elevate();
        }
    }

    private void ActualizeFlag() {
        activate_method = true;
    }

    private void Elevate() {
        Vector3 current_position = transform.position;
        float new_position = Mathf.MoveTowards(current_position.y, max_height, speed * Time.deltaTime);
        transform.position = new Vector3(current_position.x, new_position, current_position.z);
        if (Mathf.Approximately(new_position, max_height)) {
            activate_method = false;
        }
    }    
}
