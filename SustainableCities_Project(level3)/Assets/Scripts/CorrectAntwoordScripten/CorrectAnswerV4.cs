using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswerV4 : MonoBehaviour
{
    public GameObject canvas;
    public string vraag4;
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
            GameObject text = canvas.transform.Find(vraag4).gameObject;
            text.SetActive(false);
            audioSource.Play();
            StartCoroutine(DelaySecondIfStatement());
            Correct.SetActive(true);
        }
    }

    IEnumerator DelaySecondIfStatement()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject text = canvas.transform.Find(vraag5).gameObject;
        text.SetActive(true);
        Correct.SetActive(false);
    }
}
