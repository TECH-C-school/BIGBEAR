using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        private int positioncounter = 1;
        private int playercounter = 0;
        private int enemycounter = 0;

        public enum Mark
        {
            Clover,
            Spade,
            Heart,
            Diamond
        }

        public struct Card
        {
            public int number;
            public Mark mark;
        }

        public void Start()
        {
            //カードを2, 2枚表示する
            Card card1_1 = new Card();
            Card card1_2 = new Card();
            Card card2_1 = new Card();
            Card card2_2 = new Card();

            //ランダムでカードを決める
            card1_1.number = Random.Range(1, 14);
            card1_1.mark = (Mark)Random.Range(0, 3);
            card1_2.number = Random.Range(1, 14);
            card1_2.mark = (Mark)Random.Range(0, 3);
            card2_1.number = Random.Range(1, 14);
            card2_1.mark = (Mark)Random.Range(0, 3);
            card2_2.number = Random.Range(1, 14);
            card2_2.mark = (Mark)Random.Range(0, 3);


            playercounter = card1_1.number + card1_2.number;
            enemycounter = card2_1.number + card2_2.number;

            while (enemycounter <= 18)
            {
                var enemyCard = Random.Range(1, 14);
                enemycounter = enemycounter + enemyCard;
            }

            //カードを表示させる
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");

            for (int i = 0; i <= 1; i++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(0 - i, -2.5f, 0);
            }

            for (int i = 0; i <= 1; i++)
            {
                var cardObject2 = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject2.transform.position = new Vector3(0 - i, 2.5f, 0);
            }

        }

        public void AddCard()
        {
            if(playercounter <= 21)
            {
                var test = 1;
                var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/c0" + test);
                var addCardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                addCardObject.transform.position = new Vector3(positioncounter, -2.5f, 0);
                addCardObject.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
                positioncounter++;
                var playerCard = Random.Range(1, 14);
                playercounter = playercounter + playerCard;
                Debug.Log(playercounter);
            }
            
        }
        
        public void Battle()
        {
            Debug.Log(enemycounter);
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }    
    }
}
