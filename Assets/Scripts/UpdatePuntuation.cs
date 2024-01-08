using TMPro;
using UnityEngine;

public class UpdatePuntuation : MonoBehaviour
{
    public HitAnimal hit_animal;
    public TextMeshProUGUI text_component;
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
            
            text_component.text = "Score: " + score.ToString();
        }
    }
}
