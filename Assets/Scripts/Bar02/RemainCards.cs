using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainCards : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SettingCards()
    {
        GameObject backCard = GameObject.Find("Back");

        backCard.transform.position = new Vector3(
        6.0f,
        3.9f,
        0);

    }
}
