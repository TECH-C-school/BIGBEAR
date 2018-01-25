using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class mainGame : MonoBehaviour
{
    // カットインは400pxずつ画面内に入れるように移動

    public int round = 1;
    float count = 0;
    int countStart = 0;
    public int timeStart = 0;
    int randomCheck = 0;
    public int touchStart = 0;
    public int battleEnd = 0;
    public int battleLost = 0;
    public int battleDraw = 0;

    float interval;

    private Image Player;
    private Image panel;
    private Image panel2;
    private Image white;
    private Image playerCut;
    private Image enemyCut1;
    private Image enemyCut2;
    private Image enemyCut3;

    private Text otetuki;

    public Sprite player_cut1;
    public Sprite player_cut2;
    public Sprite player_cut3;

    int wait = 0;
    int outTouch = 0;
    int gmOver = 0;

    timeStarter timer;
    Pause pause;

    void Awake()
    {
        panel = GameObject.Find("BlackPanel").GetComponent<Image>();
        panel2 = GameObject.Find("BlackPanel_2").GetComponent<Image>();
        white = GameObject.Find("WhitePanel").GetComponent<Image>();
        playerCut = GameObject.Find("Player_cut").GetComponent<Image>();
        enemyCut1 = GameObject.Find("Enemy_cut1").GetComponent<Image>();
        enemyCut2 = GameObject.Find("Enemy_cut2").GetComponent<Image>();
        enemyCut3 = GameObject.Find("Enemy_cut3").GetComponent<Image>();
        otetuki = GameObject.Find("out_touch").GetComponent<Text>();
    }

    void Start ()
    {
        round = PlayerPrefs.GetInt("round", 1);
        
        timer = GameObject.Find("timerFrame").GetComponent<timeStarter>();
        pause = GameObject.Find("MainCanvas").GetComponent<Pause>();
        panel.gameObject.SetActive(false);
        panel2.gameObject.SetActive(false);
        white.gameObject.SetActive(false);
        otetuki.gameObject.SetActive(false);
        StartCoroutine(GameLoop());
    }
	
	void Update ()
    {
        if(gmOver == 0)
        {
            if (randomCheck == 0)
            {
                interval = UnityEngine.Random.Range(5.0f, 12.0f);
                randomCheck = 10;
                //Debug.Log(interval);
            }

            if (count >= interval && timer.timerGo == 0)
            {
                count += 0;
                timeStart = 10;
            }
            if (countStart == 10 && timeStart == 0 && battleEnd == 0)
            {
                count += Time.deltaTime;

                if (Input.GetMouseButtonDown(0))
                {
                    PointerEventData pointer = new PointerEventData(EventSystem.current);
                    pointer.position = Input.mousePosition;
                    List<RaycastResult> result = new List<RaycastResult>();
                    EventSystem.current.RaycastAll(pointer, result);

                    foreach (RaycastResult raycastResult in result)
                    {
                        int hantei = 0;

                        if (raycastResult.gameObject.tag == "Finish" && hantei == 0)
                        {/*
                            Debug.Log("finish");
                            outTouch = 10;
                            StartCoroutine(Result());
                            panel.gameObject.SetActive(true);
                            otetuki.gameObject.SetActive(true);
                            gmOver = 10;
                            if(pause.pauseGame == true)
                            {
                                outTouch = 0;
                                gmOver = 0;
                            }*/
                            hantei = 10;
                            Debug.Log("finish");
                        }
                        if (raycastResult.gameObject.tag != "Finish" && raycastResult.gameObject.tag == "Untagged" && hantei == 0)
                        {/*
                            Debug.Log("finish");
                            outTouch = 10;
                            StartCoroutine(Result());
                            panel.gameObject.SetActive(true);
                            otetuki.gameObject.SetActive(true);
                            gmOver = 10;
                            if(pause.pauseGame == true)
                            {
                                outTouch = 0;
                                gmOver = 0;
                            }*/
                            Debug.Log("not");
                        }
                    }/*
                    if (Time.timeScale != 0 && pause.pauseGame == false)
                    {
                        Debug.Log("time");
                        outTouch = 10;
                        StartCoroutine(Result());
                        panel.gameObject.SetActive(true);
                        otetuki.gameObject.SetActive(true);
                        gmOver = 10;
                    }*/
                }
            }

            if (round == 1)
            {
                if (wait == 10)
                {
                    playerCut.sprite = player_cut1;
                    playerCut.transform.position += new Vector3(20, 0, 0);
                    enemyCut1.transform.position += new Vector3(-20, 0, 0);
                }

                if (timeStart == 10 && battleLost == 0 && battleEnd == 0 && battleDraw == 0)
                {
                    if (Input.GetMouseButtonDown(0) && outTouch == 0)
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

                            StartCoroutine(LoadScene());
                        }

                        if (timer.LeftTime == 5)
                        {
                            battleDraw = 10;
                            StartCoroutine(WhiteOut());

                            timer.Attack.gameObject.SetActive(false);
                        }
                    }
                }

                if (timer.timerGo == 20 && battleLost == 0)
                {
                    battleLost = 10;
                    StartCoroutine(WhiteOut());
                }
            }
            if (round == 2)
            {
                if (wait == 10)
                {
                    playerCut.sprite = player_cut2;
                    playerCut.transform.position += new Vector3(20, 0, 0);
                    enemyCut2.transform.position += new Vector3(-20, 0, 0);
                }

                if (timeStart == 10 && battleLost == 0 && battleEnd == 0 && battleDraw == 0)
                {
                    if (Input.GetMouseButtonDown(0) && outTouch == 0)
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

                            StartCoroutine(LoadScene());
                        }

                        if (timer.LeftTime == 3)
                        {
                            battleDraw = 10;
                            StartCoroutine(WhiteOut());

                            timer.Attack.gameObject.SetActive(false);
                        }
                    }
                }

                if (timer.timerGo == 20 && battleLost == 0)
                {
                    battleLost = 10;
                    StartCoroutine(WhiteOut());
                }
            }
            if (round == 3)
            {
                if (wait == 10)
                {
                    playerCut.sprite = player_cut3;
                    playerCut.transform.position += new Vector3(20, 0, 0);
                    enemyCut3.transform.position += new Vector3(-20, 0, 0);
                }

                if (timeStart == 10 && battleLost == 0 && battleEnd == 0 && battleDraw == 0)
                {
                    if (Input.GetMouseButtonDown(0) && outTouch == 0)
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

                            StartCoroutine(Clear());
                        }

                        if (timer.LeftTime == 1)
                        {
                            battleDraw = 10;
                            StartCoroutine(WhiteOut());

                            timer.Attack.gameObject.SetActive(false);
                        }
                    }
                }

                if (timer.timerGo == 20 && battleLost == 0)
                {
                    battleLost = 10;
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
        yield return new WaitForSeconds(1f);
        StartCoroutine(CutIn());
        //Debug.Log("test");
    }
    
    private IEnumerator CutIn ()
    {
        if(round == 1)
        {
            panel.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            wait = 10;
            yield return new WaitForSeconds(0.45f);
            wait = 0;
            yield return new WaitForSeconds(0.8f);
            panel.gameObject.SetActive(false);
            playerCut.gameObject.SetActive(false);
            enemyCut1.gameObject.SetActive(false);
            countStart = 10;
            playerCut.gameObject.transform.localPosition = new Vector3(-620, -126, 0);
        }
        else if (round == 2)
        {
            panel.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            wait = 10;
            yield return new WaitForSeconds(0.45f);
            wait = 0;
            yield return new WaitForSeconds(0.8f);
            panel.gameObject.SetActive(false);
            playerCut.gameObject.SetActive(false);
            enemyCut2.gameObject.SetActive(false);
            countStart = 10;
            playerCut.gameObject.transform.localPosition = new Vector3(-620, -126, 0);
        }
        else if (round == 3)
        {
            panel.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            wait = 10;
            yield return new WaitForSeconds(0.45f);
            wait = 0;
            yield return new WaitForSeconds(0.8f);
            panel.gameObject.SetActive(false);
            playerCut.gameObject.SetActive(false);
            enemyCut3.gameObject.SetActive(false);
            countStart = 10;
            playerCut.gameObject.transform.localPosition = new Vector3(-620, -126, 0);
        }
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2.5f);
        round++;
        PlayerPrefs.SetInt("round", round);
        SceneManager.LoadScene("Game01");
    }

    IEnumerator Clear()
    {
        yield return new WaitForSeconds(2.5f);
        PlayerPrefs.DeleteKey("round");
        SceneManager.LoadScene("Result");
    }

    IEnumerator Result()
    {
        yield return new WaitForSeconds(2.5f);
        PlayerPrefs.DeleteKey("round");
        SceneManager.LoadScene("Result");
    }
}
