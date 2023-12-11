using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;
    // Start is called before the first frame update
    void Start()
    {
        fader.InFade(0.1f);
    }

    public void StartGame()
    {
        fader.FadeTo("PlayScene");
    }
    public void Upgrade()
    {
        fader.FadeTo("UpGrade");
    }
    public void Option()
    {
        Debug.Log("Option");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
