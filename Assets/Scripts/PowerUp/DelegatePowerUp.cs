using UnityEngine;

/// <summary>
/// This script manages the spawning of power-ups in the game.
/// </summary>
public class DelegatePowerUp : MonoBehaviour
{

    public float spawnRate = 1.0f;

    public delegate void SpawnPowerUpEvent();

    public event SpawnPowerUpEvent OnSpawnPowerUp;

    /// <summary>
    /// This function is called at the beginning of the game.
    /// It repeatedly invokes the TriggerEvent function based on the spawn rate.
    /// </summary>
    void Start()
    {
        InvokeRepeating(nameof(TriggerEvent), 1.0f, spawnRate);
    }

    /// <summary>
    /// This function triggers the OnSpawnPowerUp event.
    /// It's called periodically based on the spawn rate.
    /// </summary>
    private void TriggerEvent()
    {
        OnSpawnPowerUp?.Invoke();
    }
}
