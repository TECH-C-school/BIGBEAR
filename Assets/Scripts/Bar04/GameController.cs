using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04
{
    public class GameController : MonoBehaviour
    {

        public enum Mark
        {
            Clover,
            Heart,
            Spade,
            Diamond,
        }

        public struct Card
        {
            public int number;
            public Mark mark;

            public string GetPath()
            {
                string path;
                switch (mark)
                {
                    case Mark.Heart:
                        path = "h";
                        break;
                    case Mark.Spade:
                        path = "s";
                        break;
                    case Mark.Diamond:
                        path = "d";
                        break;
                    case Mark.Clover:
                        path = "c";
                        break;
                    default:
                        return "";
                }

                if (number < 10)
                {
                    path += "0";
                }
                path += number.ToString();

                return path;
            }
        }

        private Card[] cards;

        public GameObject Startbutton;

        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
        public void GameStart()
        {
            Debug.Log("ゲームスタート");
            Startbutton.SetActive(false);
        }

        private void Start()
        {
            MakeCard();
        }

        //カード生成
        private void MakeCard()
        {
            //52枚のカードを用意する
            cards = new Card[52];

            //クローバー1～13のカードを用意する
            int number = 1;
            for (int i = 0; i < 13; i++)
            {
                cards[i].mark = Mark.Clover;
                cards[i].number = number;
                number++;
            }
            //ハート1～13のカードを用意する
            number = 1;
            for (int i = 13; i < 26; i++)
            {
                cards[i].mark = Mark.Heart;
                cards[i].number = number;
                number++;
            }
            //スペード1～13のカードを用意する
            number = 1;
            for (int i = 26; i < 39; i++)
            {
                cards[i].mark = Mark.Spade;
                cards[i].number = number;
                number++;
            }
            //ダイヤ1～13のカードを用意する
            number = 1;
            for (int i = 39; i < 51; i++)
            {
                cards[i].mark = Mark.Diamond;
                cards[i].number = number;
                number++;
            }


            //52枚をシャッフルする
            var counter = 0;
            while (counter < 52)
            {
                int index = UnityEngine.Random.Range(counter, cards.Length);
                //選ばれたものを交換する
                var tmp = cards[counter];
                cards[counter] = cards[index];
                cards[index] = tmp;

                counter++;
            }

            /*52枚をランダムにconsoleに出す
            for (int i = 0; i < 52; i++)
            {
                Debug.Log(cards[i].number + ":" + cards[i].mark);
            }*/

//Find("");でオブジェクトを呼び出す

            //GameObject card = GameObject.Find("c10");
            //card.transform.position = GetPosition(1);

            //GameObject card1 = GameObject.Find("c09");
            //card1.transform.position = GetPosition(2);

            //GameObject card2 = GameObject.Find("c08");
            //card2.transform.position = GetPosition(3);

            //GameObject card3 = GameObject.Find("c07");
            //card3.transform.position = GetPosition(4);

            //GameObject card4 = GameObject.Find("c06");
            //card4.transform.position = GetPosition(5);

            //prefabを5個作る
            for (int i = 0; i < 5; i++)
            {
                var Card = cards[i];
                string cardString = Card.GetPath();
            }
            for (int i = 0; i < 5; ++i)
            {
              
                var prefab = Resources.Load<GameObject>("Prefabs/Bar04/Card");
                var card = Instantiate(prefab, new Vector3(-6 + 3 * i , 1.3f, 0), Quaternion.identity);
                var spriteRenderer = card.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + cards[i].GetPath());

            }
        }
        void Update()
        {
            //マウスクリックの判定
            if (!Input.GetMouseButtonDown(0)) return;

            //クリックされた位置を取得
            var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Collider2D上クリックの判定
            if (!Physics2D.OverlapPoint(tapPoint)) return;

            //クリックした位置のオブジェクトを取得
            var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
            if (!hitObject) return;

            //prefabを呼び出す
            var prefab = Resources.Load<GameObject>("Prefabs/Bar04/cardselect");
            //クリックした場所に呼び出す
            Instantiate(prefab, tapPoint, Quaternion.identity);
        }
    }
}

       /* public Vector2 GetPosition(int index)
        {
            switch (index)
            {
                case 1:
                    return new Vector2(-6, 1.3f);
                case 2:
                    return new Vector2(-3, 1.3f);
                case 3:
                    return new Vector2(0, 1.3f);
                case 4:
                    return new Vector2(3, 1.3f);
                case 5:
                    return new Vector2(6, 1.3f);
                default:
                    return new Vector2(-100, -100);
            }
        }
    }
}*/




