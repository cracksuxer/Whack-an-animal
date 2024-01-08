using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePuntuation : MonoBehaviour
{
    public HitAnimal hit_animal;
    public Text text_component;
    private int score = 0;

    public void Start()
    {
        hit_animal.AddScore += AddScore;
    }

    private void AddScore(int instanceID)
    {
        score += 10;
        UpdateText();
    }

    void UpdateText() {
        if (text_component != null) {
            text_component.text = "Puntuation: " + score.ToString();
        }
    }
}
