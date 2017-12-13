using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar05
{
    public class HandRank : MonoBehaviour
    {
        public Phase phase;

        public List<GameObject> hand;
        public List<GameObject> enemy;
        public List<GameObject> playerBoard;
        public List<GameObject> enemyBoard;

        // Use this for initialization
        void Start()
        {
            hand = phase.handCard;
            playerBoard = phase.boardList;
            playerBoard.AddRange(hand);
            playerBoard.Sort();
            enemy = phase.enemyHand;
            enemyBoard = phase.boardList;
            enemyBoard.AddRange(enemy);
            enemyBoard.Sort();
            int[] check = new int[7];
            check[0] = enemy[0].GetComponent<Card>().number;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void RankCheck()
        {
            
        }
    }
}
