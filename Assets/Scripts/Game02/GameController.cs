using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game02 {
    public class GameController : MonoBehaviour {
		[SerializeField] Shot _scope;
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
		}

		private void Update() {
			if(Input.GetMouseButton(0))
				TouchPoscheck ();
			if (Input.GetMouseButtonUp (0))
				scopeRenderer.enabled = false;

		}

		private void TouchPoscheck() {
			var touchPos = Input.mousePosition;
			var screenPos = Camera.main.ScreenToWorldPoint (touchPos);
			screenPos.z = -0.5f;
//			Debug.Log ("Pos:" + screenPos);
			scopeRenderer.enabled = true;
			_scope.gameObject.transform.position= screenPos;
			#if UNITY_EDITOR
			if(Input.GetKeyDown("space")){
				_scope.Snipe();
			}
			#endif
		}

		public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
