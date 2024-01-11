using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSwing : MonoBehaviour
{
    public AnimalController animal;
    public float forward_speed = 950.0f;
    public float forward_acceleration = 3500.0f;
    public float offsetX = 0.5f;
    public float offsetY = 1.0f;
    public float targetAngle = 135.0f;
    public float offset_angle = 50.0f;
    private bool rotating = false;
    float current_fordward_speed = 0f;

    void Start()
    {
        animal.OnWhack += OnWhack;
        transform.position = new Vector3(animal.transform.position.x + offsetX, animal.transform.position.y + offsetY, animal.transform.position.z);
    }

    public void OnCopyCreated()
    {
        animal.OnWhack += OnWhack;
        transform.position = new Vector3(animal.transform.position.x + offsetX, animal.transform.position.y + offsetY, animal.transform.position.z);
    }

    void Update()
    {
        if (rotating)
        {
            current_fordward_speed -= forward_acceleration * Time.deltaTime;
            MakeRotationFordward(-forward_speed - current_fordward_speed);
        }
        
        if (transform.rotation.eulerAngles.z >= targetAngle && transform.rotation.eulerAngles.z <= targetAngle + offset_angle)
        {
            rotating = false;
            Destroy(gameObject);
        }
    }

    void MakeRotationFordward(float speed) {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }

    void OnWhack()
    {
        rotating = true;
    }
}
