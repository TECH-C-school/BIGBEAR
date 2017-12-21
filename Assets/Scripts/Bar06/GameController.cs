using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{
    public class GameController : MonoBehaviour
    {
        void Start()
        {
            MakeDeck();
        }
        private void Update()
        {

        }

        private void MakeDeck()
        {
            int[] cards = new int[52];
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

                Debug.Log(cards[n]);
            }
        }
            
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
