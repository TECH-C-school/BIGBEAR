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

        }
        private void Update()
        {

        }

        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
