using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game06{
	public class LevelSelect : MonoBehaviour {

        public GameController _gameCtl;
        public GameObject cutinTexs;

		//------------------------------------------------------------
		// どれかの難易度が選択されたらそれに応じて難易度を設定する
		public void TapAmateur()
		{
            _gameCtl.Difficulty = GameController.DIFFICULTY.AMATEUR;
            gameObject.SetActive (false);
            _gameCtl.GameStates = GameController.GAMESTATES.CUTIN;
            cutinTexs.SetActive(true);
		}

		public void TapProfessional()
		{
            _gameCtl.Difficulty = GameController.DIFFICULTY.PROFESSIONAL;
            gameObject.SetActive(false);
            _gameCtl.GameStates = GameController.GAMESTATES.CUTIN;
            cutinTexs.SetActive(true);
        }

		public void TapLegend()
		{
            _gameCtl.Difficulty = GameController.DIFFICULTY.LEGEND;
            gameObject.SetActive(false);
            _gameCtl.GameStates = GameController.GAMESTATES.CUTIN;
            cutinTexs.SetActive(true);
        }
		//------------------------------------------------------------

	}
}
