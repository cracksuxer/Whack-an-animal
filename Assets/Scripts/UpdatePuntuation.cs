using TMPro;
using UnityEngine;

/// <summary>
/// This script manage the punctuation of the player
/// </summary>
public class UpdatePunctuation : MonoBehaviour
{
    // public ReceiveHit animal;
    public static UpdatePunctuation Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    private int score = 0;

    /// <summary>
    /// The function is called at the begging of the script and make possible the instance of a new object
    /// </summary>
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

    /// <summary>
    /// The function adds the script ReceiveHit while subscribe to a delegate
    /// </summary>
    public void subscribe(GameObject animal)
    {
        animal.GetComponent<ReceiveHit>().AddScore += AddScore;
    }

    /// <summary>
    /// Increase the punctuation in 10 points and then update the information of the UI
    /// </summary>
    private void AddScore()
    {
        score += 10;
        UpdateText();
    }

    /// <summary>
    /// Update the information of the UI
    /// </summary>
    private void UpdateText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
