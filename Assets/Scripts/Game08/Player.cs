using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;

    //public float speed = 1.0f;
    Rigidbody2D rd;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Flick();
    }

    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = Input.mousePosition;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = Input.mousePosition;
            GetDirection();
        }
    }

    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;
        string Direction = "";

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX)) {
            if (30 < directionX)
            {
                // 右向きにフリック
                Direction = "right";
                Debug.Log("右");
            }
            else if (-30 > directionX)
            {
                // 左向きにフリック
                Direction = "light";
                Debug.Log("左");
            }
            else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
            {
                if (30 < directionY)
                {
                    // 上向きにフリック
                    Direction = "up";
                    Debug.Log("上");
                }
                else if (-30 > directionY)
                {
                    // 下向きのフリック
                    Direction = "down";
                    Debug.Log("下");
                }
            }
            else
            {
                    // タッチを検出
                    Direction = "touch";
            }
        }
        switch (Direction)
        {
            case "up":
                //上フリックされた時の処理
                break;
            case "down":
                //下フリックされた時の処理
                break;
            case "right":
                //右フリックされた時の処理

                break;
            case "left":
                //左フリックされた時の処理

                break;
            case "touch":
                //タッチされた時の処理
                break;
        }
    }
}

