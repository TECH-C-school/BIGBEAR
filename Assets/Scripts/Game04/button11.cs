using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button11 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Getbutton11()
    {
        SceneManager.LoadScene("Game04");
    }

    public void Getbutton22()
    {
        SceneManager.LoadScene("main");
    }
}
