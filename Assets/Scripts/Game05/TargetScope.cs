using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Assets.Scripts.Game05 {
	public class TargetScope : MonoBehaviour {
		enum Scope {
			Right = 0,
			Left
		}
		[SerializeField]
		private Scope scope;
		private Transform trans;
		private Sequence sequence;
		void OnEnable()
		{
			if(trans == null)
				return;
			else {
				SetAnimation();
			}
		}
		void Start () {
			trans = GetComponent<Transform>();
			SetAnimation();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void SetAnimation() {
			sequence = DOTween.Sequence();
			switch(scope) {
				case Scope.Right:
				transform.localPosition = Vector3.left / 2;
				sequence.Append(
					trans.DOLocalMove(Vector3.right, 2.0f)
					.SetEase(Ease.InOutCirc)
					.SetRelative()
				);
				sequence.Append(
					trans.DOLocalMove(Vector3.left, 2.0f)
					.SetEase(Ease.InOutCirc)
					.SetRelative()
				);
				break;
				case Scope.Left:
				transform.localPosition = Vector3.right / 2;
				sequence.Append(
					trans.DOLocalMove(Vector3.left, 2.0f)
					.SetEase(Ease.InOutCirc)
					.SetRelative()
				);
				sequence.Append(
					trans.DOLocalMove(Vector3.right, 2.0f)
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