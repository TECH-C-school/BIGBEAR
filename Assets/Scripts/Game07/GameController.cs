using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game07 {
    public class GameController : MonoBehaviour {

        //ゲーム状態 goto マウスクリックするまではReady状態　クリックしたらPlay状態
        public enum GameState { Ready, Play, Result }
        [HideInInspector]
        public GameState gameState;
        //ゲーム難易度
        public enum GameLevel { Easy = 1, Normal = 3, Hard = 5 }
        [HideInInspector]
        public GameLevel gameLevel;

        const int plus_score = 10;
        public static int m_score = 0;

        public int GetScore(){ return m_score; }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
