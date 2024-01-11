using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUpHitListener : MonoBehaviour {
    void Start() {
      PowerUpDestroyManager.Instance.OnPowerUpDestroyed += OnPowerUpDestroyed;
    }

    void OnDestroy() {
      PowerUpDestroyManager.Instance.OnPowerUpDestroyed -= OnPowerUpDestroyed;
    }

    void OnPowerUpDestroyed() {
      Debug.Log("Fuck, se ha destruido un power up tío");
      //GazeManager.Instance.SetUpGaze(0.5f);
    }
}
