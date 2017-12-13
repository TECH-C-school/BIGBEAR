using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textt : MonoBehaviour {

    private Text targetText;

    static public int nume=0; 


    static public void textupt(int gou) {
        nume = gou;
    }

    public void Update()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = nume.ToString(); 
    }

}
