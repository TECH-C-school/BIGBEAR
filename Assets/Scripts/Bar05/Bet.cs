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

        private void Start()
        {
            enemy = GameObject.Find("GameController").GetComponent<Enemy>();
            phase = GameObject.Find("GameController").GetComponent<Phase>();
            betCanvas = GameObject.Find("BetCanvas");
            fieldBetMoney = phase.fieldBet;
            playerBetMoney = phase.playerBet;
            enemyBetMoney = phase.enemyBet;
            playerMoney = phase.playerMoney;
            raiseMagnification = 2;
        }

        void Check()
        {
            betCanvas.SetActive(false);
            Invoke("enemy.EnemyBet", 1);
        }

        void Call()
        {
            playerMoney -= fieldBetMoney - playerBetMoney;
            playerBetMoney = fieldBetMoney;
            betCanvas.SetActive(false);
            Invoke("enemy.EnemyBet",1);
        }

        void Raise()
        {
            fieldBetMoney *= raiseMagnification;
            playerMoney -= fieldBetMoney / raiseMagnification;
            playerBetMoney = fieldBetMoney; 
            betCanvas.SetActive(false);
            Invoke("enemy.EnemyBet", 1);
        }

        void RateUp()
        {
            RaiseCalculation(1);
            if (maxMagnification > raiseMagnification && playerMoneyTemp >= 0)
            {
                raiseMagnification++;
            }
        }

        void RateDown()
        {
            RaiseCalculation(-1);
            if (minMagnification < raiseMagnification)
            {
                raiseMagnification--;
            }
        }

        void RaiseCalculation(int rate)
        {
            playerMoneyTemp = playerMoney;
            fieldMoneyTemp = fieldBetMoney;
            fieldMoneyTemp *= raiseMagnification + rate;
            playerMoneyTemp -= fieldMoneyTemp / raiseMagnification;
        }

        void Fold()
        {
            betCanvas.SetActive(false);

            if (enemyBetMoney == fieldBetMoney)
            {
                phase.phaseEnum++;
            }
            else if (enemyBetMoney != fieldBetMoney)
            {
                Invoke("enemy.EnemyBet", 1);
            }
        }
    }
}