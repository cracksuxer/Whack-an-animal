using UnityEngine;

/// <summary>
/// This script handles the functionality related to the destruction or deactivation of power-ups in the game.
/// </summary>
public class PowerUpDestroyed : MonoBehaviour
{
    public float timeToReduce = 0.25f;

    /// <summary>
    /// This function is called when the power-up is clicked.
    /// It reduces the time required for selection, plays an audio source, and deactivates the power-up.
    /// </summary>
    public void OnPointerClick()
    {
        float currentTimeForSelection = GazeManager.Instance.GetTimeForSelection();
        if (currentTimeForSelection > timeToReduce)
        {
            transform.parent.GetComponent<AudioSource>().Play();
            GazeManager.Instance.SetUpGaze(currentTimeForSelection - timeToReduce);
            PowerUpManager.Instance.StartRestartTimeCoroutine(timeToReduce);
        }
        gameObject.SetActive(false);
        Debug.Log("Tiempo de seleccion actual: " + GazeManager.Instance.GetTimeForSelection());
    }
}