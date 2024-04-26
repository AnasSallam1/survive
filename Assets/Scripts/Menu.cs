using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Menu : MonoBehaviour
{
    // Start playing the game.
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play");
    }

    // Go to Settings.
    public void Settings()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Settings");
    }

    // Display information about the game when the button About is pressed.
    public void About()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("About");
    }

    // Exit the game when the button Exit is pressed.
    public void Exit()
    {
        Debug.Log("Exit the game.");
        Application.Quit();
    }
}
