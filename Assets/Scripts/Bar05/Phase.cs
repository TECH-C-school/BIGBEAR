using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar05
{
    public class Phase : MonoBehaviour
    {

        public GameObject card;
        public GameObject selectCard;

        public List<GameObject> boardList = new List<GameObject>();
        public List<GameObject> handCard = new List<GameObject>();
        public List<GameObject> enemyHand = new List<GameObject>();
        public List<int> mountList = new List<int>();



        public enum PhaseEnum
        {
            プリフロップ,
            フロップ,
            ターン,
            リバー,
            ショーダウン
        }

        public PhaseEnum phase;


        public string[] cardStr =
        {
            "s01", "s02", "s03", "s04", "s05", "s06", "s07", "s08", "s09", "s10", "s11", "s12", "s13",
        "h01", "h02", "h03", "h04", "h05", "h06", "h07", "h08", "h09", "h10", "h11", "h12", "h13",
        "d01", "d02", "d03", "d04", "d05", "d06", "d07", "d08", "d09", "d10", "d11", "d12", "d13",
        "c01", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "c13",

        };

        private int openCardCount;
        private Card cardScript;

        void Start()
        {
            MakeCard();
        }

        void Update()
        {
            if (phase == PhaseEnum.プリフロップ)
            {

            }
        }

        /// <summary>
        /// カードの配置と生成
        /// </summary>
        private void MakeCard()
        {
            mountList = MakeRandomNumbers();
            Sprite cardSprite = null;



            for (int i = 0; i < 9; i++)
            {
                {
                    var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                    var selCard = Instantiate(selectCard);
                    selCard.name = selectCard.name;
                    selCard.transform.parent = cardObject.transform;

                    switch (i)
                    {
                        case 0:
                            cardObject.name = "Hand 1";
                            cardObject.transform.position = new Vector3(-0.7f, -2.08f, -0.01f);
                            handCard.Add(cardObject);
                            cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[i]];
                            break;
                        case 1:
                            cardObject.name = "Hand 2";
                            cardObject.transform.position = new Vector3(0.65f, -2.08f, -0.01f);
                            handCard.Add(cardObject);
                            cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[i]];
                            break;
                        case 2:
                            cardObject.name = "EnemyHand 1";
                            cardObject.transform.position = new Vector3(-0.7f, 2.08f, -0.01f);
                            enemyHand.Add(cardObject);
                            cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[i]];
                            break;
                        case 3:
                            cardObject.name = "EnemyHand 2";
                            cardObject.transform.position = new Vector3(0.65f, 2.08f, -0.01f);
                            enemyHand.Add(cardObject);
                            cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[i]];
                            break;
                        case 4:
                            cardObject.name = "Board 1";
                            cardObject.transform.position = new Vector3(-2.7f, 0, -0.01f);
                            boardList.Add(cardObject);
                            break;
                        case 5:
                            cardObject.name = "Board 2";
                            cardObject.transform.position = new Vector3(-1.35f, 0, -0.01f);
                            boardList.Add(cardObject);
                            break;
                        case 6:
                            cardObject.name = "Board 3";
                            cardObject.transform.position = new Vector3(0f, 0, -0.01f);
                            boardList.Add(cardObject);
                            break;
                        case 7:
                            cardObject.name = "Board 4";
                            cardObject.transform.position = new Vector3(1.35f, 0, -0.01f);
                            boardList.Add(cardObject);
                            break;
                        case 8:
                            cardObject.name = "Board 5";
                            cardObject.transform.position = new Vector3(2.7f, 0, -0.01f);
                            boardList.Add(cardObject);
                            break;
                    }
                }
            }
            //プレイヤーのハンド
            for (int i = 0; i < 2; i++)
            {
                var spriteRenderer = handCard[i].GetComponent<SpriteRenderer>();
                cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + cardStr[mountList[i]]);
                spriteRenderer.sprite = cardSprite;
            }

            mountList.RemoveRange(0, 2);

            //敵のハンド
            for (int i = 0; i < 2; i++)
            {
                //var spriteRenderer = enemyHand[i].GetComponent<SpriteRenderer>();
                //cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + cardStr[mountList[i]]);
                //spriteRenderer.sprite = cardSprite;
            }

            mountList.RemoveRange(0, 2);
        }

        /// <summary>
        /// 山札の数字をランダムにする
        /// </summary>

        public List<int> MakeRandomNumbers()
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < 52; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                int random = Random.Range(1, 52);
                int temp = numbers[i];
                numbers[i] = numbers[random];
                numbers[random] = temp;
            }
            return numbers;
        }

        /// <summary>
        /// プレイヤーと敵の手札を生成
        /// </summary>
        

        void TurnCard()
        {

        }

        void handDeal()
        {

        }

    }
}