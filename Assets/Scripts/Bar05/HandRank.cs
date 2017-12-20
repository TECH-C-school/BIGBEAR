using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar05
{
    public class HandRank : MonoBehaviour
    {
        public Phase phase;

        public int[] suitCount = new int[4] { 0, 0, 0, 0 };
        public int[] enemyFlushCount = new int[4] { 0, 0, 0, 0 };
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
            suitCount = new int[4] { 0, 0, 0, 0 };
            enemyFlushCount = new int[4] { 0, 0, 0, 0 };
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
            SuitCheck(hand);
            SuitCheck(enemy);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public RankCheck SuitCheck(List<string> cards)
        {


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
            for (int i = 0; i < 4; i++)
            {
                if (suitCount[i] <= 4)
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
