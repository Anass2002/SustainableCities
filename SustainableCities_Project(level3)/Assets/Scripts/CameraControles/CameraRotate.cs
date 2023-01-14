using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Start()
    {
        offset = new Vector3(-0.57f, 8.71f, -13.59f);
    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
