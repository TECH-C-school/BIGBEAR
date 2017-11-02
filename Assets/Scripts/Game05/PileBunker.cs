using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace Assets.Scripts.Game05 {
    public class PileBunker : MonoBehaviour {
        private bool isPowerConf = false;
        private bool isTimingConf = false;
        private Rigidbody2D pile;
        private Slider powerGauge;
        private GameController gc;
        private Vector3 firstPos;
        private float power;
        public float upValue;
        // Use this for initialization
        void Start() {
            pile = this.transform.FindChild("Pile").gameObject.GetComponent<Rigidbody2D>();
            firstPos = pile.transform.position;
            powerGauge = GameObject.Find("PowerBar").GetComponent<Slider>();
            power = 0f;
            var barTap = this.UpdateAsObservable().Where(_ => Input.GetButtonDown("Fire1"))
                .Select(_ => 1).Scan((count, add) => count + add)
                .Where(tap => tap % 3 == 1)
                .Do(_ => isPowerConf = true);
            var pTap = this.UpdateAsObservable().Where(_ => Input.GetButtonDown("Fire1"))
                .Select(_ => 1).Scan((count, add) => count + add)
                .Where(tap => tap % 3 == 2)
                .Do(_ => power = powerGauge.value);
            var pendulumTap = this.UpdateAsObservable().Where(_ => Input.GetButtonDown("Fire1"))
                .Select(_ => 1).Scan((count, add) => count + add)
                .Where(tap => tap % 3 == 0)
                .Do(_ => StartCoroutine(PileShoot()));
            var taps = Observable.Merge(barTap, pTap, pendulumTap).Subscribe();
        }

        // Update is called once per frame
        void Update() {
            if(!isPowerConf)
            {
                powerGauge.value += upValue;
                if (powerGauge.maxValue <= powerGauge.value)
                    powerGauge.value = 0;
            }
            /*
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(PileShoot());
            }
            */
        }

        IEnumerator PileShoot()
        {
            if(isTimingConf) yield break;
            isTimingConf = true;
            yield return new WaitForSecondsRealtime(0.5f);
            pile.AddForce(Vector2.left * power, ForceMode2D.Impulse);
            yield return new WaitForSecondsRealtime(5f);
            pile.velocity = Vector2.zero;
            pile.transform.position = firstPos;
            powerGauge.value = 0;
            power = 0;
            isPowerConf = false;
            isTimingConf = false;
            yield break;
        }
    }
}
