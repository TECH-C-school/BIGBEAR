using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        private int playerpositionX = 0;
        private int playerpositionY = 0;
        private int enemypositionX = -2;
        private int enemypositionY = 0;
        private int playercounter = 0;
        private int enemycounter = 0;
        private int DeckCounter = 0;
        private int[] numbers = new int[52];
        private string[] mark = new string[52];
        private int i, j, k, value;
        private string val;
        public Button AddB;
        public Button BattleB;
        public Button ResetB;
        public Button BUB;
        public Button BDB;
        private int coin = 10;
        private int bet;
        private int Pnatural21 = 0;
        private int Enatural21 = 0;
        
       
        public void Win()
        {
            var winPrefab = Resources.Load<GameObject>("Prefabs/Bar06/Win");
            var win = Instantiate(winPrefab, transform.position, Quaternion.identity);
            var WinObject = GameObject.Find("Cards");
            win.transform.position = new Vector3(-7, -1, 0);
            win.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            win.transform.parent = WinObject.transform;
            if(coin < 999)
            {
                coin = coin + bet;
                if(coin >= 999)
                {
                    coin = 999;
                }
            }
            Delete();
        }

        public void Lose()
        {
            var losePrefab = Resources.Load<GameObject>("Prefabs/Bar06/Lose");
            var lose = Instantiate(losePrefab, transform.position, Quaternion.identity);
            var LoseObject = GameObject.Find("Cards");
            lose.transform.position = new Vector3(-7, -1, 0);
            lose.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            lose.transform.parent = LoseObject.transform;
            if (coin > 0)
            {
                coin = coin - bet;
                if (coin <= 0)
                {
                    coin = 0;
                }
            }
            Delete();
        }

        public void Draw()
        {
            var drawPrefab = Resources.Load<GameObject>("Prefabs/Bar06/Draw");
            var draw = Instantiate(drawPrefab, transform.position, Quaternion.identity);
            var DrawObject = GameObject.Find("Cards");
            draw.transform.position = new Vector3(-7, -1, 0);
            draw.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
            draw.transform.parent = DrawObject.transform;
            Delete();
        }

        public void Delete()
        {
            AddB.image.fillAmount = 0;
            AddB.enabled = false;
            BattleB.image.fillAmount = 0;
            BattleB.enabled = false;
            ResetB.image.fillAmount = 1;
            ResetB.enabled = true;
            
        }

        public void BetUP()
        {
            if(bet < 10)
            {
                if(bet < coin)
                {
                    bet++;
                }
            }
        }

        public void BetDown()
        {
            if (bet > 1)
            {
                bet--;
            }
        }

        public void DeleteBetButton()
        {
            BUB.image.fillAmount = 0;
            BUB.enabled = false;
            BDB.image.fillAmount = 0;
            BDB.enabled = false;
        }

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
            if(coin < 5)
            {
                bet = coin;
            }else
            {
                bet = 5;
            }
            

            var CardObject = GameObject.Find("Cards");
            
            //プレイヤーの初期カードの表示           
            for(i = 0; i < 4; i += 2)
            {
                var playerCardPrefab1 = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCounter] + numbers[DeckCounter]);
                var playerCard = Instantiate(playerCardPrefab1, transform.position, Quaternion.identity);
                playerCard.transform.position = new Vector3(-4 + i, -2, 0);
                playerCard.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
                playerCard.transform.parent = CardObject.transform;
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
                
                //ナチュラルブラックジャック判定
                if(playercounter == 21)
                {
                    Pnatural21 = 1;
                }
            }
            


            //ディーラーの初期カードの表示
            var enemyCardPrefab1 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var enemyCard1 = Instantiate(enemyCardPrefab1, transform.position, Quaternion.identity);
            enemyCard1.transform.position = new Vector3(-2, 2, 0);
            enemyCard1.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
            enemyCard1.transform.parent = CardObject.transform;

            var enemyCardPefab2 = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCounter] + numbers[DeckCounter]);
            var enemyCard2 = Instantiate(enemyCardPefab2, transform.position, Quaternion.identity);
            enemyCard2.transform.position = new Vector3(-4, 2, 0);
            enemyCard2.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
            enemyCard2.transform.parent = CardObject.transform;

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

        public void Update()
        {
            var Score1 = GameObject.Find("Canvas/Score1").GetComponent("Text") as Text;
            Score1.text = enemycounter.ToString();
            var Score2 = GameObject.Find("Canvas/Score2").GetComponent("Text") as Text;
            Score2.text = playercounter.ToString();
            var COIN = GameObject.Find("Canvas/COIN").GetComponent("Text") as Text;
            COIN.text = coin.ToString();
            var BET = GameObject.Find("Canvas/BET").GetComponent("Text") as Text;
            BET.text = bet.ToString();
        }



        //プレイヤーのカード追加
        public void AddCard()
        {
            Pnatural21 = 0;

            DeleteBetButton();

            var CardObject2 = GameObject.Find("Cards");
            if (playercounter < 22)
            {
                var addCardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCounter] + numbers[DeckCounter]);
                var addCard = Instantiate(addCardPrefab, transform.position, Quaternion.identity);
                addCard.transform.position = new Vector3(playerpositionX, -2 - playerpositionY, 0);
                addCard.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
                addCard.transform.parent = CardObject2.transform;
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
                if(playerpositionX > 4)
                {
                    playerpositionX = -4;
                    playerpositionY = 1;
                }
                if (playercounter > 21)
                {
                    Lose();
                }
            }
            
        }
        
        public void Battle()
        {
            DeleteBetButton();

            var CardObject3 = GameObject.Find("Cards");
            while (enemycounter < 17)
            {
                var addEnemyCardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DeckCounter] + numbers[DeckCounter]);
                var addEnemyCard= Instantiate(addEnemyCardPrefab, transform.position, Quaternion.identity);
                addEnemyCard.transform.position = new Vector3(enemypositionX, 2 + enemypositionY, 0);
                addEnemyCard.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
                addEnemyCard.transform.parent = CardObject3.transform;
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
                
                //ディーラーのナチュラルブラックジャック判定
                if(enemycounter == 21 && Enatural21 == 0)
                {
                    if (Pnatural21 == 1)
                    {
                        Draw();
                    }
                    else
                    {
                        Lose();
                    }
                }else
                {
                    Enatural21 = 1;
                }

                enemycounter = enemycounter + numbers[DeckCounter];
                DeckCounter++;
                if(enemypositionX > 4)
                {
                    enemypositionX = -4;
                    enemypositionY = 1;
                }
            }

            if (playercounter < enemycounter)
            {
                if (enemycounter < 22)
                {
                    Lose();
                }
                else
                {
                    Win();
                }
            }else if(playercounter == enemycounter)
            {
                if(Pnatural21 == 0)
                {
                    Draw();
                }
            }else
            {
                Win();
            }
           
            
        }

        public void ReSTART()
        {
            AddB.image.fillAmount = 1;
            AddB.enabled = true;
            BattleB.image.fillAmount = 1;
            BattleB.enabled = true;
            ResetB.image.fillAmount = 0;
            ResetB.enabled = false;
            BUB.image.fillAmount = 1;
            BUB.enabled = true;
            BDB.image.fillAmount = 1;
            BDB.enabled = true;
            var DeleteObject = GameObject.Find("Cards").transform;
            for (int i = 0; i < DeleteObject.childCount; ++i)
            {
                GameObject.Destroy(DeleteObject.GetChild(i).gameObject);
            }
            if(coin == 0)
            {
                coin = 10;
            }
            playerpositionX = 0;
            playerpositionY = 0;
            enemypositionX = -2;
            enemypositionY = 0;
            playercounter = 0;
            enemycounter = 0;
            DeckCounter = 0;
            Pnatural21 = 0;
            Enatural21 = 0;
            Start();

        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }    
    }
}
