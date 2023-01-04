using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPickupItem : MonoBehaviour
{
    Animator animator = null;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("Pickup");
            }

            // Check if the "Pickup" animation is playing
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("pickup"))
            {
                // Check if the "Pickup" animation has finished playing
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    // Transition to the "Idle" animation by calling the Animator.Play method
                    animator.Play("idle", 0, 0f);
                }
            }
        }
        
    }
}
