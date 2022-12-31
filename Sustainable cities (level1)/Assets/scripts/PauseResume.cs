using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{

    public GameObject PauseScreen;
    public GameObject PauseButton;

    bool GamePaused;


    
    void Start()
    {
        //staat op false tot je op de pause knop drukt.
        GamePaused = false;
    }

    
    void Update()
    {
        //gamestate wordt hier verandert. 
        //false = 0, true = 1
        if (GamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void PauseGame()
    {
        //functie die op de pause knop staat om te pauzeren.
        GamePaused = true;
        PauseScreen.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        //functie die op de resume knop staat om terug te spelen.
        GamePaused = false;
        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);
    }
}

