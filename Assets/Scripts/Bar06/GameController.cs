using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//namespace Assets.Scripts.Bar06 {
  /*  public class GameController : MonoBehaviour {
      private void MakeCard()
        {
            int count = 0;
            int[] randomNumbers = MakeRandomNumbers();
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
            var cardsObject = GameObject.Find("Cards");

            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector3(
                        i * 1.27f - 3.87f,
                        j * 1.27f - 2.54f,
                        0);
                    cardObject.transform.parent = cardsObject.transform;

                    var card = cardObject.GetComponent<Card>();
                    card.Number = randomNumbers[count];
                    card.TurnCardFaceDown();
                    count++;
                   
                }
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



            //オブジェクトを生産
            /*Instantiate(c01, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13,
                d01, d02, d03, d04, d05, d06, d07, d08, d09, d10, d11, d12, d13, 
                h01, h02, h03, h04, h05, h06, h07, h08, h09, h10, h11, h12, h13, 
                s01, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13);
            
        }






        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }

    }
}*/
