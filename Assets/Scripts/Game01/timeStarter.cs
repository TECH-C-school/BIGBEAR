using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class timeStarter : MonoBehaviour
{
    mainGame maingame;

    private Text textR;
    private Text textL;

    GameObject timerR;
    GameObject timerL;

    private float RightTime = 0; // 初期値は0
    private float LeftTime = 0;

    public string stringTimeR;
    public string stringTimeL;

    public Canvas canvas;

    private Image Attack;

    void Awake()
    {
        Attack = GameObject.Find("attack!").GetComponent<Image>();
    }

    void Start()
    {
        maingame = GameObject.Find("GameController").GetComponent<mainGame>();

        timerR = GameObject.Find("RightText");
        timerL = GameObject.Find("LeftText");

        textR = timerR.GetComponent<Text>();
        textL = timerL.GetComponent<Text>();

        // タイマーをfloatからstringに変換
        textR.text = "00";
        textL.text = "00";

        Attack.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Time.timeScale > 0 && maingame.timeStart == 10)
        {
            Attack.gameObject.SetActive(true);

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
