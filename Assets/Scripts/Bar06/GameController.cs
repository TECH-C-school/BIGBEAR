using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{
    public class GameController : MonoBehaviour
    {

        //カードを生成する
        private void MakeCard()
        {
            int count = 0;
            int[] randomNumbers = MakeRandomNumbers();
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/back");
            var cardsObject = GameObject.Find("Cards");

            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector2(i * 1.27f - 3.87f, j * 1.27f - 2.54f);
                    cardObject.transform.parent = cardsObject.transform;

                }
            }
        }
        private int[] MakeRandomNumbers()
        {
            int[] numbers = new int[51];
            for (var i = 0; i < 51; i++)
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
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
