using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // .
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Load a new scene.");
    }

    // .
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit the game.");
    }
}