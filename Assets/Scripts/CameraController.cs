using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script allows to move the camera when the game is executed on the unity editor
/// </summary>
public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    float xRotation = 0f;

    /// <summary>
    /// This functions is called at the begging and provides the possibility of moving the camera
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// This function is called in every frame of the game to allow us to move on the scene while using the unity editor
    /// </summary>
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y + mouseX, 0f);
    }
}