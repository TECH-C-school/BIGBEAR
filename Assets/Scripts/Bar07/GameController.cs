using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07 {
    public class GameController : MonoBehaviour {

        private GameObject bgset;
        private GameObject Card;
        private GameObject Cardflame;
        private GameObject CardflameSub;
        private GameObject faze;
        private GameObject Buttons;
        private GameObject HystoryText;
        private GameObject Timer;
        private GameObject ResultPlate;
        private GameObject CoinCounter;

        public bool timerflag = false;
        private float timers = 0;
        private int timeri = 0;

        TimerController TC;


        private void Start()
        {
            GameObject canvas = GameObject.Find("Canvas");

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
            HystoryText = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/historytext"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            HystoryText.transform.SetParent(canvas.transform, false);

            TC = GameObject.Find("Timer(Clone)").GetComponent<TimerController>();

            timers = 10;
            timerflag = true;


        }
        private void Update()
        {
            //timerflagが真の時、20カウントする
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
                    //20秒経過でタイマーは止まる
                    TC.TimerSprite(-1);
                    timerflag = false;
                    timers = 20;
                    timeri = 0;

                    FazeCChange();
                }
            }
        }


        //勝負フェイズ開始の処理
        private void FazeCChange() {
            GameObject fazeword = GameObject.Find("f_word");
            Sprite fazeword2 = Resources.Load<Sprite>("Images/Bar/f_word4");
            fazeword.GetComponent<SpriteRenderer>().sprite = fazeword2;

            CoinController CC = GameObject.Find("CoinCounter(Clone)").GetComponent<CoinController>();
            int number = (CC.betcoins / 100 + CC.betcoins / 10 + CC.betcoins) % 100 % 10;

            switch (number)
            {
                case 1:
                    CC.coins[0].SetActive(false);

                    //再配置用にbetcoinsは保持
                    CC.betcoins = CC.betcoins * -1;
                    break;
                case 2:
                    CC.coins[0].SetActive(false);
                    CC.coins[1].SetActive(false);

                    //再配置用にbetcoinsは保持
                    CC.betcoins = CC.betcoins * -1;
                    break;
                case 3:
                    CC.coins[0].SetActive(false);
                    CC.coins[1].SetActive(false);
                    CC.coins[2].SetActive(false);

                    //再配置用にbetcoinsは保持
                    CC.betcoins = CC.betcoins * -1;
                    break;
            }

            ResultPlate.SetActive(true);

            Buttons.SetActive(false);

            CardflameSub.SetActive(false);

            Card = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/Card"), transform.position = new Vector3(-3, 0, -1), Quaternion.identity);
            Card = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/Card"), transform.position = new Vector3(2, 0, -1), Quaternion.identity);
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
