﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearControlle : MonoBehaviour {

    public GameObject Bear;
    

    public float speed = 3;
    Vector2 vec;
    


    void Start () {
        
    }


    void Update () {
       if (Input.GetButton("Fire1")) {
            vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("ベアー");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(vec.x, -3.37f), speed * Time.deltaTime);
        }
    }
}
