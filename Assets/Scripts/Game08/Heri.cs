using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heri : MonoBehaviour {

    public float speed = 3;
    public float Des_speed = 5;
    Rigidbody2D heri;
    void Start () {
		heri = GetComponent<Rigidbody2D>();//これは難易度ボタンが押された後に実行させるから、そこに移動予定
	}
	
	
	void Update () {
        heri.velocity = new Vector2(-5, speed);
        Des_speed -= Time.deltaTime;
        if (Des_speed < 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
        Debug.Log("pool");
    }

}
