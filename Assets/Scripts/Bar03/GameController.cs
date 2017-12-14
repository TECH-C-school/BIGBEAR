﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar03
{
    public class GameController : MonoBehaviour
    {
        public GameObject Cards;
        // Use this for initialization
        void Start()
        {
            MakeBackCards();
        }

        // Update is called once per frame
        void Update()
        {

        }
        //enumクラスの用意と宣言
        public enum CardNumber
        {
            c01 = 1, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13,
            d01, d02, d03, d04, d05, d06, d07, d08, d09, d10, d11, d12, d13,
            h01, h02, h03, h04, h05, h06, h07, h08, h09, h10, h11, h12, h13,
            s01, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13,
        }



        // カードの生成
        public void MakeBackCards()
        {
            int count = 0;
            int[] randomCards = MakeRandomCardNumbers();

            Transform CardObject = GameObject.Find("Cards").transform;
            var CardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Cards");
            Transform CardObjectf = GameObject.Find("FrontCards").transform;
            var CardPrefabf = Resources.Load<GameObject>("Prefabs/Bar03/FrontCard");
            for (int a = 0; a < 4; a++)
            {
                for (int b = 0; b < 6; b++)
                {
                    if (b > 0)
                    {
                        var cardObject = Instantiate(CardPrefab, transform.position, Quaternion.identity);
                        cardObject.transform.position = new Vector3(
                            a * 1.7f + -7.9f,
                            -b * -0.25f + 2.35f,
                            0);
                        cardObject.transform.parent = CardObject;
                    }
                    else
                    {
                        var cardObject = Instantiate(CardPrefabf, transform.position, Quaternion.identity);
                        cardObject.transform.position = new Vector3(
                            a * 1.7f + -7.9f,
                            -b * -0.25f + 2.35f,
                            0);
                        cardObject.transform.parent = CardObjectf;
                        /*
                        var card = cardObject.GetComponent<Cards>();
                        card.String = randomCards[count];
                        card.TurnCardFaceDown();
                        count++;
                        */
                    }

                }
            }

            for (var c = 0; c < 6; c++)
            {
                for (var d = 0; d < 5; d++)
                {
                    if (d > 0)
                    {
                        var cardObject2 = Instantiate(CardPrefab, transform.position, Quaternion.identity);
                        cardObject2.transform.position = new Vector3(
                            c * 1.7f + -1.0f,
                            -d * -0.25f + 2.65f,
                            0
                            );
                        cardObject2.transform.parent = CardObject;
                    }
                    else
                    {
                        var cardObject2f = Instantiate(CardPrefabf, transform.position, Quaternion.identity);
                        cardObject2f.transform.position = new Vector3(
                            c * 1.7f + -1.0f,
                            -d * -0.25f + 2.65f,
                            0
                            );
                        cardObject2f.transform.parent = CardObjectf;
                    }
                }
            }
        }

        private int[] MakeRandomCardNumbers()
        {
            int[] values = new int[54];
            for (int a = 0; a < 54; a++)
            {
                values[a] = a + 1;
            }

            var counter = 0;
            while (counter < 54)
            {
                var index = UnityEngine.Random.Range(counter, values.Length);
                var tmp = values[counter];
                values[counter] = values[index];
                values[index] = tmp;

                counter++;
            }
            return values;
        }

        public void ClickCards()
        {

        }





        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}

