using System.Collections;
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
            MakeCards();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public enum CardNumber
        {
            S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, S13,
            C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13,
            D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, D11, D12, D13,
            H1, H2, H3, H4, H5, H6, H7, H8, H9, H10, H11, H12, H13,
        }

        public enum Card
        {
            Spead = 1,
            Club,
            Heart,
            Diarmond,
        }
        // カードの生成
        public void MakeCards()
        {
            int count = 0;
            int[] randomCards = MakeRandomCards();

            Transform CardObject = GameObject.Find("Cards").transform;
            var CardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Cards");

            for (int a = 0; a < 4; a++)
            {
                for (int b = 0; b < 5; b++)
                {
                    var cardObject = Instantiate(CardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector3(
                        a * 1.7f + -7.9f,
                        -b * -0.25f + 2.6f,
                        0);
                    cardObject.transform.parent = CardObject;

                }
            }

            for(var c = 0; c < 6; c++)
            {
                for(var d = 0; d < 4; d++)
                {
                    var cardObject2 = Instantiate(CardPrefab, transform.position, Quaternion.identity);
                    cardObject2.transform.position = new Vector3(
                        c * 1.7f + -1.0f,
                        -d * -0.25f + 2.9f,
                        0
                        );
                    cardObject2.transform.parent = CardObject;
                }
            }

            for (int e = 0; e < 4; e++)
            {
                var cardObject3 = Instantiate(CardPrefab, transform.position, Quaternion.identity);
                cardObject3.transform.position = new Vector3(
                    e * 1.7f + -7.9f,
                    -e * -0f + 2.3f,
                    -1
                    );
                cardObject3.transform.parent = CardObject;
            }

            for (int f = 0; f < 6; f++)
            {
                var cardObject4 = Instantiate(CardPrefab, transform.position, Quaternion.identity);
                cardObject4.transform.position = new Vector3(
                    f * 1.7f + -1.0f,
                    -f * -0f + 2.6f,
                    -1
                    );
                cardObject4.transform.parent = CardObject;
            }

        }

        private int[] MakeRandomCards()
        {
            int[] values = new int[13];
            for (int a = 0; a < 13; a++)
            {
                values[a] = a + 1;
            }

            var counter = 0;
            while (counter < 13)
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

