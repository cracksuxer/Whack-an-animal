using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHitDelegate : MonoBehaviour {
    // Start is called before the first frame update
    public void OnPointerClick() {
      PowerUpDestroyManager.Instance.PowerUpDestroyed();
      Destroy(gameObject);
      Debug.Log("Destruccion de power upp");
    }
}
