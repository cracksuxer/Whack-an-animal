using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

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

    public void StartRestartTimeCoroutine(float timeToReduce)
    {
        StartCoroutine(RestartTime(timeToReduce));
    }

    private IEnumerator RestartTime(float timeToReduce)
    {
        yield return new WaitForSeconds(5.0f);
        float currentTimeForSelection = GazeManager.Instance.GetTimeForSelection();
        GazeManager.Instance.SetUpGaze(currentTimeForSelection + timeToReduce);
        Debug.Log("Restablecido tiempo");
    }
}