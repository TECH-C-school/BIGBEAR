using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellControlle : MonoBehaviour {


    public GameObject shell;
    public GameObject Bear;

    public Button shot;

    bool tanpatu = true;


    //Vector2 she;


    void Start () {
        
    }
	
	
	void Update() {

    }

    public void onclick() {
        {
            shot.interactable = false;
            Instantiate(shell, new Vector2(Bear.transform.position.x, Bear.transform.position.y), Quaternion.identity);
        }
    }
}
