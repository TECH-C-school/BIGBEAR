using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    public Vector3 startposition;
    private void Start()
    {
        //開始時の座標を取得
        startposition = gameObject.transform.position;
    }

    //マウスドラッグでオブジェクトを動かす
    void OnMouseDrag()
    {
        startposition = transform.position;
        Vector3 objectPointInScreen
            = Camera.main.WorldToScreenPoint(this.transform.position);

        Vector3 mousePointInScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPointInScreen.z);

        Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
        mousePointInWorld.z = this.transform.position.z;
        this.transform.position = mousePointInWorld;

        //ドラッグを離したら元の位置に戻る
        if ()
        {
            gameObject.transform.position = startposition;
        }

    }
}
