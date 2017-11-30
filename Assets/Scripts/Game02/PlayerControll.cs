using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        [SerializeField]
        GameObject m_swayObject;
        [SerializeField]
        LayerMask m_enemyLayer;
        [SerializeField]
        Button m_shotButton;

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
                     float x = Mathf.Sin(Time.time) /10 + (Mathf.Sin(Time.time) * Mathf.Sin(Time.time) / 10 * 2);
                     float y = Mathf.Cos(Time.time) /10 + (Mathf.Cos(Time.time) * Mathf.Cos(Time.time) / 10 * 2);

                     m_swayObject.transform.position = new Vector3(x, y, 10);

                     m_scope.gameObject.SetActive(true);
                     m_scope.transform.localPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , (Input.mousePosition.y + (m_scope.sprite.rect.height/ 3f)), 10));
                    
                     RaycastHit2D hit = Physics2D.Raycast(m_scope.transform.position, m_scope.transform.forward, 10,m_enemyLayer);
                     if (hit.collider)
                     {
                         
                     }
                   

                 }).AddTo(this);

            m_trigger.OnMouseUpAsObservable()
                .Subscribe(pointerEventData =>
                {
                    m_scope.gameObject.SetActive(false);
                }).AddTo(this);
#endif
        }

        public void ShotBullet()
        {

        }


    } 
}