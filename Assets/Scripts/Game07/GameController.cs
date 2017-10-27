using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game07 {
    public class GameController : MonoBehaviour {
        //シングルトン化
        public static GameController instance;
        //ゲーム状態 goto マウスクリックするまではReady状態　クリックしたらPlay状態
        public enum GameState { Ready, Play, Result }
        public static GameState gameState = GameState.Ready;
        //ゲーム難易度
        public enum GameLevel { Easy = 1, Normal = 3, Hard = 5 }
        public static GameLevel gameLevel = GameLevel.Easy;
        //スコア関係
        const int plus_score = 1;
        const int minus_score = 10;
        public static int m_score = 0;

        //シングルトン化処理
        void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else { Destroy(gameObject); }
        }

        void Update()
        {
            //ゲーム遷移
            switch (gameState)
            {
                case GameState.Ready:
                    break;
                case GameState.Play:
                    break;
                case GameState.Result:
                    break;
            }
        }

        public int RemoveScore() { return m_score -= minus_score; }

        public int AddScore() { return m_score += plus_score; }

        public int GetScore(){
            if (m_score <= 0) { m_score = 0; }
            return m_score;
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
