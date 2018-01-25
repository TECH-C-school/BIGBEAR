using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using UniRx.Triggers;
using UniRx;
using DG.Tweening;

namespace Assets.Scripts.Game02
{
    public class PlayerControll : MonoBehaviour
    {
        public const float HIT_TIME = 0.3f;
        public const int ALL_BULLET = 6;

        enum PlayerState
        {
            Idle,
            Reload,
            Breath,
            Shot
        }

        PlayerState m_playerState = PlayerState.Idle;

        [SerializeField] Animator m_bearAnim;
        [SerializeField] ObservableEventTrigger m_trigger;
        [SerializeField] SpriteRenderer m_scope;
        [SerializeField] GameObject m_swayObject;
        [SerializeField] GameObject m_recoilObject;
        [SerializeField] LayerMask m_hitLayer; // Enemy Default
        [SerializeField] Button m_shotButton;
        [SerializeField]
        Button m_reloadButton;
        [SerializeField] Game02.EffectControll m_effectController;
        [SerializeField] Image[] m_bulletImages;

        private int m_haveBullet;
        [HideInInspector] public int m_totalUseBullet;

        // Use this for initialization
        void Start()
        {

            m_haveBullet = ALL_BULLET;
            //m_effectController.CreateBullet();
            m_trigger.OnMouseDownAsObservable()
                .Subscribe(pointerEventData =>
                {
                    m_bearAnim.SetTrigger("SetUpAction");
                    m_scope.gameObject.SetActive(true);
                    m_shotButton.interactable = true;
                    m_reloadButton.interactable = false; 

                }).AddTo(this);

            m_trigger.OnMouseDragAsObservable()
                 .Subscribe(pointerEventData =>
                 {
                     if (Input.touchCount > 1) return;
                     float x = Mathf.Sin(Time.time) /10 + (Mathf.Sin(Time.time) * Mathf.Sin(Time.time) / 10 * 2);
                     float y = Mathf.Cos(Time.time) /10 + (Mathf.Cos(Time.time) * Mathf.Cos(Time.time) / 10 * 2);

                     if(m_playerState != PlayerState.Breath)m_swayObject.transform.position = new Vector3(x, y, 10);
                     m_scope.transform.localPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , (Input.mousePosition.y + (Screen.height / 7f)), 10));

                     if (m_playerState == PlayerState.Shot || m_playerState == PlayerState.Reload) return;

                     if (m_playerState == PlayerState.Breath)
                     {
                         if (Input.GetKeyUp(KeyCode.Space))
                         {
                             ShotBullet();
                         }
                         return;
                     }

                     if (Input.GetKeyDown(KeyCode.Space))
                     {
                         m_playerState = PlayerState.Breath;
                     }
                     
                 }).AddTo(this);
            

            m_trigger.OnMouseUpAsObservable()
                .Subscribe(pointerEventData =>
                {
                    m_bearAnim.SetTrigger("QuitAction");
                    m_scope.gameObject.SetActive(false);
                    m_shotButton.interactable = false;
                    m_reloadButton.interactable = true;
                    m_playerState = PlayerState.Idle;

                }).AddTo(this);

            m_trigger.OnMouseExitAsObservable()
                .Subscribe(pointerEventData=>
                {
                    m_bearAnim.SetTrigger("QuitAction");
                    m_scope.gameObject.SetActive(false);
                    m_shotButton.interactable = false;
                    m_reloadButton.interactable = true;
                    m_playerState = PlayerState.Idle;

                }).AddTo(this);

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.R) && m_playerState == PlayerState.Idle)
                .Subscribe(_ => {
                    Reload();
                }).AddTo(this);


        }

        public void ShotBullet()
        {
            if (m_haveBullet == 0)
            {
                return;
            }

            RaycastHit2D hit = Physics2D.Raycast(m_scope.transform.position, m_scope.transform.forward, 10, m_hitLayer);
            if (!hit) return;
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Debug.Log("hit");
            }
            else
            {
                Debug.Log(hit.collider.name);
                m_effectController.CreateSpark(new Vector2(hit.point.x, hit.point.y - 0.575f), 0);
            }

            m_bulletImages[ALL_BULLET - m_haveBullet].gameObject.SetActive(false);
            m_haveBullet -= 1;
            m_totalUseBullet++;

            m_playerState = PlayerState.Shot;
            
            m_recoilObject.transform.DOMoveY(1f, 0.3f)
                .OnComplete(()=> { m_recoilObject.transform.DOMoveY(0f, 1.1f); });
            
            Camera.main.DOShakePosition(0.3f, 0.7f, 40);
            m_scope.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 0.3f, 2, 1);
            
            Observable.Timer(TimeSpan.FromSeconds(1.2f)).Subscribe(_ =>
            {
                m_playerState = PlayerState.Idle;

            }).AddTo(this);

            m_bearAnim.SetTrigger("ShotAction");
        }

        public void Reload()
        {
            m_playerState = PlayerState.Reload;
            m_haveBullet = ALL_BULLET;
            foreach (var bullet in m_bulletImages)
            {
                bullet.gameObject.SetActive(true);
            }
                Observable.Timer(TimeSpan.FromSeconds(3.0f)).Subscribe(_ =>
            {
                m_playerState = PlayerState.Idle;

            }).AddTo(this);

        }

    } 
}