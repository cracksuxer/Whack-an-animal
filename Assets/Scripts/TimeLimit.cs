using System;
using TMPro;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    // Singleton
    public static TimeLimit Instance { get; private set; }
    public float timeRemaining = 30f;
    public bool timerIsRunning = false;

    public event Action TimerEnded;
    public TextMeshProUGUI timerDisplay;

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

                OnTimerEnded();
            }
        }
    }

    public void StartTimer()
    {
        if (!timerIsRunning)
        {
            timerIsRunning = true;
            timeRemaining = 30f;
            UpdateTimerDisplay(timeRemaining);
        }
    }

    private void UpdateTimerDisplay(float timeToDisplay)
    {
        TimeSpan time = TimeSpan.FromSeconds(timeToDisplay);
        timerDisplay.text = "Time left\n  " + time.ToString(@"mm\:ss");
    }

    public void AddTime(float extraTime)
    {
        timeRemaining += extraTime;
        if (!timerIsRunning)
        {
            timerIsRunning = true;
        }
    }

    protected virtual void OnTimerEnded()
    {
        TimerEnded?.Invoke();
    }
}
