using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar05
{
    public class HandRank : MonoBehaviour
    {
        public Phase phase;

        public List<string> hand;
        public List<string> enemy;
        public List<string> board;
        public List<string> playerBoard;
        public List<string> enemyBoard;
        public List<GameObject> playerList;
        public List<GameObject> enemyList;
        public List<GameObject> boardList;

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
            hand.Sort();
            enemy.AddRange(board);
            enemy.Sort();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void SuitCheck()
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                string strTemp = playerList[i].GetComponent<Card>().cardStrPath;
                var enumtemp = playerList[i].GetComponent<Card>().suit;
                switch (enumtemp)
                {
                    case Card.Suit.Club:
                        
                        break;
                    case Card.Suit.Diamond:

                        break;
                    case Card.Suit.Heart:

                        break;
                    case Card.Suit.Spade:

                        break;
                }
                hand.Add(strTemp);
            }
            for (int i = 0; i < enemyList.Count; i++)
            {
                string strTemp = enemyList[i].GetComponent<Card>().cardStrPath;
                var enumtemp = enemyList[i].GetComponent<Card>().suit;
                switch (enumtemp)
                {
                    case Card.Suit.Club:

                        break;
                    case Card.Suit.Diamond:

                        break;
                    case Card.Suit.Heart:

                        break;
                    case Card.Suit.Spade:

                        break;
                }
                enemy.Add(strTemp);
            }

            for (int i = 0; i < boardList.Count; i++)
            {
                string strTemp = boardList[i].GetComponent<Card>().cardStrPath;
                var enumtemp = boardList[i].GetComponent<Card>().suit;
                switch (enumtemp)
                {
                    case Card.Suit.Club:

                        break;
                    case Card.Suit.Diamond:

                        break;
                    case Card.Suit.Heart:

                        break;
                    case Card.Suit.Spade:

                        break;
                }
                board.Add(strTemp);
            }
        }

        /*void RankCheck()
        {

            //ロイヤルストレートフラッシュ
            if ()
            {

            }
            //ストレートフラッシュ
            if ()
            {

            }
            //ストレート
            if ()
            {

            }
            //フラッシュ
            if ()
            {

            }
            //フォーカード
            if ()
            {

            }
            //フルハウス
            if ()
            {

            }
            //スリーカード
            if ()
            {

            }
            //ツーペア
            if ()
            {

            }
            //ワンペア
            if ()
            {

            }
            //ハイカード
            if ()
            {

            }
        }*/
    }
}
