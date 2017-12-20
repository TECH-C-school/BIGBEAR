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
        GameObject card1;
        GameObject card2;
        GameObject card3;
        GameObject card4;
        GameObject card5;
        GameObject card6;
        public Text text1;
        public Text text2;
        public Text text3;
        public Text text4;
        public Text text5;
        public int mode = 1;
        public int a;
        public int b;
        public string c = "";
        public int d;
        public int e;
        public List<string> cardlist;
        

        public void Start()
        {
             kakekin = GameObject.Find("kakekin");
             shengfu = GameObject.Find("shengfu");
             Buttonsaihaichi = GameObject.Find("Button(saihaichi)");
             Buttonreset = GameObject.Find("Button(reset)");
             winsu = GameObject.Find("winsu");
             menu = GameObject.Find("menu");
             card1 = GameObject.Find("back");
             card2 = GameObject.Find("back(1)");
             card3 = GameObject.Find("back(2)");
             card4 = GameObject.Find("back(3)");
             card5 = GameObject.Find("back(4)");
             card6 = GameObject.Find("back(5)");
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

            for(int i=0; i<4; i++)
            {
                string tempcard_f=null;
                switch (i)
                {
                    case 0:
                        tempcard_f = "s";//heitao
                        break;
                    case 1:
                        tempcard_f = "h";//hongtao
                        break;
                    case 2:
                        tempcard_f = "c";//meihua
                        break;
                    case 3:
                        tempcard_f = "d";//fangpian
                        break;

                }
                

                for(int j = 1; j < 14; j++) {
                    string tempcard = null;
                    tempcard = tempcard_f + j;
                    cardlist.Add(tempcard);
                    Debug.Log(tempcard);
                }
            }
            
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
               

            }
            if (mode == 1)
            {
                kakekin.SetActive(true);
                shengfu.SetActive(false);
                Buttonsaihaichi.SetActive(true);
                Buttonreset.SetActive(true);
                winsu.SetActive(false);
               

            }

            //mode 1は掛け金、0は勝負

        }


        public void haifu()
        {
            string card_1;
            string card_2;
            string card_3;
            string card_4;
            string card_5;
            string card_6;
            int z;
            z = Random.Range(1,52);
            card_1 = cardlist[z];
            cardlist.Remove(cardlist[z]);
            z = Random.Range(1, 51);
            card_2 = cardlist[z];
            cardlist.Remove(cardlist[z]);
            z = Random.Range(1, 50);
            card_3 = cardlist[z];
            cardlist.Remove(cardlist[z]);
            z = Random.Range(1, 49);
            card_4 = cardlist[z];
            cardlist.Remove(cardlist[z]);
            z = Random.Range(1, 48);
            card_5 = cardlist[z];
            cardlist.Remove(cardlist[z]);
            z = Random.Range(1, 47);
            card_6 = cardlist[z];
            cardlist.Remove(cardlist[z]);

            
            //card1.GetComponent<SpriteRenderer>().sprite=Resources.Load("Images/Bar/Cards/card_1" + card_1);
            





        }



        public void TaskOnClick() {


        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}

