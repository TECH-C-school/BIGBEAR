﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game07
{
    public class TimeCount : MonoBehaviour
    {
        Text TimeText;
        [SerializeField, Header("タイマーのスピード")]
        private float TimerSpeed = 1;
        [SerializeField,Header("白のマスク画像")]
        GameObject BackImage;
        [SerializeField,Header("結果発表テキスト")]
        GameObject BackText;
        [SerializeField,Header("スコアの数(本当は星)")]
        GameObject[] Items;

        private void Awake()
        {
            BackImage.SetActive(true);
        }

        void Start()
        {
            TimeText = GetComponent<Text>();
            TimeText.text = "0";
            //BackImage.SetActive(true);
        }

        void Update()
        {
            if(GameController.instance.m_gameState == GameController.GameState.Ready)
            {
                BackImage.SetActive(true);
            }else if(GameController.instance.m_gameState == GameController.GameState.Play)
            {
                BackImage.SetActive(false);
            }

            if (TimeController.instance.isCount)
            {
                TimeController.instance.times -= TimerSpeed * Time.deltaTime;

                TimeText.text = ((int)TimeController.instance.times).ToString();

                if (TimeController.instance.times <= 0)
                {
                    TimeController.instance.times = 0;
                    GameController.instance.PauseButton.SetActive(false);
                    BackImage.SetActive(true);//BackImageの表示
                    BackText.SetActive(true);
                    BackText.GetComponent<Text>().text = "Score" + ((int)GameController.instance.m_score).ToString();

                    //ここに難易度ごとにスコアの得点でランクを決める
                    //例えば　Easyの時は10点から20点の間ならnum = 1だけど、Hardの時はnum = 2になるみたいな感じ
                    //計算式は　ゲームの難易度(もちろん数字)×10点　みたいな感じで
                    //佐野先輩　やってみてください

                    int num = 0;
                    if (GameController.instance.m_score >= 0 && GameController.instance.m_score <= 10)//0以上で10以下の時
                        num = 1;
                    else if (GameController.instance.m_score >= 11 && GameController.instance.m_score <= 20)//11以上で20以下の時
                        num = 2;
                    else if (GameController.instance.m_score >= 21 && GameController.instance.m_score <= 30)//21以上で30以下の時
                        num = 3;
                    for(int i = 0; i < num; i++) // numの数だけRizarutImageを表示する
                        Items[i].SetActive(true);
                    
                    GameController.instance.Result();//ここでTimeUpの時ヘリと爆弾と物資を全部デリートの処理を呼び出し
                }
            }
        }
    }
}
