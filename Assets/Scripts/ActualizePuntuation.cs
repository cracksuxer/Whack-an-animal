using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizePuntuation : MonoBehaviour
{
    public Text score_text;
    private int score = 0;

    void Start()
    {
        HitAnimal hit_animal_script = FindObjectOfType<HitAnimal>(); // Para que funcione solo debemos tener un objeto con el script del martillo
        if (hit_animal_script != null) {
            hit_animal_script.OnCollider += AddScore;
        }
    }

    void AddScore(int instanceID) {
        score += 10; // Puedes ajustar la cantidad de puntos que deseas sumar por cada eliminación.
        UpdateScoreText();
    }

    void UpdateScoreText() {
        if (score_text != null) {
            score_text.text = "Puntuation: " + score.ToString();
        }
    }
}
