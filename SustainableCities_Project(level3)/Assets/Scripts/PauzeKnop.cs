using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauzeKnop : MonoBehaviour
{
    public GameObject PauseScreen; // Dit is een public variabele die verwijst naar het PauseScreen GameObject.
    public GameObject PauseButton;
    public AudioSource music;
    bool GamePaused;
    bool musicPlaying = true;
    void Start()
    {
        GamePaused = false; // Zet de GamePaused variabele op false wanneer de game start.
    }

    void Update()
    {
        if (GamePaused)
        {
            Time.timeScale = 0; // Stel de timeScale op 0, dit zorgt ervoor dat alles in de game stopt.
            if (musicPlaying)
            {
                music.Pause(); // Pauzeer de muziek.
                musicPlaying = false;
            }
        }
        else
        {
            Time.timeScale = 1; // Stel de timeScale op 1, dit zorgt ervoor dat alles in de game weer verder gaat.
            if (!musicPlaying)
            {
                music.Play(); // Speel de muziek af.
                musicPlaying = true;
            }
        }
    }

    public void PauseGame()
    {
        GamePaused = true;
        PauseScreen.SetActive(true); // Zet het PauseScreen GameObject aan.
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        PauseScreen.SetActive(false); 
        PauseButton.SetActive(true);
    }
}
