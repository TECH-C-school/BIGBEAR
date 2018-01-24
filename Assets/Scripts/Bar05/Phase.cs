using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        public float animSec;

        public string playerTextTemp;
        public string enemyTextTemp;

        public GameObject battleImage;
        public GameObject card;
        public GameObject cards; //Reset時消すためにpublic化
        public GameObject nowPhase;
        //public GameObject selectCard;

        public Image enemyTalk;//敵の吹き出し

        public Text enemyText;

        public List<int> mountList = new List<int>();
        public List<GameObject> boardList = new List<GameObject>(); 
        public List<GameObject> handCard = new List<GameObject>();
        public List<GameObject> enemyHand = new List<GameObject>();

        public enum PhaseEnum
        {
            スタンバイフェイズ = 0,
            word5,//プリフロップ
            word6,//フロップ
            word7,//ターン
            word8,//リバー
            word9,//ショーダウン
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
        private int wordNumber;
        private float colorMultiplication;
        private bool allInBool;

        private GameObject checkBtn;
        private GameObject betCanvas;
        private GameObject callBtn;
        private GameObject allInBtn;
        private GameObject raiseBtn;
        private GameObject startBtn;
        private GameObject flameAnim;
        private GameObject phaseAnim;

        private Image playerTalk;

        private Text playerText;

        private HandRank handRank;
        private Enemy enemy;
        private Card cardS;
        private Bet betS;

        /// <summary>
        /// -1～1を勝利アニメで使用
        /// 
        /// </summary>
        /// <param name="waitSec"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private IEnumerator ActionCor(float waitSec, int action)
        {
            if (action >= 2 && 6 >= action)
            {
                string nowPhaseStr = phaseEnum.ToString();
                var spriteRenderer = phaseAnim.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite =
                    Resources.Load<Sprite>("Images/Bar/fc_" + nowPhaseStr);


                phaseAnim.transform.position = new Vector3(11.5f, 0, -5f);
                phaseAnim.transform.DOMoveX(0, 0.8f);
                flameAnim.transform.DOScaleY(1, 1.4f);
            }

            yield return new WaitForSeconds(waitSec);
            if (action <= 1)
            {
                Win(action);
            }
            else if(action >= 2 && 6 >= action)
            {
                phaseAnim.transform.DOMoveX(-11.5f, 0.4f);
                flameAnim.transform.DOScaleY(0, 0.7f);

                yield return new WaitForSeconds(0.5f);

                switch (action)
                {
                    case 2:
                        PuriFrop();
                        break;
                    case 3:
                        Frop();
                        break;
                    case 4:
                        TurnAndLibber();
                        break;
                    case 5:
                        TurnAndLibber();
                        break;
                    case 6:
                        ShowDown();
                        break;
                }
            }
            else
            {
                //enemyTalk.transform.DOLocalMoveY(-1,1);
            }
        }

        private void Awake()
        {
            playerMoney = 20;
            enemyMoney = 20;
            startBtn = GameObject.Find("StartCanvas");
            enemyText = GameObject.Find("DealerRank").GetComponent<Text>();
            playerTalk = GameObject.Find("PlayerTalk").GetComponent<Image>();
            enemyTalk = GameObject.Find("DealerTalk2").GetComponent<Image>();
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
            raiseBtn = GameObject.Find("Raise");
            battleImage = GameObject.Find("BattleImage");
            flameAnim = GameObject.Find("FlameAnim");
            phaseAnim = GameObject.Find("PhaseAnim");
            playerText = GameObject.Find("PlayerRank").GetComponent<Text>();
            battleImage.SetActive(false);
            playerTalk.enabled = false;
            playerText.text = "";
            enemyText.text = "";
            colorMultiplication = 1 / 255f;
        }

        public void PhaseManagement(PhaseEnum phases)
        {
            string nowPhaseStr = "";

            betPhaseCount = 0;
            enemy.betCount = 0;

            nowPhaseStr = phaseEnum.ToString();

            var spriteRenderer = nowPhase.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite =
                Resources.Load<Sprite>("Images/Bar/f_" + nowPhaseStr);

            switch (phaseEnum)
            {
                case PhaseEnum.スタンバイフェイズ:
                    GameReset();
                    Standby();
                    break;
                case PhaseEnum.word5:
                    StartCoroutine(ActionCor(animSec,2));
                    break;
                case PhaseEnum.word6:
                    StartCoroutine(ActionCor(animSec, 3));
                    break;
                case PhaseEnum.word7:
                    StartCoroutine(ActionCor(animSec, 4));
                    break;
                case PhaseEnum.word8:
                    StartCoroutine(ActionCor(animSec, 5));
                    break;
                case PhaseEnum.word9:
                    StartCoroutine(ActionCor(animSec, 6));
                    break;
            }
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
                //var selCard = Instantiate(selectCard);
                //selCard.name = selectCard.name;
                //selCard.transform.parent = cardObject.transform;

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
            //var selCard = Instantiate(selectCard);
            //selCard.name = selectCard.name;
            //selCard.transform.parent = cardObject.transform;

            boardList.Add(cardObject);
            cardObject.name = "Board " + (boardCount + 1);
            cardObject.GetComponent<Card>().cardStrPath = cardStr[mountList[boardCount]];

            switch (boardCount)
            {
                case 0:
                    cardObject.transform.DOMove(new Vector3(-2.7f, 0, -0.01f),0.4f);
                    break;

                case 1:
                    cardObject.transform.DOMove(new Vector3(-1.35f, 0, -0.01f), 0.6f);
                    break;

                case 2:
                    cardObject.transform.DOMove(new Vector3(0f, 0, -0.01f), 0.8f);
                    break;

                case 3:
                    cardObject.transform.DOMove(new Vector3(1.35f, 0, -0.01f), 1f);
                    break;

                case 4:
                    cardObject.transform.DOMove(new Vector3(2.7f, 0, -0.01f), 1.2f);
                    break;
            }

            var spriteRenderer = boardList[boardCount].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = 
                Resources.Load<Sprite>("Images/Bar/Cards/" + cardStr[mountList[boardCount]]);
            boardCount++;
            mountList.RemoveRange(0, 1);
        }

        void CreateBetBotton()
        {
            int betAction = 0;
            betCanvas.SetActive(true);
            checkBtn.SetActive(false);
            callBtn.SetActive(false);

            if (enemyMoney <= 1 || playerMoney <= 1)
            {
                raiseBtn.GetComponent<Image>().color =
                    new Color(161f,161f,161f);
            }

            Debug.Log(betPhaseCount);

            if (fieldBet != playerBet)
            {
                betAction = 1;
            }
            switch (betAction)
            {
                //Check
                case 0:
                    checkBtn.SetActive(true);
                    break;
                //Call
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
                GoShowDown();
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

        private void GoShowDown()
        {
            int createCount = 0;

            switch (phaseEnum)
            {
                case PhaseEnum.word5:
                    createCount = 5;
                    break;
                case PhaseEnum.word6:
                    createCount = 2;
                    break;
                case PhaseEnum.word7:
                    createCount = 1;
                    break;
                case PhaseEnum.word8:
                    createCount = 0;
                    break;
            }

            for (int i = 0; i < createCount; i++)
            {
                CreateBoard();
            }

            if (phaseEnum == PhaseEnum.word5)
            {
                handRank.CheckReady();
            }
            phaseEnum = PhaseEnum.word9;
            StartCoroutine(ActionCor(animSec,6));
        }

        public void PlayerBet()
        {
            betPhaseCount++;

            StartCoroutine(ActionCor(1,7));

            if (fieldBet >= 10 && playerBet == fieldBet)
            {
                GoShowDown();
            }
            else if ((fieldBet == playerBet && fieldBet == enemyBet &&
                betPhaseCount >= 2))
            {
                phaseEnum++;
                PhaseManagement(phaseEnum); 
            }
            else
            {
                CreateBetBotton();
            }
        }

        void Standby()
        {
            Destroy(cards);
            handCard.Clear();
            enemyHand.Clear();
            boardList.Clear();
            boardCount = 0;

            MakeCard();
            mountList.RemoveRange(0, 4);

            //プレイヤーの強制BET
            playerBet = 1;
            playerMoney -= 1;
            betS.BetTextChange(playerBet);
            betS.MoneyTextChange(playerMoney);

            //敵の強制Bet
            enemyBet = 1;
            enemyMoney -= 1;
            enemy.EnemyBetTextChange(enemyBet);
            enemy.EnemyMoneyTextChange(enemyMoney);

            fieldBet = 1;

            //先行を決める 0:プレイヤー先行 １:敵先行
            if (preceding == 0) preceding = 1;
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
                string enemyHandStr = enemyHand[i].GetComponent<Card>().cardStrPath;
                enemyHand[i].GetComponent<SpriteRenderer>().sprite = 
                    Resources.Load<Sprite>("Images/Bar/Cards/" + enemyHandStr);
            }

            int winner = handRank.WinnerCheck();

            playerTalk.enabled = true;
            enemyTalk.enabled = true;

            playerText.text = playerTextTemp;

            StartCoroutine(ActionCor(2,winner));
        }

        public void Win(int winPlayer)
        {
            enemyText.text = enemyTextTemp;

            string winner = "";

            switch (winPlayer)
            {
                //0がプレイヤー
                case 0:
                    playerMoney += playerBet + enemyBet;
                    winner = "win";
                    Debug.Log("PlayerWIN");
                    break;

                //1が敵
                case 1:
                    enemyMoney += enemyBet + playerBet;
                    winner = "lose";
                    Debug.Log("EnemyWIN");
                    break;

                //-1が引き分け
                case -1:
                    playerMoney += 1;
                    enemyMoney += 1;
                    winner = "text_draw";
                    Debug.Log("Drow");
                    break;
            }

            battleImage.SetActive(true);

            battleImage.GetComponent<Image>().sprite
                = Resources.Load<Sprite>("Images/Bar/" + winner);

            if (playerMoney == 0 || enemyMoney == 0)
            {
                GameOver();
            }
            else
            {
                enemyBet = 0;
                playerBet = 0;
                enemy.EnemyBetTextChange(enemyBet);
                enemy.EnemyMoneyTextChange(enemyMoney);
                betS.BetTextChange(playerBet);
                betS.MoneyTextChange(playerMoney);
                startBtn.SetActive(true);
            }
        }

        public void GameReset()
        {
            enemyBet = 0;
            playerBet = 0;
            fieldBet = 0;
            playerText.text = "";
            enemyText.text = "";
            handRank.PhaseEnd();
            enemy.EnemyBetTextChange(enemyBet);
            enemy.EnemyMoneyTextChange(enemyMoney);
            betS.BetTextChange(playerBet);
            betS.MoneyTextChange(playerMoney);
            playerTalk.enabled = false;
            enemyTalk.enabled = false;
            betCanvas.SetActive(false);
            battleImage.SetActive(false);
        }

        private void GameOver()
        {
            Invoke("GameReset",1f);
            battleImage.SetActive(true);
            betS.resetBtn.SetActive(true);
        }
    }
}