using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject PauzeKnop;
    public GameObject ScoreInv;
    bool Gepauzeerd;
    // Start is called before the first frame update
    void Start()
    {
        Gepauzeerd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Gepauzeerd)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Gepauzeerd = true;
        PauseScreen.SetActive(true);
        PauzeKnop.SetActive(false);
        ScoreInv.SetActive(false);
    }

    public void ResumeGame()
    {
        Gepauzeerd = false;
        PauseScreen.SetActive(false);
        PauzeKnop.SetActive(true);
        ScoreInv.SetActive(true);
    }
}
