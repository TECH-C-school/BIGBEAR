using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour {

    // Use this for initialization
    void Start()
    {


        //数字とマークの表示
        string[] mark = new string[] { "S", "C", "H", "D" };
        for (int i = 1; i <= 52; i++)
        {
            var rndnumber = Random.Range(1, 14);
            var rndMark = Random.Range(0, 4);

            Debug.Log(mark[rndMark] + rndnumber);
        }
    }





    // Update is called once per frame

    public GameObject c;
    void Update() {
        c = GameObject.Find("C12");
    }
}
