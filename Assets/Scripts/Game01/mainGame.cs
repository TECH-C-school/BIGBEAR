using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainGame : MonoBehaviour
{
    // カットインは200pxずつ画面内に入れるように移動

    public int round = 0;
    public float count = 0;
    int test = 0;

    float interval;

    Image playerCut1;
    Image playerCut2;
    Image playerCut3;
    Image enemyCut1;
    Image enemyCut2;
    Image enemyCut3;

    Image Attack;

    void Start ()
    {
        playerCut1 = GameObject.Find("Player_cut1").GetComponent<Image>();
        playerCut2 = GameObject.Find("Player_cut2").GetComponent<Image>();
        playerCut3 = GameObject.Find("Player_cut3").GetComponent<Image>();
        enemyCut1 = GameObject.Find("Enemy_cut1").GetComponent<Image>();
        enemyCut2 = GameObject.Find("Enemy_cut2").GetComponent<Image>();
        enemyCut3 = GameObject.Find("Enemy_cut3").GetComponent<Image>();

        Attack = GameObject.Find("attack!").GetComponent<Image>();
    }
	
	void Update ()
    {
        interval = Random.Range(5.0f, 12.0f);

        Debug.Log("interval:"+interval);
        
        count += Time.deltaTime;
        if(count >= interval)
        {
            count += 0;
            test = 10;
        }
	}
}
