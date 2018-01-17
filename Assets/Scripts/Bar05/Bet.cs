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
        public int maxMagnification;
        public int minMagnification;

        private int fieldMoneyTemp;
        private int playerMoneyTemp;
        private int raiseMagnification;
        private GameObject betCanvas;

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
            raiseMagnification = 2;
        }

        void BetChange()
        {
            fieldBetMoney = phase.fieldBet;
            playerBetMoney = phase.playerBet;
            enemyBetMoney = phase.enemyBet;
            playerMoney = phase.playerMoney;
        }

        void PhaseChange()
        {
            phase.fieldBet = fieldBetMoney;
            phase.playerBet = playerBetMoney;
            phase.enemyBet = enemyBetMoney;
            phase.playerMoney =  playerMoney;
        }

        public void Check()
        {
            betCanvas.SetActive(false);
            enemy.EnemyBet();
        }

        public void Call()
        {
            PhaseChange();
            playerMoney -= fieldBetMoney - playerBetMoney;
            playerBetMoney = fieldBetMoney;
            BetChange();
            betCanvas.SetActive(false);
            enemy.EnemyBet();
        }

        public void Raise()
        {
            PhaseChange();
            fieldBetMoney *= raiseMagnification;
            playerMoney -= fieldBetMoney / 2;
            playerBetMoney = fieldBetMoney;
            BetChange();
            betCanvas.SetActive(false);
            enemy.EnemyBet();
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