using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heri : MonoBehaviour {

    public float speed = 3;
    Rigidbody2D heri;
    void Start () {
		heri = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
        heri.velocity = new Vector2(-5, speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
        Debug.Log("pool");
    }

}
