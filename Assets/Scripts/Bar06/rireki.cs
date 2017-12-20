using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rireki : MonoBehaviour {

	    private Text targetText;

    static public string nume=""; 


    static public void rirekii(int gou) {
        nume = gou.ToString()+ "\n" + nume;
    }

    public void Update()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = nume.ToString(); 
    }
}
