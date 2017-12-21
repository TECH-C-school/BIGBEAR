using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        private int positioncounter = 1;
        private int playercounter = 0;
        private int enemycounter = 0;
        private int DeckCounter = 0;
        private int[] numbers = new int[52];
        private string[] mark = new string[52];
        private int i, j, k, value;
        private string val;

        public void MakeDeck()
        {
            System.Random r = new System.Random();
            for (i = 0, j = 0; i < 52; i++, j++)
            {
                if (i < 13)
                {
                    mark[i] = "s";
                }
                else if (i < 26)
                {
                    mark[i] = "h";
                }
                else if (i < 39)
                {
                    mark[i] = "c";
                }
                else
                {
                    mark[i] = "d";
                }

                if (j + 1 >= 14)
                {
                    j = 0;
                }
                numbers[i] = j + 1;

            }
            for (i = 0; i < 52; i++)
            {
                j = r.Next(52);
                k = r.Next(52);
                value = numbers[j];
                numbers[j] = numbers[k];
                numbers[k] = value;
                val = mark[j];
                mark[j] = mark[k];
                mark[k] = val;
            }
            
        }
        
        public void Start()
        {
            //シャッフルされたデッキの用意
            MakeDeck();

            //プレイヤーの初期カードの表示           
            for (i = 0; i < 2; i++)
            {
                var playerCardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCounter] + numbers[DeckCounter]);
                var playerCard = Instantiate(playerCardPrefab, transform.position, Quaternion.identity);
                playerCard.transform.position = new Vector3(0 - i, -2.5f, 0);
                playerCard.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
                if(numbers[DeckCounter] >= 11)
                {
                    numbers[DeckCounter] = 10;
                }
                playercounter = playercounter + numbers[DeckCounter];
                DeckCounter++;
            }

            //ディーラーの初期カードの表示
            var enemyCardPrefab_1 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var enemyCardPrefab_1UP = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCounter] + numbers[DeckCounter]);
            var enemyCard_1 = Instantiate(enemyCardPrefab_1, transform.position, Quaternion.identity);
            enemyCard_1.transform.position = new Vector3(0, 2.5f, 0);
            enemyCard_1.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
            if (numbers[DeckCounter] >= 11)
            {
                numbers[DeckCounter] = 10;
            }
            enemycounter = enemycounter + numbers[DeckCounter];
            DeckCounter++;
            

            var enemyCardPefab_2 = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCounter] + numbers[DeckCounter]);
            var enemyCard_2 = Instantiate(enemyCardPefab_2, transform.position, Quaternion.identity);
            enemyCard_2.transform.position = new Vector3(-1, 2.5f, 0);
            enemyCard_2.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
            if (numbers[DeckCounter] >= 11)
            {
                numbers[DeckCounter] = 10;
            }
            enemycounter = enemycounter + numbers[DeckCounter];
            DeckCounter++;

        }

        //プレイヤーのカード追加
        public void AddCard()
        {
            if(playercounter < 22)
            {
                
                var addCardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCounter] + numbers[DeckCounter]);
                var addCard = Instantiate(addCardPrefab, transform.position, Quaternion.identity);
                addCard.transform.position = new Vector3(positioncounter, -2.5f, 0);
                addCard.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
                positioncounter++;
                if (numbers[DeckCounter] >= 11)
                {
                    numbers[DeckCounter] = 10;
                }
                playercounter = playercounter + numbers[DeckCounter];
                DeckCounter++;
            }
            
        }
        
        public void Battle()
        {
            Debug.Log(enemycounter);
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }    
    }
}
