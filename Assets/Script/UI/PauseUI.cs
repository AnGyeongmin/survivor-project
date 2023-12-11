using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public SceneFader fader;
    public GameObject Pause;

    private bool isPause = false;

    private void Update()
    {
        Debug.Log(isPause);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }

        if (isPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void Continue()
    {
        Toggle();
    }
    public void ReTry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        Toggle();
        fader.FadeTo("MainMenu");
    }
    public void Quit()
    {
        Toggle();
        Application.Quit();
    }

    private void Toggle()
    {
        isPause = !isPause;

        Pause.SetActive(isPause);
    }
}
