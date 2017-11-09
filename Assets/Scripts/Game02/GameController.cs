using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Game02
{
    public class GameController : MonoBehaviour
    {
        private int m_score = 0;

        [SerializeField]
        GameObject[] m_enemys;




        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
