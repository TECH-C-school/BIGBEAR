using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
    }

    static public void winhyou()
    {
        canb.SetActive("bakarawin", true);
    }
    static public void winhihyou()
    {
        canb.SetActive("bakarawin", false);
    }
}
