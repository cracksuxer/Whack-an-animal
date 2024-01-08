using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalRotationSpeed = 5f;
    public float verticalRotationSpeed = 5f;
    public float maxVerticalAngle = 80f; // Ángulo máximo hacia arriba
    public float minVerticalAngle = -80f; // Ángulo máximo hacia abajo

    private float verticalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Mouse X") * horizontalRotationSpeed;
        float verticalInput = Input.GetAxis("Mouse Y") * verticalRotationSpeed;

        // Aplicar rotación horizontal
        transform.Rotate(Vector3.up, horizontalInput);

        // Aplicar rotación vertical con restricciones de ángulo
        verticalRotation -= verticalInput;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        // Aplicar rotación vertical a la cámara o al objeto del jugador
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
