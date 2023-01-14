using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioClip pickupSound;
    public int points = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the pickup sound
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            // Add points to the score
            ScoreManager.instance.AddPoints(points);

            // Destroy the pickup game object
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ignore the collision and let the pickup object pass through
        Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
    }
}
