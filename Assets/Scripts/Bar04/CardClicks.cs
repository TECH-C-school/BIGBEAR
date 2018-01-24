using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Bar04
{
    public class CardClicks : MonoBehaviour
    {
        private bool cardsclick = false;
        // Use this for initialization
        void update()
        {
            if (OnTouchDown())
            {
                if (cardsclick == false)
                {
                    this.tag = "OnClicks";
                    this.GetComponent<Renderer>().sharedMaterial.color = Color.red;
                }
                else
                {
                    this.tag = "OffClicks";
                   
                }
            }
        }
        public bool OnTouchDown()
        {
            // タッチされているとき
            if (0 < Input.touchCount)
            {
                // タッチされている指の数だけ処理
                for (int i = 0; i < Input.touchCount; i++)
                {
                    // タッチ情報をコピー
                    Touch t = Input.GetTouch(i);
                    // タッチしたときかどうか
                    if (t.phase == TouchPhase.Began)
                    {
                        //タッチした位置からRayを飛ばす
                        Ray ray = Camera.main.ScreenPointToRay(t.position);
                        RaycastHit hit = new RaycastHit();
                        if (Physics.Raycast(ray, out hit))
                        {
                            //Rayを飛ばしてあたったオブジェクトが自分自身だったら
                            if (hit.collider.gameObject == this.gameObject)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false; //タッチされてなかったらfalse
        }

    }
}