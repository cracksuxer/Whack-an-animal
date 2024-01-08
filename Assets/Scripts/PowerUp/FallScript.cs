using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour {
  public float fallSpeed = 5.0f;

  void Update() {
    transform.position += Vector3.down * fallSpeed * Time.deltaTime;
  }
}
