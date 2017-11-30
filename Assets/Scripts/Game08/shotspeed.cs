using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotspeed : MonoBehaviour {

    public int speed = 10;

    //GetComponent<ShellControlle>();

    void Start () {
        
    }


    void Update() {
        
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
    }
}
