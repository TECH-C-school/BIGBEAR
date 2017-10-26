using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        private Transform towerParent;
        private PileBunker pb;
        private Difficulty _difficult = Difficulty.Amateur;
        public Difficulty difficult
        {
            get { return _difficult; }
        }

        private float posPadding = 3.15f;

        void Start()
        {
            pb = GameObject.Find("Player").GetComponent<PileBunker>();
            SetDifficult();
        }

        void SetDifficult()
        {
            switch (_difficult)
            {
                case Difficulty.Amateur:
                    pb.upValue = 1f;
                    GenerateTower(GameParam.Instance.easyNum);
                    break;
                case Difficulty.Professional:
                    pb.upValue = 2f;
                    GenerateTower(GameParam.Instance.normalNum);
                    break;
                case Difficulty.Legend:
                    pb.upValue = 3f;
                    GenerateTower(GameParam.Instance.hardNum);
                    break;
                default:
                    break;
            }
        }

        void GenerateTower(int num) {
            towerParent = GameObject.Find("Towers").transform;
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

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
