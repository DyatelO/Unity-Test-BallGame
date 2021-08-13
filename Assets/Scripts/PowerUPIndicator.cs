using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPIndicator : MonoBehaviour
{
    private float rotationIndicatorSpeed = 20f;
    
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, rotationIndicatorSpeed * Time.deltaTime);
    }
}
