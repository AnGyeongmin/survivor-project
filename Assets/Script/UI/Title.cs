using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public SceneFader fader;
    [SerializeField]
    private string loadToScene = "MainMenu";

    [SerializeField]
    private float delayTime = 3f;
    private float countdown = 0;

    [SerializeField]
    private float changeTime = 13f;

    public GameObject pressAnyeky;

    private void Start()
    {
        fader.InFade(0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;

        if (countdown > changeTime)
        {
            GoToMainMenu();
        }
        else
        {
            if (!pressAnyeky.activeSelf && countdown > delayTime)
            {
                pressAnyeky.SetActive(true);
            }

            if (Input.anyKeyDown && countdown > delayTime)
            {
                GoToMainMenu();
            }
        }
    }

    void GoToMainMenu()
    {
        fader.FadeTo(loadToScene);
    }
}
