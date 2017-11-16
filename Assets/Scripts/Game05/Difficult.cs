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
		Amateur,
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
				bg.SetActive(false);
				gc.isStart = true;
				gc.SetDifficult();
			});
			normal.OnClickAsObservable ().Subscribe (_ => {
				diff = Difficulty.Professional;
				bg.SetActive(false);
				gc.isStart = true;
				gc.SetDifficult();
			});
			hard.OnClickAsObservable ().Subscribe (_ => {
				diff = Difficulty.Legend;
				bg.SetActive(false);
				gc.isStart = true;
				gc.SetDifficult();
			});
		}
	}
}
