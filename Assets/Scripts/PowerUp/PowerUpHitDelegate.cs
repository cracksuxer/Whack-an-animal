using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHitDelegate : MonoBehaviour {
    // Start is called before the first frame update
    public void OnPointerClick() {
      PowerUpDestroyManager.Instance.PowerUpDestroyed();
      GazeManager.Instance.SetUpGaze(0.5f);
      Destroy(gameObject);
      Debug.Log("Destruccion de power upp");
    }
}
