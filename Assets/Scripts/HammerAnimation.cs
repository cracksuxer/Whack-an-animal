using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAnimation : MonoBehaviour
{
    public GameObject animal;
    public float back_speed;
    public float forward_speed;
    public float back_acceleration;
    public float forward_acceleration;
    public float time_to_go_back;
    public float time_to_go_fordward;
    public float offsetY; 
    public float offsetX; // si no se pone golpea con el palo no con el mazo, 12 en la x 30 en la y
    bool limit_time = false;
    float current_back_speed = 0f;
    float current_fordward_speed = 0f;

    void Start()
    {
        transform.position = new Vector3(animal.transform.position.x + offsetX, animal.transform.position.y + offsetY, animal.transform.position.z);
    }

    void Update()
    {
        if (Time.time > time_to_go_back) {
            if (Time.time > time_to_go_fordward) { limit_time = true; }
            if (limit_time == false) {
                current_fordward_speed += forward_acceleration * Time.deltaTime;
                MakeRotationFordward(-forward_speed -current_fordward_speed);
            }
        } else {
            current_back_speed += back_acceleration * Time.deltaTime;
            MakeRotationBack(back_speed + current_back_speed);
        }
    }

    void MakeRotationBack(float speed) {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }

    void MakeRotationFordward(float speed) {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }

    
}
