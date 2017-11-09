using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace Assets.Scripts.Game05 {
	[System.Serializable]
	public enum TowerType {
		Normal = 0,
		Last
	}
	public class Tower : MonoBehaviour {
		[SerializeField]
		private TowerType tType;
		private Button finishButton;
		private GameController gameController;
		// Use this for initialization
		void Start () {
			finishButton = GameObject.Find("FinishButton").GetComponent<Button>();
			gameController = GameObject.Find("GameController").GetComponent<GameController>();
		}
	}
}