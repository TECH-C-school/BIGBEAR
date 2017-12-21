using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject _obj;
    public GameObject _muzzle;



    // Use this for initialization
    void Start() {


    }

    // Update is called once per frame
    void Update() {
        /*
        //スペースを押したら
        if (Input.GetKeyDown(KeyCode.Space)) {
            //Instantiate( 生成するオブジェクト,  場所, 回転 );  回転はそのままなら↓
            Instantiate(_Pl, new Vector3(1.0f, 2.0f, 0.0f), Quaternion.identity);
        }
        */


        transform.position += new Vector3(-0.05f, 0f, 0f);
    }
}
