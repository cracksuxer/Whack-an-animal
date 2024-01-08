using UnityEngine;

public class DelegatePowerUp : MonoBehaviour {
  public float spawnRate = 1.0f;
  public delegate void SpawnPowerUpEvent();
  public event SpawnPowerUpEvent OnSpawnPowerUp;

  void Start() {
      // Llama al método TriggerEvent cada 30 segundos, empezando después de 30 segundos
      InvokeRepeating(nameof(TriggerEvent), 1.0f, spawnRate);
  }

  private void TriggerEvent() {
      OnSpawnPowerUp?.Invoke();
  }
}

