using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Bar05
{
    public class HandRank : MonoBehaviour
    {
        public Phase phase;

        public int[] suitCount = new int[4];
        public int[] numberCount = new int[13];
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
        public RankCheck handRank;

        private int playerPoint;
        private int enemyPoint;
        private int playerCount;
        private int enemyCount;
        private string playerSuitCount;
        private string enemySuitCount;

        // Use this for initialization
        void Start()
        {
            playerList = phase.handCard;

            enemyList = phase.enemyHand;

            boardList = phase.boardList;

            for (int i = 0; i < playerList.Count; i++)
            {
                string strTemp = playerList[i].GetComponent<Card>().cardStrPath;
                hand.Add(strTemp);
            }
            hand.AddRange(board);

            for (int i = 0; i < enemyList.Count; i++)
            {
                string strTemp = enemyList[i].GetComponent<Card>().cardStrPath;
                enemy.Add(strTemp);
            }
            enemy.AddRange(board);
            for (int i = 0; i < boardList.Count; i++)
            {
                string strTemp = boardList[i].GetComponent<Card>().cardStrPath;
                board.Add(strTemp);
            }
            hand.AddRange(board);
            enemy.AddRange(board);
            //SuitCheck(hand);
            //SuitCheck(enemy);

            //デバッグ用
            List<string> debugRoyalStrightFlushList = new List<string>() { "c10", "c11", "c12", "c13", "c01", "s02", "s03" };
            List<string> debugStraightFlushList = new List<string>() { "s02", "s03", "s04", "s05", "s06", "h03", "d03" };
            List<string> debugStraightList = new List<string>() { "c10", "d10", "s05", "h04", "s01", "s02", "s03" };
            List<string> debugFlushList = new List<string>() { "c10", "d10", "s10", "s07", "s01", "s02", "s03" };
            List<string>debugFourList = new List<string>() { "c10","d10","s10","h10","s01","s02","s03"};
            List<string> debugFullList = new List<string>() { "c10", "d10", "s10", "h01", "s01", "s02", "s03" };
            List<string> debugThreeList = new List<string>() { "c10", "d10", "s10", "h04", "s01", "s02", "s03" };
            List<string> debugTwoList = new List<string>() { "c10", "d10", "s09", "h01", "s01", "s02", "s03" };
            List<string> debugOneList = new List<string>() { "c10", "d04", "s09", "h01", "s01", "s02", "s03" };
            List<string> debugNoList = new List<string>() { "c10", "d04", "s09", "h08", "s01", "s02", "s03" };
            
            handRank = HandCheck(debugStraightFlushList);
        }

        public RankCheck HandCheck(List<string> cards)
        {
            numberCount = new int[15];
            int pairCount = 0;
            int threeCount = 0;
            int fourCount = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                string numberStr = cards[i].Substring(1, 2);
                int numberTemp = int.Parse(numberStr);
                numberCount[numberTemp]++;
            }
            numberCount[14] = numberCount[1];

            for (int i = 1; i <= numberCount.Length - 2; i++)
            {
                for (int j = 2; j <= 4; j++)
                {
                    if (numberCount[i] == 2)
                    {
                        pairCount++;
                    }
                    if (numberCount[i] == 3)
                    {
                        threeCount++;
                    }
                    if (numberCount[i] == 4)
                    {
                        fourCount++;
                    }
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
                if (suitCount[i] >= 5)
                {
                    flush = true;
                }
            }

            bool royalStraightFlush = false;
            
            if (numberCount[1] >= 1 && numberCount[10] >= 1 && numberCount[11] >= 1 && numberCount[12] >= 1 && numberCount[13] >= 1)
            {
                royalStraightFlush = true;
            }
            
            bool straight = false;
            
            for(int i = 1; i < 11; i++)
            {
                if (numberCount[i] >= 1 && numberCount[i + 1] >= 1 && numberCount[i + 2] >= 1 && numberCount[i + 3] >= 1 && numberCount[i + 4] >= 1)
                {
                    straight = true;
                }
            }

            if (flush && royalStraightFlush) return RankCheck.RoyalStraightFlush;
            else if (straight && flush) return RankCheck.StraightFlush;
            else if (fourCount >= 1) return RankCheck.FourOfAKind;
            else if (threeCount >= 1 && pairCount >= 1) return RankCheck.FullHouse;
            else if (flush) return RankCheck.Flush;
            else if (straight) return RankCheck.Straight;
            else if (threeCount >= 1) return RankCheck.ThreeOfAKind;
            else if (pairCount >= 2) return RankCheck.TwoPair;
            else if (pairCount >= 1) return RankCheck.OnePair;

            return RankCheck.NoPair;
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
