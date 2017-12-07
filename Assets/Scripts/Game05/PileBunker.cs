using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace Assets.Scripts.Game05 {
    public class PileBunker : MonoBehaviour {
		private PlayerController pc;
        // Use this for initialization
        void Start() {
			pc = GameObject.Find ("Player").GetComponent<PlayerController> ();
        }

        // Update is called once per frame
        void Update() {
        }

		void OnCollisionEnter2D(Collision2D other) {
			if (other.gameObject.name == "Tower" || other.gameObject.name == "LastTower") {
				pc.isContact = true;
			}
		}
    }
}
