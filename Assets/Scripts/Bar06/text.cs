using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour {

    private Text targetText;

    static public string num="";

    void Start()
    {
        num = "";
    }
    static public void textupt(int gou) {
        num = gou.ToString();
    }

    public void Update()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = num.ToString(); 
    }



 



}
