using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game02 {
	public class GameController : SingletonMono<GameController> {
		[SerializeField] Button shotBtn;
		[SerializeField] Button reloadBtn;
		[SerializeField] ScopeController _scope;
		SpriteRenderer scopeRenderer {
			get {
				return _scope.gameObject.GetComponent<SpriteRenderer> ();
			}
		}

		const float BULLET_SPEED = 900.0f;
		const float DISTANCE = 1000.0f;
		const float ACCELERATION = 9.8f;

		private void Start() {
			scopeRenderer.enabled = false;
			reloadBtn.interactable = false;
			shotBtn.interactable = true;
		}

		private void Update() {
			if(Input.GetMouseButton(0))
				TouchPoscheck ();
			if (Input.GetMouseButtonUp (0))
				scopeRenderer.enabled = false;
			if (_scope.isReload) {
				reloadBtn.interactable = true;
				shotBtn.interactable = false;
				#if UNITY_EDITOR
				if(Input.GetKeyDown(KeyCode.R)) {
					_scope.Reload();
				}
				#endif
			}
		}

		private void TouchPoscheck() {
			var touchPos = Input.mousePosition;
			var screenPos = Camera.main.ScreenToWorldPoint (touchPos);
			screenPos.z = -0.5f;
			scopeRenderer.enabled = true;
			_scope.Vibration (screenPos);
			#if UNITY_EDITOR
			if(Input.GetKeyDown(KeyCode.S)){
				_scope.Snipe();
			}
			#endif
		}

		public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
