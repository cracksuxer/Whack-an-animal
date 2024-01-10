using TMPro;
using UnityEngine;

public class UpdatePunctuation : MonoBehaviour
{
    // public ReceiveHit animal;
    public static UpdatePunctuation Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void subscribe(GameObject animal)
    {
        animal.GetComponent<ReceiveHit>().AddScore += AddScore;
    }

    private void AddScore()
    {
        score += 10;
        UpdateText();
    }

    private void UpdateText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
