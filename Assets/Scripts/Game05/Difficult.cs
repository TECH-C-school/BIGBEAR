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
		private Button easyButton;
		[SerializeField]
		private Button normalButton;
		[SerializeField]
		private Button hardButton;
		[SerializeField]
		private GameObject bg;
		private GameController gc;
		// Use this for initialization
		void Start () {
			gc = GetComponent<GameController> ();
			var easy = easyButton.OnClickAsObservable ().Do (_ => diff = Difficulty.Amateur);
			var normal = normalButton.OnClickAsObservable ().Do (_ => diff = Difficulty.Professional);
			var hard = hardButton.OnClickAsObservable ().Do (_ => diff = Difficulty.Legend);
			Observable.Merge(easy, normal, hard)
			.Subscribe(_ => {
				bg.SetActive(false);
				gc.isStart = true;
				gc.SetDifficult();
			}).AddTo(this.gameObject);
		}
	}
}
