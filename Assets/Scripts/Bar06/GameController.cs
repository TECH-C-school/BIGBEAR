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

        public struct MakeCards
        {
            public int number;
            public Mark mark;
        }

        //カード生成
        public void Start()
        {
            MakeCards card1_1 = new MakeCards();
            MakeCards card1_2 = new MakeCards();
            MakeCards card2_1 = new MakeCards();
            MakeCards card2_2 = new MakeCards();
        }

        //乱数作成
        private int[] MakeRandomNumbers()
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
        }
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
