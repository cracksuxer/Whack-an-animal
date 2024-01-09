using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleHammerAnimation : MonoBehaviour
{
    public GameObject animal;
    public float forward_speed;
    public float forward_acceleration;
    public float offsetY; 
    public float offsetX; // si no se pone golpea con el palo no con el mazo, 12 en la x 30 en la y
    public float targetAngle;
    public float offset_angle;
    private bool rotating = true;
    float current_fordward_speed = 0f;

    void Start()
    {
        transform.position = new Vector3(animal.transform.position.x + offsetX, animal.transform.position.y + offsetY, animal.transform.position.z);
    }

    void Update() {
        if (rotating)
        {
            current_fordward_speed -= forward_acceleration * Time.deltaTime;
            MakeRotationFordward(-forward_speed - current_fordward_speed);
        }

        // Nuevo: Verificar si se alcanzó el ángulo objetivo
        if (transform.rotation.eulerAngles.z >= targetAngle && transform.rotation.eulerAngles.z <= targetAngle + offset_angle)
        {
            rotating = false; // Detener la rotación
        }
    }

    void MakeRotationFordward(float speed) {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
