using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07
{
    public class CardController : MonoBehaviour
    {
        //カードに付けてクリックで反転



        //初期設定で裏
        private bool cardstate = false;

        private string[,] testcase = new string[4,13];


        void OnMouseDown()
        { 
                testcase[0, 0] = "images/Bar/Cards/c01";  
            cardaction();
        }

        //カードステートが偽で表に変える
        //要追加:カードのナンバーをランダムで取得して表示する処理
        public void cardaction()
        {
            SpriteRenderer cardRenderer = transform.GetComponent<SpriteRenderer>();
            if (cardstate != true)
            {
                cardRenderer.sprite = Resources.Load<Sprite>(testcase[0,0]);
                cardstate = true;
            }
            else
            {
                cardRenderer.sprite = Resources.Load<Sprite>("images/Bar/Cards/back");
                cardstate = false;
            }


        }


    }

}