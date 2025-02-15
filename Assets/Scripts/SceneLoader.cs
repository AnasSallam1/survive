using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Load the main menu
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading the Menu scene.");
    }

    // Load the main scene
    public void Play()
    {
        SceneManager.LoadScene("LoadingScreen");
        Debug.Log("Loading the Loading Screen.");
    }

    // Load the scene Settings
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
        Debug.Log("Loading Settings scene.");
    }

    // Load the scene About
    public void About()
    {
        SceneManager.LoadScene("About");
        Debug.Log("Loading About scene.");
    }

    // Exit the game
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit the game.");
    }

}
