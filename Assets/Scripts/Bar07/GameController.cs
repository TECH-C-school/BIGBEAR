using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07 {

    public class GameController : MonoBehaviour {
        GameObject kakekin;
        GameObject shengfu;
        GameObject Buttonsaihaichi;
        GameObject Buttonreset;
        GameObject winsu ;
        GameObject menu;
        public Text text1;
        public Text text2;
        public Text text3;
        public Text text4;
        public Text text5;
        int mode = 1;
        public int a;
        public int b;
        public string c = "";
        public int d;
        public int e;
        
        public void Start()
        {
             kakekin = GameObject.Find("kakekin");
             shengfu = GameObject.Find("shengfu");
             Buttonsaihaichi = GameObject.Find("Button(saihaichi)");
             Buttonreset = GameObject.Find("Button(reset)");
             winsu = GameObject.Find("winsu");
             menu = GameObject.Find("menu");
            a = 10000;
            b = 1;

            if (a > 999999) { a = 9999999; }
            if (b > 10000) { b = 10000; }
            //aとbの最大値を設定

            text1.GetComponent<Text>().text = a.ToString();
            text2.GetComponent<Text>().text = b.ToString();
            text3.GetComponent<Text>().text = c;
            text4.GetComponent<Text>().text = d.ToString();
            text5.GetComponent<Text>().text = e.ToString();
            //textの中


        }
        
        public void Update()
        {
           
            if (mode == 0)
            {
                kakekin.SetActive(false);
                shengfu.SetActive(true);
                Buttonsaihaichi.SetActive(false);
                Buttonreset.SetActive(false);
                winsu.SetActive(true);
                menu.SetActive(false);

            }
            if (mode == 1)
            {
                kakekin.SetActive(true);
                shengfu.SetActive(false);
                Buttonsaihaichi.SetActive(true);
                Buttonreset.SetActive(true);
                winsu.SetActive(false);
                menu.SetActive(false);

            }
            if (mode == 2)
            {
                menu.SetActive(true);
                Buttonreset.SetActive(false);
                Buttonsaihaichi.SetActive(false);
                //途中
            }
            //mode 1は掛け金、0は勝負、2はmenu

        }
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}

