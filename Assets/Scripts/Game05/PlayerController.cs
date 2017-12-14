using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace Assets.Scripts.Game05 {
	public class PlayerController : MonoBehaviour {
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
		public bool isContact = false;
		private bool isTimingConf = false;
		private Rigidbody2D pile;
		private GameController gc;
		private PowerGauge powerGauge;
		public PowerGauge Gauge {
			get { return powerGauge; }
		}

		private Vector3 firstPos;
		private float power;
		private float tMatch;
		private float pMatch;
		private GameObject tapField;

		// Use this for initialization
		void Start () {
			gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ();
			powerGauge = GameObject.Find("Gauge").GetComponent<PowerGauge>();
			pile = GameObject.Find("Pile").GetComponent<Rigidbody2D>();
			tapField = GameObject.Find ("TapField");
			firstPos = pile.transform.position;
			power = 0f;
			tMatch = 0f;
			pMatch = 0f;
			var field = tapField.AddComponent<ObservableEventTrigger> ();
			var barTap = field.OnPointerDownAsObservable()
				.Where(_ => gc.isStart == true)
				.Select(_ => 1).Scan((count, add) => count + add)
				.Where(tap => tap % 3 == 1)
				.Do(_ => PowerDecision());
			var pTap = field.OnPointerDownAsObservable()
				.Where(_ => gc.isStart == true)
				.Select(_ => 1).Scan((count, add) => count + add)
				.Where(tap => tap % 3 == 2)
				.Do(_ => TargetMatch());
			var pendulumTap = field.OnPointerDownAsObservable()
				.Where(_ => gc.isStart == true)
				.Select(_ => 1).Scan((count, add) => count + add)
				.Where(tap => tap % 3 == 0)
				.Do(_ => StartCoroutine(PileShoot()));
			var taps = Observable.Merge (barTap, pTap, pendulumTap).Subscribe ().AddTo (this.gameObject);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void GenerateScopes(float duration) {
			var scopeParent = GameObject.Find ("Cursors").transform;
			for (int i = 0; i < 2; i++) {
				var cursor = Instantiate (scopeInstance, scopeParent);
				cursor.GetComponent<TargetScope> ().scope = (Scope)i;
				cursor.GetComponent<TargetScope> ().Duration = duration;
				scopes.Add (cursor);
			}
		}

		public void GeneratePendulums(float duration) {
			var pParent = GameObject.Find ("Pendulums").transform;
			var pendulum = Instantiate (pendulumInsance, pParent);
			var circle = Instantiate (circleInstance, pParent);
			pendulum.GetComponent<Pendulum> ().Duration = duration;
			pendulums.Add (pendulum);
			pendulums.Add (circle);

		}

		void PowerDecision() {
			//power = powerGauge.Slider.value;
			power = powerGauge.Slider.maxValue;
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
			pMatch = DistanceDecision (pendulums [0].transform.position, pendulums [1].transform.position);
			foreach (var obj in pendulums) {
				obj.SetActive (false);
			}
		}

		IEnumerator PileShoot() {
			if (isTimingConf)
				yield break;
			isTimingConf = true;
			PendulumMatch ();
			yield return new WaitForSecondsRealtime (0.5f);
			Debug.LogFormat ("power : {0} tMatch : {1} pMatch : {2}", power, tMatch, pMatch);
			pile.AddForce ((Vector2.left * power * tMatch * pMatch), ForceMode2D.Impulse);
			yield return new WaitWhile (() => isContact);
			yield return new WaitForSecondsRealtime (coolTime);
			pile.velocity = Vector2.zero;
			pile.transform.position = firstPos;
			isTimingConf = false;
			isContact = false;
			powerGauge.gameObject.SetActive (true);
			power = 0;
			yield break;
		}

		float DistanceDecision(Vector3 right, Vector3 left) {
			var distances = Distance.Instance.DISTANCES;
			var percent = Distance.Instance.PERCENT;
			float rNum = percent [0];
			var distance = (right - left).sqrMagnitude;
			bool isPass = false;
			for (int i = 0; i < distances.Length; i++) {
				if (distance < distances [i] * distances [i]) {
					rNum = percent [i];
					isPass = true;
					break;
				}
			}
			if (!isPass)
				rNum = percent [percent.Length - 1];
			return rNum;
		}
	}
}