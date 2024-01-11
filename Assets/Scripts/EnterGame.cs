using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script allows to load a new screen
/// </summary>
public class EnterGame : MonoBehaviour
{
    public string sceneToLoad;

    /// <summary>
    /// This function allows to load a new screen
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
