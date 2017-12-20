using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour {

        public GameObject Startbutton;

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
        public void GameStart(){
            Debug.Log("ゲームスタート");
            Startbutton.SetActive(false);
        }
        //カード生成
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

                }
            }
        }

        //52枚をランダムにする
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
        //手役
        public enum PokerHand
        {
            RoyalStraightFlush,
            StraightFlush,
            FourOfAKind,
            FullHouse,
            Flush,
            Straight,
            ThreeOfAkind,
            TwoPair,
            onepair,
            Nopair,
        }
       /* public　PokerHand Judge(List<int> cards)
        {
            if (cards.Count() < 2) return PokerHand.Nopair;
        }*/
    }
}
