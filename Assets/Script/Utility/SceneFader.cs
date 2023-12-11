using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    //페이더 이미지
    public Image img;

    public GameObject FadeUI;

    //값(Value)을 커브값으로 환산대응
    public AnimationCurve curve;

    [SerializeField]
    private float fadeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //시작하면 무조건 화면이 검정색
        img.color = new Color(0, 0, 0, 1);
    }

    public void InFade(float fadeDelay)
    {
        StartCoroutine(FadeIn(fadeDelay));
    }

    //씬 시작시 1초동안 페이드인 효과 (알파값 이용) - 코룬틴
    IEnumerator FadeIn(float fadeDelay)
    {
        if (fadeDelay > 0)
        {
            yield return new WaitForSeconds(fadeDelay);
        }

        float t = 1f;

        while (t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0, 0, 0, a);
            yield return 0;
        }
        FadeUI.SetActive(false);
    }

    public void FadeTo(string sceneName)
    {
        FadeUI.SetActive(true);
        StartCoroutine (FadeOut(sceneName));
    }

    IEnumerator FadeOut(string sceneName)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0, 0, 0, a);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
