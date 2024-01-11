using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUpDestroyManager : MonoBehaviour {
    public static PowerUpDestroyManager Instance;

    public event Action OnPowerUpDestroyed;

    void Awake() {
      if (Instance == null) Instance = this;
      else if (Instance != this) Destroy(gameObject);
    }

    public void PowerUpDestroyed() {
        OnPowerUpDestroyed?.Invoke();
    }
}
