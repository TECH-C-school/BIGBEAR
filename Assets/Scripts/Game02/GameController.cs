using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UniRx.Triggers;
using UniRx;
using DG.Tweening;

namespace Assets.Scripts.Game02
{
    public class GameController : MonoBehaviour
    {
        
        private void Start()
        {

            GetComponent<ObservableDragTrigger>().OnDragAsObservable().Subscribe(_=>

            {

            });
        }

        private void Update()
        {
            
        }


        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
