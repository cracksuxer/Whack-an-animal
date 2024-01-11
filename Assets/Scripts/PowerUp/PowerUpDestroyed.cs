using System.Collections;
using System.Collections.Generic;using UnityEngine;


public class PowerUpDestroyed : MonoBehaviour
{
    public float timeToReduce = 0.25f;

    public void OnPointerClick()
    {
        float currentTimeForSelection = GazeManager.Instance.GetTimeForSelection();
        if (currentTimeForSelection > timeToReduce)
        {
            GazeManager.Instance.SetUpGaze(currentTimeForSelection - timeToReduce);
            PowerUpManager.Instance.StartRestartTimeCoroutine(timeToReduce);
        }
        gameObject.SetActive(false);
        Debug.Log("Tiempo de seleccion actual: " + GazeManager.Instance.GetTimeForSelection());
    }
}