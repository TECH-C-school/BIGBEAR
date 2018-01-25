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
		private GameController gameController;
		private bool isSkipped = false;
		private float startPos = 0;
		private float endPos = 0;

		// Use this for initialization
		void Start () {
			gameController = GameObject.Find("GameController").GetComponent<GameController>();
		}

		void OnCollisionEnter2D(Collision2D other) {
			if (other.gameObject.name == "Pile") {
				startPos = transform.localPosition.x;
			}
		}

		void OnCollisionExit2D(Collision2D other) {
			if (!isSkipped)
				return;
			else if (other.gameObject.name == "Pile") {
				GetFlying ();
			}
		}

		void GetFlying() {
			endPos = transform.localPosition.x;
			gameController.AddScore (Mathf.Abs (endPos - startPos), tType.ToString());
			gameObject.SetActive (false);
		}

		void OnBecameVisible() {
			isSkipped = false;
		}

		void OnBecameInvisible() {
			isSkipped = true;
		}
	}
}