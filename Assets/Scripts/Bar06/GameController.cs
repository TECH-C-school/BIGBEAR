using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {

       /* private int count = 1;
        private int playercount = 0;
        private int enemycount = 0;



        public enum Mark
        {
            c,
            d,
            h,
            s,
        }

        public struct Cards
        {
            public int number;
            public Mark mark;
        }*/

        public void deck()
        {
            int[] deck = new int[52];
            for(int i = 0; i < deck.Length; i++)
            {
                deck[i] = i;
            }
            System.Random rng = new System.Random();
            for(int i = 0; i < deck.Length; i++)
            {
                int ransu = rng.Next(deck.Length);
                int kari = deck[i];
                deck[i] = deck[ransu];
                deck[ransu] = kari;
            }
            int kazu = 0;
            string number = "";
            string[] mark = new string[] { "c", "d", "h", "s" };
            for (int i = 0; i < deck.Length; i++)
            {
                if (deck[i] >= 51)
                {
                    number = "";
                }
                else
                {
                    kazu = deck[i] % 13 + 1;
                    string.Format("{0:D2}", kazu);
                    number = kazu.ToString();
                }
            }
        }

        //カード生成
       /* public void Start()
        {
            Cards card1_1 = new Cards();
            Cards card1_2 = new Cards();
            Cards card2_1 = new Cards();
            Cards card2_2 = new Cards();

            card1_1.number = Random.Range(01, 14);
            card1_1.mark = (Mark)Random.Range(0, 3);

            card1_2.number = Random.Range(01, 14);
            card1_2.mark = (Mark)Random.Range(0, 3);

            card2_1.number = Random.Range(01, 14);
            card2_1.mark = (Mark)Random.Range(0, 3);

            card2_2.number = Random.Range(01, 14);
            card2_2.mark = (Mark)Random.Range(0, 3);

            int playercount = card1_1.number + card1_2.number;

            int value = card1_1.number;
            value.ToString().PadLeft(2, '0');



            // var cardPrefab = Resources.Load<GameObject>().

            Debug.Log(card1_1.mark.ToString() + card1_1.number);
            Debug.Log(card1_2.mark.ToString() + card1_2.number);
            Debug.Log(playercount);

            Debug.Log(card2_1.mark.ToString() + card2_1.number);
            Debug.Log(card2_2.mark.ToString() + card2_2.number);
            Debug.Log(enemycount);

            //自分
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            for (int y = 0; y <= 1; y++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(0 - y, 1.5f, 0);
            }
            //相手///
            for (int y = 0; y <= 1; y++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(0 - y, -1.5f, 0);
            }
        }*/

        public void Addcard()
        {
           /* if (playercount <= 21)
            {
                var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.localScale = new Vector3(0.1f, 0.1f, 0);

                count++;
            }*/
        }
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
        private void RemoveCards()
        {
            var cardsObject = GameObject.Find("Cards").transform;
            foreach (Transform cardObject in cardsObject)
            {
                Destroy(cardObject.gameObject);
            }
        }
    }
}
