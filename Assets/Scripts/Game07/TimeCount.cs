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
        [Header("制限時間")]
        public static float times = 10;//これが制限時間
        [SerializeField,Header("白のマスク画像")]
        GameObject BackImage;
        [SerializeField,Header("結果発表テキスト")]
        GameObject BackText;
        [SerializeField,Header("スコアの数(本当は星)")]
        GameObject[] Items;
        public static bool isCount = false;

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

            if (isCount)
            {
                times -= TimerSpeed * Time.deltaTime;

                TimeText.text = ((int)times).ToString();

                if (times <= 0)
                {
                    times = 0;
                    GameController.instance.PauseButton.SetActive(false);
                    BackImage.SetActive(true);//BackImageの表示
                    BackText.SetActive(true);
                    BackText.GetComponent<Text>().text = "Score" + ((int)GameController.instance.m_score).ToString();
                    // 永田がここの部分書きました。採用するかあとで決めてください 
                    // なんで永田先輩に書かしてるんだ　コラ 取りあえずはここは後で修正。
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
