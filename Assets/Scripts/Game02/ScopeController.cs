using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game02 {
	public class ScopeController : MonoBehaviour {
		[SerializeField] List<GameObject> bulletMagazine;

		Transform scopeTransform {
			get {
				return this.gameObject.transform;
			}
		}

		FigureOfEight eightAnim {
			get { return GetComponent<FigureOfEight> ();}
		}

		public void Move(Vector3 targetPos) {
			this.gameObject.transform.position = targetPos;
			eightAnim.MoveToFigureOfEight (this.transform.position);
		}

		public void Snipe(){
			var ray = new Ray (scopeTransform.position, scopeTransform.forward);
			RaycastHit rHit;
			if(Physics.Raycast(ray, out rHit)){
				if(rHit.collider.tag == "Enemy"){
					Debug.LogFormat ("Hit!!!!!!, pos:{0}", rHit.point);
					rHit.collider.gameObject.GetComponent<EnemyBase> ().Eliminate();
				}
			}
			Debug.DrawRay (ray.origin, ray.direction, Color.red);
		}
	}
}
