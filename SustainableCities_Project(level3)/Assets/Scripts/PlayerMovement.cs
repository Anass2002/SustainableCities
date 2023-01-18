using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 720f; // De snelheid waarmee het object draait

    [SerializeField]
    private float jumpSpeed = 10f; // De snelheid waarmee het object springt

    [SerializeField]
    private float jumpButtonGracePeriod = 0f; // De tijd waarmee de knop ingedrukt moet worden om te springen

    [SerializeField]

    private float jumpHorizontalSpeed = 10f; // De horizontale snelheid tijdens het springen

    private Animator animator; // De animator van het object
    private CharacterController characterController; // De character controller van het object

    private float ySpeed; // De verticale snelheid
    private float originalStepOffset; // De originele step offset van de character controller

    private float? lastGroundedTime; // De tijd waarop het object voor het laatst op de grond stond
    private float? jumpButtonPressedTime; // De tijd waarop de jump knop ingedrukt werd

    private bool isJumping; // Of het object aan het springen is
    private bool isGrounded; // Of het object op de grond staat
                             // Start wordt aangerroepen voor de eerste frame
    void Start()
    {
        animator = GetComponent<Animator>(); // Haal de animator van het object op
        characterController = GetComponent<CharacterController>(); // Haal de character controller van het object op
        originalStepOffset = characterController.stepOffset; // Sla de originele step offset op
    }
    // Update wordt elke frame aangeroepen
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Haal de horizontale input op

        float verticalInput = Input.GetAxis("Vertical"); // Haal de verticale input op

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput); // Bereken de bewegingsrichting

        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude); // Bereken de magnitude van de input

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude /= 2;
        }

        animator.SetFloat("InputMagnitude", inputMagnitude, 0.05f, Time.deltaTime); // Stel de input magnitude in op de animator
        ySpeed += Physics.gravity.y * Time.deltaTime; // Voeg de zwaartekracht toe aan de verticale snelheid

        if (characterController.isGrounded) // Als het object op de grond staat
        {
            lastGroundedTime = Time.time; // Sla de tijd op
        }
        if (Input.GetButtonDown("Jump")) // Als de jump knop ingedrukt wordt
        {
            jumpButtonPressedTime = Time.time; // Sla de tijd op
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod) // Als de grace periode nog niet voorbij is
        {
            characterController.stepOffset = originalStepOffset; // Zet de step offset terug naar de originele waarde
            ySpeed = -0.5f; // Zet de verticale snelheid terug naar -0.5
            animator.SetBool("IsGrounded", true); // Stel de animator in dat het object op de grond staat
            isGrounded = true; // Zet de grounded status op true
            animator.SetBool("IsJumping", false); // Zet de jumping status op false
            isJumping = false; // Zet de jumping status op false
            animator.SetBool("IsFalling", false); // Zet de falling status op false

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod) // Als de jump knop binnen de grace periode ingedrukt is
            {
                ySpeed = jumpSpeed; // Zet de verticale snelheid op de jump snelheid
                animator.SetBool("IsJumping", true); // Zet de jumping status op true
                isJumping = true; // Zet de jumping status op true
                jumpButtonPressedTime = null; // Reset de tijd waarop de knop ingedrukt is
                lastGroundedTime = null; // Reset de tijd waarop het object voor het laatst op de grond stond
            }
        }

        else // Als het object niet op de grond staat
        {
            characterController.stepOffset = 0; // Zet de step offset op 0
            animator.SetBool("IsGrounded", false); // Zet de grounded status op false
            isGrounded = false; // Zet de grounded status op false
            if ((isJumping && ySpeed < 0) || ySpeed < -2) // Als het object aan het vallen is na een sprong of als de verticale snelheid minder dan -2 is
            {
                animator.SetBool("IsFalling", true); // Zet de falling status op true
            }
        }
        if (movementDirection != Vector3.zero) // Als er beweging plaatsvindt
        {
            animator.SetBool("IsMoving", true); // Zet de moving status op true
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up); // Bereken de rotatie naar de bewegingsrichting
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime); // Roteren naar de bewegingsrichting met de rotation speed
        }
        else // Als er geen beweging plaatsvindt
        {
            animator.SetBool("IsMoving", false); // Zet de moving status op false
        }

        if (isGrounded == false) // Als het object niet op de grond staat
        {
            Vector3 velocity = movementDirection * inputMagnitude * jumpHorizontalSpeed;
            velocity.y = ySpeed; // Voeg de verticale snelheid toe aan de snelheid

            characterController.Move(velocity * Time.deltaTime);  // Beweeg het object met de snelheid
        }
    }

    private void OnAnimatorMove()
    {
        if (isGrounded) // Als het object op de grond staat
        {
            Vector3 velocity = animator.deltaPosition; // Haal de verandering van positie op van de animator
            velocity.y = ySpeed * Time.deltaTime; // Voeg de verticale snelheid toe aan de snelheid

            characterController.Move(velocity); // Beweeg het object met de snelheid
        }
    }
}
