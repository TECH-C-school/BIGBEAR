using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game07
{
    public class TimeCount : MonoBehaviour
    {
        [SerializeField, Header("タイマーのスピード")]
        private float TimerSpeed = 1;
        [Header("制限時間")]
        public static float times = 10;//これが制限時間
        [SerializeField,Header("白のマスク画像")]
        GameObject backImage;
        [SerializeField,Header("")]
        GameObject backText;
        [SerializeField]
        GameObject[] items;
        public static bool isCount = false;

        void Start()
        {
            GetComponent<Text>().text = ((int)times).ToString();
        }

        void Update()
        {
            if(GameController.m_gameState == GameController.GameState.Ready)
            {
                backImage.SetActive(true);
            }else if(GameController.m_gameState == GameController.GameState.Play)
            {
                backImage.SetActive(false);
            }

            if (isCount)
            {
                times -= TimerSpeed * Time.deltaTime;

                GetComponent<Text>().text = ((int)times).ToString();

                if (times <= 0)
                {
                    times = 0;
                    backImage.SetActive(true);//BackImageの表示
                    backText.SetActive(true);
                    backText.GetComponent<Text>().text = "Score" + ((int)GameController.m_score).ToString();
                    // 永田がここの部分書きました。採用するかあとで決めてください
                    int num = 0;
                    if (GameController.m_score >= 0 && GameController.m_score <= 10)//0以上で10以下の時
                        num = 1;
                    else if (GameController.m_score >= 11 && GameController.m_score <= 20)//11以上で20以下の時
                        num = 2;
                    else if (GameController.m_score >= 21 && GameController.m_score <= 30)//21以上で30以下の時
                        num = 3;
                    for(int i = 0; i < num; i++) // numの数だけRizarutImageを表示する
                        items[i].SetActive(true);
                    /*
                    //goto　処理続き　書け(佐野さんの仕事)
                    if (GameController.m_score >= 0 && GameController.m_score < 10)//0以上で10以下の時
                    {
                        items[0].SetActive(true);//RizarutImageの表示
                    }
                    if (GameController.m_score >= 11 && GameController.m_score < 20)//11以上で20以下の時
                    {
                        items[0].SetActive(true);//RizarutImageの表示
                        items[1].SetActive(true);//RizarutImageの表示
                    }
                    if (GameController.m_score >= 21 && GameController.m_score < 30)//21以上で30以下の時
                    {
                        items[0].SetActive(true);//RizarutImageの表示
                        items[1].SetActive(true);//RizarutImageの表示
                        items[2].SetActive(true);//RizarutImageの表示
                    }
                    */
                    GameController.instance.Result();//ここでTimeUpの時ヘリと爆弾と物資を全部デリートの処理を呼び出し
                }
            }
        }
    }
}
