﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textt : MonoBehaviour {

    private Text targetText;

    static public string nume="";

    void Start()
    {
        nume = "";
    }
    static public void textupt(int gou) {
        nume = gou.ToString();
    }

    public void Update()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = nume.ToString(); 
    }

}
