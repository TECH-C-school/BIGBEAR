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
        private Transform towerParent;
        private PileBunker pb;
        private Difficulty _difficult = Difficulty.Amateur;
        public Difficulty difficult
        {
            get { return _difficult; }
        }

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
                    break;
                case Difficulty.Professional:
                    pb.upValue = 2f;
                    break;
                case Difficulty.Legend:
                    pb.upValue = 3f;
                    break;
                default:
                    break;
            }
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
