using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        //we roepen de huidige scene op en doen deze + 1 je kan de index kiezen in build settings.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        //aangezien we in de editor deze methode niet kunnen gebruiken gaan we gewoon quit loggen.
        Debug.Log("Quiting!");
        //werkt alleen op de .exe versie van de game.
        Application.Quit();
    }
}
