using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{
    public class GameController : MonoBehaviour
    {

        int[] cards = new int[52];



        [SerializeField]

        string[] Deck =
            {
            "s01","s02","s03","s04","s05","s06","s07","s08","s09","s10","s11","s12","s13","h01","h02","h03","h04","h05","h06","h07","h08","h09","h10","h11","h12","h13","c01","c02","c03","c04","c05","c06","c07","c08","c09","c10","c11","c12","c13","d01","d02","d03","d04","d05","d06","d07","d08","d09","d10","d11","d12","d13",
            };

        int count = 0;





        // ランダムな山札作る
        private void MakeYamahuda()
        {

            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = i + 1;
            }
            System.Random rng = new System.Random();
            int n = cards.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int tmp = cards[k];
                cards[k] = cards[n];
                cards[n] = tmp;
            }
        }


           





        // ２枚のカードを配る
        private void CardsKubaru()
        {
            for (int i = 0; i < 4; i++)
            {

            }
        }
        // カード表示
        private void LoadingCards(int x, int y, int z)
        {
            var card = GameObject.Find("Cards");

            var Card = Resources.Load<Sprite>("Prefabs/Bar06/Cards/" + Deck[cards[count]]);
            var Dummy = Instantiate(card, new Vector2(y - 2f, z * 4 - 1.2f), Quaternion.identity);
            //Card.transform.parent = card.transform;
            count++;

            //Dummy （ダミー）　←なにこれ

        }

        struct card
        {
            char mark;
            int num;
        };

        


        void Start()
        {
            int x = 0;
            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    if (i == 1)
                    {
                        i++;
                        x = 1;
                    }
                    LoadingCards(cards[i + j], i - x, j);
                }
            }

            MakeYamahuda();
            CardsKubaru();
        }



        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }

    }
}




/*
 
     void Start()
        {
            MakeDeck();
            Dealcards();
            int x = 0;
            for (var i = 0; i < 2; i++)
            { 
                for (var j = 0; j < 2; j++)
                {
                    if(i == 1)
                    {
                        i++;
                        x = 1;
                    }
                    LoadCards(cards[i + j], i - x, j);
                }
            } 
        }
     
             // クリックしたらカードを追加する
       /* public void ClickAddCardButton()
        {
            
            var Card = Resources.Load<GameObject>("Prefabs/Bar06/Cards/" + CardsName[x - 1]);
            Card = Instantiate(Card, new Vector2(- 0.5f, 2 - 1f), Quaternion.identity);
            var card = GameObject.Find("Cards");
            Card.transform.parent = card.transform;
            Debug.Log(x);


                //4枚のカードの表示
            var counterForTrump = 0;
            var cardsObject = GameObject.Find("PlayerCard").transform;
            foreach (Transform cardObject in cardsObject.transform)
            {
                var fileName = "";

                switch (trump[counterForTrump].mark)
                {
                    case Mark.S:
                        fileName += "s";
                        break;
                    case Mark.C:
                        fileName += "c";
                        break;
                    case Mark.H:
                        fileName += "h";
                        break;
                    default:
                        fileName += "d";
                        break;
                }

                if (trump[counterForTrump].number < 10)
                {
                    fileName += "0" + trump[counterForTrump].number;
                }
                else
                {
                    fileName += trump[counterForTrump].number;
                }





     */
