using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{
    public class GameController : MonoBehaviour
    {
        private int ep = 0;
        private int PC = 2;
        private int pc = 0;
        private int ec = 0;
        private int DC = 0;
        private int[] numbers = new int[52];
        private string[] mark = new string[52];
        private int i, j, k, value;
        private string val;
        public Canvas image_win;
        public Canvas image_lose;
        public Canvas image_drow;


        public void MakeDeck()
        {
            System.Random random = new System.Random();
            for (i = 0, j = 0; i < 52; i++, j++)
            {
                if (i < 13)
                {
                    mark[i] = "c";
                }
                else if (i < 26)
                {
                    mark[i] = "d";
                }
                else if (i < 39)
                {
                    mark[i] = "h";
                }
                else
                {
                    mark[i] = "s";
                }

                if (j + 1 >= 14)
                {
                    j = 0;
                }
                numbers[i] = j + 1;
            }
            for (i = 0; i < 52; i++)
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
        }
        public void Start()
        {
            MakeDeck();
            //player default
            for (i = 0; i < 2; i += 1)
            {
                var pCP_1 = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DC] + numbers[DC]);
                var pC_1 = Instantiate(pCP_1, transform.position, Quaternion.identity);
                pC_1.transform.position = new Vector2(0 - i, -1.5f);
                pC_1.transform.localScale = new Vector2(0.17f, 0.17f);
                if (numbers[DC] >= 11)
                {
                    numbers[DC] = 10;
                }
                if (numbers[DC] == 1)
                {
                    if (pc < 11)
                    {
                        numbers[DC] = 11;
                    }
                    else
                    {
                        numbers[DC] = 1;
                    }
                }
                pc = pc + numbers[DC];
                DC++;
            }
            //enemy default
            var eCP_1 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var eC_1 = Instantiate(eCP_1, transform.position, Quaternion.identity);
            eC_1.transform.position = new Vector2(0, 1.5f);
            eC_1.transform.localScale = new Vector2(0.17f, 0.17f);

            var eCP_2 = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DC] + numbers[DC]);
            var eC_2 = Instantiate(eCP_2, transform.position, Quaternion.identity);
            eC_2.transform.position = new Vector2(-1, 1.5f);
            eC_2.transform.localScale = new Vector2(0.17f, 0.17f);
            if (numbers[DC] >= 11)
            {
                numbers[DC] = 10;
            }
            if (numbers[DC] == 1)
            {
                if (ec < 11)
                {
                    numbers[DC] = 11;
                }
                else
                {
                    numbers[DC] = 1;
                }
            }
            ec = ec + numbers[DC];
            DC++;
        }
        //player addcard
        public void AddCard()
        {
            if (pc <= 21)
            {
                var aCP = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DC] + numbers[DC]);
                var aC = Instantiate(aCP, transform.position, Quaternion.identity);
                aC.transform.position = new Vector2(-1 + PC, -1.5f);
                aC.transform.localScale = new Vector2(0.17f, 0.17f);
                PC += 1;
                if (numbers[DC] >= 11)
                {
                    numbers[DC] = 10;
                }
                if (numbers[DC] == 1)
                {
                    if (pc < 11)
                    {
                        numbers[DC] = 11;
                    }
                    else
                    {
                        numbers[DC] = 1;
                    }
                }
                pc = pc + numbers[DC];
                DC ++;
                if (pc >= 22)
                {
                    fight();
                }
            }

        }
        //fight
        public void fight()
        {
            while (ec <= 16)
            {
                var aECP = Resources.Load<GameObject>("Prefabs/Bar06/" + mark[DC] + numbers[DC]);
                var aEC = Instantiate(aECP, transform.position, Quaternion.identity);
                aEC.transform.position = new Vector2(0 + ep, 1.5f);
                aEC.transform.localScale = new Vector2(0.17f, 0.17f);
                ep ++;
                if (numbers[DC] >= 11)
                {
                    numbers[DC] = 10;
                }
                if (numbers[DC] == 1)
                {
                    if (ec < 11)
                    {
                        numbers[DC] = 11;
                    }
                    else
                    {
                        numbers[DC] = 1;
                    }
                }
                ec = ec + numbers[DC];
                DC++;
                if (pc > 21)
                {
                    "Prefabs/Bar06/win"fillAmount = 1;
                }else if (pc < ec)
                {
                    
                }
            }
        }


        public GameObject Score;
        private GUIText Scoretext;
        public void Text()
        {
            Scoretext = Score.GetComponent<GUIText>();
        }

        
       /* public void Result()
        {

        }*/
    }
}
 