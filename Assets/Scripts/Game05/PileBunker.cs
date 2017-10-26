using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game05 {
    public class PileBunker : MonoBehaviour {
        private bool isTouch = false;
        private Rigidbody2D pile;
        private Slider powerGauge;
        private GameController gc;
        private Vector3 firstPos;
        public float upValue;
        // Use this for initialization
        void Start() {
            pile = this.transform.FindChild("Pile").gameObject.GetComponent<Rigidbody2D>();
            firstPos = pile.transform.position;
            powerGauge = GameObject.Find("PowerBar").GetComponent<Slider>();
        }

        // Update is called once per frame
        void Update() {
            if(!isTouch)
            {
                powerGauge.value += upValue;
                if (powerGauge.maxValue <= powerGauge.value)
                    powerGauge.value = 0;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(PileShoot());
            }
        }

        IEnumerator PileShoot()
        {
            if(isTouch)
                yield break;
            isTouch = true;
            yield return new WaitForSecondsRealtime(0.5f);
            pile.AddForce(Vector2.left * powerGauge.value, ForceMode2D.Impulse);
            yield return new WaitForSecondsRealtime(5f);
            pile.velocity = Vector2.zero;
            pile.transform.position = firstPos;
            powerGauge.value = 0;
            isTouch = false;
            yield break;
        }
    }
}
