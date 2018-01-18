using System.Collections;
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
                    BackText.GetComponent<Text>().text = "Score" + (GameController.instance.m_score).ToString();

                    int num = 0;
                    int level = (int)GameController.instance.m_gameLevel;
                    if (GameController.instance.m_score >= 0 * level && GameController.instance.m_score <= 10 * level)//0以上で10以下の時
                        num = 1;
                    else if (GameController.instance.m_score >= 11 * level && GameController.instance.m_score <= 20 * level)//11以上で20以下の時
                        num = 2;
                    else if (GameController.instance.m_score >= 21 * level && GameController.instance.m_score <= 30 * level)//21以上で30以下の時
                        num = 3;
                    for(int i = 0; i < num; i++) // numの数だけRizarutImageを表示する
                        Items[i].SetActive(true);
                    
                    GameController.instance.Result();//ここでTimeUpの時ヘリと爆弾と物資を全部デリートの処理を呼び出し
                }
            }
        }
    }
}
