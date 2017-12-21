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
            List<string>debugFourList = new List<string>() { "c10","d10","s10","h10","s01","s02","s03"};
            List<string> debugFullList = new List<string>() { "c10", "d10", "s10", "h01", "s01", "s02", "s03" };
            List<string> debugThreeList = new List<string>() { "c10", "d10", "s10", "h04", "s01", "s02", "s03" };
            List<string> debugTwoList = new List<string>() { "c10", "d10", "s09", "h01", "s01", "s02", "s03" };

            SuitCheck(debugThreeList);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public RankCheck SuitCheck(List<string> cards)
        {
            numberCount = new int[14];
            int pairCount = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                string numberStr = cards[i].Substring(1, 2);
                int numberTemp = int.Parse(numberStr);
                numberCount[numberTemp]++;
            }
            for (int i = 1; i <= numberCount.Length - 1; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    if (numberCount[i] >= j)
                    {
                        pairCount++;
                    }
                    if (numberCount[i] == j + 2)
                    {
                        pairCount++;
                    }
                    if (numberCount[i] == j + 3)
                    {
                        pairCount++;
                    }
                }
            }
            Debug.Log(pairCount);
            switch (pairCount)
            {
                case 4: return RankCheck.FourOfAKind;
                case 5: return RankCheck.FullHouse;
                case 3: return RankCheck.ThreeOfAKind;
                case 2: return RankCheck.TwoPair;
                case 1: return RankCheck.OnePair;
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
                if (suitCount[i] <= 5)
                {
                    flush = true;
                }
            }
            bool straight = false;
            bool FourOfAKind = false;
            bool FullHouse = false;
            bool ThreeOfAKind = false;
            bool TwoPair = false;
            bool OnePair = false;

            if (straight && flush) return RankCheck.RoyalStraightFlush;
            if (ThreeOfAKind && TwoPair) return RankCheck.FullHouse;
            if (straight) return RankCheck.Straight;
            if (flush) return RankCheck.Flush;

            return RankCheck.NoPair;
        }
    }
}

/*ストレート && フラッシュ = ロイヤルストレート
 * !スリカード == !FourCard
 * スリーカード && TwoPair == FullHouse
* 
* 
 
     */
