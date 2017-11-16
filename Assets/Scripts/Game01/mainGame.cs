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
    public int touchStart = 0;
    public int battleEnd = 0;

    float interval;

    private Image panel;
    private Image white;
    private Image playerCut1;
    private Image playerCut2;
    private Image playerCut3;
    private Image enemyCut1;
    private Image enemyCut2;
    private Image enemyCut3;

    public float cutSpeed = 1;

    timeStarter timer;

    void Awake()
    {
        panel = GameObject.Find("BlackPanel").GetComponent<Image>();
        white = GameObject.Find("WhitePanel").GetComponent<Image>();
        playerCut1 = GameObject.Find("Player_cut1").GetComponent<Image>();
        playerCut2 = GameObject.Find("Player_cut2").GetComponent<Image>();
        playerCut3 = GameObject.Find("Player_cut3").GetComponent<Image>();
        enemyCut1 = GameObject.Find("Enemy_cut1").GetComponent<Image>();
        enemyCut2 = GameObject.Find("Enemy_cut2").GetComponent<Image>();
        enemyCut3 = GameObject.Find("Enemy_cut3").GetComponent<Image>();
    }

    void Start ()
    {
        timer = GameObject.Find("timerFrame").GetComponent<timeStarter>();
        panel.gameObject.SetActive(false);
        white.gameObject.SetActive(false);
        //StartCoroutine(GameLoop());
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
        if(count >= interval && timer.timerGo == 0)
        {
            count += 0;
            timeStart = 10;
        }

        if(timeStart == 10)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(timer.timerGo == 0)
                {

                }
                else if(timer.timerGo == 10)
                {
                    timeStart = 0;
                    StartCoroutine(WhiteOut());
                }
            }
        }
    }

    private IEnumerator WhiteOut ()
    {
        white.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        white.gameObject.SetActive(false);
    }

    private IEnumerator GameLoop ()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(CutIn());
        //Debug.Log("test");
    }
    
    private IEnumerator CutIn ()
    {
        int wait = 0;

        if(round == 1)
        {
            panel.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            playerCut1.transform.position += new Vector3(180f * Time.deltaTime, 0, 0);
            
            enemyCut1.transform.position = new Vector3(
                enemyCut1.transform.position.x - 180,
                enemyCut1.transform.position.y,
                enemyCut1.transform.position.z);
        }
    }
}
