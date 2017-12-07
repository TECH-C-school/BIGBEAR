using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar02 {

    public enum Mark
    {
        Spade,
        Heart,
        Diamond,
        Clover
    }

    public struct Card
    {
        public int number;
        public Mark mark;
    }

    public class GameController : MonoBehaviour {
        public void Start()
        {
            int[] cards = new int[52];
            //21枚のカードを用意する
            for (int i = 0; i < 52; i++)
            {
                cards[i] = i + 1;
            }

            var counter = 0;
            while (counter < 52)
            {
                var index = Random.Range(counter, cards.Length);
                var tmp = cards[counter];
                cards[counter] = cards[index];
                cards[index] = tmp;

                counter++;
            }

            Card[] trump = new Card[21];
            for (int i = 0; i < 21; i++)
            {
               
                //19
                trump[i].number = (cards[i] - 1) % 13 + 1;
                trump[i].mark = (Mark)((cards[i] - 1) / 13);
            }



            //21枚のカードを表示する
            var counterForTrump = 0;
            var cardsObject = GameObject.Find("Cards").transform;
            foreach (Transform cardObject in cardsObject.transform)
            {
                var fileName = "";

                switch(trump[counterForTrump].mark)
                {
                    case Mark.Spade:
                        fileName += "s";
                        break;
                    case Mark.Heart:
                        fileName += "h";
                        break;
                    case Mark.Clover:
                        fileName += "c";
                        break;
                    default:
                        fileName += "d";
                        break;
                }

                if (trump[counterForTrump].number < 10)
                {
                    fileName += "0" + trump[counterForTrump].number;
                } else
                {
                    fileName += trump[counterForTrump].number;
                }



                var cardSpriteRenderer = cardObject.GetComponent<SpriteRenderer>();
                cardSpriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + fileName);

                counterForTrump++;
            }
            

        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
