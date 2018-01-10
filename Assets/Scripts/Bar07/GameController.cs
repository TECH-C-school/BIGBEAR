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
        GameObject card1;
        GameObject card2;
        GameObject card3;
        GameObject card4;
        GameObject card5;
        GameObject card6;
        GameObject back1;
        GameObject back2;
        GameObject coin1_text;
        GameObject coin2_text;
        GameObject coin3_text;
        GameObject money;
        GameObject Buttonshoufu;
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
        int haifu_flag=0;
        public int x = 0;
        public int y = 0;
        public int z = 0;
        public int c1 = 0;
        public int c2 = 0;
        public int c3 = 0;
        public int c4 = 0;
        public int c5 = 0;
        public int c6 = 0;





        public void Start()
        {
             kakekin = GameObject.Find("kakekin");
             shengfu = GameObject.Find("shengfu");
             Buttonsaihaichi = GameObject.Find("Button(saihaichi)");
             Buttonreset = GameObject.Find("Button(reset)");
            Buttonshoufu = GameObject.Find("Button(shoufu)");
             winsu = GameObject.Find("winsu");
             card1 = GameObject.Find("back");
             card2 = GameObject.Find("back (1)");
             card3 = GameObject.Find("back (2)");
             card4 = GameObject.Find("back (3)");
             card5 = GameObject.Find("back (4)");
             card6 = GameObject.Find("back (5)");
             back1= GameObject.Find("back1");
             back2 = GameObject.Find("back2");
            coin1_text = GameObject.Find("coin1_text");
            coin2_text = GameObject.Find("coin2_text");
            coin3_text = GameObject.Find("coin3_text");
            money = GameObject.Find("money");
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

            


            modechange();


           
           
        }

        public void modechange()
        {
            if (mode == 1)
            {
                if (haifu_flag == 0)
                {
                    haifu();
                    haifu_flag = 1;

                }

                kakekin.SetActive(true);
                shengfu.SetActive(false);
                Buttonsaihaichi.SetActive(true);
                Buttonreset.SetActive(true);
                Buttonshoufu.SetActive(true);
                winsu.SetActive(false);
                card1.SetActive(false);
                card2.SetActive(true);
                card3.SetActive(false);
                card4.SetActive(false);
                card5.SetActive(true);
                card6.SetActive(false);
                back1.SetActive(true);
                back2.SetActive(true);

            }
            if (mode == 0)
            {
                kakekin.SetActive(false);
                shengfu.SetActive(true);
                Buttonsaihaichi.SetActive(false);
                Buttonreset.SetActive(false);
                Buttonshoufu.SetActive(false);
                winsu.SetActive(true);



            }

            //mode 1は掛け金、0は勝負
        }


        public void Update()
        {


        }


        public void haifu()
        {
            for (int i = 0; i < 4; i++)
            {
                string tempcard_f = null;
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

                for (int j = 1; j < 10; j++)
                {
                    string tempcard = null;

                    tempcard = tempcard_f + "0" + j;

                    cardlist.Add(tempcard);
                }
                for(int j = 10; j < 14; j++)
                {
                    string tempcard = null;

                    tempcard = tempcard_f  + j;

                    cardlist.Add(tempcard);
                }
                

            }

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
            z = Random.Range(1,51);
            card_2 = cardlist[z];
            cardlist.Remove(cardlist[z]);
            z = Random.Range(1,50);
            card_3 = cardlist[z];
            cardlist.Remove(cardlist[z]);
            z = Random.Range(1,49);
            card_4 = cardlist[z];
            cardlist.Remove(cardlist[z]);
            z = Random.Range(1,48);
            card_5 = cardlist[z];
            cardlist.Remove(cardlist[z]);
            z = Random.Range(1,47);
            card_6 = cardlist[z];
            cardlist.Remove(cardlist[z]);





            card1.GetComponent<SpriteRenderer>().sprite=　Resources.Load<Sprite>("Images/Bar/Cards/" + card_1);
            card2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + card_2);
            card3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + card_3);
            card4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + card_4);
            card5.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + card_5);
            card6.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + card_6);


            string card11 = card_1.Substring(1, card_1.Length-1);
            int.TryParse(card_1,out c1);
            int.TryParse(card_2, out c2);
            int.TryParse(card_3, out c3);
            int.TryParse(card_4, out c4);
            int.TryParse(card_5, out c5);
            int.TryParse(card_6, out c6);
            Debug.Log(card_1);
            Debug.Log(card_2);
            Debug.Log(card_3);
            Debug.Log(card_4);
            Debug.Log(card_5);
            Debug.Log(card_6);
            Debug.Log(c1);
            Debug.Log(c2);
            Debug.Log(c3);
            Debug.Log(c4);
            Debug.Log(c5);
            Debug.Log(c6);



        }

        public void cb1()
        {
            
            x = x + 1;
            a = a - 1;
            coin1_text.GetComponent<Text>().text = x.ToString();
            money.GetComponent<Text>().text = a.ToString();
        }

        public void cb2()
        {

            y = y + 1;
            a = a - 1;
            coin2_text.GetComponent<Text>().text = y.ToString();
            money.GetComponent<Text>().text = a.ToString();
        }
        public void cb3()
        {

            z = z + 1;
            a = a - 1;
            coin3_text.GetComponent<Text>().text = z.ToString();
            money.GetComponent<Text>().text = a.ToString();
        }
        //発注

        public void riset()
        {
            a = a + x + y + z;
            x = 0;
            y = 0;
            z = 0;
            coin1_text.GetComponent<Text>().text = x.ToString();
            coin2_text.GetComponent<Text>().text = y.ToString();
            coin3_text.GetComponent<Text>().text = z.ToString();
            money.GetComponent<Text>().text = a.ToString();
        }

        public void saihaichi()
        {
            haifu();
            riset();
        }

        public void shoufu()
        {
            



            mode = 0;
            modechange();
        }




        public void TaskOnClick() {


        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}

