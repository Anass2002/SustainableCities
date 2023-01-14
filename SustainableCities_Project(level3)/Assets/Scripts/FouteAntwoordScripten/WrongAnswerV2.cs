using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswerV2 : MonoBehaviour
{
    public GameObject canvas;
    public float speed = 50f;
    private Vector3 targetPosition;
    public GameObject Dying;
    public string vraag2;

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
            GameObject text = canvas.transform.Find(vraag2).gameObject;
            text.SetActive(false);
            targetPosition = transform.position;
            targetPosition.y = -242.7f;
            Dying.SetActive(true);
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (targetPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position.y == -242.7f)
            {
                targetPosition = Vector3.zero;
            }
        }
    }
}
