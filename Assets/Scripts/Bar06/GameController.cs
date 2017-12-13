using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {


    public class Cards : MonoBehaviour
    {

        // Use this for initialization
        void Start() {

        }

        private void MakeCards()
        {
            int count = 0;

            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/PlayerCardbk");
            var cardsObject = GameObject.Find("PlayerCardbk");

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector3(
                        i * 2f,
                        j * 5f,
                        0);

                    cardObject.transform.parent = cardsObject.transform;

                    var card = cardObject.GetComponent<Cards>();
                    count++;
                }
            }
        }






        private int[] MakeRandomNumbers()
        {
            int[] numbers = new int[52];

            for (int i = 0; i < numbers.Length; i++)
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
    }
    public enum mark
    {
        S = 0,
        C = 1,
        H = 2,
        D = 3
    }



    public class GameController : MonoBehaviour {
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
