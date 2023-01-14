using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateX : MonoBehaviour
{
    public float rotationSpeed = 120.0f; // The speed at which the object rotates

    void Update()
    {
        // Rotate the object around its x-axis
        transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
    }
}
