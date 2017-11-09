using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class timeStarter : MonoBehaviour
{
    private Text textR;
    private Text textL;

    GameObject timerR;
    GameObject timerL;

    private float RightTime = 0; // 初期値は0
    private float LeftTime = 0;

    public string stringTimeR;
    public string stringTimeL;

    public Canvas canvas;
    timeText _timetext;

    void Start()
    {
        timerR = GameObject.Find("RightText");
        timerL = GameObject.Find("LeftText");

        textR = timerR.GetComponent<Text>();
        textL = timerL.GetComponent<Text>();

        // タイマーをfloatからstringに変換
        textR.text = "00";
        textL.text = "00";

        _timetext = canvas.GetComponent<timeText>();
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            // 0から加算していく
            RightTime += Time.deltaTime * 100f;

            if(RightTime < 10)
            {
                textR.text = ((int)0).ToString() + ((int)RightTime).ToString();
            }
            else if(10 <= RightTime)
            {
                textR.text = ((int)RightTime).ToString();
            }

            if (LeftTime < 10)
            {
                textL.text = ((int)0).ToString() + ((int)LeftTime).ToString();
            }
            else if (10 <= LeftTime)
            {
                textL.text = ((int)LeftTime).ToString();
            }

            stringTimeR = ((int)RightTime).ToString();

            if(RightTime >= 98)
            {
                RightTime -= 99;
                LeftTime += 1;
            }
        }

        PlayerPrefs.SetString("TimeR", stringTimeR);
        PlayerPrefs.SetString("TimeL", stringTimeL);
    }
}
