﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game02 {
    public class GameController : MonoBehaviour {
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
