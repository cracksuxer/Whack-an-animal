using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script serves as a manager for power-ups in the game, handling the global state and behavior of power-ups.
/// </summary>
public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

    /// <summary>
    /// This function is called when the script instance is being loaded.
    /// It ensures that only one instance of the PowerUpManager exists throughout the game.
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
    /// Starts a coroutine that waits a fixed amount of time before increasing the time required for selection.
    /// </summary>
    /// <param name="timeToReduce">The amount of time to be added back after the waiting period.</param>
    public void StartRestartTimeCoroutine(float timeToReduce)
    {
        StartCoroutine(RestartTime(timeToReduce));
    }

    /// <summary>
    /// Coroutine that waits for a specified time before increasing the gaze selection time.
    /// </summary>
    /// <param name="timeToReduce">The time to be added back to the selection process.</param>
    /// <returns>IEnumerator for coroutine.</returns>
    private IEnumerator RestartTime(float timeToReduce)
    {
        yield return new WaitForSeconds(5.0f);
        float currentTimeForSelection = GazeManager.Instance.GetTimeForSelection();
        GazeManager.Instance.SetUpGaze(currentTimeForSelection + timeToReduce);
        Debug.Log("Restablecido tiempo");
    }
}