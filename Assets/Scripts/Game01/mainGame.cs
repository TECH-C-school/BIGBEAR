using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainGame : MonoBehaviour
{
    // カットインは400pxずつ画面内に入れるように移動

    public int round = 1;
    float count = 0;
    public int timeStart = 0;
    int randomCheck = 0;
    public int touchStart = 0;
    public int battleEnd = 0;
    public int battleLost = 0;
    public int battleDraw = 0;

    float interval;

    private Image Player;
    private Image panel;
    private Image white;
    private Image playerCut;
    private Image enemyCut1;
    private Image enemyCut2;
    private Image enemyCut3;

    public Sprite player_cut1;
    public Sprite player_cut2;
    public Sprite player_cut3;

    public float cutSpeed = 1;

    timeStarter timer;

    void Awake()
    {
        panel = GameObject.Find("BlackPanel").GetComponent<Image>();
        white = GameObject.Find("WhitePanel").GetComponent<Image>();
        playerCut = GameObject.Find("Player_cut").GetComponent<Image>();
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

        if(round == 1)
        {
            if (timeStart == 10 && battleLost == 0 && battleEnd == 0 && battleDraw == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    touchStart = 10;

                    if (timer.timerGo == 0)
                    {

                    }
                    else if (timer.timerGo == 10)
                    {
                        timeStart = 0;
                        StartCoroutine(WhiteOut());
                        battleEnd = 1;

                        timer.Attack.gameObject.SetActive(false);
                    }

                    if(timer.LeftTime == 5)
                    {
                        battleDraw = 10;
                        StartCoroutine(WhiteOut());

                        timer.Attack.gameObject.SetActive(false);
                    }
                }
            }

            if(timer.timerGo == 20 && battleLost == 0)
            {
                battleLost = 10;
                StartCoroutine(WhiteOut());
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
            playerCut.sprite = player_cut1;
            playerCut.transform.position += new Vector3(180f * Time.deltaTime, 0, 0);
            
            enemyCut1.transform.position = new Vector3(
                enemyCut1.transform.position.x - 180,
                enemyCut1.transform.position.y,
                enemyCut1.transform.position.z);
        }
    }
}
