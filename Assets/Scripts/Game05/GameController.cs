using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace Assets.Scripts.Game05 {
    [System.Serializable]
    public enum Difficulty
    {
        Amateur,
        Professional,
        Legend
    }
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
        private bool isTimingConf = false;
        private Rigidbody2D pile;
        private PowerGauge powerGauge;
        private Vector3 firstPos;
        private float power;
        private float tMatch;
        private float pMatch;
        private Difficulty _difficult = Difficulty.Amateur;
        public Difficulty difficult
        {
            get { return _difficult; }
        }

        private float posPadding = 3.15f;

        private readonly float[] DISTANCES = {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

        private readonly float[] PERCENT = {
            1.0f, 0.9f, 0.8f, 0.7f, 0.6f, 0.5f, 0.4f, 0.3f, 0.2f, 0.1f
        };

        void Start()
        {
            powerGauge = GameObject.Find("Gauge").GetComponent<PowerGauge>();
            pile = GameObject.Find("Pile").GetComponent<Rigidbody2D>();
            firstPos = pile.transform.position;
            power = 0f;
            tMatch = 0f;
            pMatch = 0f;
            var barTap = this.UpdateAsObservable().Where(_ => Input.GetButtonDown("Fire1"))
                .Select(_ => 1).Scan((count, add) => count + add)
                .Where(tap => tap % 3 == 1)
                .Do(_ => PowerDecision());
            var pTap = this.UpdateAsObservable().Where(_ => Input.GetButtonDown("Fire1"))
                .Select(_ => 1).Scan((count, add) => count + add)
                .Where(tap => tap % 3 == 2)
                .Do(_ => TargetMatch());
            var pendulumTap = this.UpdateAsObservable().Where(_ => Input.GetButtonDown("Fire1"))
                .Select(_ => 1).Scan((count, add) => count + add)
                .Where(tap => tap % 3 == 0)
                .Do(_ => StartCoroutine(PileShoot()));
            var taps = Observable.Merge(barTap, pTap, pendulumTap).Subscribe();
            SetDifficult();
            GenerateScopes();
            GeneratePendulums();
        }

        void SetDifficult()
        {
            switch (_difficult)
            {
                case Difficulty.Amateur:
                    powerGauge.upValue = 1f;
                    GenerateTower(GameParam.Instance.easyNum);
                    break;
                case Difficulty.Professional:
                    powerGauge.upValue = 2f;
                    GenerateTower(GameParam.Instance.normalNum);
                    break;
                case Difficulty.Legend:
                    powerGauge.upValue = 3f;
                    GenerateTower(GameParam.Instance.hardNum);
                    break;
                default:
                    break;
            }
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
                scopes.Add(cursor);
            }
        }

        void GeneratePendulums() {
            var pParent = GameObject.Find("Pendulums").transform;
            var pendulum = Instantiate(pendulumInsance, pParent);
            var circle = Instantiate(circleInstance, pParent);
            pendulum.GetComponent<Pendulum>().pState = PState.Pendulum;
            circle.GetComponent<Pendulum>().pState = PState.Circle;
            pendulums.Add(pendulum);
            pendulums.Add(circle);
        }

        void PowerDecision() {
            power = powerGauge.slider.value;
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
            pile.AddForce((Vector2.left * power * tMatch * tMatch), ForceMode2D.Impulse);
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
            float rNum = PERCENT[0];
            var distance = (right - left).sqrMagnitude;
            for(int i = 0; i < DISTANCES.Length; i++) {
                if(distance < DISTANCES[i] * DISTANCES[i]) {
                    rNum = PERCENT[i];
                    break;
                }
            }
            return rNum;
        }
    }
}
