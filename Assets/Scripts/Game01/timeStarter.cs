using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class timeStarter : MonoBehaviour
{
    public Text Timers;

    int LeftTime;
    float RightTime;
    int OldRight;
    

    void Start ()
    {
        LeftTime = 0;
        RightTime = 0;
        OldRight = 0;
	}
	
	void Update ()
    {
        if(Time.timeScale > 0)
        {
            RightTime += Time.deltaTime * 60;

            if(RightTime >= 60.0f)
            {
                LeftTime++;
                RightTime = RightTime - 60;
            }

            if(RightTime != OldRight)
            {
                //Timers.text = LeftTime.ToString("00") + "  " + 
            }
        }
	}
}
