using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar05
{
    public class Enemy : MonoBehaviour
    {
        private Phase phase;

        private int enemyNumber1;
        private int enemyNumber2;
        private int fieldBet;
        private int enemyBet;
        private string enemySuit1;
        private string enemySuit2;
        private bool findBool;

        private void Start()
        {
            phase = GameObject.Find("GameController").GetComponent<Phase>();
            fieldBet = phase.fieldBet;
            enemyBet = phase.enemyBet;
            findBool = false;
        }

        public void EnemyBet()
        {
            if (findBool == false)
            {
                string enemyHand1 = GameObject.Find("EnemyHand1").GetComponent<Card>().cardStrPath;
                string enemyHand2 = GameObject.Find("EnemyHand2").GetComponent<Card>().cardStrPath;

                enemyNumber1 = int.Parse(enemyHand1.ToString().Substring(1, 2));
                enemyNumber2 = int.Parse(enemyHand2.ToString().Substring(1, 2));

                enemySuit1 = enemyHand1.ToString().Substring(0, 1);
                enemySuit2 = enemyHand2.ToString().Substring(0, 1);

                findBool = true;
            }

            int enemyNumberAbs = Mathf.Abs(enemyNumber1 - enemyNumber2);

            int tenRandom = Random.Range(0, 9);

            //強気
            if (enemyNumber1 + enemyNumber2 >= 20 || enemyNumber1 == enemyNumber2)
            {
                int raiseRandom = Random.Range(1, 4);
                if (raiseRandom == 1)
                {

                }
                else if (raiseRandom == 2 || raiseRandom == 3)
                {

                }
                else if (raiseRandom == 4)
                {

                }
            }
            //普通
            else if (enemyNumberAbs >= 1 || enemySuit1 == enemySuit2 ||
                enemyNumber1 == 13 || enemyNumber2 == 13 ||
                enemyNumber1 == 1 || enemyNumber2 == 1)
            {
                if (fieldBet == enemyBet && tenRandom >= 2)
                {
                    EnemyContinuation();
                }
                else if (tenRandom == 0)
                {

                }
                else
                {

                }
            }
            //弱気
            else
            {
                if (tenRandom <= 8)
                {

                }
            }
            int probability = Random.Range(0, 100);

            phase.PlayerBetPhase();
        }


        void EnemyContinuation()
        {
            int betAction = 0;

            if (fieldBet == enemyBet)
            {
                //EnemyのCheck

            }
            else
            {
                //EnemyのCall
                enemyBet = fieldBet - enemyBet;
            }
        }

        void EnemyRaise()
        {

        }

        void EnemyFold()
        {

        }
    }
}