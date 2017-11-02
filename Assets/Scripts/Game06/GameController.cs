using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game06 {
    public class GameController : MonoBehaviour {

		public enum DIFFICULTY
		{
			AMATEUR = 0,
			PROFESSIONAL,
			LEGEND
		}

		public DIFFICULTY Difficulty; 

		public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
