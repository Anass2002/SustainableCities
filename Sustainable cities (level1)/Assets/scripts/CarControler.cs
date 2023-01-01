using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControler : MonoBehaviour
{


    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    public Rigidbody rb;
    public Vector3 newCenterOfMass;

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    

    [SerializeField] private float motorForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider Wheel_01;
    [SerializeField] private WheelCollider Wheel_02;
    [SerializeField] private WheelCollider Wheel_03;
    [SerializeField] private WheelCollider Wheel_04;

    [SerializeField] private Transform Wheel_01_Transform;
    [SerializeField] private Transform Wheel_02_Transform;
    [SerializeField] private Transform Wheel_03_Transform;
    [SerializeField] private Transform Wheel_04_Transform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    public void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);

    }
    private void HandleMotor()
    {
        Wheel_01.motorTorque = verticalInput * motorForce;
        Wheel_03.motorTorque = verticalInput * motorForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        Wheel_01.steerAngle = currentSteerAngle;
        Wheel_03.steerAngle = currentSteerAngle;
    }
    private void UpdateWheels()
    {
        UpdateSingleWheel(Wheel_01, Wheel_01_Transform);
        UpdateSingleWheel(Wheel_02, Wheel_02_Transform);
        UpdateSingleWheel(Wheel_03, Wheel_03_Transform);
        UpdateSingleWheel(Wheel_04, Wheel_04_Transform);
    }

    private void UpdateSingleWheel(WheelCollider wheel, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        wheel.GetWorldPose(out position, out rotation);
        wheelTransform.rotation = rotation;
        wheelTransform.position = position;
    }
    void Start()
    {
        
        rb.centerOfMass = newCenterOfMass;
    }
}

   

