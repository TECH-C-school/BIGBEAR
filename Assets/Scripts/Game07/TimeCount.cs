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
        [SerializeField,Header("制限時間")]
        float times = 10;//これが制限時間
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
            if(GameController.gameState == GameController.GameState.Ready)
            {
                backImage.SetActive(true);
            }else if(GameController.gameState == GameController.GameState.Play)
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
                    backImage.SetActive(true);
                    backText.SetActive(true);
                    backText.GetComponent<Text>().text = "Score" + ((int)GameController.m_score).ToString();
                    //goto　処理続き　書け(佐野さんの仕事)
                    if (GameController.m_score >= 0 && GameController.m_score < 10)
                    {
                        items[0].SetActive(true);
                        GameController.instance.Result();
                    }
                }
            }
        }
    }
}
