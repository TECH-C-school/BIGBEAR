using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class time : MonoBehaviour {

    private float timecount = 100;

    public 

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = ((int)timecount).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        //1秒に1ずつ減らしていく
        timecount -= Time.deltaTime;
        //マイナスは表示しない
        if (timecount < 0) timecount = 0;
        GetComponent<Text>().text = ((int)timecount).ToString();

        if(timecount == 0)
        { 
            SceneManager.LoadScene("result_04");
        }
    }
}
