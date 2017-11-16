using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
				Debug.Log ("Hit!!!!!!");
			}
		}
		Debug.DrawRay (ray.origin, ray.direction, Color.red);
	}
}