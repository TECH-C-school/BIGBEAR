using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        public void TransitionToResult() {
            Sprite[] image = Resources.LoadAll<Sprite>("Images/Bar/Cards/");

            SceneManager.LoadScene("Result");
        }
    }
}
