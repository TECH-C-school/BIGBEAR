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
		private Rigidbody2D rigidbody2d;
		private bool isSkipped = false;
		private float startPos = 0;
		private float endPos = 0;
		// Use this for initialization
		void Start () {
			rigidbody2d = GetComponent<Rigidbody2D> ();
			finishButton = GameObject.Find("FinishButton").GetComponent<Button>();
			gameController = GameObject.Find("GameController").GetComponent<GameController>();
		}
		/*
		void Update() {
			if (isSkipped && rigidbody2d.IsSleeping ()) {
				GetFlying ();
			}
		}
		*/
		void OnCollisionEnter2D(Collision2D other) {
			if (other.gameObject.name == "Pile") {
				//startPos = GetComponent<Rigidbody2D> ().velocity.x;
				startPos = transform.localPosition.x;
				Debug.Log ("kita");
			}
		}

		void OnCollisionExit2D(Collision2D other) {
			if (other.gameObject.name == "Pile") {
				//endPos = GetComponent<Rigidbody2D> ().velocity.x;
				//isSkipped = true;
				StartCoroutine (GetFlying ());
				//gameController.AddScore (Mathf.Abs (endPos - startPos));
				//gameObject.SetActive (false);
			}
		}

		IEnumerator GetFlying() {
			yield return new WaitForSecondsRealtime (3);
			endPos = transform.localPosition.x;
			gameController.AddScore (Mathf.Abs (endPos - startPos), tType.ToString());
			gameObject.SetActive (false);
		}
	}
}