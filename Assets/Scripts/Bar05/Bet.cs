using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Bar05
{
    public class Bet : MonoBehaviour
    {
        public int fieldBetMoney;
        public int playerBetMoney;
        public int enemyBetMoney;
        public int playerMoney;

        public GameObject resetBtn;

        private int enemyMoney;
        private int fieldMoneyTemp;
        private int playerMoneyTemp;
        private bool start;
        private bool menuBool;
        private GameObject betCanvas;
        private GameObject startCanvas;
        private GameObject menuBtn;
        private GameObject posePanel;
        private GameObject betText;
        private GameObject betText2;
        private GameObject moneyText;
        private GameObject moneyText2;

        private Phase phase;
        private Enemy enemy;

        private void Awake()
        {
            enemy = gameObject.GetComponent<Enemy>();
            phase = gameObject.GetComponent<Phase>();
        }
        private void Start()
        {
            betCanvas = GameObject.Find("BetCanvas");
            startCanvas = GameObject.Find("StartCanvas");
            menuBtn = GameObject.Find("Menu");
            posePanel = GameObject.Find("PosePanel");
            resetBtn = GameObject.Find("Reset");
            betText = GameObject.Find("PlayerBet");
            betText2 = GameObject.Find("PlayerBet2");
            moneyText = GameObject.Find("PlayerMoney");
            moneyText2 = GameObject.Find("PlayerMoney2");
            betCanvas.SetActive(false);
            resetBtn.SetActive(false);
            posePanel.SetActive(false);
            BetChange();
            MoneyTextChange(playerMoney);
            BetTextChange(0);
        }

        void BetChange()
        {
            fieldBetMoney = phase.fieldBet;
            playerBetMoney = phase.playerBet;
            enemyBetMoney = phase.enemyBet;
            playerMoney = phase.playerMoney;
            enemyMoney = phase.enemyMoney;
        }

        void PhaseChange()
        {
            phase.fieldBet = fieldBetMoney;
            phase.playerBet = playerBetMoney;
            phase.playerMoney = playerMoney;
        }

        public void BetTextChange(int playerBetMoney)
        {
            string betSubStr = playerBetMoney.ToString().Substring(0,1); ;
            string betSubStr2 = "";

            if (playerBetMoney > 9)
            {
                betSubStr2 = playerBetMoney.ToString().Substring(1, 1);

                var textTemp2 = Resources.Load<Sprite>("Images/Bar/t_" + betSubStr2);
                betText2.GetComponent<SpriteRenderer>().sprite = textTemp2;
                betText.transform.localPosition = new Vector3(-6.3f, -1.15f, -1f);
            }
            else
            {
                betText2.GetComponent<SpriteRenderer>().sprite = null;
                betText.transform.localPosition = new Vector3(-6.15f, -1.15f, -1f);
            }

            var textTemp = Resources.Load<Sprite>("Images/Bar/t_" + betSubStr);
            betText.GetComponent<SpriteRenderer>().sprite = textTemp;
        }

        public void MoneyTextChange(int playerMoney)
        {
            string moneySubStr = playerMoney.ToString().Substring(0, 1);
            string moneySubStr2 = "";

            if (playerMoney >= 10)
            {
                moneySubStr2 = playerMoney.ToString().Substring(1, 1);

                var textTemp2 = Resources.Load<Sprite>("Images/Bar/t_" + moneySubStr2);
                moneyText2.GetComponent<SpriteRenderer>().sprite = textTemp2;
                moneyText.transform.localPosition = new Vector3(-6.3f, -1.82f, -1f);
            }
            else
            {
                moneyText2.GetComponent<SpriteRenderer>().sprite = null;
                moneyText.transform.localPosition = new Vector3(-6.15f, -1.82f, -1f);
            }

            var textTemp = Resources.Load<Sprite>("Images/Bar/t_" + moneySubStr);
            moneyText.GetComponent<SpriteRenderer>().sprite = textTemp;
        }

        void GoNext()
        {
            betCanvas.SetActive(false);
            PhaseChange();
            MoneyTextChange(playerMoney);
            BetTextChange(playerBetMoney);
            enemy.EnemyBet();
        }

        public void Check()
        {
            BetChange();
            Debug.Log("Player : Check");
            betCanvas.SetActive(false);
            enemy.EnemyBet();
        }

        public void Call()
        {
            BetChange();

            Debug.Log(fieldBetMoney);
            playerMoney -= fieldBetMoney - playerBetMoney;
            playerBetMoney = fieldBetMoney;

            Debug.Log("Player : Call");
            GoNext();
        }

        public void Raise()
        {
            BetChange();

            if (playerMoney >= 2 || enemyMoney <= 1)
            {
                Debug.Log("Player : Raise");

                fieldBetMoney = fieldBetMoney + 2;

                if (fieldBetMoney >= 10)fieldBetMoney = 10;

                playerMoney -= fieldBetMoney - playerBetMoney;
                playerBetMoney = fieldBetMoney;

                GoNext();
            }
        }

        public void StartBtn()
        {
            if (start == false)
            {
                phase.phaseEnum = Phase.PhaseEnum.スタンバイフェイズ;
                phase.PhaseManagement(phase.phaseEnum);
                startCanvas.SetActive(false);
                start = true;
            }
            else
            {
                phase.phaseEnum = Phase.PhaseEnum.スタンバイフェイズ;
                phase.PhaseManagement(phase.phaseEnum);
                startCanvas.SetActive(false);
            }
        }

        //private void RaiseCalculation(int rate)
        //{
        //    playerMoneyTemp = playerMoney;
        //    fieldMoneyTemp = fieldBetMoney;
        //    fieldMoneyTemp *= raiseMagnification + rate;
        //    playerMoneyTemp -= fieldMoneyTemp / raiseMagnification;
        //}

        public void Fold()
        {
            betCanvas.SetActive(false);
            phase.Win(1);
        }

        public void Menu()
        {
            if (menuBool == false)
            {
                menuBtn.transform.DOLocalMove(new Vector3(470f, 244f, 0f), 0.8f);
                menuBool = true;
                posePanel.SetActive(true);
                resetBtn.SetActive(true);
            }
            else
            {
                menuBtn.transform.DOLocalMove(new Vector3(620f, 244f, 0f), 0.8f);
                menuBool = false;
                posePanel.SetActive(false);
                resetBtn.SetActive(false);
            }
        }

        public void ResetButton()
        {
            Destroy(phase.cards);
            phase.nowPhase.GetComponent<SpriteRenderer>().sprite = null;
            menuBtn.transform.DOLocalMove(new Vector3(620f, 244f, 0f), 0.8f);
            menuBool = false;
            posePanel.SetActive(false);
            resetBtn.SetActive(false);
            phase.playerMoney = 20;
            phase.enemyMoney = 20;
            phase.GameReset();
            start = false;
            startCanvas.SetActive(true);
        }

        public void ChangeState()
        {
            phase.battleImage.SetActive(false);
            posePanel.SetActive(false);
        }
    }
}