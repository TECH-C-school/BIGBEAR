using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectController : MonoBehaviour
{
    private Image player1_stand;
    private Image player1_win;
    private Image player1_draw;
    private Image player1_lost;
    private Image player2_stand;
    private Image player2_win;
    private Image player2_draw;
    private Image player2_lost;
    private Image player3_stand;
    private Image player3_win;
    private Image player3_draw;
    private Image player3_lost;

    private Image enemy1_stand;
    private Image enemy1_win;
    private Image enemy1_draw;
    private Image enemy1_lost;
    private Image enemy2_stand;
    private Image enemy2_win;
    private Image enemy2_draw;
    private Image enemy2_lost;
    private Image enemy3_stand;

    mainGame maingame;
    timeStarter timer;

    void Awake()
    {
        player1_stand = GameObject.Find("Player1/stand").GetComponent<Image>();
        player1_win = GameObject.Find("Player1/win").GetComponent<Image>();
        player1_draw = GameObject.Find("Player1/draw").GetComponent<Image>();
        player1_lost = GameObject.Find("Player1/lost").GetComponent<Image>();
        player2_stand = GameObject.Find("Player2/stand").GetComponent<Image>();
        player2_win = GameObject.Find("Player2/win").GetComponent<Image>();
        player2_draw = GameObject.Find("Player2/draw").GetComponent<Image>();
        player2_lost = GameObject.Find("Player2/lost").GetComponent<Image>();
        player3_stand = GameObject.Find("Player3/stand").GetComponent<Image>();
        player3_win = GameObject.Find("Player3/win").GetComponent<Image>();
        player3_lost = GameObject.Find("Player3/lost").GetComponent<Image>();

        enemy1_stand = GameObject.Find("Enemy1/stand").GetComponent<Image>();
        enemy1_win = GameObject.Find("Enemy1/win").GetComponent<Image>();
        enemy1_draw = GameObject.Find("Enemy1/draw").GetComponent<Image>();
        enemy1_lost = GameObject.Find("Enemy1/lost").GetComponent<Image>();
        enemy2_stand = GameObject.Find("Enemy2/stand").GetComponent<Image>();
        enemy2_win = GameObject.Find("Enemy2/win").GetComponent<Image>();
        enemy2_draw = GameObject.Find("Enemy2/draw").GetComponent<Image>();
        enemy3_stand = GameObject.Find("Enemy3/stand").GetComponent<Image>();
    }

    void Start ()
    {
        maingame = GameObject.Find("MainCanvas").GetComponent<mainGame>();
        timer = GameObject.Find("timerFrame").GetComponent<timeStarter>();

        player1_stand.gameObject.SetActive(false);
        player1_win.gameObject.SetActive(false);
        player1_draw.gameObject.SetActive(false);
        player1_lost.gameObject.SetActive(false);
        player2_stand.gameObject.SetActive(false);
        player2_win.gameObject.SetActive(false);
        player2_draw.gameObject.SetActive(false);
        player2_lost.gameObject.SetActive(false);
        player3_stand.gameObject.SetActive(false);
        player3_win.gameObject.SetActive(false);
        player3_lost.gameObject.SetActive(false);

        enemy1_stand.gameObject.SetActive(false);
        enemy1_win.gameObject.SetActive(false);
        enemy1_draw.gameObject.SetActive(false);
        enemy1_lost.gameObject.SetActive(false);
        enemy2_stand.gameObject.SetActive(false);
        enemy2_win.gameObject.SetActive(false);
        enemy2_draw.gameObject.SetActive(false);
        enemy3_stand.gameObject.SetActive(false);
    }
	
	void Update ()
    {
        if(maingame.round == 1)
        {
            if (timer.timerGo == 10 && maingame.touchStart == 10)
            {
                player1_stand.gameObject.SetActive(false);
                enemy1_stand.gameObject.SetActive(false);
                player1_win.gameObject.SetActive(true);
                enemy1_lost.gameObject.SetActive(true);
            }
            if (timer.timerGo == 20 && maingame.battleLost == 10)
            {
                player1_stand.gameObject.SetActive(false);
                enemy1_stand.gameObject.SetActive(false);
                player1_lost.gameObject.SetActive(true);
                enemy1_win.gameObject.SetActive(true);

                StartCoroutine(Result());
            }
            if(maingame.battleDraw == 10)
            {
                player1_stand.gameObject.SetActive(false);
                enemy1_stand.gameObject.SetActive(false);
                player1_draw.gameObject.SetActive(true);
                enemy1_draw.gameObject.SetActive(true);
            }
            if(timer.timerGo == 0 && maingame.touchStart == 0 && maingame.battleLost == 0 && maingame.battleDraw == 0)
            {
                player1_stand.gameObject.SetActive(true);
                enemy1_stand.gameObject.SetActive(true);
            }
        }
        if (maingame.round == 2)
        {
            if (timer.timerGo == 10 && maingame.touchStart == 10)
            {
                player2_stand.gameObject.SetActive(false);
                enemy2_stand.gameObject.SetActive(false);
                player2_win.gameObject.SetActive(true);
                enemy2_lost.gameObject.SetActive(true);
            }
            if (timer.timerGo == 20 && maingame.battleLost == 10)
            {
                player2_stand.gameObject.SetActive(false);
                enemy2_stand.gameObject.SetActive(false);
                player2_lost.gameObject.SetActive(true);
                enemy2_win.gameObject.SetActive(true);

                StartCoroutine(Result());
            }
            if (maingame.battleDraw == 10)
            {
                player2_stand.gameObject.SetActive(false);
                enemy2_stand.gameObject.SetActive(false);
                player2_draw.gameObject.SetActive(true);
                enemy2_draw.gameObject.SetActive(true);
            }
            if (timer.timerGo == 0 && maingame.touchStart == 0 && maingame.battleLost == 0 && maingame.battleDraw == 0)
            {
                player2_stand.gameObject.SetActive(true);
                enemy2_stand.gameObject.SetActive(true);
            }
        }
        if (maingame.round == 3)
        {
            if (timer.timerGo == 10 && maingame.touchStart == 10)
            {
                player3_stand.gameObject.SetActive(false);
                enemy3_stand.gameObject.SetActive(false);
                player3_win.gameObject.SetActive(true);
            }
            if (timer.timerGo == 20 && maingame.battleLost == 10)
            {
                player3_stand.gameObject.SetActive(false);
                enemy3_stand.gameObject.SetActive(false);
                player3_lost.gameObject.SetActive(true);

                StartCoroutine(Result());
            }
            if (maingame.battleDraw == 10)
            {
                player3_stand.gameObject.SetActive(false);
                enemy3_stand.gameObject.SetActive(false);
                player3_draw.gameObject.SetActive(true);
                //enemy3_draw.gameObject.SetActive(true);
            }
            if (timer.timerGo == 0 && maingame.touchStart == 0 && maingame.battleLost == 0 && maingame.battleDraw == 0)
            {
                player3_stand.gameObject.SetActive(true);
                enemy3_stand.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator Result()
    {
        yield return new WaitForSeconds(2f);
        PlayerPrefs.DeleteKey("round");
        SceneManager.LoadScene("Result");
    }
}
