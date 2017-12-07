using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(0, 0.3f, 0);

        if (transform.position.y > 6) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        Destroy(coll.gameObject);
        Destroy(gameObject);
    }
}
