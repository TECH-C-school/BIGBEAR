using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }

        private void card()
        {
            int number = 0;
            string number2 = "";
            string[] mark = new string[] { "h", "d", "s", "c"};
            for (int i = 0; i <= 52; i++)
            {
                if (i >= 51)
                {
                    number2 = "";
                } else
                {
                    number = i % 13;
                    number2 = number.ToString();
                }

                Debug.Log(mark[i / 13] + number2);
            }
        }
    }
}
