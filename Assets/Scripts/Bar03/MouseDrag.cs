﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {


    private GameObject startposition;
    private bool button;
    Vector3 hit;
    Vector3 position;

    private void Start()
    {
     
    }
    private void Update()
    {
        MouseD();
        MouseUp();
        if (button == true)
        {
            hit = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit.z = -9;
            startposition.transform.position = hit;
        }
        
    }
    //マウスドラッグでオブジェクトを動かす
    void MouseD()
    {

        //マウスクリックの判定
        if (!Input.GetMouseButtonDown(0)) return;

        Vector3 tmp = GameObject.Find("FrontCards").transform.position;
        float x = tmp.x;
        float y = tmp.y;
        GameObject.Find("FrontCards").transform.position = new Vector2(tmp.x, tmp.y);

        //クリックした位置を取得
        /*
        var x2 = Input.mousePosition;
        */
        var tapPoint = Camera.main.ScreenToWorldPoint(tmp);
        hit = tapPoint;
        hit.z = -9;

        //Collider2D上のクリックの判定
        if (!Physics2D.OverlapPoint(tapPoint)) return;
        
        //クリックした位置のオブジェクトを取得
        var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);

        startposition = hitObject.transform.gameObject;
        position = startposition.transform.position;
        

        //常に起動させる
        button = true;

    }
     void MouseUp()
    {
        //マウスを離したかの判定
        if (!Input.GetMouseButtonUp(0)) return;

        //positionの取得
        startposition.transform.position = position;

        button = false;
  
    }
}
