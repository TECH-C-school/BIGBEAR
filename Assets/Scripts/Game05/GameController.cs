﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace Assets.Scripts.Game05 {
    public class GameController : MonoBehaviour {
        [SerializeField]
        private GameObject towerInstance;
        [SerializeField]
        private GameObject towerTop;
        [SerializeField]
        private GameObject scopeInstance;
        private List<GameObject> scopes = new List<GameObject>();
        [SerializeField]
        private GameObject pendulumInsance;
        [SerializeField]
        private GameObject circleInstance;
        private List<GameObject> pendulums = new List<GameObject>();
		public bool isStart = false;
        private bool isTimingConf = false;
        private Rigidbody2D pile;
        private PowerGauge powerGauge;
        private Vector3 firstPos;
        private float power;
        private float tMatch;
        private float pMatch;
		private Difficult difficult;
		private float posPadding = 3.15f;

        void Start()
        {
			difficult = GetComponent<Difficult> ();
            powerGauge = GameObject.Find("Gauge").GetComponent<PowerGauge>();
            pile = GameObject.Find("Pile").GetComponent<Rigidbody2D>();
            firstPos = pile.transform.position;
            power = 0f;
            tMatch = 0f;
            pMatch = 0f;
            var barTap = this.UpdateAsObservable().Where(_ => Input.GetButtonDown("Fire1"))
				.Where(_ => isStart == true)
                .Select(_ => 1).Scan((count, add) => count + add)
                .Where(tap => tap % 3 == 1)
                .Do(_ => PowerDecision());
            var pTap = this.UpdateAsObservable().Where(_ => Input.GetButtonDown("Fire1"))
				.Where(_ => isStart == true)
				.Select(_ => 1).Scan((count, add) => count + add)
                .Where(tap => tap % 3 == 2)
                .Do(_ => TargetMatch());
            var pendulumTap = this.UpdateAsObservable().Where(_ => Input.GetButtonDown("Fire1"))
				.Where(_ => isStart == true)
				.Select(_ => 1).Scan((count, add) => count + add)
                .Where(tap => tap % 3 == 0)
                .Do(_ => StartCoroutine(PileShoot()));
            var taps = Observable.Merge(barTap, pTap, pendulumTap).Subscribe();
        }

		public void SetDifficult()
        {
			switch (difficult.Diff)
            {
                case Difficulty.Amateur:
                    powerGauge.UpValue = 1f;
                    GenerateTower(GameParam.Instance.easyNum);
                    break;
                case Difficulty.Professional:
                    powerGauge.UpValue = 2f;
                    GenerateTower(GameParam.Instance.normalNum);
                    break;
                case Difficulty.Legend:
                    powerGauge.UpValue = 3f;
                    GenerateTower(GameParam.Instance.hardNum);
                    break;
                default:
                    break;
            }
			GenerateScopes ();
			GeneratePendulums ();
        }

        void GenerateTower(int num) {
            var towerParent = GameObject.Find("Towers").transform;
            var top = Instantiate(towerTop, towerParent);
            var lastPos = Vector3.zero;
            lastPos.y = posPadding * num;
            top.transform.localPosition = lastPos;
            for(int i = 0; i < num; i++) {
                var tower = Instantiate(towerInstance, towerParent);
                var newPos = Vector3.zero;
                newPos.y = posPadding * num - (i + 1);
                tower.transform.localPosition = newPos;
            }
        }

        void GenerateScopes() {
            var scopeParent = GameObject.Find("Cursors").transform;
            for(int i = 0; i < 2; i++) {
                var cursor = Instantiate(scopeInstance, scopeParent);
                cursor.GetComponent<TargetScope>().scope = (Scope)i;
				switch(difficult.Diff) {
                    case Difficulty.Amateur:
                    cursor.GetComponent<TargetScope>().Duration = GameParam.Instance.easyDuration;
                    break;
                case Difficulty.Professional:
                    cursor.GetComponent<TargetScope>().Duration = GameParam.Instance.normalDuration;
                    break;
                case Difficulty.Legend:
                    cursor.GetComponent<TargetScope>().Duration = GameParam.Instance.hardDuration;
                    break;
                default:
                    break;
                }
                scopes.Add(cursor);
            }
        }

        void GeneratePendulums() {
            var pParent = GameObject.Find("Pendulums").transform;
            var pendulum = Instantiate(pendulumInsance, pParent);
            var circle = Instantiate(circleInstance, pParent);
			switch(difficult.Diff) {
                    case Difficulty.Amateur:
                    pendulum.GetComponent<Pendulum>().Duration = GameParam.Instance.easyDuration;
                    break;
                case Difficulty.Professional:
                    pendulum.GetComponent<Pendulum>().Duration = GameParam.Instance.normalDuration;
                    break;
                case Difficulty.Legend:
                    pendulum.GetComponent<Pendulum>().Duration = GameParam.Instance.hardDuration;
                    break;
                default:
                    break;
                }
            pendulums.Add(pendulum);
            pendulums.Add(circle);
        }

        void PowerDecision() {
            power = powerGauge.Slider.value;
            powerGauge.gameObject.SetActive(false);
            foreach(var obj in scopes) {
                obj.SetActive(true);
            }
        }

        void TargetMatch() {
            tMatch = DistanceDecision(scopes[0].transform.position, scopes[1].transform.position);
            foreach(var obj in scopes) {
                obj.SetActive(false);
            }
            foreach(var obj in pendulums) {
                obj.SetActive(true);
            }
        }

        void PendulumMatch() {
            pMatch = DistanceDecision(pendulums[0].transform.position, pendulums[1].transform.position);
            foreach(var obj in pendulums) {
                obj.SetActive(false);
            }
        }

        IEnumerator PileShoot()
        {
            if(isTimingConf) yield break;
            isTimingConf = true;
            PendulumMatch();
            yield return new WaitForSecondsRealtime(0.5f);
            Debug.Log("power : " + power + " tMatch : " + tMatch + " pMatch : " + pMatch);
            pile.AddForce((Vector2.left * power * tMatch * pMatch), ForceMode2D.Impulse);
            yield return new WaitForSecondsRealtime(5f);
            pile.velocity = Vector2.zero;
            pile.transform.position = firstPos;
            isTimingConf = false;
            powerGauge.gameObject.SetActive(true);
            power = 0;
            yield break;
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }

        float DistanceDecision(Vector3 right, Vector3 left) {
			var distances = Distance.Instance.DISTANCES;
			var percent = Distance.Instance.PERCENT;
			float rNum = percent[0];
            var distance = (right - left).sqrMagnitude;
            bool isPass = false;
            for(int i = 0; i < distances.Length; i++) {
				if(distance < distances[i] * distances[i]) {
					rNum = percent[i];
                    isPass = true;
                    break;
                }
            }
			if(!isPass) rNum = percent[percent.Length - 1];
            return rNum;
        }
    }
}
