using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{


    public class GameController : MonoBehaviour
    {

        public void PlayerMakeCards()
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/PlayerCardbk");
            var cardsObject = GameObject.Find("PlayerCard");

            for (int i = 0; i < 2; i++)
            {
                    var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector3(
                        i * -2f,
                        -0.8f,
                        0);

                    cardObject.transform.parent = cardObject.transform;

                    var card = cardObject.GetComponent<Cards>();
            }
        }
        /*public void NPCMakeCards()
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/NPCardbk");
            var cardsObject = GameObject.Find("NPCCardbk");

            for (int j = 0; j < 2; j++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(
                    j * 2f,
                    3f,
                    0);

                cardObject.transform.parent = cardObject.transform;

                var card = cardObject.GetComponent<Cards>();

            }
        }*/

        struct trump
        {
            public string mark;
            public int Number;
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
                Debug.Log(counter);
            }
            return numbers;
        }

        private void Start()
        {
            PlayerMakeCards();
            MakeRandomNumbers();
            //NPCMakeCards();
        }

        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
