using System;
using UnityEngine;

public class HitAnimal : MonoBehaviour
{
    public delegate void CollisionEvent(int instanceID);
    public event CollisionEvent OnCollider;
    
    public delegate void ScoreEvent(int instanceID);
    public event ScoreEvent AddScore;

    private void OnCollisionEnter(Collision other)
    {
        Console.WriteLine("HitAnimal: OnCollisionEnter");
        OnCollider?.Invoke(other.gameObject.GetInstanceID());
        AddScore?.Invoke(other.gameObject.GetInstanceID());
    }
}
