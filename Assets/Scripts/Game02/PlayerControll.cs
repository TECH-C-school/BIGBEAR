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
    public class PlayerControll : MonoBehaviour
    {

        [SerializeField]
        ObservableEventTrigger trigger;

        []

        // Use this for initialization
        void Start()
        {
#if !UNITY_EDITOR
            trigger.OnDragAsObservable()
                .Subscribe(pointerEventData =>
                {
                    Debug.Log("a");
                }).AddTo(this);
#endif
#if UNITY_EDITOR
            trigger.OnMouseDragAsObservable()
                 .Subscribe(pointerEventData =>
                 {
                     
                 }).AddTo(this);
#endif
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}