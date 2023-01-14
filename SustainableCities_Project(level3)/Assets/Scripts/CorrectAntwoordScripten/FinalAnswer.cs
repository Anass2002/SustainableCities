using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAnswer : MonoBehaviour
{
    public GameObject canvas;
    public string vraag5;
    public GameObject Correct;
    public AudioClip audioClip;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (!audioSource)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = audioClip;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Correct.SetActive(true);
            GameObject text = canvas.transform.Find(vraag5).gameObject;
            audioSource.Play();
            text.SetActive(false);
        }
    }
}
