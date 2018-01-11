using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game02 {
	public class EnemyBase : MonoBehaviour {
		protected int _column = 0;
		protected int _row = 0;
		protected Vector3 _genPos;

		private Transform _parentTransform {
			get{ return this.gameObject.transform.parent;}
		}

		protected virtual void Init() {
			Debug.Log ("Parent!!");
		}

		protected virtual void Generate() {
			this.gameObject.transform.position = _genPos;
			this.gameObject.SetActive (true);
		}

		protected virtual void Eliminate() {
			this.gameObject.SetActive (false);
			this.gameObject.transform.position = _parentTransform.position;
		}
	}
}
