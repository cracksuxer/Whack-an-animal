using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimal : MonoBehaviour
{
    public delegate void CollisionEvent();
    public event CollisionEvent OnCollider;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Animal") {
            OnCollider?.Invoke();
        }
    }
}
