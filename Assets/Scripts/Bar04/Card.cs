using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    private LayerMask mask;

    // Use this for initialization



    // Update is called once per frame
    void Update()
    {

    }


    //void OnMouseDown()
    //{


    //    Debug.Log("hogehoge");

    //}

    //void ray()
    //{
    //    var Sel = gameObject.transform.FindChild("SelCard").gameObject;
    //    // Rayの作成
    //    Ray ray = new Ray(transform.position, transform.forward);
    //    Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    // Rayが衝突したコライダーの情報を得る
    //    RaycastHit hit;

    //    // Rayが衝突したかどうか
    //    if (Physics.Raycast(ray,out hit, 10.0f, mask))
    //    {
    //        var gae = hit.collider.GetComponentInChildren<GameObject>();
    //        gae.

    //    }
    //    //clickされた奴の子を非表示にする作業中。

    //}








    /*
        //スマホのタッチ判定
        //スマホ向け そのオブジェクトがタッチされていたらtrue（マルチタップ対応）
        bool OneTouchDown()
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
                            if (hit.collider.gameObject == cardPrefab)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;//タッチされてなかったらfalse
        }
        */









}

