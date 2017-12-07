using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heri : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
        Debug.Log("pool");
    }

}
