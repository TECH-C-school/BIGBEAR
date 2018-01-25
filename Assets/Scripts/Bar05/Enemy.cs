using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Assets.Scripts.Bar05
{
    public class Enemy : MonoBehaviour
    {
        private Phase phase;
        private HandRank handRank;

        private int enemyMoney;
        private int enemyNumber1;
        private int enemyNumber2;
        private int firstBet;
        private int fieldBet;
        private int playerBet;
        private int enemyBet;
        public int raiseCount;
        private int firstCount;
        private int textCount;
        public int betCount;

        private string enemySuit1;
        private string enemySuit2;
        private string enemyTalkStr;
        private string talkTemp;
        private bool bigRaiseBool;
        private bool attackRaiseBool;
        private bool strongBool;
        private bool foldBool;

        private GameObject enemyBetText;
        private GameObject enemyBetText2;
        private GameObject enemyMoneyText;
        private GameObject enemyMoneyText2;

        private Text enemyTalkText;

        private Image enemyTalk;
        private Image enemyTalkAction;

        private Sprite talkActionSprite;

        private void Awake()
        {
            phase = gameObject.GetComponent<Phase>();
            handRank = gameObject.GetComponent<HandRank>();
        }

        private void Start()
        { 
            fieldBet = phase.fieldBet;
            enemyMoney = phase.enemyMoney;
            firstBet = 0;
            enemyBetText = GameObject.Find("DealerBet");
            enemyBetText2 = GameObject.Find("DealerBet2");
            enemyMoneyText = GameObject.Find("DealerMoney");
            enemyMoneyText2 = GameObject.Find("DealerMoney2");
            enemyTalk = phase.enemyTalk;
            enemyTalkAction = GameObject.Find("DealerAction").GetComponent<Image>();
            enemyTalkText = phase.enemyText;
            enemyTalk.enabled = false;
            enemyTalkAction.enabled = false;
        }

        private IEnumerator AnimetionCor(float action) 
        {
            yield return new WaitForSeconds(action);
            if (action == 2)
            {
                TalkReset();
            }
            else //if(action == 0.2f)
            {
                enemyTalk.enabled = true;
                enemyTalkText.text = talkTemp;
                if (enemyTalkStr != "")
                {
                    enemyTalkAction.enabled = true;
                    enemyTalkAction.sprite = talkActionSprite;
                }
            }
        }

        void TalkReset()
        {
            enemyTalk.enabled = false;
            enemyTalkAction.enabled = false;
            talkTemp = "";
            enemyTalkText.text = "";
            enemyTalkStr = "";
        }

        public void EnemyBet()
        {
            betCount++;

            fieldBet = phase.fieldBet;
            playerBet = phase.playerBet;
            enemyBet = phase.enemyBet;
            enemyMoney = phase.enemyMoney;

            if (playerBet == enemyBet && 10 <= fieldBet)
            {
                //何も処理せず進む
            }
            else if (betCount <= 1 || fieldBet != enemyBet)
            {
                StopCoroutine(AnimetionCor(2));

                TalkReset();

                if (phase.phaseEnum == Phase.PhaseEnum.word5)
                {
                    EnemyFirstBet();
                }
                else
                {
                    EnemyAfterBet();
                }

                talkActionSprite = Resources.Load<Sprite>("Images/Bar/" + enemyTalkStr);
                enemyTalkAction.enabled = false;

                //表示処理
                StartCoroutine(AnimetionCor(0.2f));

                //削除処理
                StartCoroutine(AnimetionCor(2));
            }
            

            if (foldBool == false)
            {
                phase.fieldBet = fieldBet;
                phase.enemyBet = enemyBet;
                phase.enemyMoney = enemyMoney;
                EnemyMoneyTextChange(enemyMoney);
                EnemyBetTextChange(enemyBet);
                phase.PlayerBet();
            }
            foldBool = false;
        }

        public void EnemyMoneyTextChange(int enemyMoney)
        {
            string moneySubStr = enemyMoney.ToString().Substring(0, 1);
            string moneySubStr2 = "";

            if (enemyMoney >= 10)
            {
                moneySubStr2 = enemyMoney.ToString().Substring(1, 1);

                var textTemp2 = Resources.Load<Sprite>("Images/Bar/t_" + moneySubStr2);
                enemyMoneyText2.GetComponent<SpriteRenderer>().sprite = textTemp2;
                enemyMoneyText.transform.localPosition = new Vector3(-6.3f, 0.72f, -1f);
            }
            else
            {
                enemyMoneyText.transform.localPosition = new Vector3(-6.15f, 0.72f, -1f);
                enemyMoneyText2.GetComponent<SpriteRenderer>().sprite = null;
            }

            var textTemp = Resources.Load<Sprite>("Images/Bar/t_" + moneySubStr);
            enemyMoneyText.GetComponent<SpriteRenderer>().sprite = textTemp;
        }

        public void EnemyBetTextChange(int enemyBet)
        {
            string betSubStr = enemyBet.ToString().Substring(0, 1); ;
            string betSubStr2 = "";

            if (enemyBet >= 10)
            {
                betSubStr2 = enemyBet.ToString().Substring(1, 1);

                var textTemp2 = Resources.Load<Sprite>("Images/Bar/t_" + betSubStr2);
                enemyBetText2.GetComponent<SpriteRenderer>().sprite = textTemp2;
                enemyBetText.transform.localPosition = new Vector3(-6.3f, 1.45f, -1f);
            }
            else
            {
                enemyBetText2.GetComponent<SpriteRenderer>().sprite = null;
                enemyBetText.transform.localPosition = new Vector3(-6.15f, 1.45f, -1f);
            }

            var textTemp = Resources.Load<Sprite>("Images/Bar/t_" + betSubStr);
            enemyBetText.GetComponent<SpriteRenderer>().sprite = textTemp;
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
                strongBool = true;
                if (raiseCount <= 1 || tenRandom <= 3)
                {
                    EnemyRaise();
                }
                else
                {
                    EnemyContinuation();
                }

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

            int moneyTemp = enemyMoney - fieldBet - 2;

            handPower = handRank.EnemyHandCheck();
            Debug.Log("enemyRank : " + handPower);

            int tenRandom = Random.Range(1, 10);

            if (strongBool == true || handPower >= 2)
            {
                if (tenRandom >= 3 && moneyTemp >= 0)
                {
                    EnemyRaise();
                }
                else
                {
                    EnemyContinuation();
                }
            }
            else if(attackRaiseBool == true || bigRaiseBool == true || handPower == 1
                || fieldBet == enemyBet)
            {
                
                if (tenRandom == 1 && raiseCount != 1 && moneyTemp >= 0)
                {
                    EnemyRaise();
                }
                else if (raiseCount != 1 && bigRaiseBool == false && moneyTemp >= 0)
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
                if (tenRandom <= 4 || enemyBet == fieldBet)
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
                enemyMoney -= fieldBet - enemyBet;
                enemyBet = fieldBet;
                enemyTalkAction.enabled = true;
                enemyTalkStr = "talk1";
            }
            else
            {
                talkTemp = "チェック";
            }
        }

        /// <summary>
        /// レイズの処理
        /// </summary>
        void EnemyRaise()
        {
            if (fieldBet >= 9 || phase.playerMoney <= 1)
            {
                EnemyContinuation();
            }
            else
            {
                raiseCount++;

                fieldBet = fieldBet + 2;
                enemyMoney -= fieldBet - enemyBet;
                enemyBet = fieldBet;

                talkTemp = "倍賭け";
            }
        }

        void EnemyFold()
        {
            if (raiseCount >= 1 || enemyMoney <= 5 || (fieldBet >= 5 && enemyMoney >= 3))
            {
                EnemyContinuation();
            }
            else
            {
                foldBool = true;
                enemyTalkAction.enabled = true;
                enemyTalkStr = "talk3";
                phase.Win(0);
            }
        }
    }
}