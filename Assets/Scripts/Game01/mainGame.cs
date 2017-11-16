using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainGame : MonoBehaviour
{
    // カットインは400pxずつ画面内に入れるように移動

    public int round = 1;
    public float count = 0;
    public int timeStart = 0;
    public int randomCheck = 0;

    float interval;

    private Image panel;
    private Image playerCut1;
    private Image playerCut2;
    private Image playerCut3;
    private Image enemyCut1;
    private Image enemyCut2;
    private Image enemyCut3;

    void Awake()
    {
        panel = GameObject.Find("BlackPanel").GetComponent<Image>();
        playerCut1 = GameObject.Find("Player_cut1").GetComponent<Image>();
        playerCut2 = GameObject.Find("Player_cut2").GetComponent<Image>();
        playerCut3 = GameObject.Find("Player_cut3").GetComponent<Image>();
        enemyCut1 = GameObject.Find("Enemy_cut1").GetComponent<Image>();
        enemyCut2 = GameObject.Find("Enemy_cut2").GetComponent<Image>();
        enemyCut3 = GameObject.Find("Enemy_cut3").GetComponent<Image>();
    }

    void Start ()
    {
        panel.gameObject.SetActive(false);
    }
	
	void Update ()
    {
        if(randomCheck == 0)
        {
            interval = UnityEngine.Random.Range(5.0f, 12.0f);
            randomCheck = 10;
            Debug.Log(interval);
        }

        count += Time.deltaTime;
        if(count >= interval)
        {
            count += 0;
            timeStart = 10;
        }
	}

    private IEnumerator GameLoop ()
    {
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(CutIn());
    }

    private IEnumerator CutIn ()
    {
        if(round == 1)
        {
            panel.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
