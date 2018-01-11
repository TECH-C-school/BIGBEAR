using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game02 {
	public class EnemyBase : MonoBehaviour {
		protected int _column = 0;
		protected int _row = 0;

		private Transform _parentTransform {
			get{ return this.gameObject.transform.parent;}
		}

		public void Generate(Vector3 genPos) {
			this.gameObject.transform.position = genPos;
			this.gameObject.SetActive (true);
			Init ();
		}

		protected virtual void Init() {
			Debug.Log ("Parent"); 
		}

		public void Eliminate() {
			Debug.Log ("Delete");
			this.gameObject.SetActive (false);
			this.gameObject.transform.position = _parentTransform.position;
		}
	}
}
