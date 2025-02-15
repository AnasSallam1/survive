using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    void Update()
    {
        // Toggle pause when Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Pause();
        }
        else
        {
            Continue();
        }
    }

    // .
    void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true; // Pause all audio
    }

    // .
    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false; // Resume audio
        isPaused = false;
    }
}