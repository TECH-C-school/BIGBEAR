using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {


        private void MakeCard()
        {
            int count = 0;
            int[] randomNumbers = MakeRandomNumbers();
            var Prefab = Resources.Load<GameObject>("Prefabs/Bar06/back");
            var cardsObject = GameObject.Find("Card");

            for (var i = 0; i < 2; i++)
            {
                var cardObject = Instantiate(Prefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(i * 0f - 1f,0);
                cardObject.transform.parent = cardObject.transform;

                
            }
        }
        private int[] MakeRandomNumbers()
        {
            int[] num = new int[52];
            for (var i = 0; i < 52; i++)
            {
                num[i] = i + 1;
            }

            var counter = 0;
            while (counter < 52)
            {
                var index = Random.Range(counter, num.Length);
                var tmp = num[counter];
                num[counter] = num[index];
                num[index] = tmp;

                counter++;
            }
            return num;
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
