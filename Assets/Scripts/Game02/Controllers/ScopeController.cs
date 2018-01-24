using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Game02 {
	public class ScopeController : MonoBehaviour {
		[SerializeField] int _maxBulletNum = 5;
		[SerializeField] List<GameObject> _bulletMagazine = new List<GameObject>();
		int _bulletRemnant = 0;

		public bool isReload {
			get {return _bulletRemnant == 0;}
		}

		void Start() {
			Reload ();
		}

		Transform scopeTransform {
			get {
				return this.gameObject.transform;
			}
		}

		FigureOfEight eightAnim {
			get { return GetComponent<FigureOfEight> ();}
		}

		public void Vibration(Vector3 targetPos) {
			this.gameObject.transform.position = targetPos;
			eightAnim.MoveToFigureOfEight (this.transform.position);
		}

		void Recoil() {
		}

		public void Snipe(){
			if (isReload)
				return;
			_bulletRemnant--;
			_bulletMagazine.FirstOrDefault (bullet => bullet.activeSelf == true).SetActive(false);

			var ray = new Ray (scopeTransform.position, scopeTransform.forward);
			RaycastHit rHit;
			if(Physics.Raycast(ray, out rHit)){
				if(rHit.collider.tag == "Enemy"){
					Debug.LogFormat ("Hit!!!!!!, pos:{0}", rHit.point);
					EffectController.Instance.GenerateEffect (EffectType.hit, rHit.point);
					rHit.collider.gameObject.GetComponent<EnemyBase> ().Eliminate();
				}
			}
			Debug.DrawRay (ray.origin, ray.direction, Color.red);
		}

		public void Reload() {
			for(int i = 0; i < _bulletMagazine.Count; i++) {
				if (i < _maxBulletNum)
					_bulletMagazine [i].SetActive (true);
				else
					_bulletMagazine [i].SetActive (false);
			}
			_bulletRemnant = _maxBulletNum;
		}
	}
}
