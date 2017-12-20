using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class syouritu : MonoBehaviour {

    private Text targetText;

    static public double syou = 0;
    static public double goukei = 0;

    static public void syouri(int gou)
    {
        goukei++;
        if (gou == 1) { syou++; }
    }

    public void Update()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = ((syou/goukei)*100).ToString()+"%";
    }
}
