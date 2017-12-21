using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{
    public class GameController : MonoBehaviour
    {

        int[] cards = new int[52];
        void Start()
        {
            MakeDeck();
            Dealcards();
        }
        private void Update()
        {

        }

        /// <summary>
        /// 山札をシャッフルで作る
        /// </summary>
        private void MakeDeck()
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = i + 1;
            }
            System.Random rng = new System.Random();
            int n = cards.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int tmp = cards[k];
                cards[k] = cards[n];
                cards[n] = tmp;

                //Debug.Log(cards[n]);
            }
        }
        /// <summary>
        /// カードを２枚ずつ配る
        /// </summary>
        private void Dealcards()
        {
            for(int i = 0; i < 2; i++)
            {
                Debug.Log(cards[i]);
            }
        }
        /// <summary>
        /// カードを表示する
        /// </summary>
        private void LoadCard(int x, int y)
        {




        }
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
