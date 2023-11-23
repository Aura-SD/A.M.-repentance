using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public Canvas canvas;

    private bool isPaused = false;

    void Start()
    {
        canvas.enabled = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(0);
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        canvas.enabled = isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void Salir()
    {
        Application.Quit();
    }
}
