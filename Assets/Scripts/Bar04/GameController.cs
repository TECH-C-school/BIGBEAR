using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Bar0404
{
    public class GameController : SingletonMonoBehaviour<GameController>
    {

        //ボタン関係
        public GameObject StartButton;
        public GameObject ChangeButton;
        public GameObject RestartButton;

        //リザルト関係
        public GameObject ScoreScreen;
        public Text ResultHundText;
        public Text ResultScoreText;

        //チップ関係
        public Text HundChiptext;
        public Text BetChiptext;
        public GameObject BetUpButton;
        public GameObject BetDownButton;

        //フェイズ管理用
        public Image Phase;
        public Sprite SetchipPhase;
        public Sprite CardChangePhase;
        public Sprite ResultPhase;
        

        //カード関係の変数
        public int[] shuffulCards;
        public List<GameObject> Card;
        int nextCard = 0;

        //手札関係の変数
        int[] m_HundNumber = new int[5];
        char[] m_HundMark = new char[5];
        public GameObject PokerHund;



        public void TransitionToResult(){
            SceneManager.LoadScene("Result");
        }



        public void Start(){
            HundChiptext.text = "" + ScoreManager.Instance.HundChip;
            BetChiptext.text = "" + ScoreManager.Instance.BetChip;
        }



        public void Update(){
            CardClick();

        }

        //山札をシャッフルするための乱数生成
        public int[] MakeRundumNumber(){
            int[] values = new int[52];
            for (int i = 0; i < 52; i++){
                values[i] = i;
            }
            for (int i = 0; i < 52; i++) {
                int abc = UnityEngine.Random.Range(0, values.Length);
                int xyz;
                xyz = values[i];
                values[i] = values[abc];
                values[abc] = xyz;
            }

            return values;
        }

        //スタートボタンを押したときの処理
        public void GameStart(){
            //山札をシャッフル
            shuffulCards = MakeRundumNumber();
            MakeFirstCards();
            StartButton.SetActive(false);
            ChangeButton.SetActive(true);
            CardSort();
            Phase.sprite = CardChangePhase;
            ScoreManager.Instance.Payment();
            HundChiptext.text = "" + ScoreManager.Instance.HundChip;
            BetUpButton.SetActive(false);
            BetDownButton.SetActive(false);
        }

        //入れ替えを実行したときの処理
        public void CardChange() {
            for (int i = 0; i < Card.Count; i++){
                var cardsprict = Card[i].GetComponent<Card>();
                if (cardsprict.Select){
                    cardsprict.Number = shuffulCards[nextCard];
                    cardsprict.TurnCardFlont();
                    nextCard++;
                    cardsprict.CardSelect();
                }
            }
            CardSort();
            ChangeButton.SetActive(false);
            RestartButton.SetActive(true);
            Phase.sprite = ResultPhase;
            PokerHand.Instance.PokerCheck();
            ResultHundText.text = ScoreManager.Instance.resulttext;
            ResultScoreText.text = ScoreManager.Instance.resultChip;
            ScoreScreen.SetActive(true);
        }

        //Restart時の処理
        public void Restart() {
            for (int i = 0; i < Card.Count; i++){
                var cardScript = Card[i].GetComponent<Card>();
                cardScript.TurnCardBack();
            }
            nextCard = 0;
            RestartButton.SetActive(false);
            StartButton.SetActive(true);
            Phase.sprite = SetchipPhase;
            ScoreScreen.SetActive(false);
            ScoreManager.Instance.BetChip = 0;
            HundChiptext.text = "" + ScoreManager.Instance.HundChip;
            BetChiptext.text = "0";
            BetUpButton.SetActive(true);
        }

        //BetUpの処理
        public void BetUp() {
            ScoreManager.Instance.BetChip += 10;
            BetChiptext.text = "" + ScoreManager.Instance.BetChip;
            if (ScoreManager.Instance.BetChip >= 0) {
                BetDownButton.SetActive(true);
            }
            if (ScoreManager.Instance.BetChip >= 50) {
                BetUpButton.SetActive(false);
            }
        }

        //BetDownの処理
        public void BetDown()
        {
            ScoreManager.Instance.BetChip -= 10;
            BetChiptext.text = "" + ScoreManager.Instance.BetChip;
            if (ScoreManager.Instance.BetChip <= 0){
                BetDownButton.SetActive(false);
            }
            if (ScoreManager.Instance.BetChip <= 50)
            {
                BetUpButton.SetActive(true);
            }
        }


        //最初のカードを配る        
        public void MakeFirstCards(){

            for (int i = 0; i < Card.Count; i++) {
                var cardsprict = Card[i].GetComponent<Card>();
                cardsprict.Number = shuffulCards[nextCard];
                cardsprict.TurnCardFlont();
                nextCard++;
            }

        }



        void CardSort(){
            //手札のナンバーを取得
            for (int i = 0; i < Card.Count; i++){
                var cardsprict = Card[i].GetComponent<Card>();
                int xyz = cardsprict.Number;
                m_HundMark[i] = cardsprict.CardMark[xyz];
                m_HundNumber[i] = cardsprict.CardNumber[xyz];
            }
            //カードをソート
            for (int i = 0; i < m_HundNumber.Length; i++){
                int min = m_HundNumber[i];
                int minnum = i;
                for (int j = i; j < m_HundNumber.Length; j++){
                    if (min > m_HundNumber[j]) {
                        min = m_HundNumber[j];
                        minnum = j;
                    }


                }
                int value = m_HundNumber[i];
                m_HundNumber[i] = min;
                m_HundNumber[minnum] = value;
                var cardsprict = Card[i].GetComponent<Card>();
                var cardsprict2 = Card[minnum].GetComponent<Card>();
                value = cardsprict.Number;
                cardsprict.Number = cardsprict2.Number;
                cardsprict2.Number = value;
            }

            for (int i = 0; i < Card.Count; i++)
            {
                var cardsprict = Card[i].GetComponent<Card>();
                int xyz = cardsprict.Number;
                m_HundMark[i] = cardsprict.CardMark[xyz];
            }

            for (int i = 0; i < Card.Count; i++)
            {
                var cardsprict = Card[i].GetComponent<Card>();
                cardsprict.TurnCardFlont();
            }
            var Pokersprict = PokerHund.GetComponent<PokerHand>();
            Pokersprict.Hund = m_HundNumber;
            Pokersprict.HundM = m_HundMark;

        }


        //カードを押すための関数
        void CardClick() {
            if (!Input.GetMouseButtonDown(0)) { return; }
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collision2D = Physics2D.OverlapPoint(tapPoint);
            if (!collision2D) { return; }
            GameObject Card = collision2D.transform.gameObject;
            var CardSprict = Card.GetComponent<Card>();
            CardSprict.CardSelect();
            
        }



    }

}



