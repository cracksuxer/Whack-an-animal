using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    public string newAnimationName;  // Asigna la nueva animación desde el Inspector

    void Start()
    {
        /*
        if (newAnimation != null) {
            ChangePrefabAnimation();
        }
        */
        Invoke("ChangePrefabAnimation", 3.0f);
    }

    void ChangePrefabAnimation() {
        Animator animatorComponent = GetComponent<Animator>();

        if (animatorComponent == null)
        {
            Debug.LogError("El prefab no tiene un componente Animator.");
            return;
        }

        // Cambia la animación utilizando el nombre de la capa de animación
        animatorComponent.Play(newAnimationName, -1, 0f);
    }
}
