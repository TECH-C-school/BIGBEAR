using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04_06
{
    public class GameController : MonoBehaviour
    {
        private object cardObject;

        private void Start()
        {
            var cards = MakeRandomNumbers();
            MakeBackCards(cards);
        }
        public enum suit
        {
            Clover,
            Dia,
            Heart,
            Spade
        }

        public struct Card
        {
            public int number;
            public suit mark;

            public string CardString()
            {
                string cardString = "";

                switch (mark)
                {
                    case suit.Clover:
                        cardString += "c";
                        break;
                    case suit.Spade:
                        cardString += "s";
                        break;
                    case suit.Heart:
                        cardString += "h";
                        break;
                    case suit.Dia:
                        cardString += "d";
                        break;
                }

                if (number < 10)
                {
                    cardString += "0";
                }

                cardString += number.ToString();

                return cardString;
            }

            internal void HoldCardFaceUp()
            {
                throw new NotImplementedException();
            }

            internal void HoldCardFaceDown()
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 山札の作成
        /// </summary>

        public Card[] MakeRandomNumbers()
        {

            Card[] number = new Card[52];
            for (int i = 0; i < number.Length; i++)
            {
                if (i <= 13)
                {
                    number[i].number = i;
                    number[i].mark = suit.Clover;
                }
                else if (i <= 26)
                {
                    number[i].number = i - 13;
                    number[i].mark = suit.Dia;
                }
                else if (i <= 39)
                {
                    number[i].number = i - 26;
                    number[i].mark = suit.Heart;
                }
                else
                {
                    number[i].number = i - 39;
                    number[i].mark = suit.Spade;
                }
            }
            //シャッフルする
            System.Random rng = new System.Random();
            int n = number.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card tmp = number[k];
                number[k] = number[n];
                number[n] = tmp;

            }

            return number;
        }
        /// <summary>
        /// カードの配置　　　
        /// </summary>

        public void MakeBackCards(Card[] cards)
        {


            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/Prefabs/Back");
            var cardsObject = GameObject.Find("Cards");

            int j = -4;
            for (int i = 0; i < 5; i++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(
                j, 0, 0);
                cardObject.transform.parent = cardsObject.transform;
                j = j + 2;

                var spriteRenderer = cardObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + cards[i].CardString());



            }
            var TrumpCard = GameObject.Find("Cards").transform;
            var card = TrumpCard.GetComponent<Card>();
            card.HoldCardFaceUp();
        }

        /// <summary>
        /// クリックしたカードをHoldし、クリックされていないカードを捨て場に送る
        /// </summary>
        // 左クリックしたオブジェクトを取得する関数(2D)
        private void ClickCard()
        {
            //マウスクリックの判定
            if (!Input.GetMouseButtonDown(0)) return;

            //クリックされた位置を取得
            var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Collider2D上クリックの判定
            if (!Physics2D.OverlapPoint(tapPoint)) return;

            //クリックされた位置のオブジェクトを取得
            var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
            if (!hitObject) return;

            //クリックされたカードスクリプトを取得
            var card = hitObject.collider.gameObject.GetComponent<Card>();
            card.HoldCardFaceDown();



        }
        /// <summary>
        /// 捨て場に送った枚数分手札に加える
        /// </summary>



        /// <summary>
        /// 所持しているカードの役を判別する
        /// </summary>
        /// 

        
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
