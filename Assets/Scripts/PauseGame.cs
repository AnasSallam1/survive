using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    void Update()
    {
<<<<<<< HEAD
    
    }

    // Pause the game when Space is pressed.
    public void Pause()
=======
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
>>>>>>> local
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true; // Pause all audio
    }

    // Continue the game when Space is pressed again.
    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false; // Resume audio
        isPaused = false;
    }
}