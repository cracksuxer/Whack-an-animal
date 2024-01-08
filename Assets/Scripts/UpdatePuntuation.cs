using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePuntuation : MonoBehaviour
{
    public HitAnimal hit_animal;
    public Text text_component;

    public void Start()
    {
        hit_animal.AddScore += AddScore;
    }

    private void AddScore()
    {
        // Puedes realizar acciones adicionales al recibir la colisión
        int new_points = 10;  // Reemplaza esto con la lógica para obtener los puntos
        text_component.text = "Puntuation: " + new_points;
    }
}
