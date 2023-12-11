using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI Min;
    public TextMeshProUGUI Sec;

    private float Secend = 0;
    private int sec = 0;
    private float minute = 0f;

    public int stageLevel = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Secend += Time.deltaTime;
        sec = (int)Secend;
        if (Secend < 10)
        {
            Sec.text = "0" + sec.ToString();
        }
        else
        {
            Sec.text = sec.ToString();
        }
        if (sec >= 60)
        {
            minute++;
            Secend = 0;
        }
        if (minute < 10)
        {
            Min.text = "0" + minute.ToString();
        }
        Min.text = minute.ToString();

        stageLevel = Mathf.FloorToInt(minute / 5 + 1);
    }
}
