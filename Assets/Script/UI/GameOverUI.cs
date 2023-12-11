using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class GameOverUI : MonoBehaviour
{
    public SceneFader fader;
    [SerializeField]
    private string loadToScene = "MainMenu";

    [SerializeField]
    private float delayTime = 3f;
    private float countdown = 0;

    public GameObject pressAnyeky;
    public GameObject GameOver;

    // Update is called once per frame
    void Update()
    {
        if (!GameOver.activeSelf)
            return;
        countdown += Time.deltaTime;
        if (!pressAnyeky.activeSelf && countdown > delayTime)
        {
            pressAnyeky.SetActive(true);
        }
        if (Input.anyKeyDown && countdown > delayTime)
        {
            GoToMainMenu();
        }
    }

    void GoToMainMenu()
    {
        fader.FadeTo(loadToScene);
    }
}
