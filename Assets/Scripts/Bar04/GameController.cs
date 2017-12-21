using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour {

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

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
        public void GameStart() {
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


            //52枚をシャッフルにする
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

            /*52枚をconsoleに出す
            for (int i = 0; i < 52; i++)
            {
                Debug.Log(cards[i].number + ":" + cards[i].mark);
            }*/

        }

    }

}


        //手役

