using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Game05 {
	[System.Serializable]
	public enum PState {
		Pendulum = 0,
		Circle
	}
	public class Pendulum : MonoBehaviour {
		[SerializeField]
		private PState _pState;
		public PState pState{
			get { return _pState; }
			set { _pState = value; }
		}

		private float duration;
		public float Duration {
			get { return duration; }
			set { duration = value; }
		}
		private float distance = 0.3f;
		private float radius = 1.2f;
		private Vector3 startPos;

		void OnEnable() {
			if (startPos == null)
				return;
			transform.localPosition = startPos;
		}

		void Start () {
			transform.localPosition = Vector3.zero;
			var newPos = pState == PState.Pendulum ? new Vector3 (0, distance * radius, 0) : transform.localPosition;
			startPos = newPos;
			gameObject.SetActive(false);
		}

		void Update() {
			if (pState == PState.Pendulum) {
				PendulumMove ();
			}
		}

		void PendulumMove() {
			var time = Time.time;
			var x = startPos.x + Mathf.Cos (time * duration) * radius;
			var y = startPos.y + Mathf.Cos (time * duration * 2) * radius / 3;
			var z = transform.localPosition.z;
			transform.localPosition = new Vector3 (x, y, z);
		}
	}
}