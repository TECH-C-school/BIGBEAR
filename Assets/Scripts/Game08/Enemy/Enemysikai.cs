using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemysikai : MonoBehaviour {

    public LayerMask mask;


    public GameObject enemy;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //メインカメラ上のマウスカーソルのある位置からRayを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        //Rayの長さ
        float maxDistance = 10;

        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);

        //なにかと衝突した時だけそのオブジェクトの名前をログに出す
        if (hit.collider)
        {
            Debug.Log(hit.collider.gameObject.name);
        }


        float enemyx = enemy.transform.position.x;
        float playerx = player.transform.position.x;


       // playerx = Mathf.Round(, 0, MidpointRounding.AwayFromZero);
       // enemyx = Mathf.Round(enemyx,MidpointRounding.AwayFromZero);
    }

}
