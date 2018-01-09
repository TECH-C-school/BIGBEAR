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

        private void Start()
        {
            phase = GameObject.Find("GameController").GetComponent<Phase>();
            fieldBet = phase.fieldBet;
            enemyBet = phase.enemyBet;

            string enemyHand1 = GameObject.Find("EnemyHand 1").GetComponent<Card>().cardStrPath;
            string enemyHand2 = GameObject.Find("EnemyHand 2").GetComponent<Card>().cardStrPath;

            enemyNumber1 = int.Parse(enemyHand1.ToString().Substring(1, 2));
            enemyNumber2 = int.Parse(enemyHand2.ToString().Substring(1, 2));

            enemySuit1 = enemyHand1.ToString().Substring(0, 1);
            enemySuit2 = enemyHand2.ToString().Substring(0, 1);
        }

        public void EnemyBet()
        {

            int enemyNumberAbs = Mathf.Abs(enemyNumber1 - enemyNumber2);

            int tenRandom = Random.Range(0, 9);

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
            else
            {
                if (tenRandom <= 8)
                {

                }
            }
            int probability = Random.Range(0, 100);

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