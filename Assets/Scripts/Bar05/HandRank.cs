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
        public List<GameObject> playerList;
        public List<GameObject> enemyList;
        public List<GameObject> boardList;
        public List<string> handList;

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

        public RankCheck rankCheck;

        private int number;
        private int playerPoint;
        private int enemyPoint;
        private int playerCount;
        private int enemyCount;
        private string playerSuitCount;
        private string enemySuitCount;

        [SerializeField]
        private int[] handArray;
        [SerializeField]
        private int[] enemyArray;
        private int[] boardArray;
        private int[] suitArray;

        private void Start()
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

            enemyArray = new int[2];

            for (int i = 0; i < enemyList.Count; i++)
            {
                string strTemp = enemyList[i].GetComponent<Card>().cardStrPath;
                enemy.Add(strTemp);
                enemyArray[i] = enemyList[i].GetComponent<Card>().number;
            }
        }

        public void BoardReady()
        {
            board = new List<string>();
            boardArray = new int[15];
            suitArray = new int[4];

            for (int i = 0; i < boardList.Count; i++)
            {
                string strTemp = boardList[i].GetComponent<Card>().cardStrPath;
                board.Add(strTemp);
                int number = int.Parse(strTemp.Substring(1, 2));
                boardArray[number]++;

                string enumTemp = strTemp.Substring(0, 1);

                switch (enumTemp)
                {
                    case "s":
                        suitArray[0]++;
                        break;
                    case "c":
                        suitArray[1]++;
                        break;
                    case "h":
                        suitArray[2]++;
                        break;
                    case "d":
                        suitArray[3]++;
                        break;
                }
                
            }
        }

        public int EnemyHandCheck()
        {
            return HandCheck(enemy);
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

            for (int i = 2; i <= numberCount.Length - 1; i++)
            {
                if (numberCount[i] == 2)
                {
                    pairCount++;
                    //switch (pairCount)
                    //{
                    //    case 1:
                    //        selPairTemp = i;
                    //        break;
                    //    case 2:
                    //        selPairTemp2 = i;
                    //        break;
                    //    case 3:
                    //        selPairTemp = i;
                    //        break;
                    //}
                }
                if (numberCount[i] == 3)
                {
                    threeCount++;
                    //selThreeTemp = i;
                    //if (threeCount == 2)
                    //{
                    //    selThreeTemp = i;
                    //}
                }
                if (numberCount[i] == 4)
                {
                    fourCount++;
                    //selFourTemp = i;
                }
            }

            //Flushの判定
            suitCount = suitArray;
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

            for (int i = 1; i < 11; i++)
            {
                if (numberCount[i] >= 1 && numberCount[i + 1] >= 1 && numberCount[i + 2] >= 1 && 
                    numberCount[i + 3] >= 1 && numberCount[i + 4] >= 1)
                    straight = true;
            }

            if (flush && royalStraightFlush)
            {
                rankCheck = RankCheck.RoyalStraightFlush;
                return 9;
            }
            else if (straight && flush)
            {
                rankCheck = RankCheck.StraightFlush;
                return 8;
            }
            else if (fourCount >= 1)
            {
                rankCheck = RankCheck.FourOfAKind;
                return 7;
            }
            else if (threeCount >= 1 && pairCount >= 1)
            {
                rankCheck = RankCheck.FullHouse;
                return 6;
            }
            else if (flush)
            {
                rankCheck = RankCheck.Flush;
                return 5;
            }
            else if (straight)
            {
                rankCheck = RankCheck.Straight;
                return 4;
            }
            else if (threeCount >= 1)
            {
                rankCheck = RankCheck.ThreeOfAKind;
                return 3;
            }
            else if (pairCount >= 2)
            {
                rankCheck = RankCheck.TwoPair;
                return 2;
            }
            else if (pairCount >= 1)
            {
                rankCheck = RankCheck.OnePair;
                return 1;
            }
            return 0;
        }

        public int WinnerCheck()
        {
            handList = board;
            handList.AddRange(enemy);
            BoardReady();
            handRank = HandCheck(hand);
            phase.playerTextTemp = rankCheck.ToString(); 
            BoardReady();
            enemyRank = HandCheck(enemy);
            phase.enemyTextTemp = rankCheck.ToString();

            if (handRank > enemyRank) return 0;
            else if (handRank < enemyRank) return 1;

            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (handArray[i] == 1) handArray[i] = 14;
                    if (enemyArray[i] == 1) enemyArray[i] = 14;
                }

                int handMax = Mathf.Max(handArray[0], handArray[1]);
                int enemyMax = Mathf.Max(enemyArray[0], enemyArray[1]);

                if (handMax > enemyMax)return 0;
                else if (enemyMax > handMax) return 1;
                else if (handMax == enemyMax)
                {
                    int handMin = Mathf.Min(handArray[0], handArray[1]);
                    int enemyMin = Mathf.Min(enemyArray[0], enemyArray[1]);

                    if (handMin > enemyMin)return 0;
                    else if (enemyMin > handMin)return 1;
                }  
            }
            return -1;
        }

        public void PhaseEnd()
        {
            hand.Clear();
            enemy.Clear();
            board.Clear();
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
