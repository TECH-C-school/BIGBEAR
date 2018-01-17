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
        private int firstCount;
             
        private string enemySuit1;
        private string enemySuit2;
        private int firstBet;
        private bool bigRaiseBool;
        private bool attackRaiseBool;
        private bool strongBool;

        private void Awake()
        {
            phase = gameObject.GetComponent<Phase>();
            handRank = gameObject.GetComponent<HandRank>();
        }

        private void Start()
        { 
            fieldBet = phase.fieldBet;
            enemyBet = phase.enemyBet;
            firstBet = 0;
        }

        public void EnemyBet()
        {
            fieldBet = phase.fieldBet;
            enemyBet = phase.enemyBet;

            if (phase.phaseEnum == Phase.PhaseEnum.プリフロップ)
            {
                EnemyFirstBet();
            }
            else
            {
                EnemyAfterBet();
            }

            phase.fieldBet = fieldBet;
            phase.enemyBet = enemyBet;
            phase.PlayerBet();
        }

        private void EnemyFirstBet()
        {
            attackRaiseBool = false;
            bigRaiseBool = false;

            int enemyNumberAbs = Mathf.Abs(enemyNumber1 - enemyNumber2);

            if (firstCount == 0)
            {
                string enemyHand1 = GameObject.Find("EnemyHand1").GetComponent<Card>().cardStrPath;
                string enemyHand2 = GameObject.Find("EnemyHand2").GetComponent<Card>().cardStrPath;

                enemyNumber1 = int.Parse(enemyHand1.ToString().Substring(1, 2));
                enemyNumber2 = int.Parse(enemyHand2.ToString().Substring(1, 2));

                enemySuit1 = enemyHand1.ToString().Substring(0, 1);
                enemySuit2 = enemyHand2.ToString().Substring(0, 1);

                
                firstCount = 1;
            }

            int tenRandom = Random.Range(1, 10);

            //強気
            if (enemyNumber1 + enemyNumber2 >= 20 || enemyNumber1 == enemyNumber2)
            {
                int raiseRandom = Random.Range(2,3);
                strongBool = true;

                EnemyRaise();
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
                    EnemyRaise();
                }
                else
                {
                    attackRaiseBool = true;
                    EnemyRaise();
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
                    EnemyRaise();
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

            handRank.BoardReady();
            handPower = handRank.EnemyHandCheck();

            int tenRandom = Random.Range(1, 10);

            if (strongBool == true || handPower >= 2)
            {
                if (tenRandom >= 4 )
                {
                    EnemyRaise();
                }
                else
                {
                    EnemyContinuation();
                }
            }
            else if(attackRaiseBool == true || bigRaiseBool == true || handPower == 1)
            {
                if (tenRandom == 1 && raiseCount != 1)
                {
                    EnemyRaise();
                }
                else if (bigRaiseBool == false)
                {
                    EnemyRaise();
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
        void EnemyRaise()
        {
            raiseCount++;
            enemyBet = fieldBet * 2;
            fieldBet = enemyBet;
            Debug.Log("レイズ");
        }

        void EnemyFold()
        {
            Debug.Log("Fold");
        }
    }
}