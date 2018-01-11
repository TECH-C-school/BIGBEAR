using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar03
{
    public class GameController : MonoBehaviour
    {
        public GameObject Cards;
        int[] m_Cards;

        int NextCard = 0;


        // Use this for initialization
        void Start()
        {
            MakeBackCards();
        }

        // Update is called once per frame
        void Update()
        {

        }
        //クラスの用意と宣言
        string[] Card =
        {
            "c01", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "c13",
            "d01", "d02", "d03", "d04", "d05", "d06", "d07", "d08", "d09", "d10", "d11", "d12", "d13",
            "h01", "h02", "h03", "h04", "h05", "h06", "h07", "h08", "h09", "h10", "h11", "h12", "h13",
            "s01", "s02", "s03", "s04", "s05", "s06", "s07", "s08", "s09", "s10", "s11", "s12", "s13",
            "c01", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "c13",
            "d01", "d02", "d03", "d04", "d05", "d06", "d07", "d08", "d09", "d10", "d11", "d12", "d13",
            "h01", "h02", "h03", "h04", "h05", "h06", "h07", "h08", "h09", "h10", "h11", "h12", "h13",
            "s01", "s02", "s03", "s04", "s05", "s06", "s07", "s08", "s09", "s10", "s11", "s12", "s13",
        };


        // カードの生成
        public void MakeBackCards()
        {

            m_Cards = MakeRandomCardNumbers();

            //カードオブジェクトの生成
            Transform CardObject = GameObject.Find("Cards").transform;
            var CardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Cards");
            Transform DeckObject = GameObject.Find("Deck").transform;
            Transform CardObjectf = GameObject.Find("FrontCards").transform;


            //４×６（5枚裏面1枚表面）でカードを配置
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
                        var CardPrefabf = Resources.Load<GameObject>("Prefabs/Bar03/Front/" + Card[m_Cards[NextCard]]);
                        var cardObject = Instantiate(CardPrefabf, transform.position, Quaternion.identity);
                        cardObject.transform.position = new Vector3(
                            a * 1.7f + -7.9f,
                            -b * -0.25f + 2.35f,
                            0);
                        cardObject.transform.parent = CardObjectf;
                        NextCard++;
                    }

                }
            }
            //６×５（4枚裏面1枚表面）でカードを配置
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

                        var CardPrefabf = Resources.Load<GameObject>("Prefabs/Bar03/Front/" + Card[m_Cards[NextCard]]);
                        var cardObject2f = Instantiate(CardPrefabf, transform.position, Quaternion.identity);
                        cardObject2f.transform.position = new Vector3(
                            c * 1.7f + -1.0f,
                            -d * -0.25f + 2.65f,
                            0
                            );
                        cardObject2f.transform.parent = CardObjectf;
                        NextCard++;
                    }
                }
            }

            //残りのカードでデッキを生成
            for (var f = NextCard; f < m_Cards.Length - 54; f++)
            {
                var cardObject3 = Instantiate(CardPrefab, transform.position, Quaternion.identity);
                cardObject3.transform.position = new Vector3(
                    -7.84f,
                    -2.5f,
                    0
                    );
                cardObject3.transform.parent = DeckObject;
            }

        }



        //山札を作る際のカウント
        int[] MakeRandomCardNumbers()
        {
            int[] values = new int[104];
            for (int a = 0; a < values.Length; a++)
            {
                values[a] = a + 1;
            }

            var counter = 0;
            while (counter < values.Length)
            {
                var index = UnityEngine.Random.Range(counter, values.Length);
                var cum = values[counter];
                values[counter] = values[index];
                values[index] = cum;

                counter++;
            }
            return values;
        }

       





        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}

