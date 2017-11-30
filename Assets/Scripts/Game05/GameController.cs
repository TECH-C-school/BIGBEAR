using System.Collections;
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
		[SerializeField]
		private float coolTime;
		[HideInInspector]
		public bool isStart = false;
        private bool isTimingConf = false;
        private Rigidbody2D pile;
        private PowerGauge powerGauge;
        private Vector3 firstPos;
        private float power;
        private float tMatch;
        private float pMatch;
		private Difficult difficult;
		private float moveingPos = 0f;
		private float maxMoving = 0f;

		private const float POSPADDING = 3.15f;
		private const float VALUEMAG = 1.5f;

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
			GenerateTower (GameParam.Instance.createNum [(int)difficult.Diff]);
			GenerateScopes (GameParam.Instance.durations[(int)difficult.Diff]);
			GeneratePendulums (GameParam.Instance.durations[(int)difficult.Diff]);
			powerGauge.UpValue = GameParam.Instance.upValues[(int)difficult.Diff] * VALUEMAG;
			Debug.Log (maxMoving);
        }

        void GenerateTower(int num) {
            var towerParent = GameObject.Find("Towers").transform;
            var top = Instantiate(towerTop, towerParent);
            var lastPos = Vector3.zero;
			lastPos.y = POSPADDING * num;
            top.transform.localPosition = lastPos;
            for(int i = 0; i < num; i++) {
                var tower = Instantiate(towerInstance, towerParent);
                var newPos = Vector3.zero;
				newPos.y = POSPADDING * num - (i + 1);
                tower.transform.localPosition = newPos;
            }
			maxMoving = GameParam.Instance.maxMove * (num + 1);
        }

		void GenerateScopes(float duration) {
            var scopeParent = GameObject.Find("Cursors").transform;
            for(int i = 0; i < 2; i++) {
                var cursor = Instantiate(scopeInstance, scopeParent);
                cursor.GetComponent<TargetScope>().scope = (Scope)i;
				cursor.GetComponent<TargetScope> ().Duration = duration;
                scopes.Add(cursor);
            }
        }

		void GeneratePendulums(float duration) {
            var pParent = GameObject.Find("Pendulums").transform;
            var pendulum = Instantiate(pendulumInsance, pParent);
            var circle = Instantiate(circleInstance, pParent);
			pendulum.GetComponent<Pendulum> ().Duration = duration;
            pendulums.Add(pendulum);
            pendulums.Add(circle);
        }

        void PowerDecision() {
            power = powerGauge.Slider.value;
			//power = powerGauge.Slider.maxValue;
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
			yield return new WaitForSecondsRealtime(coolTime);
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

		public void AddScore(float score, string type) {
			Debug.LogFormat ("Score : {0}\nType : {1}", score, type);
			moveingPos += score;
		}
    }
}
