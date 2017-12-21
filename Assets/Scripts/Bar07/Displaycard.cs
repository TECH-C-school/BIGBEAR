using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Displaycard : MonoBehaviour {
    public Assets.Scripts.Bar07.GameController Controller;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void numbercard()
    {
        Controller.controlcard();      
    }
}
