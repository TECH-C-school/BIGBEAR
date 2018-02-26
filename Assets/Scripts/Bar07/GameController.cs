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
        GameObject coin1;
        GameObject coin2;
        GameObject coin3;
        GameObject playerwin;
        GameObject bankerwin;
        GameObject history;
        GameObject winb;
        GameObject winp;
        public Text text1;
        public Text text2;
        public Text text3;
        public Text text4;
        public Text text5;
        public int mode = 1;
        public int a=0;
        public int b=0;
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
        public string h;



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
            coin1 = GameObject.Find("coin1");
            coin2 = GameObject.Find("coin2");
            coin3 = GameObject.Find("coin3");
            money = GameObject.Find("money");
            playerwin = GameObject.Find("playerwin");
            bankerwin = GameObject.Find("bankerwin");
            history = GameObject.Find("history");
            winb = GameObject.Find("winb");
            winp = GameObject.Find("winp");


            int a = 10000;
            int b = 1;
            





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
                Buttonsaihaichi.SetActive(false);
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
                coin1.SetActive(true);
                coin2.SetActive(true);
                coin3.SetActive(true);
                winp.SetActive(false);
                winb.SetActive(false);


            }
            if (mode == 0)
            {
                kakekin.SetActive(false);
                shengfu.SetActive(true);
                Buttonsaihaichi.SetActive(true);
                Buttonreset.SetActive(false);
                Buttonshoufu.SetActive(false);
                winsu.SetActive(true);
                coin1.SetActive(false);
                coin2.SetActive(false);
                coin3.SetActive(false);
                back1.SetActive(false);
                back2.SetActive(false);



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
            string card22 = card_2.Substring(1, card_2.Length - 1);
            string card33 = card_3.Substring(1, card_3.Length - 1);
            string card44 = card_4.Substring(1, card_4.Length - 1);
            string card55 = card_5.Substring(1, card_5.Length - 1);
            string card66 = card_6.Substring(1, card_6.Length - 1);

            int.TryParse(card11, out c1);
            int.TryParse(card22, out c2);
            int.TryParse(card33, out c3);
            int.TryParse(card44, out c4);
            int.TryParse(card55, out c5);
            int.TryParse(card66, out c6);
            if(c1>=10)
            { c1 = 0; }
            if (c2 >= 10)
            { c2 = 0; }
            if (c3 >= 10)
            { c3 = 0; }
            if (c4 >= 10)
            { c4 = 0; }
            if (c5 >= 10)
            { c5 = 0; }
            if (c6 >= 10)
            { c6 = 0; }
         
            


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
        public void re()
        {
            x = 0;
            y = 0;
            z = 0;
            coin1_text.GetComponent<Text>().text = x.ToString();
            coin2_text.GetComponent<Text>().text = y.ToString();
            coin3_text.GetComponent<Text>().text = z.ToString();
        }
        public void saihaichi()
        {
            mode = 1;
            modechange();
            haifu();
            re();
        }

        public void shoufu()
        {
            
           int player = c2 + c3;
            if (player > 10)
            {
                player = player - 10;
            }
           int banker = c5 + c6;
            if (banker > 10)
            {
                banker = banker - 10;
            }
            if (player > 8|| banker>8 )
            {
                card1.SetActive(false);
                card2.SetActive(true);
                card3.SetActive(true);
                card4.SetActive(false);
                card5.SetActive(true);
                card6.SetActive(true);
                string his;
                if (player > banker)
                {
                    a = a + 2 * x;
                    money.GetComponent<Text>().text = a.ToString();
                    d = d + 1;
                    playerwin.GetComponent<Text>().text = d.ToString();
                    his = "P";
                   
                    h = his+h;
                    history.GetComponent<Text>().text = h;
                    winp.SetActive(true);
                    
                }


                else if (player < banker)
                {
                    a = a + 2 * z;
                    money.GetComponent<Text>().text = a.ToString();
                    e = e + 1;
                    bankerwin.GetComponent<Text>().text = e.ToString();
                    his = "B";
                    h = his + h;
                    history.GetComponent<Text>().text = h;
                    winb.SetActive(true);
                }
                else
                {
                    a = a + 9 * y;
                    money.GetComponent<Text>().text = a.ToString();
                    his = "D";
                    h = his + h;
                    history.GetComponent<Text>().text = h;
                }


            }
            else if((player==5||player==6)&& (banker == 5 ||banker == 6))
            {
                card1.SetActive(false);
                card2.SetActive(true);
                card3.SetActive(true);
                card4.SetActive(false);
                card5.SetActive(true);
                card6.SetActive(true);
                string his;
                if (player > banker)
                {
                    a = a + 2 * x;
                    money.GetComponent<Text>().text = a.ToString();
                    d = d + 1;
                    playerwin.GetComponent<Text>().text = d.ToString();
                    his = "P";
                    h = his + h;
                    history.GetComponent<Text>().text = h;
                    winp.SetActive(true);

                }


                else if (player < banker)
                {
                    a = a + 2 * z;
                    money.GetComponent<Text>().text = a.ToString();
                    e = e + 1;
                    bankerwin.GetComponent<Text>().text = e.ToString();
                    his = "B";
                    h = his + h;
                    history.GetComponent<Text>().text = h;
                    winb.SetActive(true);
                }
                else
                {
                    a = a + 9 * y;
                    money.GetComponent<Text>().text = a.ToString();
                    his = "D";
                    h = his + h;
                    history.GetComponent<Text>().text = h;
                }


            }
            else
            {
                if (player < 6)
                {
                    player = player + c1;
                    if (player > 10)
                    {
                        player = player - 10;
                    }
                    card1.SetActive(true);
                    card2.SetActive(true);
                    card3.SetActive(true);
                    card5.SetActive(true);
                    card6.SetActive(true);
                    switch (c1)
                    {
                        case 0:if(banker<4)
                            {
                                banker = banker + c4;
                                if (banker > 10)
                                {
                                    banker = banker - 10;
                                }
                                card4.SetActive(true);
                            }
                            else
                            {
                                card4.SetActive(false);
                            }
                            break;
                        case 1:
                            if (banker < 4)
                            {
                                banker = banker + c4;
                                if (banker > 10)
                                {
                                    banker = banker - 10;
                                }
                                card4.SetActive(true);
                            }
                            else
                            {
                                card4.SetActive(false);
                            }
                            break;
                        case 2:
                            if (banker < 5)
                            {
                                banker = banker + c4;
                                if (banker > 10)
                                {
                                    banker = banker - 10;
                                }
                                card4.SetActive(true);
                            }
                            else
                            {
                                card4.SetActive(false);
                            }
                            break;
                        case 3:
                            if (banker < 5)
                            {
                                banker = banker + c4;
                                if (banker > 10)
                                {
                                    banker = banker - 10;
                                }
                                card4.SetActive(true);
                            }
                            else
                            {
                                card4.SetActive(false);
                            }
                            break;
                        case 4:
                            if (banker < 6)
                            {
                                banker = banker + c4;
                                if (banker > 10)
                                {
                                    banker = banker - 10;
                                }
                                card4.SetActive(true);
                            }
                            else
                            {
                                card4.SetActive(false);
                            }
                            break;
                        case 5:
                            if (banker < 6)
                            {
                                banker = banker + c4;
                                if (banker > 10)
                                {
                                    banker = banker - 10;
                                }
                                card4.SetActive(true);
                            }
                            else
                            {
                                card4.SetActive(false);
                            }
                            break;
                        case 6:
                            if (banker < 7)
                            {
                                banker = banker + c4;
                                if (banker > 10)
                                {
                                    banker = banker - 10;
                                }
                                card4.SetActive(true);
                            }
                            else
                            {
                                card4.SetActive(false);
                            }
                            break;
                        case 7:
                            if (banker < 7)
                            {
                                banker = banker + c4;
                                if (banker > 10)
                                {
                                    banker = banker - 10;
                                }
                                card4.SetActive(true);
                            }
                            else
                            {
                                card4.SetActive(false);
                            }
                            break;
                        case 8:
                            if (banker < 3)
                            {
                                banker = banker + c4;
                                if (banker > 10)
                                {
                                    banker = banker - 10;
                                }
                                card4.SetActive(true);
                            }
                            else
                            {
                                card4.SetActive(false);
                            }
                            break;

                        case 9:
                            if (banker < 4)
                            {
                                banker = banker + c4;
                                if (banker > 10)
                                {
                                    banker = banker - 10;
                                }
                                card4.SetActive(true);
                            }
                            else
                            {
                                card4.SetActive(false);
                            }
                            break;
                    }


                }else
                {
                    card1.SetActive(false);
                    card2.SetActive(true);
                    card3.SetActive(true);
                    card5.SetActive(true);
                    card6.SetActive(true);
                    if (banker < 6)
                    {
                        banker = banker + c4;
                        if (banker > 10)
                        {
                            banker = banker - 10;
                        }
                        card4.SetActive(true);
                    }
                    else
                    {
                        card4.SetActive(false);
                    }
                }
                string his;
                if (player > banker)
                {
                    a = a + 2 * x;
                    money.GetComponent<Text>().text = a.ToString();
                    d = d + 1;
                    playerwin.GetComponent<Text>().text = d.ToString();
                    his = "P";
                    h = his+h;
                    history.GetComponent<Text>().text = h;
                    winp.SetActive(true);

                }


                else if (player < banker)
                {
                    a = a + 2 * z;
                    money.GetComponent<Text>().text = a.ToString();
                    e = e + 1;
                    bankerwin.GetComponent<Text>().text = e.ToString();
                    his = "B";
                    h = his+h;
                    history.GetComponent<Text>().text = h;
                    winb.SetActive(true);
                }
                else
                {
                    a = a + 9 * y;
                    money.GetComponent<Text>().text = a.ToString();
                    his = "D";
                    h = his + h;
                    history.GetComponent<Text>().text = h;
                }


            }







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

