using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMoveForwards : MonoBehaviour
{
    public float stepDistance = 1.0f;
    void Update()
    {
        transform.Translate(Vector3.up * stepDistance);    
    }
}
