using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {

        public enum Mark
        {
            Spade,
            Heart,
            Diamonds,
            Club,
        }

        public enum Number
        {
            Ace,
            two,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine,
            ten,
            eleven,
            twelve,
            thirteen,
        }

        /// <summary>
        /// プレイヤーとディーラーにカードを2枚づつ生成
        /// </summary>
        private void MakeCard()
        {
            int[] randomNumbers = MakeRandomNumbers();
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/back");
            
            for (var i = 0; i < 2; i++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(i * 1.27f - 2.54f, 0);
     

            }
        }
        private int[] MakeRandomNumbers()
        {
            int[] numbers = new int[52];
            for (var i = 0; i < 52; i++)
            {
                numbers[i] = i + 1;
            }
            var counter = 0;
            while (counter < 52)
            {
                var index = Random.Range(counter, numbers.Length);
                var tmp = numbers[counter];
                numbers[counter] = numbers[index];
                numbers[index] = tmp;

                counter++;
            }
            return numbers;
        }


        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
