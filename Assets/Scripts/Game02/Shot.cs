using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game02 {
	public class Shot : MonoBehaviour {
		[SerializeField] List<GameObject> bulletMagazine;

		Transform scopeTransform {
			get {
				return this.gameObject.transform;
			}
		}

		public void Snipe(){
			var ray = new Ray (scopeTransform.position, scopeTransform.forward);
			RaycastHit rHit;
			if(Physics.Raycast(ray, out rHit)){
				if(rHit.collider.tag == "Enemy"){
					Debug.LogFormat ("Hit!!!!!!, pos:{0}", rHit.point);
				}
			}
			Debug.DrawRay (ray.origin, ray.direction, Color.red);
		}
	}
}