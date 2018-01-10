using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07
{
    public class CardController : MonoBehaviour
    {
        //カードに付けてクリックで反転

        ResultController RC;


        //初期設定で裏
        private bool cardstate = false;

        private bool side;

        private int resultnumber;

        public SpriteRenderer cardRenderer;

        private void Start()
        {
            RC = GameObject.Find("ResultPlate(Clone)").GetComponent<ResultController>();
            cardRenderer = transform.GetComponent<SpriteRenderer>();
        }



        void OnMouseDown()
        { 
            cardaction();
        }

        //カードステートが偽で表に変える

        public void cardaction()
        {

            if (cardstate == false)
            {
                if (transform.position.x < 0) {side = true;}
                else if (transform.position.x > 0) {side = false;}

                cardRenderer.sprite = RC.CardChange();




                
                resultnumber = (RC.randomarray[RC.count - 1] + 1) % 13;
                if(resultnumber >= 10)
                {
                    RC.ChangeScore(0, side);
                }
                else
                {
                    RC.ChangeScore(resultnumber, side);
                }



                cardstate = true;


                
                //ゲーム終了条件、試験用
                if (RC.count >= 2)
                {
                    RC.DesideWinner();
                }

            }


        }



    }

}