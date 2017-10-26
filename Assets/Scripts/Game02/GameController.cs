using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game02 {
    public class GameController : MonoBehaviour {
		[SerializeField] Image _scope;

		const float BULLET_SPEED = 900.0f;
		const float DISTANCE = 1000.0f;
		const float ACCELERATION = 9.8f;

		private void Update() {
			if(Input.GetMouseButton(0))
				TouchPoscheck ();
			if (Input.GetMouseButtonUp(0))
				_scope.gameObject.SetActive (false);
			#if UNITY_EDITOR
			if(Input.GetKeyDown("space")){

			}
			#endif
		}

		private void TouchPoscheck() {
			RaycastHit hit;
			var touchPos = Input.mousePosition;
			var screenPos = Camera.main.ScreenToWorldPoint (touchPos);
			screenPos.z = 0;
			Debug.Log ("Pos:" + screenPos);
			_scope.gameObject.SetActive (true);
			_scope.gameObject.transform.position= screenPos;
		}

		private void Snipe(Vector3 firePos){

		}

		public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
