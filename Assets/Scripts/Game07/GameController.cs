using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game07
{
    public class GameController : MonoBehaviour, IStopObject
    {
        [SerializeField]
        int m_time = 60;

        [SerializeField]
        Text m_timeText;
        [SerializeField]
        Text m_scoreText;

        int m_score;        
        float m_elapsedTime = 0.0f;
        bool m_isGameFinish;

        private void Update()
        {
            if (m_isGameFinish) { return; }

            m_elapsedTime += Time.deltaTime;
            if(m_elapsedTime > 1.0f)
            {
                m_elapsedTime -= 1.0f;
                m_time--;
                m_timeText.text = m_time.ToString("00");
            }

            if (m_time == 0)
            {
                m_isGameFinish = true;
                TransitionToResult();
            }
        }

        public void AddScore(int score)
        {
            m_score += score;
            m_score = m_score < 0 ? 0 : m_score;
            m_scoreText.text = m_score.ToString("000");
        }

        public void SetStop(bool enabled)
        {

        }

        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
