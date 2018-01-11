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
        }

        private Card[] cards;

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
        }

        private Card[] cards;

        public GameObject Startbutton;

        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
<<<<<<< HEAD
        public void GameStart()
        {
=======
        public void GameStart() {
>>>>>>> 01ce8ed687f78da83200015da85bc26c867bf3d0
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
<<<<<<< HEAD


=======
>>>>>>> 01ce8ed687f78da83200015da85bc26c867bf3d0
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
<<<<<<< HEAD
=======
            }
            //ダイヤ1～13のカードを用意する
            number = 1;
            for (int i = 39; i < 51; i++)
            {
                cards[i].mark = Mark.Diamond;
                cards[i].number = number;
                number++;
>>>>>>> 01ce8ed687f78da83200015da85bc26c867bf3d0
            }
            //ダイヤ1～13のカードを用意する
            number = 1;
            for (int i = 39; i < 51; i++)
            {
                cards[i].mark = Mark.Diamond;
                cards[i].number = number;
                number++;
            }


<<<<<<< HEAD
            //52枚をシャッフルする
=======

            //52枚をシャッフルにする
>>>>>>> 01ce8ed687f78da83200015da85bc26c867bf3d0
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
<<<<<<< HEAD
            
        }
        /*52枚をランダムにconsoleに出す
        for (int i = 0; i < 52; i++)
        {
            Debug.Log(cards[i].number + ":" + cards[i].mark);
        }*/

        //カード五枚をゲーム画面上に配置
        public void Cards() { 
            GameObject card = GameObject.Find("c01");
            card.transform.position = GetPosition(1);
            
            GameObject card1 = GameObject.Find("c02");
            card1.transform.position = GetPosition(2);

            GameObject card2 = GameObject.Find("h03");
            card2.transform.position = GetPosition(3);

            GameObject card3 = GameObject.Find("h04");
            card3.transform.position = GetPosition(4);

            GameObject card4 = GameObject.Find("s05");
            card4.transform.position = GetPosition(5);

        }

        //カード五枚の座標(空の箱を用意)
        public Vector2 GetPosition(int index)
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

=======

            /*52枚をconsoleに出す
            for (int i = 0; i < 52; i++)
            {
                Debug.Log(cards[i].number + ":" + cards[i].mark);
            }*/

        }

>>>>>>> 01ce8ed687f78da83200015da85bc26c867bf3d0
    }

}


<<<<<<< HEAD
//手役
=======
        //手役

>>>>>>> 01ce8ed687f78da83200015da85bc26c867bf3d0
