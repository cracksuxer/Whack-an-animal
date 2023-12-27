using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveHit : MonoBehaviour
{
    public HitAnimal hit_animal;

    void Start() {
        hit_animal.OnCollider += OnCollider;
    }
    
    private void OnCollider() {
        Destroy(gameObject);
    }
}
