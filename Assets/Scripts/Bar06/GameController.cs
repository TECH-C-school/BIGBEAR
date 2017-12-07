using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {


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
            var counter = 0;
            while (counter <= 3)
            {
                int number = Random.Range(1, 14);
                int markValue = Random.Range(0, 4);
                Mark mark = (Mark)markValue;
                string str = mark.ToString();
                Debug.Log(str + number);
                counter++;
            }

            //カードを表示させる
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            for (int i = 0; i <= 1; i++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(0 - i, -2.5f, 0);
            }
            
        }

        public void AddCard()
        {
            Debug.Log("AddCard");
        }

        public void Battle()
        {
            Debug.Log("Battle");
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }    
    }
}
