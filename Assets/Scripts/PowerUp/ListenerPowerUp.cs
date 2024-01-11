using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script listens for power-up spawn events and handles the instantiation and positioning of power-ups in the game.
/// </summary>
public class ListenerPowerUp : MonoBehaviour {
  public DelegatePowerUp spawnPowerUpEvent;
  public GameObject powerUp;
  public GameObject spawnBase;
  public float spawnRadius = 50.0f;
  public float offsetSpawnRadius = 10.0f;
  public float spawnHeight = 50.0f;
  public float powerUpSpeedFall = 5.0f;

    /// <summary>
    /// This function is called at the start of the game. It subscribes to the spawn power-up event.
    /// </summary>
    void Start() {
      spawnPowerUpEvent.OnSpawnPowerUp += OnSpawnPowerUp;
    }  
  
    /// <summary>
    /// This function is called when a power-up spawn event is triggered.
    /// It handles the instantiation and positioning of the power-up.
    /// </summary>
    private void OnSpawnPowerUp() {
      Vector3 spawnCoordinates = GetRandomPointInCircle(spawnRadius, offsetSpawnRadius);
      float powerUpX = spawnBase.transform.position.x + spawnCoordinates.x;
      float powerUpY = spawnBase.transform.position.y + spawnHeight;
      float powerUpZ = spawnBase.transform.position.z + spawnCoordinates.y;
      GameObject powerUpClone = InstantiateNewPowerUp();
      powerUpClone.transform.position = new Vector3(powerUpX, powerUpY, powerUpZ);
      OrientPowerUp(powerUpClone);
      Destroy(powerUpClone, (spawnHeight - 1.0f) / powerUpSpeedFall);
    }
  
/// <summary>
    /// Generates a random point within a specified circular area.
    /// </summary>
    /// <param name="maxRadius">Maximum radius of the circle.</param>
    /// <param name="minRadius">Minimum offset radius from the center.</param>
    /// <returns>A Vector3 representing a random point within the specified circle.</returns>
    Vector3 GetRandomPointInCircle(float maxRadius, float minRadius) {
      float distance = Random.Range(minRadius, maxRadius); // Radio aleatorio dentro del círculo
      float theta = Random.Range(0, 2 * Mathf.PI); // Ángulo aleatorio en radianes
      float x = distance * Mathf.Cos(theta);
      float y = distance * Mathf.Sin(theta);
      return new Vector3(x, y, 0); // Asumiendo una circunferencia en el plano XY
    }
  
    /// <summary>
    /// Instantiates a new power-up and adds a FallScript component to it.
    /// </summary>
    /// <returns>The instantiated power-up GameObject.</returns>
    GameObject InstantiateNewPowerUp() {
      GameObject powerUpClone = Instantiate(powerUp);
      FallScript fall = powerUpClone.AddComponent<FallScript>();
      fall.fallSpeed = powerUpSpeedFall;
      return powerUpClone;
    }
  
    /// <summary>
    /// Orients the power-up to face towards the spawn base.
    /// </summary>
    /// <param name="powerUpClone">The power-up GameObject to be oriented.</param>
    void OrientPowerUp(GameObject powerUpClone) {
      powerUpClone.transform.LookAt(spawnBase.transform.position);
      Vector3 currentRotation = powerUpClone.transform.eulerAngles;
      powerUpClone.transform.eulerAngles = new Vector3(90, currentRotation.y, currentRotation.z);
    }
}
