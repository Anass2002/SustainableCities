using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauzeKnop : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject PauseButton;
    public GameObject QuitButton;

    bool GamePaused;
    void Start()
    {
        GamePaused = false;
    }

    void Update()
    {
        if (GamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void PauseGame()
    {
        GamePaused = true;
        PauseScreen.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
