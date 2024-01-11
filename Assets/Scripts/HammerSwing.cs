using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script manage all the topics related with the animation of the hammer and their funcionalities
/// </summary>
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

    /// <summary>
    /// This function is called at the begging of the execution to situate the hammer next to the animal
    /// </summary>
    void Start()
    {
        animal.OnWhack += OnWhack;
        transform.position = new Vector3(animal.transform.position.x + offsetX, animal.transform.position.y + offsetY, animal.transform.position.z);
    }

    /// <summary>
    /// This functions allows to create copies of the hammer to ensure that is possible to destroy every animal
    /// </summary>
    public void OnCopyCreated()
    {
        animal.OnWhack += OnWhack;
        transform.position = new Vector3(animal.transform.position.x + offsetX, animal.transform.position.y + offsetY, animal.transform.position.z);
    }

    /// <summary>
    /// This function it will be called in every frame during the game and it is on charge of managing all the topics related with movements of the hammer
    /// </summary>
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

    /// <summary>
    /// This function is in charge of making the rotation of the hammer
    /// </summary>
    void MakeRotationFordward(float speed) {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }

    /// <summary>
    /// This function set the variable that controls the movements of the hammer to true
    /// </summary>
    void OnWhack()
    {
        rotating = true;
    }
}
