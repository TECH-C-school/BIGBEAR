﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game07
{
    public class GameController : MonoBehaviour {
        //シングルトン化
        public static GameController instance;
        //ゲーム状態 goto マウスクリックするまではReady状態　クリックしたらPlay状態
        public enum GameState { Ready, Play, Result }
        [HideInInspector]
        public GameState m_gameState = GameState.Ready;
        //ゲーム難易度
        public enum GameLevel { Easy = 1, Normal = 2, Hard = 3 }
        [HideInInspector]
        public GameLevel m_gameLevel = GameLevel.Easy;
        //スコア関係
        const int plus_score = 1;
        const int minus_score = 10;
        [HideInInspector]
        public int m_score = 0;
        //UI情報
        [SerializeField,Header("ゲームスタートボタン")]
        private GameObject GameStartButton;
        [SerializeField, Header("ゲーム07フォント")]
        private GameObject GameStartFont;
        [SerializeField, Header("難易度簡単ボタン")]
        private GameObject EasyButton;
        [SerializeField, Header("難易度普通ボタン")]
        private GameObject NormalButton;
        [SerializeField, Header("難易度難しいボタン")]
        private GameObject HardButton;
        [Header("Pauseボタン")]
        public GameObject PauseButton;
        [Header("Retryボタン")]
        public GameObject RetryButton;
        [Header("Continueボタン")]
        public GameObject ContinueButton;

        //シングルトン化処理
        void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else { Destroy(gameObject); }

            //ゲームの初期化
            Player.isMove = false;
            HeridController.instance.IsTimeStart = false;
            //TimeController.instance.isCount = false;
            PauseButton.SetActive(false);
            m_gameLevel = GameLevel.Easy;
            RetryButton.SetActive(false);
            ContinueButton.SetActive(false);
            m_score = 0;
        }
        
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

        public void GameSelect()
        {
            //難易度決定ボタン表示
            GameStartButton.SetActive(false);
            EasyButton.SetActive(true);
            NormalButton.SetActive(true);
            HardButton.SetActive(true);
        }

        public void SetLevel(int level)
        {
            m_gameLevel = (GameLevel)level;
        }

        public void Ready(int level)
        {
            //ゲームスタート処理
            //難易度決定
            m_gameState = GameState.Play;
            Player.isMove = true;
            HeridController.instance.IsTimeStart = true;
            TimeController.instance.times *= level;
            TimeController.instance.isCount = true;
            //UI非表示処理
            EasyButton.SetActive(false);
            NormalButton.SetActive(false);
            HardButton.SetActive(false);
            GameStartFont.SetActive(false);
            PauseButton.SetActive(true);
        }

        public void GamePlay()
        {
            m_gameState = GameState.Result;
            //ここで難易度設定(各クラスに値を渡す)
        }

        public void Pause()
        {
            Time.timeScale = 0;
            //RetryButton.SetActive(true);
            ContinueButton.SetActive(true);
        }
        public void Retry()
        {
            SceneManager.LoadScene("Game07");
            PauseButton.SetActive(false);
        }
        public void Continue()
        {
            Time.timeScale = 1;
            RetryButton.SetActive(false);
            ContinueButton.SetActive(false);
        }
        public void Result()
        {
            //ヘリと物資を削除
            CatchObject[] catchObj = FindObjectsOfType<CatchObject>();/*HierarchyのCatchObject全取得*/
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
            HeridController.instance.IsTimeStart = false;
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
