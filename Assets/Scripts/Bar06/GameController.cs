using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        private int PC = 1;
        private int playercount = 0;
        private int enemycount = 0;
        private int DeckCount = 0;
        private int[] numbers = new int[52];
        private string[] mark = new string[52];
        private int i, j, k, value;
        private string val;

        public void Start()
        {
            System.Random random = new System.Random();
            for (i = 0,j = 0; i < 52; i++, j++)
            {
                if (i < 13)
                {
                    mark[i] = "c";
                }else if (i < 26)
                {
                    mark[i] = "d";
                }else if (i < 39)
                {
                    mark[i] = "h";
                }else
                {
                    mark[i] = "s";
                }

                if (j + 1 >= 14)
                {
                    j = 0;
                }
                numbers[i] = j + 1;
            }
            for(i = 0; i < 52; i++)
            {
                j = random.Next(52);
                k = random.Next(52);
                value = numbers[j];
                numbers[j] = numbers[k];
                numbers[k] = value;
                val = mark[k];
                mark[j] = mark[k];
                mark[k] = val;
            }
            //player
            for(i = 0; i < 2; i++)
            {
                var playerCardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCount] + numbers[DeckCount]);
                var playerCard = Instantiate(playerCardPrefab, transform.position, Quaternion.identity);
                playerCard.transform.position = new Vector2(0 - i, -1.5f);
                playerCard.transform.localScale = new Vector2(0.17f, 0.17f);
                DeckCount++;
            }
            //enemy
            var enemyCardPrefab_1 = Resources.Load<GameObject>("Prefabs/Bar06/");
        }

        public void Addcard()
        {
           if (playercount <= 21)
            {
                var test = 1;
                var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/c0"+test);
                var AddcardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                AddcardObject.transform.position = new Vector2(PC, -2.5f);
                AddcardObject.transform.localScale = new Vector2(0.17f, 0.17f);
                PC++;
                var playerCard = Random.Range(1, 14);
                playercount = playercount + playerCard;
                Debug.Log(playercount);
            }
        }

        public void Battle()
        {
            Debug.Log(enemycount);
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
