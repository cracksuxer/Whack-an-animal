using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    public string new_animation_name;
    public float time_to_dissapear;

    void Start()
    {
        Invoke("ChangePrefabAnimation", 3.0f);
    }

    void ChangePrefabAnimation() {
        Animator animator_component = GetComponent<Animator>();

        if (animator_component == null) {
            Debug.LogError("El prefab no tiene un componente Animator.");
            return;
        }
        animator_component.Play(new_animation_name, -1, 0f);
        if (new_animation_name == "Death") {
            Invoke("DestroyObject", time_to_dissapear);
        }
    }

    void DestroyObject() {
        Destroy(gameObject);
    }
}