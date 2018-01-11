using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemysikai : MonoBehaviour {

    public LayerMask mask;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Ray()
    {
        // Rayの作成
        Ray ray = new Ray(transform.position, new Vector3(0, -10, 0));

        // Rayが衝突したコライダーの情報を得る
        RaycastHit hit;

        
    }



}
