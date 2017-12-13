using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07 {
    public class GameController : MonoBehaviour {

        //フィールド
        private GameObject bgset;
        private GameObject Card;
        private GameObject Cardflame;
        private GameObject CardflameSub;
        private GameObject faze;
        private GameObject Buttons;
        private GameObject Timer;

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
            //Card = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/Card"), transform.position = new Vector3(0, 0, -1), Quaternion.identity);
            Cardflame = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/main_caldflame"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            CardflameSub = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/draw_cardflame"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            faze = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/faze"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            Timer=Instantiate((GameObject)Resources.Load("Prefabs/Bar07/Timer"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);


            //uguiの生成

            Buttons = Instantiate((GameObject)Resources.Load("Prefabs/Bar07/Buttons"), transform.position = new Vector3(0, 0, 0), Quaternion.identity);
            Buttons.transform.SetParent(canvas.transform,false);

            TC = GameObject.Find("Timer(Clone)").GetComponent<TimerController>();

            timers = 20;
            timerflag = true;


        }
        private void Update()
        {
            if (timerflag == true) {

                timers -= Time.deltaTime;


                if(timeri != (int)timers)
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
                }

            }
        }





        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
