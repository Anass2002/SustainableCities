using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator = null;
    CharacterController cc = null;
    [SerializeField]
    float movementSpeed = 5f;
    [SerializeField]
    float rotationSpeed = 100f;
    void Start()
    {
        this.cc = this.GetComponent<CharacterController>();
        this.animator = this.GetComponent<Animator>();
    }
    void Update()
    {
        Vector3 movement = new Vector3();

        if (Input.GetKey("up") == true)
            movement += transform.forward;
        if (Input.GetKey("down") == true)
            movement -= transform.forward;
        if (Input.GetKey("left") == true)
            transform.Rotate(Vector3.up, -1f * this.rotationSpeed * Time.deltaTime);
        if (Input.GetKey("right") == true)
            transform.Rotate(Vector3.up, this.rotationSpeed * Time.deltaTime);

        this.cc.Move(movement.normalized * this.movementSpeed * Time.deltaTime);

        if (movement.sqrMagnitude > 0)
        {
            this.animator.SetBool("IsRunning", true);
        }
        else
        {
            this.animator.SetBool("IsRunning", false);
        }
    }
}
