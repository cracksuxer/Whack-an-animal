using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWithHammer : MonoBehaviour
{
    public float initial_speed;  // Velocidad de rotación hacia atras
    public float final_speed; // Velocidad de rotación hacia delante
    // Vector3.up eje Y
    // Vector3.forward eje z
    // Vector3.right eje x

    void Update()
    {
        MakeRotationBack(initial_speed);
        if (Time.time > 0.5f) {
            MakeRotationFordward(final_speed);
        }
    }

    void MakeRotationBack(float speed) {
        transform.Rotate(Vector3.forward, -speed * Time.deltaTime);
    }

    void MakeRotationFordward(float speed) {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
