using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        private void MakeCard()
        {
           
        }
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
