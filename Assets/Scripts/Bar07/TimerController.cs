using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Bar07
{
    public class TimerController : MonoBehaviour
    {
        //関数使用領域
        Sprite[] numberSprite = new Sprite[10];

        GameObject timerm;
        GameObject timerl;
        GameObject timers;

        //計算用
        int timerx = 0;

        private void Start()
        {
            //子オブジェクトを取得
            timerm = gameObject.transform.FindChild("timerm").gameObject;
            timerl = gameObject.transform.FindChild("timerl").gameObject;
            timers = gameObject.transform.FindChild("timers").gameObject;

        }


        //タイマーの表示部分の処理
        //０～９９の数値を受け取って画像で表示する

        public void TimerSprite(int timer) {
            if (timer >= 10)
            {
                timerl.SetActive(true);
                timerm.SetActive(true);
                timers.SetActive(false);

                timerx = timer / 10;
                timerm.GetComponent<SpriteRenderer>().sprite = SpriteSearch(timerx);

                timerx = timer % 10;
                timerl.GetComponent<SpriteRenderer>().sprite = SpriteSearch(timerx);

            }
            else if(timer >= 0)
            {
                timerl.SetActive(false);
                timerm.SetActive(false);
                timers.SetActive(true);

                timers.GetComponent<SpriteRenderer>().sprite = SpriteSearch(timer);


            }
            //負の値の時はすべて非表示にする
            else
            {
                timerl.SetActive(false);
                timerm.SetActive(false);
                timers.SetActive(false);
            }

        }


        //指定したナンバーの数字スプライトを渡す
        private Sprite SpriteSearch(int number)
        {
            Sprite result;
            if (numberSprite[number] == null)
            {
                switch (number)
                {
                    case 0:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_0");
                        break;
                    case 1:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_1");
                        break;
                    case 2:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_2");
                        break;
                    case 3:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_3");
                        break;
                    case 4:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_4");
                        break;
                    case 5:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_5");
                        break;
                    case 6:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_6");
                        break;
                    case 7:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_7");
                        break;
                    case 8:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_8");
                        break;
                    case 9:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_9");
                        break;
                    default:
                        result = null;
                        break;

                }
            }

            result = numberSprite[number];


            return result;
        }
    }
}