using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Game02
{
    public enum Wind
    {
        East,
        West,
        North,
        South,
    }

    public enum Diff
    {
        Easy,
        Normal,
        Hard
    }

    public enum Speed
    {
        None = 0,
        Low = 1,
        Mid = 2,
        High = 4
    }
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
