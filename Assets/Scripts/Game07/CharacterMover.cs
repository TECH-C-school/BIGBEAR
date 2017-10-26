using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game07
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CharacterMover : MonoBehaviour, IStopObject
    {

        [SerializeField]
        GameController m_gameController;
        [SerializeField]
        float m_moveSpeed = 7.0f;

        #region Animator
        public class PlayerAnimator
        {
            Animator m_animator;

            public PlayerAnimator(Animator animator)
            {
                m_animator = animator;
            }

            static readonly int s_onMoveStart = Animator.StringToHash("OnMoveStart");
            static readonly int s_onMoveEnd = Animator.StringToHash("OnMoveEnd");
            static readonly int s_onDamage = Animator.StringToHash("OnDamage");
            static readonly int s_damageState = Animator.StringToHash("Base Layer.Damage");

            public void OnMoveStart()
            {
                m_animator.SetTrigger(s_onMoveStart);
            }

            public void ResetOnMoveStart()
            {
                m_animator.ResetTrigger(s_onMoveStart);
            }

            public void OnMoveEnd()
            {
                m_animator.SetTrigger(s_onMoveEnd);
            }

            public void ResetOnMoveEnd()
            {
                m_animator.ResetTrigger(s_onMoveEnd);
            }

            public void OnDamage()
            {
                m_animator.SetTrigger(s_onDamage);
            }

            public void ResetOnDamage()
            {
                m_animator.ResetTrigger(s_onDamage);
            }

            public bool IsDamageState()
            {
                return m_animator.GetCurrentAnimatorStateInfo(0).fullPathHash == s_damageState;
            }
        }
#endregion Animator
        PlayerAnimator m_animator;
        Transform m_transform;

        Vector3 m_movePosition;
        Vector3 m_eulerAngles;

        float m_touchPosX;

        void Start()
        {
            m_transform = GetComponent<Transform>();
            m_animator = new PlayerAnimator(GetComponent<Animator>());

            m_movePosition = m_transform.position;
            m_eulerAngles = m_transform.eulerAngles;
        }

        void Update()
        {
            if(m_animator.IsDamageState())
            {
                return;
            }

            if(Input.GetMouseButtonDown(0))
            {
                MoveStart();
            }
            else if(Input.GetMouseButton(0))
            {
                MovePosition();
            }
            else if(Input.GetMouseButtonUp(0))
            {
                MoveEnd();
            }
        }
        
        void MoveStart()
        {
            m_touchPosX = Input.mousePosition.x;
            m_animator.OnMoveStart();
            MovePosition();
        }

        void MovePosition()
        {
            float currentPosX = Input.mousePosition.x;

            // 右に移動
            if(currentPosX > m_touchPosX)
            {
                m_movePosition.x += m_moveSpeed * Time.deltaTime;
                m_eulerAngles.y = 0.0f;
            }
            // 左に移動
            else if(currentPosX < m_touchPosX)
            {
                m_movePosition.x -= m_moveSpeed * Time.deltaTime;
                m_eulerAngles.y = 180.0f;
            }

            m_movePosition.x = Mathf.Clamp(m_movePosition.x, -8f, 8f);

            m_transform.position = m_movePosition;
            m_transform.eulerAngles = m_eulerAngles;
        }

        void MoveEnd()
        {
            m_touchPosX = 0;
            m_animator.OnMoveEnd();
        }

        public void SetStop(bool enabled)
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // アイテム取得可能な状態かどうか
            if (m_animator.IsDamageState()) { return; }

            // スコアを取得(失敗すればリターン)
            var item = collision.GetComponent<IScoreItem>();
            if(item == null) { return; }

            // スコア加算(マイナスならダメージ)
            int score = item.GetScore();

            if(score < 0)
            {
                m_animator.ResetOnDamage();
            }

            collision.gameObject.SetActive(false);

            m_gameController.AddScore(score);
        }
    }
}