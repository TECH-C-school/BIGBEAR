using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {

        public enum Mark
        {
            Clover,
            Diamond,
            Heart,
            Spade,
        }

        public struct Cards
        {
            public int number;
            public Mark mark;
        }

        //カード生成
        public void Start()
        {
            Cards card1_1 = new Cards();
            Cards card1_2 = new Cards();
            Cards card2_1 = new Cards();
            Cards card2_2 = new Cards();

            var counter = 0;
            while (counter <= 3)
            {
                int number = Random.Range(1, 14);
                int markV = Random.Range(0, 4);
                Mark mark = (Mark)markV;
                string str = mark.ToString();
                Debug.Log(str + number);
            }
        }
        public void MakeCards()
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            for(int y = 0; y < 2; y++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(-1f + y, -2.5f);
            }
        }
        //乱数作成
        /* private int[] MakeRandomNumbers()
         {
             int[] numbers = new int[51];
             for (int i = 0; i <= 51; i++)
             {
                 numbers[i] = i + 1;
             }
             var counter = 0;
             while (counter < 51)
             {
                 var index = Random.Range(counter, numbers.Length);
                 var tmp = numbers[counter];
                 numbers[counter] = numbers[index];
                 numbers[index] = tmp;

                 counter++;

                 var a = index % 13 +1;
                 Debug.Log(Mark[a]+(a+1));
             }
             return numbers;
         }
         //ボタン
         public void ClickDrowButton()
         {
             var cardsObject = GameObject.Find("Cards").transform;
             foreach (Transform cardObject in cardsObject)
             {
                 var card = cardsObject.GetComponent<MakeCards>();

             }
         }*/
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
