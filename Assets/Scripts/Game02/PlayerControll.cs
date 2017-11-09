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
        ObservableEventTrigger m_trigger;

        [SerializeField]
        SpriteRenderer m_scope;

        // Use this for initialization
        void Start()
        {
#if !UNITY_EDITOR
            m_trigger.OnDragAsObservable()
                .Subscribe(pointerEventData =>
                {
                     m_scope.gameObject.SetActive(true);
                     m_scope.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, (Input.mousePosition.y + 100.0f), 10));

                }).AddTo(this);

             m_trigger.OnPointerUpAsObservable()
                .Subscribe(pointerEventData =>
                {
                    m_scope.gameObject.SetActive(false);
                });

#endif
#if UNITY_EDITOR

            m_trigger.OnMouseDragAsObservable()
                 .Subscribe(pointerEventData =>
                 {
                     m_scope.gameObject.SetActive(true);
                     m_scope.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, (Input.mousePosition.y + 100.0f), 10));
                     
                 }).AddTo(this);

            m_trigger.OnMouseUpAsObservable()
                .Subscribe(pointerEventData =>
                {
                    m_scope.gameObject.SetActive(false);
                }).AddTo(this);
           
#endif
        }
    }
}