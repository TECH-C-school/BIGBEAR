using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar03 {
    public class GameController : MonoBehaviour {
        public static bool frag = false;
        public static bool frag2 = false;

        void Start()
        {

        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}