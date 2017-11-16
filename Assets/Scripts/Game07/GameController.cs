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
        //UI情報
        [SerializeField,Header("ゲームスタートボタン")]
        GameObject GameStartButton;
        [SerializeField, Header("ゲーム07フォント")]
        GameObject GameStartFont;

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

        void Start()
        {
            //ゲームの初期化
            Player.isMove = false;
            HeridController.IsTimeStart = false;
            TimeCount.isCount = false;
        }

        //void Update()
        //{
        //    switch (gameState)
        //    {
        //        case GameState.Ready:
        //            break;
        //        case GameState.Play:
        //            break;
        //        case GameState.Result:
        //            break;
        //    }
        //}

        /// <summary>
        /// スコア用関数
        /// </summary>
        /// <returns></returns>
        public int RemoveScore() { return m_score -= minus_score; }

        public int AddScore() { return m_score += plus_score; }

        public int GetScore(){
            if (m_score <= 0) { m_score = 0; }
            return m_score;
        }

        public void Ready()
        {
            //ゲームスタート処理
            gameState = GameState.Play;
            Player.isMove = true;
            HeridController.IsTimeStart = true;
            TimeCount.isCount = true;
            GameStartButton.SetActive(false);
            GameStartFont.SetActive(false);
        }

        public void GamePlay()
        {
            gameState = GameState.Result;
            //ここで難易度設定(各クラスに値を渡す)
        }

        public void Result()
        {
            //ヘリと物資を削除
            CatchObject[] catchObj = FindObjectsOfType<CatchObject>();
            foreach (var s_catchObj in catchObj)
            {
                Destroy(s_catchObj.gameObject);
            }
            Herid[] heridS = FindObjectsOfType<Herid>();
            foreach (var herid in heridS)
            {
                Destroy(herid.gameObject);
            }
            //プレイヤーとヘリ生成を終了
            Player.isMove = false;
            HeridController.IsTimeStart = false;
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
