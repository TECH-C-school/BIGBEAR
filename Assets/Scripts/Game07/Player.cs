﻿using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game07
{
    public class Player : MonoBehaviour,IInitPlayerMoveInterface
    {
        //プレイヤーが動けるかどうか
        public static bool isMove = true;//CatchObjectとこのソースに使われている
        Animator anim;
        private static int AnimMoveHash = Animator.StringToHash("Move");
        private static int HitDown = Animator.StringToHash("HitDown");
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
            //Debug.Log(isMove);
            if (isMove) { Move(); }
        }

        void Move()
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos.y = Y_P_Pos;
            X_P_Pos = mousePos.x;
            mousePos.x = Mathf.Clamp(X_P_Pos, Min_X_P_Pos, Max_Y_P_Pos);
            transform.position = Vector2.MoveTowards(transform.position, mousePos, p_speed * 100 * Time.deltaTime);
            float anim_switch_num = Mathf.Abs(transform.position.x - mousePos.x);
            anim.SetBool(AnimMoveHash, anim_switch_num > 0 || mousePos != (Vector2)transform.position);
            if (anim.GetBool(HitDown)) { anim.SetBool(HitDown, false); }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.name == "Bullet")
            {
                anim.SetBool(HitDown, true);
                StartCoroutine(InitPos());
            }
        }

        public IEnumerator InitPos()
        {
            isMove = false;
            yield return new WaitForSeconds(GameController.instance.WaitTime);
            anim.SetBool(HitDown, false);
            isMove = true;
        }
    }

}

