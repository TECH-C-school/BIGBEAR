using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace Assets.Scripts.Game05 {
    public class PileBunker : MonoBehaviour {
		private PlayerController pc;

		private float initPos, newPos, minPos, maxPos;
		private GameObject powerFx;
		private bool vibToggle = true;
		private bool isVib = false;
		public bool IsVib { 
			get{ return isVib; }
			set{ powerFx.SetActive(value); isVib = value; }
		}
		[HideInInspector]
		public float vibRange, vibSpeed;

        // Use this for initialization
        void Start() {
			pc = GameObject.Find ("Player").GetComponent<PlayerController> ();
			powerFx = transform.Find ("Effect01").gameObject;
			IsVib = false;
			initPos = powerFx.transform.localPosition.y;
			newPos = initPos;
			minPos = initPos - vibRange;
			maxPos = initPos + vibRange;
		}

		void Update(){
			if (isVib) {
				Vibrate ();
			}
		}

		void Vibrate() {
			if (newPos <= minPos || maxPos <= newPos)
				vibToggle = !vibToggle;
			newPos = vibToggle ? newPos + (vibSpeed * Time.deltaTime) : newPos - (vibSpeed * Time.deltaTime);
			newPos = Mathf.Clamp (newPos, minPos, maxPos);
			powerFx.transform.localPosition = new Vector3 (0, newPos, 0);
		}

		void OnCollisionEnter2D(Collision2D other) {
			if (other.gameObject.name == "Tower" || other.gameObject.name == "LastTower") {
				pc.isContact = true;
			}
		}
    }
}
