using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour {

    private Text targetText;

    static public int num=0; 


    static public void textupt(int gou) {
        num = gou;
    }

    public void Update()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = num.ToString(); 
    }


 



}
