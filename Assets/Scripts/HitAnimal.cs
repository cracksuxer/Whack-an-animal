using System;
using UnityEngine;

/// <summary>
/// This script is on charge of managing all the topics related with make the acction of hit an animal
/// </summary>
public class HitAnimal : MonoBehaviour
{
    public delegate void CollisionEvent(int instanceID);
    public event CollisionEvent OnCollider;
    
    public delegate void ScoreEvent(int instanceID);
    public event ScoreEvent AddScore;

    /// <summary>
    /// This function is on charge of activates of the events related with the collission of the hammer
    /// </summary>
    private void OnCollisionEnter(Collision other)
    {
        Console.WriteLine("HitAnimal: OnCollisionEnter");
        OnCollider?.Invoke(other.gameObject.GetInstanceID());
        AddScore?.Invoke(other.gameObject.GetInstanceID());
    }
}
