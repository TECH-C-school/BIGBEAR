using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {


	void Start () {
		
	}
	
	
	void Update () {
        transform.Translate(0, -0.2f, 0);

        if(transform.position.y > 0) {
            Destroy(gameObject);
        }
	}
}
