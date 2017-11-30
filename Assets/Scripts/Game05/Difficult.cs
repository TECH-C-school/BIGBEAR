using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace Assets.Scripts.Game05 {
	[System.Serializable]
	public enum Difficulty
	{
		Amateur = 0,
		Professional,
		Legend
	}
	public class Difficult : MonoBehaviour {
		private Difficulty diff;
		public Difficulty Diff {
			get { return diff; }
		}
		[SerializeField]
		private Button easy;
		[SerializeField]
		private Button normal;
		[SerializeField]
		private Button hard;
		[SerializeField]
		private GameObject bg;
		private GameController gc;
		// Use this for initialization
		void Start () {
			gc = GetComponent<GameController> ();
			easy.OnClickAsObservable ().Subscribe (_ => {
				diff = Difficulty.Amateur;
				PlayGame();
			});
			normal.OnClickAsObservable ().Subscribe (_ => {
				diff = Difficulty.Professional;
				PlayGame();
			});
			hard.OnClickAsObservable ().Subscribe (_ => {
				diff = Difficulty.Legend;
				PlayGame();
			});
		}

		void PlayGame() {
			bg.SetActive(false);
			gc.isStart = true;
			gc.SetDifficult();
		}
	}
}
