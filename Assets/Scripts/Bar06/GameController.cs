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
            int a = 0;
            string[] mark = new string[] {"Spade", "Heart", "Clover","Dia" };
            for (int i = 0; i < 51; i++)
            {
                a = i % 13 + 1;

                Debug.Log(mark[i / 13] + a);
            }
        }
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
