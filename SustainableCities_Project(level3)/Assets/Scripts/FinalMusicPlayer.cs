using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMusicPlayer : MonoBehaviour
{
    public AudioClip music;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            audioSource.clip = music;
            audioSource.Play();
        }
    }
}
