﻿using UnityEngine;

namespace Assets.Scripts.Game07
{
    public class Player : MonoBehaviour
    {
        //プレイヤーが動けるかどうか
        public static bool isMove = true;//CatchObjectとこのソースに使われている
        Animator anim;
        private static int AnimMoveHash = Animator.StringToHash("Move");
        private float X_P_Pos;
        private float Y_P_Pos = 120;
        private float Min_X_P_Pos = 30;
        private float Max_Y_P_Pos = Screen.width - 30;
        [SerializeField, Header("プレイヤーのスピード")]
        private float p_speed = 1.0f;

        void Start()
        {
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (isMove) { Move(); }
        }

        void Move()
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos.y = Y_P_Pos;
            X_P_Pos = mousePos.x;
            mousePos.x = Mathf.Clamp(X_P_Pos, Min_X_P_Pos, Max_Y_P_Pos);
            transform.position = Vector2.MoveTowards(transform.position, mousePos, p_speed * 100 * Time.deltaTime);
            float anim_switch_num = transform.position.x > mousePos.x ? transform.position.x - mousePos.x : mousePos.x - transform.position.x;
            anim.SetBool(AnimMoveHash, anim_switch_num > 0);
        }

        /// <summary>
        ///  佐野先輩この↓バグになるので、修正お願いします。
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "CatchObj")
            {
                anim.SetBool("HitDown", true);
            }
        }

    }

}

