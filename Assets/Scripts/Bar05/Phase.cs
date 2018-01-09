    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar05
{
    public class Phase : MonoBehaviour
    {
        public int playerMoney;
        public int playerBet;
        public int enemyBet;
        public int betMoney;
        public int fieldBet;

        public GameObject card;
        public GameObject selectCard;

        public List<int> mountList = new List<int>();
        public List<GameObject> boardList = new List<GameObject>(); 
        public List<GameObject> handCard = new List<GameObject>();
        public List<GameObject> enemyHand = new List<GameObject>();

        public enum PhaseEnum
        {
            プリフロップ,
            フロップ,
            ターン,
            リバー,
            ショーダウン
        }

        public PhaseEnum phaseEnum;

        private string[] cardStr =
        {
            "s01", "s02", "s03", "s04", "s05", "s06", "s07", "s08", "s09", "s10", "s11", "s12", "s13",
        "h01", "h02", "h03", "h04", "h05", "h06", "h07", "h08", "h09", "h10", "h11", "h12", "h13",
        "d01", "d02", "d03", "d04", "d05", "d06", "d07", "d08", "d09", "d10", "d11", "d12", "d13",
        "c01", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "c13",

        };

        private int playerNumber;
        private int openCardCount;
        private Card cardScript;
        private GameObject checkBtn;
        private GameObject betCanvas;
        private GameObject callBtn;

        void Start()
        {
            checkBtn = GameObject.Find("Check");
            betCanvas = GameObject.Find("BetCanvas");
            callBtn = GameObject.Find("Call");
            MakeCard();
        }

        void PhaseManagement()
        {
            PuriFrop();
        }

        /// <summary>
        /// カードの配置と生成
        /// </summary>
        private void MakeCard()
        {
            mountList = MakeRandomNumbers();
            Sprite cardSprite = null;

            for (int i = 0; i < 4; i++)
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

            mountList.RemoveRange(0, 4);
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

        void CreateBoard()
        {
            for (int i = 0; i < 5; i++)
            {
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                var selCard = Instantiate(selectCard);
                selCard.name = selectCard.name;
                selCard.transform.parent = cardObject.transform;

                boardList.Add(cardObject);
                cardObject.name = "Board " + (i + 1);
                cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[i]];

                switch (i)
                {
                    case 0:
                        cardObject.transform.position = new Vector3(-2.7f, 0, -0.01f);
                        break;
                    case 1:
                        cardObject.transform.position = new Vector3(-1.35f, 0, -0.01f);
                        break;
                    case 2:
                        cardObject.transform.position = new Vector3(0f, 0, -0.01f);
                        break;
                    case 3:
                        cardObject.transform.position = new Vector3(1.35f, 0, -0.01f);
                        break;
                    case 4:
                        cardObject.transform.position = new Vector3(2.7f, 0, -0.01f);
                        break;
                }
            }

            mountList.RemoveRange(0, 5);
        }

        /// <summary>
        /// プレイヤーと敵の手札を生成
        /// </summary>
        
        void CreateBetBotton()
        {
            int betAction = 0;
            betCanvas.SetActive(true);

            //場の金額と自分の金額が同じならチェックを表示
            if (fieldBet == playerBet)
            {
                betAction = 1;
            }
            switch (betAction)
            {
                //Call
                case 0:
                    checkBtn.SetActive(false);
                    callBtn.SetActive(true);
                    break;
                //Check
                case 1:
                    callBtn.SetActive(false);
                    checkBtn.SetActive(true);
                    break;
                //Raise
                //Fold
            }
        }

        void BetPhase()
        {
            if(fieldBet == playerBet && fieldBet == enemyBet)
            {
                phaseEnum++;
            }

            if (fieldBet != playerBet)
            {
                CreateBetBotton();
            }
        }


        void PuriFrop()
        {

        }

        void Frop()
        {

        }

        void TurnAndLibber()
        {

        }

        void ShowDown()
        {

        }
    }
}