using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame: MonoBehaviour
{
    public GameObject PausePanel;

    // Update is called once per frame
    void Update()
    {

    }

    // .
    public void Pause()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // .
    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
