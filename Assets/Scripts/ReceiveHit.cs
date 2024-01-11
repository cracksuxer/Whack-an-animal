using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveHit : MonoBehaviour
{
    public ParticleSystem death_particles;
    private readonly int myInstanceID;
    public List<AudioClip> deathSounds; // List of AudioClips
    private AudioSource audioSource; // AudioSource variable

    public delegate void ScoreEvent();
    public event ScoreEvent AddScore;

    void Start()
    {
        // Initialize AudioSource
        if (!TryGetComponent<AudioSource>(out audioSource))
        {
            Debug.LogError("No AudioSource component found on the GameObject.");
            return;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Hammer")) {
            GetComponent<Rigidbody>().isKinematic = true;
            AddScore?.Invoke();

            if (audioSource != null && deathSounds.Count > 0) {
                AudioClip randomClip = deathSounds[Random.Range(0, deathSounds.Count)];
                audioSource.clip = randomClip;
                audioSource.Play();
            }

            ActivateParticles(death_particles);
            Animator animator_component = GetComponent<Animator>();
            string new_animation_name = "Death";
            float time_to_disappear = 1.0f;
            if (animator_component == null) {
                Debug.LogError("El prefab no tiene un componente Animator.");
                return;
            }

            animator_component.Play(new_animation_name, -1, 0f);
            Invoke(nameof(DestroyObject), time_to_disappear);
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
        audioSource.Stop();
        Destroy(gameObject);
    }
}
