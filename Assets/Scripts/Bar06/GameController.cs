using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{
    public class GameController : MonoBehaviour
    {

        public enum Suits
        {
            CLUB, DIAMOND, HEART, SPADE, 
        }
        public enum Cards
        {
            one = 1, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen,
        } 
        //カードを生成する
        private void MakeCard()
        {
            int count = 0;
            int[] randomNumbers = MakeRandomNumbers();
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06");
            var cardsObject = GameObject.Find("Card");

            for (var i = 0; i < 2; i++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(i * 0f - 1f,0);
                cardObject.transform.parent = cardObject.transform;
            }
        }
        private int[] MakeRandomNumbers()
        {
            int[] num = new int[51];
            for (var i = 0; i < 51; i++)
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
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
