using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
			transform.localPosition = Vector3.zero;
			gameObject.SetActive(false);
		}
		void SetAnimation() {
			sequence = DOTween.Sequence();
			if(_pState == PState.Pendulum) {
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
			}
			sequence.SetLoops(-1);
			sequence.Play();
		}

		void OnDisable() {
			sequence.Kill();
		}
	}
}