using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerPowerUp : MonoBehaviour {
  public DelegatePowerUp spawnPowerUpEvent;
  public GameObject powerUp;
  public GameObject spawnBase;
  public float spawnRadius = 50.0f;
  public float spawnHeight = 50.0f;
  public float powerUpSpeedFall = 5.0f;

  void Start() {
    spawnPowerUpEvent.OnSpawnPowerUp += OnSpawnPowerUp;
  }  

  private void OnSpawnPowerUp() {
    Vector3 spawnCoordinates = GetRandomPointInCircle(spawnRadius);
    float powerUpX = spawnBase.transform.position.x + spawnCoordinates.x;
    float powerUpY = spawnBase.transform.position.y + spawnHeight;
    float powerUpZ = spawnBase.transform.position.z + spawnCoordinates.y;
    GameObject powerUpClone = InstantiateNewPowerUp();
    powerUpClone.transform.position = new Vector3(powerUpX, powerUpY, powerUpZ);
    OrientPowerUp(powerUpClone);
    Destroy(powerUpClone, (spawnHeight - 1.0f) / powerUpSpeedFall);
  }

  Vector3 GetRandomPointInCircle(float radius) {
    float distance = Random.Range(0, radius); // Radio aleatorio dentro del círculo
    float theta = Random.Range(0, 2 * Mathf.PI); // Ángulo aleatorio en radianes
    float x = distance * Mathf.Cos(theta);
    float y = distance * Mathf.Sin(theta);
    return new Vector3(x, y, 0); // Asumiendo una circunferencia en el plano XY
  }

  GameObject InstantiateNewPowerUp() {
    GameObject powerUpClone = Instantiate(powerUp);
    FallScript fall = powerUpClone.AddComponent<FallScript>();
    fall.fallSpeed = powerUpSpeedFall;
    return powerUpClone;
  }

  void OrientPowerUp(GameObject powerUpClone) {
    powerUpClone.transform.LookAt(spawnBase.transform.position);
    Vector3 currentRotation = powerUpClone.transform.eulerAngles;
    powerUpClone.transform.eulerAngles = new Vector3(90, currentRotation.y, currentRotation.z);
  }
}
