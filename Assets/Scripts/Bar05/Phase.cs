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
            スタンバイフェイズ = 0,
            プリフロップ,
            フロップ,
            ターン,
            リバー,
            ショーダウン
        }

        public PhaseEnum phaseEnum;

        public string[] cardStr =
        {
            "s01", "s02", "s03", "s04", "s05", "s06", "s07", "s08", "s09", "s10", "s11", "s12", "s13",
        "h01", "h02", "h03", "h04", "h05", "h06", "h07", "h08", "h09", "h10", "h11", "h12", "h13",
        "d01", "d02", "d03", "d04", "d05", "d06", "d07", "d08", "d09", "d10", "d11", "d12", "d13",
        "c01", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "c13",

        };

        private int playerNumber;
        private int openCardCount;
        private int betPhaseCount;
        private int boardCount;
        private GameObject checkBtn;
        private GameObject betCanvas;
        private GameObject callBtn;
        private GameObject allInBtn;
        private bool allInBool;

        void Start()
        {
            checkBtn = GameObject.Find("Check");
            betCanvas = GameObject.Find("BetCanvas");
            callBtn = GameObject.Find("Call");
            allInBtn = GameObject.Find("AllIn");
            PhaseManagement(phaseEnum);
        }

        void PhaseManagement(PhaseEnum phases)
        {
            Debug.Log(phaseEnum);
            switch (phaseEnum)
            {
                case PhaseEnum.スタンバイフェイズ:
                    Standby();
                    break;
                case PhaseEnum.プリフロップ:
                    PuriFrop();
                    break;
                case PhaseEnum.フロップ:
                    Frop();
                    break;
                case PhaseEnum.ターン:
                    TurnAndLibber();
                    break;
                case PhaseEnum.リバー:
                    ShowDown();
                    break;
                case PhaseEnum.ショーダウン:
                    ShowDown();
                    break;
            }
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
                            cardObject.name = "Hand1";
                            cardObject.transform.position = new Vector3(-0.7f, -2.08f, -0.01f);
                            handCard.Add(cardObject);
                            cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[i]];
                            break;
                        case 1:
                            cardObject.name = "Hand2";
                            cardObject.transform.position = new Vector3(0.65f, -2.08f, -0.01f);
                            handCard.Add(cardObject);
                            cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[i]];
                            break;
                        case 2:
                            cardObject.name = "EnemyHand1";
                            cardObject.transform.position = new Vector3(-0.7f, 2.08f, -0.01f);
                            enemyHand.Add(cardObject);
                            cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[i]];
                            break;
                        case 3:
                            cardObject.name = "EnemyHand2";
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

        void CreateBoard(int boardNumber)
        {
            var cardObject = Instantiate(card, transform.position, Quaternion.identity);
            var selCard = Instantiate(selectCard);
            selCard.name = selectCard.name;
            selCard.transform.parent = cardObject.transform;

            boardList.Add(cardObject);
            cardObject.name = "Board " + (boardNumber + 1);
            cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[boardNumber]];

            switch (boardNumber)
            {
                case 0:
                    cardObject.transform.position = new Vector3(-2.7f, 0, -0.01f);
                    cardObject.transform.position = new Vector3(-1.35f, 0, -0.01f);
                    cardObject.transform.position = new Vector3(0f, 0, -0.01f);
                    mountList.RemoveRange(0, 3);
                    break;
                case 1:
                    cardObject.transform.position = new Vector3(1.35f, 0, -0.01f);
                    mountList.RemoveRange(0, 1);
                    break;
                case 2:
                    cardObject.transform.position = new Vector3(2.7f, 0, -0.01f);
                    mountList.RemoveRange(0, 1);
                    break;
            }
            boardCount++;
        }

        /// <summary>
        /// プレイヤーと敵の手札を生成
        /// </summary>
        
        void CreateBetBotton()
        {
            int betAction = 0;
            betCanvas.SetActive(true);
            checkBtn.SetActive(false);
            callBtn.SetActive(false);
            allInBtn.SetActive(false);

            //場の金額と自分の金額が同じならチェックを表示
            if (fieldBet == playerBet)
            {
                betAction = 1;
            }
            else if (fieldBet >= playerMoney)
            {
                betAction = 2;
            }
            switch (betAction)
            {
                //Call
                case 0:
                    callBtn.SetActive(true);
                    break;
                //Check
                case 1:
                    checkBtn.SetActive(true);
                    break;
                //AllIn
                case 2:
                    allInBtn.SetActive(true);
                    break;
            }
        }

        public void PlayerBetPhase()
        {
            betPhaseCount++;
            if(fieldBet == playerBet && fieldBet == enemyBet && betPhaseCount >= 2)
            {
                phaseEnum++;
                PhaseManagement(phaseEnum);
            }

            if (fieldBet != playerBet || betPhaseCount <= 1)
            {
                CreateBetBotton();
            }
        }

        void Standby()
        {
            MakeCard();
            phaseEnum++;
            PhaseManagement(phaseEnum);
        }

        void PuriFrop()
        {
            PlayerBetPhase();
        }

        void Frop()
        {
            CreateBoard(boardCount);
            PlayerBetPhase();
        }

        void TurnAndLibber()
        {
            CreateBoard(boardCount);
            PlayerBetPhase();
        }

        void ShowDown()
        {

        }
    }
}