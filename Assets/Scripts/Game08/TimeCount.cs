using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class TimeCount : MonoBehaviour
{


    public float timeCounter = 6; //左上時間カウント
    Text timeLabel;        //カウントテキスト
    float waitCount = 9;   //内部カウント・リザルト

    void Start()
    {
        GetComponent<Text>().text = ((int)timeCounter).ToString();

    }

    void Update()
    {
        timeCounter -= Time.deltaTime;
        waitCount -= Time.deltaTime;

        if (timeCounter < 0) timeCounter = 0;
        GetComponent<Text>().text = ((int)timeCounter).ToString();


        if (waitCount < 0)
        {
            waitCount = 0;
            SceneManager.LoadScene("Result");
            return;
        }

    }
}
