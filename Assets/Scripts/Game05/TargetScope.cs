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
		private Transform trans;
		private Sequence sequence;
		void OnEnable() {
			if(trans == null)
				return;
			else {
				SetAnimation();
			}
		}
		void Start () {
			trans = GetComponent<Transform>();
			gameObject.SetActive(false);
		}

		void SetAnimation() {
			sequence = DOTween.Sequence();
			switch(_scope) {
				case Scope.Right:
				transform.localPosition = Vector3.left;
				sequence.Append(
					trans.DOLocalMove(Vector3.right * 2, 2.0f)
					.SetEase(Ease.InOutCirc)
					.SetRelative()
				);
				sequence.Append(
					trans.DOLocalMove(Vector3.left * 2, 2.0f)
					.SetEase(Ease.InOutCirc)
					.SetRelative()
				);
				break;
				case Scope.Left:
				transform.localPosition = Vector3.right;
				sequence.Append(
					trans.DOLocalMove(Vector3.left * 2, 2.0f)
					.SetEase(Ease.InOutCirc)
					.SetRelative()
				);
				sequence.Append(
					trans.DOLocalMove(Vector3.right * 2, 2.0f)
					.SetEase(Ease.InOutCirc)
					.SetRelative()
				);
				break;
				default:
				break;
			}
			sequence.SetLoops(-1);
			sequence.Play();
		}

		void OnDisable()
		{
			Debug.Log("shinda");
			sequence.Kill();
		}
	}
}