using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Bar05
{
    public class HandRank : MonoBehaviour
    {
        [SerializeField]
        private Phase phase;

        public int[] suitCount = new int[4];
        public int[] numberCount;
        public List<string> hand;
        public List<string> enemy;
        public List<string> board;
        public List<string> playerBoard;
        public List<string> enemyBoard;
        public List<GameObject> playerList;
        public List<GameObject> enemyList;
        public List<GameObject> boardList;

        public enum RankCheck
        {
            RoyalStraightFlush,
            StraightFlush,
            FourOfAKind,
            FullHouse,
            Flush,
            Straight,
            ThreeOfAKind,
            TwoPair,
            OnePair,
            NoPair,
        }
        public int handRank;
        public int enemyRank;


        private int number;
        private int playerPoint;
        private int enemyPoint;
        private int playerCount;
        private int enemyCount;
        private string playerSuitCount;
        private string enemySuitCount;

        [SerializeField]
        private int[] handArray;
        private int[] enemyArray;
        private int[] boardArray;

        private void Awake()
        {
            phase = gameObject.GetComponent<Phase>();
        }

        // Use this for initialization
        public void CheckReady()
        {
            playerList = phase.handCard;
            enemyList = phase.enemyHand;
            boardList = phase.boardList;

            handArray = new int[2];

            for (int i = 0; i < playerList.Count; i++)
            {
                string strTemp = playerList[i].GetComponent<Card>().cardStrPath;
                hand.Add(strTemp);
                handArray[i] = playerList[i].GetComponent<Card>().number;
            }


            for (int i = 0; i < enemyList.Count; i++)
            {
                string strTemp = enemyList[i].GetComponent<Card>().cardStrPath;
                enemy.Add(strTemp);
            }
        }

        public void BoardReady()
        {
            boardArray = new int[15];
            for (int i = 0; i < boardList.Count; i++)
            {
                string strTemp = boardList[i].GetComponent<Card>().cardStrPath;
                board.Add(strTemp);
                int number = int.Parse(strTemp.Substring(1, 2));
                boardArray[number]++;
            }
        }

        void PlayerHandCheck()
        {
            handRank = HandCheck(hand);
        }

        public int EnemyHandCheck()
        {
            return enemyRank = HandCheck(enemy);
        }

        public int HandCheck(List<string> cards)
        {
            numberCount = boardArray;
            int pairCount = 0;
            int threeCount = 0;
            int fourCount = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                int number = int.Parse(cards[i].Substring(1, 2));
                numberCount[number]++;
            }
            numberCount[14] = numberCount[1];

            for (int i = 1; i <= numberCount.Length - 2; i++)
            {
                for (int j = 2; j <= 4; j++)
                {
                    if (numberCount[i] == 2) pairCount++;
                    if (numberCount[i] == 3) threeCount++;
                    if (numberCount[i] == 4)fourCount++;
                }
            }

            //Flushの判定
            suitCount = new int[4];
            for (int i = 0; i < cards.Count; i++)
            {
                var enumTemp = cards[i].Substring(0, 1);
                switch (enumTemp)
                {
                    case "s":
                        suitCount[0]++;
                        break;
                    case "c":
                        suitCount[1]++;
                        break;
                    case "h":
                        suitCount[2]++;
                        break;
                    case "d":
                        suitCount[3]++;
                        break;
                }
            }
            Debug.Log("player:" + suitCount[0] + "," + suitCount[1] + "," + suitCount[2] + "," + suitCount[3]);
            bool flush = false;
            //配列の数値が5以上ならフラッシュ
            for (int i = 0; i < suitCount.Length; i++)
            {
                if (suitCount[i] >= 5) flush = true;
            }

            bool royalStraightFlush = false;
            
            if (numberCount[1] >= 1 && numberCount[10] >= 1 && numberCount[11] >= 1 &&
                numberCount[12] >= 1 && numberCount[13] >= 1)
                royalStraightFlush = true;
            
            bool straight = false;
            
            for(int i = 1; i < 11; i++)
            {
                if (numberCount[i] >= 1 && numberCount[i + 1] >= 1 && numberCount[i + 2] >= 1 && 
                    numberCount[i + 3] >= 1 && numberCount[i + 4] >= 1)
                    straight = true;
            }

            if (flush && royalStraightFlush) return 9;
            else if (straight && flush) return 8;
            else if (fourCount >= 1) return 7;
            else if (threeCount >= 1 && pairCount >= 1) return 6;
            else if (flush) return 5;
            else if (straight) return 4;
            else if (threeCount >= 1) return 3;
            else if (pairCount >= 2) return 2;
            else if (pairCount >= 1) return 1;

            return 0;
        }

        public int WinnerCheck()
        {
            handRank = HandCheck(hand);
            enemyRank = HandCheck(enemy);

            if (handRank < enemyRank) return 0;
            else if (handRank > enemyRank) return 1;

            if (handRank == enemyRank)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (handArray[i] == 1) handArray[i] = 14;
                    if (enemyArray[i] == 1) enemyArray[i] = 14;
                }

                int handMax = Mathf.Max(enemyArray[0], enemyArray[1]);
                int enemyMax = Mathf.Max(handArray[0], handArray[1]);

                if (handMax > enemyMax)return 0;
                else if (enemyMax > handMax) return 1;
                else if (handMax == enemyMax)
                {
                    int handMin = Mathf.Min(handArray[0], handArray[1]);
                    int enemyMin = Mathf.Min(handArray[0], handArray[1]);

                    if (handMin > enemyMin)return 0;
                    else if (enemyMin > handMin)return 1;
                }  
            }
            return -1;
        }
    }
}

/*
* 1,2,3,4,5
* 2,3,4,5,6
* 3,4,5,6,7
* 4,5,6,7,8
* 5,6,7,8,9
* 6,7,8,9,10
* 7,8,9,10,11
* 8,9,10,11,12
* 9,10,11,12,13
* 10,11,12,13,14
*/
