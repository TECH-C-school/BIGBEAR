using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game01
{
    public class GameController : MonoBehaviour
    {
        public void TransitionToResult()
        {
            PlayerPrefs.DeleteKey("round");
            SceneManager.LoadScene("Result");
        }
    }
}
