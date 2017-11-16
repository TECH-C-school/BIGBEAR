using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotspeed : MonoBehaviour {

    public int speed = 10;
    


    void Start () {
        
    }


    void Update() {
        if (GetComponent<ShellControlle>())//弾が生成された時、と書きたい
        {

            Destroy(gameObject, 1f);
            GetComponent<ShellControlle>().shot.interactable = true;
        }
        else {
            //Destroy(ヘリに当たって消える);
        }
        
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
    }
}
