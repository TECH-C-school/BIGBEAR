using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Bar05
{
    public class Phase : MonoBehaviour
    {
        public int playerMoney;
        public int enemyMoney;
        public int playerBet;
        public int enemyBet;
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

        [SerializeField]
        private string[] cardStr =
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
        private int preceding;
        private bool allInBool;

        private GameObject cards;
        private GameObject checkBtn;
        private GameObject betCanvas;
        private GameObject callBtn;
        private GameObject allInBtn;
        private GameObject startBtn;
        private GameObject nowPhase;

        private HandRank handRank;
        private Enemy enemy;
        private Card cardS;
        private Bet betS;

        private IEnumerator ActionCor(float waitSec)
        {
            yield return new WaitForSeconds(waitSec);
        }

        private void Awake()
        {
            playerMoney = 20;
            enemyMoney = 20;
            startBtn = GameObject.Find("StartCanvas");
        }

        private void Start()
        {
            handRank = gameObject.GetComponent<HandRank>();
            enemy = gameObject.GetComponent<Enemy>();
            betS = gameObject.GetComponent<Bet>();

            betCanvas = GameObject.Find("BetCanvas");
            checkBtn = GameObject.Find("Check");
            callBtn = GameObject.Find("Call");
            nowPhase = GameObject.Find("NowPhase");
        }

        public void PhaseManagement(PhaseEnum phases)
        {
            string nowPhaseStr = "";

            betPhaseCount = 0;
            enemy.betCount = 0;
            Debug.Log(phaseEnum);
            switch (phaseEnum)
            {
                case PhaseEnum.スタンバイフェイズ:
                    nowPhaseStr = "word5";
                    Standby();
                    break;
                case PhaseEnum.プリフロップ:
                    nowPhaseStr = "word5";
                    PuriFrop();
                    break;
                case PhaseEnum.フロップ:
                    nowPhaseStr = "word6";
                    Frop();
                    break;
                case PhaseEnum.ターン:
                    nowPhaseStr = "word7";
                    TurnAndLibber();
                    break;
                case PhaseEnum.リバー:
                    nowPhaseStr = "word8";
                    TurnAndLibber();
                    break;
                case PhaseEnum.ショーダウン:
                    nowPhaseStr = "word9";
                    ShowDown();
                    break;
            }
            var spriteRenderer = nowPhase.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite =
                Resources.Load<Sprite>("Images/Bar/fc_" + nowPhaseStr);
        }

        /// <summary>
        /// カードの配置と生成
        /// </summary>
        private void MakeCard()
        {
            mountList = MakeRandomNumbers();
            cards = new GameObject(); 

            for (int i = 0; i < 4; i++)
            {
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.parent = cards.transform;
                var selCard = Instantiate(selectCard);
                selCard.name = selectCard.name;
                selCard.transform.parent = cardObject.transform;

                switch (i)
                {
                    case 0:
                        cardObject.name = "Hand1";
                        cardObject.transform.DOMove(new Vector3(-0.7f, -2.08f, -0.01f), 0.4f);
                        handCard.Add(cardObject);
                        cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[i]];
                        break;
                    case 1:
                        cardObject.name = "Hand2";
                        cardObject.transform.DOMove(new Vector3(0.65f, -2.08f, -0.01f), 0.8f);
                        handCard.Add(cardObject);
                        cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[i]];
                        break;
                    case 2:
                        cardObject.name = "EnemyHand1";
                        cardObject.transform.DOMove(new Vector3(-0.7f, 2.08f, -0.01f), 0.6f);
                        cardObject.transform.Rotate(new Vector3(0, 0, 1), 180);
                        enemyHand.Add(cardObject);
                        cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[i]];
                        break;
                    case 3:
                        cardObject.name = "EnemyHand2";
                        cardObject.transform.DOMove(new Vector3(0.65f, 2.08f, -0.01f), 1);
                        cardObject.transform.Rotate(new Vector3(0, 0, 1), 180);
                        enemyHand.Add(cardObject);
                        cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[i]];
                        break;
                }
            }

            //プレイヤーのハンド
            for (int i = 0; i < 2; i++)
            {
                var spriteRenderer = handCard[i].GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + cardStr[mountList[i]]);
            }
        }

        /// <summary>
        /// 山札の数字をランダムにする
        /// </summary>
        public static List<int> MakeRandomNumbers()
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
            var cardObject = Instantiate(card, transform.position, Quaternion.identity);
            cardObject.transform.parent = cards.transform;
            var selCard = Instantiate(selectCard);
            selCard.name = selectCard.name;
            selCard.transform.parent = cardObject.transform;

            boardList.Add(cardObject);
            cardObject.name = "Board " + (boardCount + 3);
            cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[boardCount]];

            switch (boardCount)
            {
                case 0:
                    cardObject.transform.DOMove(new Vector3(-2.7f, 0, -0.01f),0.4f);
                    mountList.RemoveRange(0, 1);
                    break;

                case 1:
                    cardObject.transform.DOMove(new Vector3(-1.35f, 0, -0.01f), 0.6f);
                    mountList.RemoveRange(0, 1);
                    break;

                case 2:
                    cardObject.transform.DOMove(new Vector3(0f, 0, -0.01f), 0.8f);
                    mountList.RemoveRange(0, 1);
                    break;

                case 3:
                    cardObject.transform.DOMove(new Vector3(1.35f, 0, -0.01f), 1);
                    mountList.RemoveRange(0, 1);
                    break;

                case 4:
                    cardObject.transform.DOMove(new Vector3(2.7f, 0, -0.01f), 1);
                    mountList.RemoveRange(0, 1);
                    break;
            }

            var spriteRenderer = boardList[boardCount].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = 
                Resources.Load<Sprite>("Images/Bar/Cards/" + cardStr[mountList[boardCount]]);
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

            if (fieldBet != playerBet || (phaseEnum == PhaseEnum.プリフロップ && betPhaseCount <= 1))
            {
                betAction = 1;
            }
            switch (betAction)
            {
                //Call
                case 0:
                    checkBtn.SetActive(true);
                    break;
                //Check
                case 1:
                    callBtn.SetActive(true);
                    break;
            }
        }


        public void BetPhase()
        {
            //コインが無いときは両者最後まで進ませる。
            if (playerMoney == 0 || enemyMoney == 0)
            {
                phaseEnum++;
                PhaseManagement(phaseEnum);
            }
            else
            {
                handRank.BoardReady();

                switch (preceding)
                {
                    case 0:
                        PlayerBet();
                        break;

                    case 1:
                        enemy.EnemyBet();
                        break;
                }
            }
        }

        public void PlayerBet()
        {
            betPhaseCount++;
            if ((fieldBet == playerBet && fieldBet == enemyBet &&
                betPhaseCount >= 2) || (fieldBet >= 10 && playerBet == fieldBet))
            {
                phaseEnum++;
                PhaseManagement(phaseEnum); 
            }
            else
            {
                CreateBetBotton();
            }
        }

        void GoEnd()
        {
            
        }

        void Standby()
        {
            Destroy(cards);
            handCard.Clear();
            enemyHand.Clear();
            boardList.Clear();

            MakeCard();

            //raiseCount = 0;

            mountList.RemoveRange(0, 4);
            //先行を決める
            if (enemyMoney < playerMoney) preceding = 1;
            else preceding = 0;
            
            phaseEnum++;
            PhaseManagement(phaseEnum);
        }

        void PuriFrop()
        {
            BetPhase();
        }

        void Frop()
        {
            CreateBoard();
            CreateBoard();
            CreateBoard();
            handRank.CheckReady();
            BetPhase();
        }

        void TurnAndLibber()
        {
            CreateBoard();
            BetPhase();
        }

        void ShowDown()
        {
            //プレイヤーのハンド
            for (int i = 0; i < 2; i++)
            {
                var spriteRenderer = enemyHand[i].GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + cardStr[mountList[i]]);
            }

            Win(handRank.WinnerCheck());
        }

        public void Win(int winPlayer)
        {
            switch(winPlayer)
            {
                //0がプレイヤー
                case 0:
                    playerMoney += fieldBet + enemyBet;
                    Debug.Log("PlayerWIN");
                    break;

                //1が敵
                case 1:
                    enemyMoney += fieldBet + playerBet;
                    Debug.Log("EnemyWIN");
                    break;

                //-1が引き分け
                case -1:
                    playerMoney += 1;
                    enemyMoney += 1;
                    Debug.Log("Drow");
                    break;
            }

            enemy.EnemyBetTextChange();
            enemy.EnemyPhaseChange();
            betS.BetTextChange();
            betS.PhaseChange();
            Debug.Log(startBtn);
            startBtn.SetActive(true);
        }
    }
}