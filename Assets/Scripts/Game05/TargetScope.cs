using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Assets.Scripts.Game05 {
	[System.Serializable]
	public enum Scope {
		Right = 0,
		Left
	}
	public class TargetScope : MonoBehaviour {
		
		[SerializeField]
		private Scope _scope;
		public Scope scope{
			get { return _scope; }
			set { _scope = value; }
		}

		private float duration;
		public float Duration {
			get { return duration; }
			set { duration = value; }
		}
		private float dir;
		private Vector3 startPos;
			
		void OnEnable() {
			if (startPos == null)
				return;
			else
				transform.localPosition = startPos;
		}
		void Start () {
			StateInit ();
			gameObject.SetActive(false);
		}

		void Update() {
			ScopeMove ();
		}

		void StateInit() {
			var newPos = transform.localPosition;
			dir = 2.0f;
			newPos.x = scope == Scope.Left ? -1f : 1f;
			duration = scope == Scope.Left ? -duration : duration;
			transform.localPosition = newPos;
			startPos = transform.localPosition;
		}

		void ScopeMove() {
			var time = Time.time;
			var x = Mathf.Cos (time * duration);
			x = scope == Scope.Left ? startPos.x + x : startPos.x - x;
			var y = Mathf.Sin (time * duration * dir) / 3;
			y = scope == Scope.Left ? startPos.y + y : startPos.y - y;
			var z = transform.localPosition.z;
			transform.localPosition = new Vector3 (x, y, z);
		}
	}
}