using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for handling the falling behavior of an object in the game.
/// </summary>
public class FallScript : MonoBehaviour
{
    public float fallSpeed = 5.0f;

    /// <summary>
    /// This function is called once per frame. It updates the position of the object,
    /// making it fall downwards at the specified fall speed.
    /// </summary>
    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }
}