using System;
using TMPro;
using UnityEngine;

/// <summary>
/// This script manage the time of the game
/// </summary>
public class TimeLimit : MonoBehaviour
{
    // Singleton
    public static TimeLimit Instance { get; private set; }
    public float timeRemaining = 30f;
    public bool timerIsRunning = false;
    public TextMeshProUGUI finalScoreDisplay;
    public event Action TimerEnded;
    public TextMeshProUGUI timerDisplay;
    public GameObject endGameCanvas;

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
    /// This functions it will be called in every frame during the game and it is on charge of managing all the topics related with the time during the game
    /// </summary>
    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                UpdateTimerDisplay(timeRemaining);
                timerIsRunning = false;

                finalScoreDisplay.text = UpdatePunctuation.Instance.scoreText.text;

                // Activate the end game canvas
                endGameCanvas.SetActive(true);

                OnTimerEnded();
            }
        }
    }

    /// <summary>
    /// The function start the timer during the game
    /// </summary>
    public void StartTimer()
    {
        if (!timerIsRunning)
        {
            timerIsRunning = true;
            timeRemaining = 30f;
            UpdateTimerDisplay(timeRemaining);
        }
    }

    /// <summary>
    /// Update the time on the UI
    /// </summary>
    private void UpdateTimerDisplay(float timeToDisplay)
    {
        TimeSpan time = TimeSpan.FromSeconds(timeToDisplay);
        timerDisplay.text = "Time left\n  " + time.ToString(@"mm\:ss");
    }

    /// <summary>
    /// This function provides the possiblity of add an amount of time to the game
    /// </summary>
    public void AddTime(float extraTime)
    {
        Console.WriteLine("Adding time");
        timeRemaining += extraTime;
        if (!timerIsRunning)
        {
            timerIsRunning = true;
        }
    }

    /// <summary>
    /// The function is called when the timer ends to finish the game
    /// </summary>
    protected virtual void OnTimerEnded()
    {
        TimerEnded?.Invoke();
    }
}