using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07 {
    public class GameController : MonoBehaviour {

        private GameObject bgset;
        private GameObject Cardflame;
        private GameObject CardflameSub;
        private GameObject faze;
        private GameObject Buttons;
        private GameObject MenuButtons;
        private GameObject HystoryText;
        private GameObject Timer;
        private GameObject ResultPlate;
        private GameObject CoinCounter;
        private GameObject fazeword;
        private GameObject Card;

        //カウントフラグ
        public bool timerflag = false;
        //カウント設定秒数、代入のタイミング注意
        public float timers = 0;

        private int timeri = 0;
        private bool thisfaze;


        TimerController TC;
        CoinController CC;



        private void Start()
        {
            GameObject canvas = GameObject.Find("Canvas");

            GameObject[] Card = new GameObject[4];

            //スタートの時点で定位置に設置する
            //スプライトの生成

            bgset = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/bg"), transform.position = new Vector3(0, 0, 1), Quaternion.identity);

            Cardflame = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/main_caldflame"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            CardflameSub = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/draw_cardflame"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            faze = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/faze"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            Timer = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/Timer"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            CoinCounter = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/CoinCounter"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            ResultPlate = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/ResultPlate"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            ResultPlate.SetActive(false);

            //uguiの生成

            Buttons = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/Buttons"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            Buttons.transform.SetParent(canvas.transform,false);
            MenuButtons = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/MenuButtons"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            MenuButtons.transform.SetParent(canvas.transform, false);
            HystoryText = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/historytext"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            HystoryText.transform.SetParent(canvas.transform, false);

            TC = GameObject.Find("Timer(Clone)").GetComponent<TimerController>();
            CC = GameObject.Find("CoinCounter(Clone)").GetComponent<CoinController>();


            fazeword = GameObject.Find("f_word");

            FazeStart();


        }
        private void Update()
        {
            //timerflagが真の時、カウントする
            CountTimer();


        }

        private void CountTimer()
        {
            if (timerflag == true)
            {

                timers -= Time.deltaTime;


                if (timeri != (int)timers)
                {
                    //ここでタイマースクリプトに数値を渡し、画像を変更させる
                    TC.TimerSprite((int)timers);

                }

                timeri = (int)timers;

                if (timers < 0)
                {
                    //timersに設定した秒数経過でタイマーは止まる
                    TC.TimerSprite(-1);
                    timerflag = false;
                    timeri = 0;

                    if(thisfaze == true)
                    {
                        FazeChange();

                    }
                    else
                    {
                        FazeStart();

                    }

                }
            }
        }


        //勝負フェイズ開始の処理
        private void FazeChange() {

            Sprite fazeword2 = Resources.Load<Sprite>("Images/Bar/f_word4");
            fazeword.GetComponent<SpriteRenderer>().sprite = fazeword2;

            CoinController CC = GameObject.Find("CoinCounter(Clone)").GetComponent<CoinController>();
            int number = (CC.betcoins / 100 + CC.betcoins / 10 + CC.betcoins) % 100 % 10;

            switch (number)
            {
                case 1:
                    CC.coins[0].SetActive(false);
                    break;
                case 2:
                    CC.coins[0].SetActive(false);
                    CC.coins[1].SetActive(false);
                    break;
                case 3:
                    CC.coins[0].SetActive(false);
                    CC.coins[1].SetActive(false);
                    CC.coins[2].SetActive(false);
                    break;
            }

            timers = 8;
            thisfaze = false;
            CC.createflag = false;

            ResultPlate.SetActive(true);
            CardflameSub.SetActive(false);
            Buttons.SetActive(false);


            CardCreate(0);
            CardCreate(1);
        }




        //掛け金決定フェイズ開始の処理
        private void FazeStart()
        {

            for (int i = 0; i < 4; i++)
            {
                Card = GameObject.Find("Card" + (i).ToString());
                if (Card != null)
                {

                    Destroy(Card);
                }

            }


            Sprite fazeword1 = Resources.Load<Sprite>("Images/Bar/f_word2");
            fazeword.GetComponent<SpriteRenderer>().sprite = fazeword1;


            ResultPlate.SetActive(false);
            CardflameSub.SetActive(true);
            Buttons.SetActive(true);

            if (CC.betcoins > 0)
            {
                CC.betcoins = CC.betcoins * -1;
            }

            timers = 12;
            timerflag = true;
            thisfaze = true;
            CC.createflag = true;

        }

        //指定した分(１＝半枚)位置を右にずらしてカードを２枚ずつ生成する
        public void CardCreate(int pos)
        {
            Card = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/Card"), transform.position = new Vector3(-3+pos, 0, -1), Quaternion.identity);
            Card.name = "Card" + (pos * 2).ToString();
            Card = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/Card"), transform.position = new Vector3(2+pos, 0, -1), Quaternion.identity);
            Card.name = "Card" + (pos * 2 + 1).ToString();

        }


        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
