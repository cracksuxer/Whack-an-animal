using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveHit : MonoBehaviour
{
    // public HitAnimal hit_animal;
    public ParticleSystem death_particles;
    private int myInstanceID;

    void Start()
    {
        // myInstanceID = gameObject.GetInstanceID();
        // hit_animal.OnCollider += OnCollider;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Hammer") {
            ActivateParticles(death_particles);
            Animator animator_component = GetComponent<Animator>();
            string new_animation_name = "Death";
            float time_to_dissapear = 3.0f;
            if (animator_component == null) {
                Debug.LogError("El prefab no tiene un componente Animator.");
                return;
            }
            animator_component.Play(new_animation_name, -1, 0f);
            Invoke("DestroyObject", time_to_dissapear);
            Destroy(gameObject);
        }
    }

    private void OnCollider(int collidedInstanceID) {
        if (collidedInstanceID == myInstanceID) {
            ActivateParticles(death_particles);
            Animator animator_component = GetComponent<Animator>();
            string new_animation_name = "Death";
            float time_to_dissapear = 3.0f;
            if (animator_component == null) {
                Debug.LogError("El prefab no tiene un componente Animator.");
                return;
            }
            animator_component.Play(new_animation_name, -1, 0f);
            Invoke("DestroyObject", time_to_dissapear);
            Destroy(gameObject);
        }
    }

    void ActivateParticles(ParticleSystem particles_prefab) {
        if (particles_prefab != null) {
            ParticleSystem particles_instance = Instantiate(particles_prefab, transform.position, Quaternion.identity);
            particles_instance.Play();
            Destroy(particles_instance.gameObject, particles_instance.main.duration);
        }
    }

    void DestroyObject() {
        Destroy(gameObject);
    }
}

