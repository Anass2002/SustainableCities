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
    public Transform startPosition;

    private float horizontalInput;
    private float verticalInput;
    private float brakeforce;
    private bool isbreaking;
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
        //Main methodeds worden geladen
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    public void GetInput()
    {
        //Ik gebruik de project settings om mij auto te besturen
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isbreaking = Input.GetKey(KeyCode.Space);

    }
    private void HandleMotor()
    {
        //Voorwiel aandrdijving, regelt naar voor en naar achter rijden.
        Wheel_01.motorTorque = verticalInput * motorForce;
        Wheel_03.motorTorque = verticalInput * motorForce;

        //remmen
        brakeforce = isbreaking ? 3000f : 0f;
        Wheel_01.brakeTorque = brakeforce;
        Wheel_02.brakeTorque = brakeforce;
        Wheel_03.brakeTorque = brakeforce;
        Wheel_04.brakeTorque = brakeforce;
    }
   

    private void HandleSteering()
    {
        //het besturen, zorgt ervoor dat de wielen draaien.
        currentSteerAngle = maxSteerAngle * horizontalInput;
        Wheel_01.steerAngle = currentSteerAngle;
        Wheel_03.steerAngle = currentSteerAngle;
    }
    private void UpdateWheels()
    {
        //de methode die ervoor zorgt dat de wielen draaien en de auto kan bewegen.
        UpdateSingleWheel(Wheel_01, Wheel_01_Transform);
        UpdateSingleWheel(Wheel_02, Wheel_02_Transform);
        UpdateSingleWheel(Wheel_03, Wheel_03_Transform);
        UpdateSingleWheel(Wheel_04, Wheel_04_Transform);
    }
    //in depth, ik neem de huidige coordinaat, update die en stuur hem terug.
    //voor het draaien van de wielen gebruik ik Quaternion.
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
    //terug naar het begin als je wordt geraakt.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.position = startPosition.position;
        }
    }
}

   

