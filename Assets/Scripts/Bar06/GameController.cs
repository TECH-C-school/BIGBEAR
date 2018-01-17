using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{


    public class GameController : MonoBehaviour
    {

        public void PlayerMakeCards()

        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/PlayerCardbk");
            //var cardsObject = GameObject.Find("PlayerCard");

            for (int i = 0; i < 2; i++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(
                    i * -2f,
                    -0.8f,
                    0);

                cardObject.transform.parent = cardObject.transform;
                //var card = cardObject.GetComponent<Cards>();
            }
        }
        public void NPCMakeCards()
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/NPCCardbk");
            //var cardsObject = GameObject.Find("NPCCardbk");

            for (int j = 0; j < 2; j++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(
                    j * 2f,
                    3f,
                    0);
                cardObject.transform.parent = cardObject.transform;

                //var card = cardObject.GetComponent<Cards>();

            }
        }

        public enum Mark
        {
            S,
            H,
            D,
            C
        }

        public struct card
        {
            public int number;
            public Mark mark;
        }


        public void trump()
        {
            string[] Deck = { "s01", "s02", "s03", "s04", "s05", "s06", "s07", "s08", "s09", "s10", "s11", "s12", "s13", "c1", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "c13", "h01", "h02", "h03", "h04", "h05", "h06", "h07", "h08", "h09", "h10", "h11", "h12", "h13", "d1", "d02", "d03", "d04", "d05", "d06", "d07", "d08", "d09", "d10", "d11", "d12", "d13" };
        }

        

        //52個の数字用意
        public int[] MakeYamahuda()
        {
            int[] numbers = new int[52];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;

            }
            var counter = 0;
            while (counter < 52)
            {
                var index = Random.Range(counter, numbers.Length);
                var tmp = numbers[counter];
                numbers[counter] = numbers[index];
                numbers[index] = tmp;


                counter++;
            }
            return numbers;
        }

        private void Start()
        {
            int[] cards = new int[52];
            //52枚のカードを用意
            for (int i = 0; i < 52; i++)
            {
                cards[i] = i + 1;

            }

            var counter = 0;
            while (counter < 4)
            {
                var index = Random.Range(counter, cards.Length);
                var tmp = cards[counter];
                cards[counter] = cards[index];
                cards[index] = tmp;

                counter++;
            }

            card[] trump = new card[52];
            for (int i = 0; i < 52; i++)
            {


                trump[i].number = (cards[i] - 1) % 13 + 1;
                trump[i].mark = (Mark)((cards[i] - 1) / 13);
            }


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



                var cardSpriteRenderer = cardObject.GetComponent<SpriteRenderer>();
                cardSpriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + fileName);

                counterForTrump++;
            }

            

    

            PlayerMakeCards();
            MakeYamahuda();
            NPCMakeCards();
        }

        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
        
    }
}

