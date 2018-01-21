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

        private int fieldMoneyTemp;
        private int playerMoneyTemp;
        private bool start;
        private GameObject betCanvas;
        private GameObject startCanvas;
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
            betText = GameObject.Find("PlayerBet");
            betText2 = GameObject.Find("PlayerBet2");
            moneyText = GameObject.Find("PlayerMoney");
            moneyText2 = GameObject.Find("PlayerMoney2");
            betCanvas.SetActive(false);
            BetChange();
            BetTextChange();
        }

        void BetChange()
        {
            fieldBetMoney = phase.fieldBet;
            playerBetMoney = phase.playerBet;
            enemyBetMoney = phase.enemyBet;
            playerMoney = phase.playerMoney;
        }

        public void BetTextChange()
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

        public void PhaseChange()
        {
            phase.fieldBet = fieldBetMoney;
            phase.playerBet = playerBetMoney;
            phase.playerMoney =  playerMoney;

            string moneySubStr = playerMoney.ToString().Substring(0, 1);
            string moneySubStr2 = "";

            if (playerMoney > 9)
            {
                moneySubStr2 = playerMoney.ToString().Substring(1, 1);

                var textTemp2 = Resources.Load<Sprite>("Images/Bar/t_" + moneySubStr2);
                moneyText2.GetComponent<SpriteRenderer>().sprite = textTemp2;
                moneyText.transform.localPosition = new Vector3(-6.3f, -1.82f, -1f);
            }
            else
            {
                moneyText.transform.position = new Vector3(-6.15f, -1.82f, -1f);
            }

            var textTemp = Resources.Load<Sprite>("Images/Bar/t_" + moneySubStr);
            moneyText.GetComponent<SpriteRenderer>().sprite = textTemp;
        }

        public void Check()
        {
            Debug.Log("Player : Check");
            betCanvas.SetActive(false);
            PhaseChange();
            BetTextChange();
            enemy.EnemyBet();
        }

        public void Call()
        {
            if (fieldBetMoney > 0)
            {
                BetChange();
                playerMoney -= fieldBetMoney - playerBetMoney;
                playerBetMoney = fieldBetMoney;
            }
            else
            {
                playerMoney -= 1;
                playerBetMoney = 1;
                fieldBetMoney = 1;
            }

            Debug.Log("Player : Call");
            PhaseChange();
            BetTextChange();
            betCanvas.SetActive(false);
            enemy.EnemyBet();
        }

        public void Raise()
        {
            Debug.Log("Player : Raise");
            BetChange();
            
            fieldBetMoney += 2;
            playerMoney -= fieldBetMoney - playerBetMoney;
            playerBetMoney = fieldBetMoney;

            PhaseChange();
            BetTextChange();
            betCanvas.SetActive(false);
            enemy.EnemyBet();
        }

        public void StartBtn()
        {
            if (start == false)
            {
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
    }
}