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
		private GameObject playerInstance;
		[SerializeField]
		private Button pauseButton;
		[SerializeField]
		private GameObject pauseBack;

		private PlayerController pc;
		[HideInInspector]
		public bool isStart = false;
		[HideInInspector]
		public bool isPause = false;
		private Difficult difficult;
		private float moveingPos = 0f;
		private float maxMoving = 0f;

		private const float POSPADDING = 3.15f;
		private const float VALUEMAG = 1.5f;

        void Start() {
			pauseButton.OnClickAsObservable ()
				.Subscribe (_ => {
					isPause = !isPause;
					if(pauseBack.activeSelf) 
						Time.timeScale = 1;
					else
						Time.timeScale = 0;
					pauseBack.SetActive(!pauseBack.activeSelf);
				});
			difficult = GetComponent<Difficult> ();
			var player = Instantiate (playerInstance);
			player.name = "Player";
			pc = player.GetComponent<PlayerController> ();
		}

		public void SetDifficult() {
			GenerateTower (GameParam.Instance.createNum [(int)difficult.Diff]);
			pc.GenerateScopes (GameParam.Instance.durations[(int)difficult.Diff]);
			pc.GeneratePendulums (GameParam.Instance.durations[(int)difficult.Diff]);
			pc.Gauge.UpValue = GameParam.Instance.upValues[(int)difficult.Diff] * VALUEMAG;
			Debug.Log (maxMoving);
        }

        void GenerateTower(int num) {
            var towerParent = GameObject.Find("Towers").transform;
            var top = Instantiate(towerTop, towerParent);
			top.name = "LastTower";
			top.GetComponent<Renderer> ().sortingOrder = num;
            var lastPos = Vector3.zero;
			lastPos.y = POSPADDING * num;
            top.transform.localPosition = lastPos;
            for(int i = 0; i < num; i++) {
                var tower = Instantiate(towerInstance, towerParent);
				tower.name = "Tower";
				tower.GetComponent<Renderer> ().sortingOrder = (num - (i + 1));
                var newPos = Vector3.zero;
				newPos.y = POSPADDING * (num - (i + 1));
                tower.transform.localPosition = newPos;
            }
			maxMoving = GameParam.Instance.maxMove * (num + 1);
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }

		public void AddScore(float score, string type) {
			Debug.LogFormat ("Score : {0}\nType : {1}", score, type);
			moveingPos += score;
		}
    }
}
