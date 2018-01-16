using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar05
{
    public class Enemy : MonoBehaviour
    {
        private Phase phase;
        private HandRank handRank;

        private int enemyNumber1;
        private int enemyNumber2;
        private int fieldBet;
        private int enemyBet;
        private int raiseCount;
        private string enemySuit1;
        private string enemySuit2;
        private int firstBet;
        private bool bigRaiseBool;
        private bool attackRaiseBool;
        private bool strongBool;

        private void Start()
        {
            phase = gameObject.GetComponent<Phase>();
            handRank = gameObject.GetComponent<HandRank>();
            fieldBet = phase.fieldBet;
            enemyBet = phase.enemyBet;
            firstBet = 0;
        }

        public void EnemyBet()
        {
            fieldBet = phase.fieldBet;
            enemyBet = phase.enemyBet;
            if (firstBet == 0)
            {
                EnemyFirstBet();
                firstBet++;
            }
            else
            {
                EnemyAfterBet();
            }
            phase.fieldBet = fieldBet;
            phase.enemyBet = enemyBet;
            phase.PlayerBetPhase();
        }

        private void EnemyFirstBet()
        {
            attackRaiseBool = false;
            bigRaiseBool = false;

            string enemyHand1 = GameObject.Find("EnemyHand1").GetComponent<Card>().cardStrPath;
            string enemyHand2 = GameObject.Find("EnemyHand2").GetComponent<Card>().cardStrPath;

            enemyNumber1 = int.Parse(enemyHand1.ToString().Substring(1, 2));
            enemyNumber2 = int.Parse(enemyHand2.ToString().Substring(1, 2));

            enemySuit1 = enemyHand1.ToString().Substring(0, 1);
            enemySuit2 = enemyHand2.ToString().Substring(0, 1);

            int enemyNumberAbs = Mathf.Abs(enemyNumber1 - enemyNumber2);

            int tenRandom = Random.Range(1, 10);

            //強気
            if (enemyNumber1 + enemyNumber2 >= 20 || enemyNumber1 == enemyNumber2)
            {
                int raiseRandom = Random.Range(2,3);
                strongBool = true;

                EnemyRaise(raiseRandom);
            }
            //普通
            else if (enemyNumberAbs == 1 || enemySuit1 == enemySuit2 ||
                enemyNumber1 == 13 || enemyNumber2 == 13 ||
                enemyNumber1 == 1 || enemyNumber2 == 1)
            {
                if (fieldBet == enemyBet && tenRandom >= 3)
                {
                    EnemyContinuation();
                }
                else if (tenRandom == 1)
                {
                    bigRaiseBool = true;
                    EnemyRaise(3);
                }
                else
                {
                    attackRaiseBool = true;
                    EnemyRaise(2);
                }
            }
            //弱気
            else if(tenRandom <= 8)
            {
                EnemyContinuation();
            }
            else
            {
                if (fieldBet == enemyBet)
                {
                    EnemyContinuation();
                }
                else if (tenRandom == 0)
                {
                    EnemyRaise(2);
                }
                else
                {
                    EnemyFold();
                }
            }
        }

        private void EnemyAfterBet()
        {
            int handPower = 0;

            if (phase.phaseEnum != Phase.PhaseEnum.プリフロップ)
            {
                handPower = handRank.EnemyHandCheck();
            }
            int tenRandom = Random.Range(1, 10);

            if (strongBool == true || handPower >= 2)
            {
                if (tenRandom >= 4)
                {
                    EnemyRaise(2);
                }
                else
                {
                    EnemyContinuation();
                }
            }
            else if(attackRaiseBool == true || bigRaiseBool == true || handPower == 1)
            {
                if (tenRandom == 1)
                {
                    EnemyRaise(2);
                }
                else if (bigRaiseBool == false)
                {
                    EnemyRaise(2);
                    attackRaiseBool = false;
                }
                else
                {
                    EnemyContinuation();
                }
            }
            else
            {
                if (tenRandom == 9)
                {
                    EnemyContinuation();
                }
                else
                {
                    EnemyFold();
                }
            }
        }

        /// <summary>
        /// コールとチェックの処理
        /// </summary>
        void EnemyContinuation()
        {
            if (fieldBet != enemyBet)
            {
                enemyBet = fieldBet - enemyBet;
            }
            Debug.Log("チェックorコール");
        }

        /// <summary>
        /// レイズの処理
        /// </summary>
        void EnemyRaise(int raiseMagnification)
        {
            raiseCount++;
            enemyBet = fieldBet * raiseMagnification;
            fieldBet = enemyBet;
        }

        void EnemyFold()
        {
            Debug.Log("Fold");
        }
    }
}