using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatePowerUp : MonoBehaviour {
  void Start() {
    // Llama al método TriggerEvent cada 30 segundos, empezando después de 30 segundos
    InvokeRepeating("TriggerEvent", 1.0f, 1.0f);
  }
  public delegate void SpawnPowerUpEvent();
  public event SpawnPowerUpEvent OnSpawnPowerUp;
  private void TriggerEvent() {
    OnSpawnPowerUp?.Invoke();
  }
}

