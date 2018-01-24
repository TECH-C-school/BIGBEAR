using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Game02 {
	public class ScopeController : MonoBehaviour {
		[SerializeField] int _maxBulletNum = 5;
		[SerializeField] List<GameObject> _bulletMagazine = new List<GameObject>();
		int _bulletRemnant = 0;
		[SerializeField] Animator bearAnim;

		bool _isShot = false;

		public bool _isReload {
			get {return _bulletRemnant == 0;}
		}

		void Start() {
			StartCoroutine (Reload (0));
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
			if (_isShot)
				return;
			this.gameObject.transform.position = targetPos;
			eightAnim.MoveToFigureOfEight (this.transform.position);
		}

		void Recoil(Vector3 currentPos) {
			this.transform.DOLocalJump (currentPos, 0.5f, 1, 1.0f);
		}

		public IEnumerator Snipe(float delayTime, Vector3 currentPos){
			if (_isReload || _isShot)
				yield break;
			_isShot = true;
			bearAnim.Play ("Shooting", 0, 0);
			Recoil (currentPos);
			_bulletRemnant--;
			_bulletMagazine.FirstOrDefault (bullet => bullet.activeSelf == true).SetActive(false);

			var ray = new Ray (scopeTransform.position, scopeTransform.forward);
			RaycastHit rHit;
			if(Physics.Raycast(ray, out rHit)){
				if(rHit.collider.tag == "Enemy"){
					EffectController.Instance.GenerateEffect (EffectType.hit, rHit.point);
					rHit.collider.gameObject.GetComponent<EnemyBase> ().Eliminate();
				}
			}
			Debug.DrawRay (ray.origin, ray.direction, Color.red);
			yield return new WaitForSeconds (delayTime);
			_isShot = false;
		}

		public IEnumerator Reload(float delayTime) {
			bearAnim.Play ("Reload", 0, 0);
			yield return new WaitForSeconds (delayTime);
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
