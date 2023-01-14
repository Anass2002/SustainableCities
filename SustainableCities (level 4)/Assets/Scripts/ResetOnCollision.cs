using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResetOnCollision : MonoBehaviour
{
    public AudioSource deathSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Play the death sound
            deathSound.Play();

            // Wait for half a second
            StartCoroutine(WaitForReset(0.5f));
        }
    }

    IEnumerator WaitForReset(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Reset the time scale
        Time.timeScale = 1;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}




