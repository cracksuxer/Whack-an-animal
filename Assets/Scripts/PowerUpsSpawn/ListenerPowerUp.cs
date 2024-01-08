using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerPowerUp : MonoBehaviour {
  public DelegatePowerUp spawnPowerUpEvent;
  public GameObject powerUp;
  public GameObject spawnBase;
  public float spawnRadius = 10.0f;
  public float spawnHeight = 10.0f;
  public float fallSpeed = 5.0f;

  void Start() {
    spawnPowerUpEvent.OnSpawnPowerUp += OnSpawnPowerUp;
  }  
  // Update is called once per frame
  void Update() {
      
  }  

  private void OnSpawnPowerUp() {
    float powerUpX = spawnBase.transform.position.x;
    float powerUpY = spawnBase.transform.position.y + spawnHeight;
    float powerUpZ = spawnBase.transform.position.z;
    GameObject powerUpClone = Instantiate(powerUp);
    powerUpClone.transform.position = new Vector3(powerUpX, powerUpY, powerUpZ);
  }
}
