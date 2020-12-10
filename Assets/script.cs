using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{

    public Transform sphere;
    private Vector3 dist;
    float rotY;
    public float RotSpeed = 1.5f;

    void Start()
    {
        dist = transform.position - sphere.position;
        rotY = transform.eulerAngles.y;
    }

    void Update()
    {
        rotY += Input.GetAxis("Horizontal") * RotSpeed;
        transform.position = sphere.position - (Quaternion.Euler(0, rotY, 0) * dist);
        transform.LookAt(sphere);
    }
}   