using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

string db = "";
for (int i = 0; i < List.Length; i++)
{
	switch(List[i])
	{
	case 1:
		db = db + "A" + ":";
		break;
	case 11:
		db = db + "J" + ":";
		break;
	case 12:
		db = db + "Q" + ":";
		break;
	case 13:
		db = db + "K" + ":";
		break;
	default:
		db = db + List[i] + ":";
		break;
	}
}