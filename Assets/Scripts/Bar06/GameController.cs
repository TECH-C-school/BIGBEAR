using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        private int playerpositionX = 2;
        private int playerpositionY = 0;
        private int enemypositionX = 0;
        private int enemypositionY = 0;
        private int playercounter = 0;
        private int enemycounter = 0;
        private int DeckCounter = 0;
        private int[] numbers = new int[52];
        private string[] mark = new string[52];
        private int i, j, k, value;
        private string val;
        private int DeckLock = 0;
        


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
            for(i = 0; i < 4; i += 2)
            {
                var playerCardPrefab1 = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCounter] + numbers[DeckCounter]);
                var playerCard1 = Instantiate(playerCardPrefab1, transform.position, Quaternion.identity);
                playerCard1.transform.position = new Vector3(-2 + i, -2, 0);
                playerCard1.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
                if (numbers[DeckCounter] >= 11)
                {
                    numbers[DeckCounter] = 10;
                }
                if (numbers[DeckCounter] == 1)
                {
                    if (playercounter < 11)
                    {
                        numbers[DeckCounter] = 11;
                    }
                    else
                    {
                        numbers[DeckCounter] = 1;
                    }
                }
                playercounter = playercounter + numbers[DeckCounter];
                DeckCounter++;
            }
            

           

            //ディーラーの初期カードの表示
            var enemyCardPrefab_1 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var enemyCard_1 = Instantiate(enemyCardPrefab_1, transform.position, Quaternion.identity);
            enemyCard_1.transform.position = new Vector3(0, 2, 0);
            enemyCard_1.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
            

            var enemyCardPefab_2 = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCounter] + numbers[DeckCounter]);
            var enemyCard_2 = Instantiate(enemyCardPefab_2, transform.position, Quaternion.identity);
            enemyCard_2.transform.position = new Vector3(-2, 2, 0);
            enemyCard_2.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
            if (numbers[DeckCounter] >= 11)
            {
                numbers[DeckCounter] = 10;
            }
            if (numbers[DeckCounter] == 1)
            {
                if (enemycounter < 11)
                {
                    numbers[DeckCounter] = 11;
                }
                else
                {
                    numbers[DeckCounter] = 1;
                }
            }
            enemycounter = enemycounter + numbers[DeckCounter];
            DeckCounter++;

        }


        //プレイヤーのカード追加
        public void AddCard()
        {
            if(DeckLock == 0)
            {
                
                var addCardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCounter] + numbers[DeckCounter]);
                var addCard = Instantiate(addCardPrefab, transform.position, Quaternion.identity);
                addCard.transform.position = new Vector3(playerpositionX, -2 - playerpositionY, 0);
                addCard.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
                playerpositionX += 2;
                if (numbers[DeckCounter] >= 11)
                {
                    numbers[DeckCounter] = 10;
                }
                if (numbers[DeckCounter] == 1)
                {
                    if (playercounter < 11)
                    {
                        numbers[DeckCounter] = 11;
                    }
                    else
                    {
                        numbers[DeckCounter] = 1;
                    }
                }
                playercounter = playercounter + numbers[DeckCounter];
                DeckCounter++;
                if(playerpositionX > 6)
                {
                    playerpositionX = -2;
                    playerpositionY = 1;
                }
                if (playercounter >= 22)
                {
                    Battle();
                }
            }
            
        }
        
        public void Battle()
        {
            DeckLock = 1;
            while (enemycounter < 17)
            {
                var addEnemyCardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCounter] + numbers[DeckCounter]);
                var addEnemyCard= Instantiate(addEnemyCardPrefab, transform.position, Quaternion.identity);
                addEnemyCard.transform.position = new Vector3(enemypositionX, 2 + enemypositionY, 0);
                addEnemyCard.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
                enemypositionX += 2;
                if (numbers[DeckCounter] >= 11)
                {
                    numbers[DeckCounter] = 10;
                }
                if (numbers[DeckCounter] == 1)
                {
                    if (enemycounter < 11)
                    {
                        numbers[DeckCounter] = 11;
                    }
                    else
                    {
                        numbers[DeckCounter] = 1;
                    }
                }
                enemycounter = enemycounter + numbers[DeckCounter];
                DeckCounter++;
                if(enemypositionX > 6)
                {
                    enemypositionX = -2;
                    enemypositionY = 1;
                }
            }
        }

        public void ReSTART()
        {
            
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }    
    }
}
