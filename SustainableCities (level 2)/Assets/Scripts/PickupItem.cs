using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public float pickupRange = 2f;
    public LayerMask pickupLayer;
    public AudioClip pickupSound;
    public string[] pickupTags;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }
    }

    private void Pickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, pickupLayer))
        {
            foreach (string tag in pickupTags)
            {
                if (hit.collider.tag == tag)
                {
                    audioSource.PlayOneShot(pickupSound);
                    hit.collider.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
}
