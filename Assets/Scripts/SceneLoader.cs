using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // .
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading the Menu scene.");
    }

    // .
    public void Play()
    {
        SceneManager.LoadScene("LoadingScreen");
        Debug.Log("Loading the Loading Screen.");
    }

    // .
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
        Debug.Log("Loading Settings scene.");
    }

    // .
    public void About()
    {
        SceneManager.LoadScene("About");
        Debug.Log("Loading About scene.");
    }

    // .
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit the game.");
    }

}
