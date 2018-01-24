using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour {

        static int coin = 100;
        static int BET = 1;
        static int count1;
        static int count2;
        static int count3;
        static int count4;
        static int count5;
        static List<int> List = new List<int>(52);
        static int[] numbers = new int[5];

        void Start()
        {
            InitGame();
            var Coin = GameObject.Find("Coin");
            var num0 = Resources.Load<GameObject>("Prefabs/Bar04/Number/t_0");
            num0 = Instantiate(num0, transform.position, Quaternion.identity);
            num0.transform.position = new Vector2(-2,-4);
            num0.transform.parent = Coin.transform;
            num0 = Instantiate(num0, transform.position, Quaternion.identity);
            num0.transform.position = new Vector2(-2.5f, -4);
            num0.transform.parent = Coin.transform;
            var num5 = Resources.Load<GameObject>("Prefabs/Bar04/Number/t_1");
            num5 = Instantiate(num5, transform.position, Quaternion.identity);
            num5.transform.position = new Vector2(-3f, -4);
            num5.transform.parent = Coin.transform;
            var Bet = GameObject.Find("Bet");
            var num1 = Resources.Load<GameObject>("Prefabs/Bar04/Number/t_1");
            num1 = Instantiate(num1, transform.position, Quaternion.identity);
            num1.transform.position = new Vector2(3.2f, -4);
            num1.transform.parent = Bet.transform;
        }
        void Update()
        {
           //Click();
        }
        public void ClickFightButton()
        {
            if (coin != 0)
            {
                GameObject cardsObject = GameObject.Find("Cards");
                //Cardsの子要素を消す
                foreach (Transform cardObject in cardsObject.transform)
                {
                    Destroy(cardObject.gameObject);
                }
                //デッキを作る
                MakeDeck();
                //山札の上から5枚を配る
                for (var j = 0; j < 5; j++)
                {
                    numbers[j] = LoadCard(List[j], j);
                }
                //Fightボタンを移動(非表示)する
                transform.position = new Vector2(1011, -100);
                //Changeボタン、NotChangeボタンを移動(表示)する
                var change = GameObject.Find("Change");
                change.transform.position = new Vector2(1011, 50);
                var notchange = GameObject.Find("NotChange");
                notchange.transform.position = new Vector2(1011, 142);
            } else {
                Debug.Log("coinがありません");
            }
        }
        public void ClickChangeButton()
        {
            int counter = 5;
            //選択ボタンで選択されているカードを交換する
            var childTransform = GameObject.Find("RandomCards").GetComponentsInChildren<Transform>();
            if (count1 == 1)
            {
                Destroy(childTransform[1].gameObject);
                numbers[0] = LoadCard(List[counter], 0);
                counter++;
            }
            if (count2 == 1)
            {
                Destroy(childTransform[2].gameObject);
                numbers[1] = LoadCard(List[counter], 1);
                counter++;
            }
            if (count3 == 1)
            {
                Destroy(childTransform[3].gameObject);
                numbers[2] = LoadCard(List[counter], 2);
                counter++;
            }
            if (count4 == 1)
            {
                Destroy(childTransform[4].gameObject);
                numbers[3] = LoadCard(List[counter], 3);
                counter++;
            }
            if (count5 == 1)
            {
                Destroy(childTransform[5].gameObject);
                numbers[4] = LoadCard(List[counter], 4);
                counter++;
            }
            ButtonAndFlame();
            Prize();
        }
        public void ClickNotChangebutton()
        {
            ButtonAndFlame();
            Prize();
        }
        public void ClickResetButton()
        {
            var cardsObject = GameObject.Find("RandomCards");
            foreach (Transform cardObject in cardsObject.transform)
            {
                Destroy(cardObject.gameObject);
            }
            InitGame();
        }
        public void ButtonAndFlame()
        {
            //ChangeボタンとNotChangeボタンを移動(非表示)する
            var change = GameObject.Find("Change");
            change.transform.position = new Vector2(-100, 0);
            var notchange = GameObject.Find("NotChange");
            notchange.transform.position = new Vector2(-100, 0);
            //Resetボタンを移動(表示)する
            var reset = GameObject.Find("Reset");
            reset.transform.position = new Vector2(1011, 74);
            //カードの枠を消す
            var flame = GameObject.Find("CardFlame");
            foreach (Transform cardObject in flame.transform)
            {
                Destroy(cardObject.gameObject);
            }
            //選択ボタンの
            count1 = 0;
            count2 = 0;
            count3 = 0;
            count4 = 0;
            count5 = 0;
        }
        /// <summary>
        /// 役の判定
        /// </summary>
        public void Prize()
        {
            var win = GameObject.Find("bakarawin");
            int counter = 0;
            int x = 0;
            while(x < 1)
            {
                int min = 52;
                int max = 0;
                //ロイヤルストレートフラッシュ
                for (int j = 0; j < 5; j++)
                {
                    if (numbers[j] < min)
                    {
                        min = numbers[j];
                    }
                    if (numbers[j] > max)
                    {
                        max = numbers[j];
                    }
                }
                if (numbers[0] != numbers[1] && numbers[0] != numbers[2] && numbers[0] != numbers[3] && numbers[0] != numbers[4] && numbers[2] != numbers[1] && numbers[3] != numbers[1] && numbers[4] != numbers[1] && numbers[2] != numbers[3] && numbers[2] != numbers[4] && numbers[3] != numbers[4])
                {
                    if (numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4] == 42 || numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4] == 107 || numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4] == 172 || numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4] == 237 && min == 0)
                    {
                        counter = 8;
                        win.transform.position = new Vector2(0, 3.75f);
                        break;
                    }
                }
                //ストレートフラッシュ
                if (numbers[0] >= 0 && numbers[0] < 13 && numbers[1] >= 0 && numbers[1] < 13 && numbers[2] >= 0 && numbers[2] < 13 && numbers[3] >= 0 && numbers[3] < 13 && numbers[4] >= 0 && numbers[4] < 13 || numbers[0] >= 13 && numbers[0] < 26 && numbers[1] >= 13 && numbers[1] < 26 && numbers[2] >= 13 && numbers[2] < 26 && numbers[3] >= 13 && numbers[3] < 26 && numbers[4] >= 13 && numbers[4] < 26 || numbers[0] >= 26 && numbers[0] < 39 && numbers[1] >= 26 && numbers[1] < 39 && numbers[2] >= 26 && numbers[2] < 39 && numbers[3] >= 26 && numbers[3] < 39 && numbers[4] >= 26 && numbers[4] < 39 || numbers[0] >= 39 && numbers[0] < 52 && numbers[1] >= 39 && numbers[1] < 52 && numbers[2] >= 39 && numbers[2] < 52 && numbers[3] >= 39 && numbers[3] < 52 && numbers[4] >= 39 && numbers[4] < 52)
                {
                    if (numbers[0] != numbers[1] && numbers[0] != numbers[2] && numbers[0] != numbers[3] && numbers[0] != numbers[4] && numbers[2] != numbers[1] && numbers[3] != numbers[1] && numbers[4] != numbers[1] && numbers[2] != numbers[3] && numbers[2] != numbers[4] && numbers[3] != numbers[4])
                    {
                        if (max - min == 4)
                        {
                            counter = 7;
                            win.transform.position = new Vector2(0, 3.75f);
                            break;
                        }
                    }
                }
                
                //フラッシュ
                if (numbers[0] >= 0 && numbers[0] < 13 && numbers[1] >= 0 && numbers[1] < 13 && numbers[2] >= 0 && numbers[2] < 13 && numbers[3] >= 0 && numbers[3] < 13 && numbers[4] >= 0 && numbers[4] < 13 || numbers[0] >= 13 && numbers[0] < 26 && numbers[1] >= 13 && numbers[1] < 26 && numbers[2] >= 13 && numbers[2] < 26 && numbers[3] >= 13 && numbers[3] < 26 && numbers[4] >= 13 && numbers[4] < 26 || numbers[0] >= 26 && numbers[0] < 39 && numbers[1] >= 26 && numbers[1] < 39 && numbers[2] >= 26 && numbers[2] < 39 && numbers[3] >= 26 && numbers[3] < 39 && numbers[4] >= 26 && numbers[4] < 39 || numbers[0] >= 39 && numbers[0] < 52 && numbers[1] >= 39 && numbers[1] < 52 && numbers[2] >= 39 && numbers[2] < 52 && numbers[3] >= 39 && numbers[3] < 52 && numbers[4] >= 39 && numbers[4] < 52)
                {
                    counter = 4;
                    win.transform.position = new Vector2(0, 3.75f);
                    break;
                }
                for (int i = 0; i < 5; i++)
                {
                    if (numbers[i] >= 13)
                    {
                        if (numbers[i] >= 26)
                        {
                            if (numbers[i] >= 39)
                            {
                                numbers[i] = numbers[i] -= 13;
                            }
                            numbers[i] = numbers[i] -= 13;
                        }
                        numbers[i] = numbers[i] -= 13;
                    }
                }
                int min2 = 52;
                int max2 = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (numbers[j] < min2)
                    {
                        min2 = numbers[j];
                    }
                    if (numbers[j] > max2)
                    {
                        max2 = numbers[j];
                    }
                }
                //フォーカード
                if (numbers[0] == numbers[1] && numbers[0] == numbers[2] && numbers[0] == numbers[3] || numbers[0] == numbers[1] && numbers[0] == numbers[2] && numbers[0] == numbers[4] || numbers[0] == numbers[1] && numbers[0] == numbers[3] && numbers[0] == numbers[4] || numbers[0] == numbers[4] && numbers[0] == numbers[2] && numbers[0] == numbers[3] || numbers[1] == numbers[4] && numbers[1] == numbers[2] && numbers[1] == numbers[3])
                {
                    counter = 6;
                    win.transform.position = new Vector2(0, 3.75f);
                    break;
                }
                //フルハウス
                if (numbers[0] == numbers[1] && numbers[0] == numbers[2] && numbers[3] == numbers[4] || numbers[0] == numbers[1] && numbers[0] == numbers[3] && numbers[2] == numbers[4] || numbers[0] == numbers[1] && numbers[0] == numbers[4] && numbers[2] == numbers[3] || numbers[0] == numbers[2] && numbers[0] == numbers[3] && numbers[1] == numbers[4] || numbers[0] == numbers[2] && numbers[0] == numbers[4] && numbers[1] == numbers[3] || numbers[0] == numbers[3] && numbers[0] == numbers[4] && numbers[1] == numbers[2] || numbers[1] == numbers[2] && numbers[1] == numbers[3] && numbers[0] == numbers[4] || numbers[1] == numbers[2] && numbers[1] == numbers[4] && numbers[0] == numbers[3] || numbers[1] == numbers[3] && numbers[1] == numbers[4] && numbers[0] == numbers[2] || numbers[2] == numbers[3] && numbers[2] == numbers[4] && numbers[0] == numbers[1])
                {
                    counter = 5;
                    win.transform.position = new Vector2(0, 3.75f);
                    break;
                }
                //ストレート
                if (numbers[0] != numbers[1] && numbers[0] != numbers[2] && numbers[0] != numbers[3] && numbers[0] != numbers[4] && numbers[2] != numbers[1] && numbers[3] != numbers[1] && numbers[4] != numbers[1] && numbers[2] != numbers[3] && numbers[2] != numbers[4] && numbers[3] != numbers[4])
                {
                    if (max2 - min2 == 4)
                    {
                        counter = 3;
                        win.transform.position = new Vector2(0, 3.75f);
                        break;
                    }
                }
                //スリーカード
                if (numbers[0] == numbers[1] && numbers[0] == numbers[2] || numbers[0] == numbers[1] && numbers[0] == numbers[3] || numbers[0] == numbers[1] && numbers[0] == numbers[4] || numbers[0] == numbers[2] && numbers[0] == numbers[3] || numbers[0] == numbers[2] && numbers[0] == numbers[4] || numbers[0] == numbers[3] && numbers[0] == numbers[4] || numbers[1] == numbers[2] && numbers[1] == numbers[3] || numbers[1] == numbers[2] && numbers[1] == numbers[4] || numbers[1] == numbers[3] && numbers[1] == numbers[4] || numbers[2] == numbers[3] && numbers[2] == numbers[4])
                {
                    counter = 2;
                    win.transform.position = new Vector2(0, 3.75f);
                    break;
                }

                //ツーペア
                if (numbers[0] == numbers[1] && numbers[2] == numbers[3] || numbers[0] == numbers[1] && numbers[2] == numbers[4] || numbers[0] == numbers[1] && numbers[3] == numbers[4] || numbers[0] == numbers[2] && numbers[1] == numbers[3] || numbers[0] == numbers[2] && numbers[1] == numbers[4] || numbers[0] == numbers[2] && numbers[3] == numbers[4] || numbers[0] == numbers[3] && numbers[1] == numbers[2] || numbers[0] == numbers[3] && numbers[1] == numbers[4] || numbers[0] == numbers[3] && numbers[2] == numbers[4] || numbers[0] == numbers[4] && numbers[1] == numbers[2] || numbers[0] == numbers[4] && numbers[1] == numbers[3] || numbers[0] == numbers[4] && numbers[2] == numbers[3] || numbers[1] == numbers[2] && numbers[3] == numbers[4])
                {
                    counter = 1;
                    win.transform.position = new Vector2(0, 3.75f);
                    break;
                }
                x += 2;
                //loseを移動(表示)する
                var lose = GameObject.Find("bakaralose");
                lose.transform.position = new Vector2(0, 3.75f);
            }
            if (counter == 1)
            {
                Debug.Log("ツーペア");
            }
            else if (counter == 2)
            {
                Debug.Log("スリーカード");
            }
            else if (counter == 3)
            {
                Debug.Log("ストレード");
            }
            else if (counter == 4)
            {
                Debug.Log("フラッシュ");
            }
            else if (counter == 5)
            {
                Debug.Log("フルハウス");
            }
            else if (counter == 6)
            {
                Debug.Log("フォーカード");
            }
            else if (counter == 7)
            {
                Debug.Log("ストレートフラッシュ");
            }
            else if (counter == 8)
            {
                Debug.Log("ロイヤルストレートフラッシュ");
            }
            Dividend(counter);
        }
        public void Dividend(int x)
        {
            if (x == 0)
            {
                coin = coin -= BET;
                FindNumbers();
            }
            else if (x == 1)
            {
                coin = coin -= BET;
                coin = coin += BET * 1;
                FindNumbers();
            }
            else if (x == 2)
            {
                coin = coin -= BET;
                coin = coin += BET * 2;
                FindNumbers();
            }
            else if (x == 3)
            {
                coin = coin -= BET;
                coin = coin += BET * 3;
                FindNumbers();
            }
            else if (x == 4)
            {
                coin = coin -= BET;
                coin = coin += BET * 5;
                FindNumbers();
            }
            else if (x == 5)
            {
                coin = coin -= BET;
                coin = coin += BET * 10;
                FindNumbers();
            }
            else if (x == 6)
            {
                coin = coin -= BET;
                coin = coin += BET * 15;
                FindNumbers();
            }
            else if (x == 7)
            {
                coin = coin -= BET;
                coin = coin += BET * 30;
                FindNumbers();
            }
            else if (x == 8)
            {
                coin = coin -= BET;
                coin = coin += BET * 100;
                FindNumbers();
            }
        }
        public void FindNumbers()
        {
            var Coin = GameObject.Find("Coin").transform;
            foreach (Transform cardObject in Coin.transform)
            {
                Destroy(cardObject.gameObject);
            }
            int x = 0;
            if (coin >= 100)
            {
                if (coin >= 200)
                {
                    if (coin >= 300)
                    {
                        if (coin >= 400)
                        {
                            if (coin >= 500)
                            {
                                if (coin >= 600)
                                {
                                    if (coin >= 700)
                                    {
                                        if (coin >= 800)
                                        {
                                            if (coin >= 900)
                                            {
                                                coin -= 100;
                                                x += 1;
                                            }
                                            coin -= 100;
                                            x += 1;
                                        }
                                        coin -= 100;
                                        x += 1;
                                    }
                                    coin -= 100;
                                    x += 1;
                                }
                                coin -= 100;
                                x += 1;
                            }
                            coin -= 100;
                            x += 1;
                        }
                        coin -= 100;
                        x += 1;
                    }
                    coin -= 100;
                    x += 1;
                }
                coin -= 100;
                x += 1;
            }
            switch (coin)
            {
                case 1:
                case 11:
                case 21:
                case 31:
                case 41:
                case 51:
                case 61:
                case 71:
                case 81:
                case 91:
                    LoadNumber2(1, 1);
                    break;
                case 2:
                case 12:
                case 22:
                case 32:
                case 42:
                case 52:
                case 62:
                case 72:
                case 82:
                case 92:
                    LoadNumber2(2, 1);
                    break;
                case 3:
                case 13:
                case 23:
                case 33:
                case 43:
                case 53:
                case 63:
                case 73:
                case 83:
                case 93:
                    LoadNumber2(3, 1);
                    break;
                case 4:
                case 14:
                case 24:
                case 34:
                case 44:
                case 54:
                case 64:
                case 74:
                case 84:
                case 94:
                    LoadNumber2(4, 1);
                    break;
                case 5:
                case 15:
                case 25:
                case 35:
                case 45:
                case 55:
                case 65:
                case 75:
                case 85:
                case 95:
                    LoadNumber2(5, 1);
                    break;
                case 6:
                case 16:
                case 26:
                case 36:
                case 46:
                case 56:
                case 66:
                case 76:
                case 86:
                case 96:
                    LoadNumber2(6, 1);
                    break;
                case 7:
                case 17:
                case 27:
                case 37:
                case 47:
                case 57:
                case 67:
                case 77:
                case 87:
                case 97:
                    LoadNumber2(7, 1);
                    break;
                case 8:
                case 18:
                case 28:
                case 38:
                case 48:
                case 58:
                case 68:
                case 78:
                case 88:
                case 98:
                    LoadNumber2(8, 1);
                    break;
                case 9:
                case 19:
                case 29:
                case 39:
                case 49:
                case 59:
                case 69:
                case 79:
                case 89:
                case 99:
                    LoadNumber2(9, 1);
                    break;
                case 0:
                case 10:
                case 20:
                case 30:
                case 40:
                case 50:
                case 60:
                case 70:
                case 80:
                case 90:
                    LoadNumber2(0, 1);
                    break;
            }
            if (coin >= 10)
            {
                switch (coin)
                {
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                        LoadNumber2(1, 0);
                        break;
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                    case 26:
                    case 27:
                    case 28:
                    case 29:
                        LoadNumber2(2, 0);
                        break;
                    case 30:
                    case 31:
                    case 32:
                    case 33:
                    case 34:
                    case 35:
                    case 36:
                    case 37:
                    case 38:
                    case 39:
                        LoadNumber2(3, 0);
                        break;
                    case 40:
                    case 41:
                    case 42:
                    case 43:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                        LoadNumber2(4, 0);
                        break;
                    case 50:
                    case 51:
                    case 52:
                    case 53:
                    case 54:
                    case 55:
                    case 56:
                    case 57:
                    case 58:
                    case 59:
                        LoadNumber2(5, 0);
                        break;
                    case 60:
                    case 61:
                    case 62:
                    case 63:
                    case 64:
                    case 65:
                    case 66:
                    case 67:
                    case 68:
                    case 69:
                        LoadNumber2(6, 0);
                        break;
                    case 70:
                    case 71:
                    case 72:
                    case 73:
                    case 74:
                    case 75:
                    case 76:
                    case 77:
                    case 78:
                    case 79:
                        LoadNumber2(7, 0);
                        break;
                    case 80:
                    case 81:
                    case 82:
                    case 83:
                    case 84:
                    case 85:
                    case 86:
                    case 87:
                    case 88:
                    case 89:
                        LoadNumber2(8, 0);
                        break;
                    case 90:
                    case 91:
                    case 92:
                    case 93:
                    case 94:
                    case 95:
                    case 96:
                    case 97:
                    case 98:
                    case 99:
                        LoadNumber2(9, 0);
                        break;
                }
            }
            else
            {
                LoadNumber2(0, 0);
            }
            if (x >= 1)
            {
                switch (x)
                {
                    case 1:
                        LoadNumber2(1, -1);
                        break;
                    case 2:
                        LoadNumber2(2, -1);
                        break;
                    case 3:
                        LoadNumber2(3, -1);
                        break;
                    case 4:
                        LoadNumber2(4, -1);
                        break;
                    case 5:
                        LoadNumber2(5,-1);
                        break;
                    case 6:
                        LoadNumber2(6,-1);
                        break;
                    case 7:
                        LoadNumber2(7,-1);
                        break;
                    case 8:
                        LoadNumber2(8,-1);
                        break;
                    case 9:
                        LoadNumber2(9,-1);
                        break;
                }
                if (x == 1)
                {
                    if (x == 2)
                    {
                        if (x == 3)
                        {
                            if (x == 4)
                            {
                                if (x == 5)
                                {
                                    if (x == 6)
                                    {
                                        if (x == 7)
                                        {
                                            if (x == 8)
                                            {
                                                if (x == 9)
                                                {
                                                    coin += 100;
                                                }
                                                coin += 100;
                                            }
                                            coin += 100;
                                        }
                                        coin += 100;
                                    }
                                    coin += 100;
                                }
                                coin += 100;
                            }
                            coin += 100;
                        }
                        coin += 100;
                    }
                    coin += 100;
                }
            }
        }
        /// <summary>
        /// カード選択時のflameをつける
        /// </summary>
        public int Counter(int x,int y)
        {
            var serectFlame = Resources.Load<GameObject>("Prefabs/Bar04/cardSerect");
            var flameBox = GameObject.Find("CardFlame");
            if (x == 0)
            {
                //カードを選択する

                var cardFlame = Instantiate(serectFlame, transform.position, Quaternion.identity);
                cardFlame.transform.parent = flameBox.transform;
                cardFlame.name = "cardSerect" + (y+1);
                cardFlame.transform.position = new Vector3(y * 2.5f - 5, 0.5f, -1);
                x = 1;
            }
            else
            {
                //カードの選択を解除する
                var cardFlame = GameObject.Find("cardSerect" + (y+1));
                Destroy(cardFlame);
                x = 0;
            }
            return x;
        }
        /// <summary>
        /// それぞれの選択ボタンの処理
        /// </summary>
        public void SerectButton1()
        {
            count1 = Counter(count1,0);
        }
        public void SerectButton2()
        {
            count2 = Counter(count2,1);
        }
        public void SerectButton3()
        {
            count3 = Counter(count3,2);
        }
        public void SerectButton4()
        {
            count4 = Counter(count4,3);
        }
        public void SerectButton5()
        {
            count5 = Counter(count5,4);
        }
        
        /// <summary>
        /// 山札を作成する
        /// </summary>
        public void MakeDeck()
        {
            //Listに0～51までの数値を追加する
            for (int i = 0; i < 52; i++)
            {
                List.Add(i);
            }
            //Fisher-Yatesアルゴリズムでシャッフルする
            System.Random rng = new System.Random();
            int n = 52;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int tmp = List[k];
                List[k] = List[n];
                List[n] = tmp;
            }
        }
        /// <summary>
        /// ゲームを初期状態に戻す関数
        /// </summary>
        public void InitGame()
        {
            numbers = new int[5];
            //裏面のカードを配置
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/card");
            var Card = GameObject.Find("Cards");
            for (var i = 0; i < 5; i++)
            {
                var cardObbject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObbject.transform.position = new Vector2(i * 2.5f - 5, 0.5f);
                cardObbject.transform.parent = Card.transform;
            }
            //Fightボタンを移動(表示)する
            var fihgt = GameObject.Find("Fight");
            fihgt.transform.position = new Vector2(1011, 74);
            //Fightボタン以外を移動(非表示)する
            var change = GameObject.Find("Change");
            change.transform.position = new Vector2(1011, -100);
            var notchange = GameObject.Find("NotChange");
            notchange.transform.position = new Vector2(1011, -100);
            var reset = GameObject.Find("Reset");
            reset.transform.position = new Vector2(1011, -200);
            var lose = GameObject.Find("bakaralose");
            lose.transform.position = new Vector2(-100,0);
            var win = GameObject.Find("bakarawin");
            win.transform.position = new Vector2(-100, 0);
            
        }
        /// <summary>
        /// BET枚数を変更するボタン
        /// </summary>
        public void BetUp()
        {
            var Coin = GameObject.Find("Coin").transform;
            var Bet = GameObject.Find("Bet").transform;
            if(BET >= coin)
            {
                Debug.Log("これ以上BETできません");
            }
            else if(BET < 99)
            {
                foreach (Transform cardObject in Bet.transform)
                {
                    Destroy(cardObject.gameObject);
                }
                BET++;
                switch (BET)
                {
                    case 1:case 11:case 21:case 31:case 41:case 51:case 61:case 71:case 81:case 91:
                        LoadNumber(1, 1);
                        break;
                    case 2:case 12:case 22:case 32:case 42:case 52:case 62:case 72:case 82:case 92:
                        LoadNumber(2, 1);
                        break;
                    case 3:case 13:case 23:case 33:case 43:case 53:case 63:case 73:case 83:case 93:
                        LoadNumber(3, 1);
                        break;
                    case 4:case 14:case 24:case 34:case 44:case 54:case 64:case 74:case 84:case 94:
                        LoadNumber(4, 1);
                        break;
                    case 5:case 15:case 25:case 35:case 45:case 55:case 65:case 75:case 85:case 95:
                        LoadNumber(5, 1);
                        break;
                    case 6:case 16:case 26:case 36:case 46:case 56:case 66:case 76:case 86:case 96:
                        LoadNumber(6, 1);
                        break;
                    case 7:case 17:case 27:case 37:case 47:case 57:case 67:case 77:case 87:case 97:
                        LoadNumber(7, 1);
                        break;
                    case 8:case 18:case 28:case 38:case 48:case 58:case 68:case 78:case 88:case 98:
                        LoadNumber(8, 1);
                        break;
                    case 9:case 19:case 29:case 39:case 49:case 59:case 69:case 79:case 89:case 99:
                        LoadNumber(9, 1);
                        break;
                    case 10:case 20:case 30:case 40:case 50:case 60:case 70:case 80:case 90:
                        LoadNumber(0, 1);
                        break;
                }
                if (BET >= 10)
                {
                    switch (BET)
                    {
                        case 10:case 11:case 12:case 13:case 14:case 15:case 16:case 17:case 18:case 19:
                            LoadNumber(1,0);
                            break;
                        case 20:case 21:case 22:case 23:case 24:case 25:case 26:case 27:case 28:case 29:
                            LoadNumber(2,0);
                            break;
                        case 30:case 31:case 32:case 33:case 34:case 35:case 36:case 37:case 38:case 39:
                            LoadNumber(3,0);
                            break;
                        case 40:case 41:case 42:case 43:case 44:case 45:case 46:case 47:case 48:case 49:
                            LoadNumber(4,0);
                            break;
                        case 50:case 51:case 52:case 53:case 54:case 55:case 56:case 57:case 58:case 59:
                            LoadNumber(5,0);
                            break;
                        case 60:case 61:case 62:case 63:case 64:case 65:case 66:case 67:case 68:case 69:
                            LoadNumber(6,0);
                            break;
                        case 70:case 71:case 72:case 73:case 74:case 75:case 76:case 77:case 78:case 79:
                            LoadNumber(7,0);
                            break;
                        case 80:case 81:case 82:case 83:case 84:case 85:case 86:case 87:case 88:case 89:
                            LoadNumber(8,0);
                            break;
                        case 90:case 91:case 92:case 93:case 94:case 95:case 96:case 97:case 98:case 99:
                            LoadNumber(9,0);
                            break;
                    }
                }
            }
            else
            {
                Debug.Log("MAXBETです");
            }
        }
        public void BetDown()
        {
            var Bet = GameObject.Find("Bet").transform;
            var Coin = GameObject.Find("Coin").transform;
            if (BET > 1)
            {
                foreach (Transform cardObject in Bet.transform)
                {
                    Destroy(cardObject.gameObject);
                }
                BET--;
                switch (BET)
                {
                    case 1:case 11:case 21:case 31:case 41:case 51:case 61:case 71:case 81:case 91:
                        LoadNumber(1, 1);
                        break;
                    case 2:case 12:case 22:case 32:case 42:case 52:case 62:case 72:case 82:case 92:
                        LoadNumber(2, 1);
                        break;
                    case 3:case 13:case 23:case 33:case 43:case 53:case 63:case 73:case 83:case 93:
                        LoadNumber(3, 1);
                        break;
                    case 4:case 14:case 24:case 34:case 44:case 54:case 64:case 74:case 84:case 94:
                        LoadNumber(4, 1);
                        break;
                    case 5:case 15:case 25:case 35:case 45:case 55:case 65:case 75:case 85:case 95:
                        LoadNumber(5, 1);
                        break;
                    case 6:case 16:case 26:case 36:case 46:case 56:case 66:case 76:case 86:case 96:
                        LoadNumber(6, 1);
                        break;
                    case 7:case 17:case 27:case 37:case 47:case 57:case 67:case 77:case 87:case 97:
                        LoadNumber(7, 1);
                        break;
                    case 8:case 18:case 28:case 38:case 48:case 58:case 68:case 78:case 88:case 98:
                        LoadNumber(8, 1);
                        break;
                    case 9:case 19:case 29:case 39:case 49:case 59:case 69:case 79:case 89:case 99:
                        LoadNumber(9, 1);
                        break;
                    case 10:case 20:case 30:case 40:case 50:case 60:case 70:case 80:case 90:
                        LoadNumber(0, 1);
                        break;
                }
                if (BET >= 10)
                {
                    switch (BET)
                    {
                        case 10:case 11:case 12:case 13:case 14: case 15: case 16: case 17:case 18:case 19:
                            LoadNumber(1,0);
                            break;
                        case 20:case 21:case 22:case 23:case 24:case 25:case 26:case 27:case 28:case 29:
                            LoadNumber(2,0);
                            break;
                        case 30:case 31:case 32:case 33: case 34:case 35:case 36:case 37: case 38: case 39:
                            LoadNumber(3,0);
                            break;
                        case 40: case 41: case 42:case 43:case 44:case 45:case 46:case 47:case 48:case 49:
                            LoadNumber(4,0);
                            break;
                        case 50: case 51:case 52:case 53:case 54:case 55:case 56:case 57:case 58: case 59:
                            LoadNumber(5,0);
                            break;
                        case 60:case 61:case 62:case 63: case 64:case 65: case 66:case 67:case 68:case 69:
                            LoadNumber(6,0);
                            break;
                        case 70:case 71:case 72:case 73:case 74:case 75:case 76:case 77:case 78:  case 79:
                            LoadNumber(7,0);
                            break;
                        case 80:case 81:case 82:case 83:case 84:case 85:case 86:case 87:case 88:case 89:
                            LoadNumber(8,0);
                            break;
                        case 90:case 91: case 92:case 93:case 94:case 95:case 96: case 97: case 98: case 99:
                            LoadNumber(9,0);
                            break;
                        
                    }
                }
            }
            else
            {
                Debug.Log("MINBETです");
            }
        }
        public void LoadNumber(int x,int y)
        {
            var bet = GameObject.Find("Bet");
            var num = Resources.Load<GameObject>("Prefabs/Bar04/Number/t_" + x);
            num = Instantiate(num, transform.position, Quaternion.identity);
            num.transform.position = new Vector2(2.7f + (y*0.5f),-4);
            num.transform.parent = bet.transform;
        }
        public void LoadNumber2(int x, int y)
        {
            var coin = GameObject.Find("Coin");
            var num = Resources.Load<GameObject>("Prefabs/Bar04/Number/t_" + x);
            num = Instantiate(num, transform.position, Quaternion.identity);
            num.transform.position = new Vector2(-2.5f + (y * 0.5f), -4);
            num.transform.parent = coin.transform;
        }
        public int LoadCard(int x, int y)
        {
            var RandomCrads = GameObject.Find("RandomCards");
            if (x == 0)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c01");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 1)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c02");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 2)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c03");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 3)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c04");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 4)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c05");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 5)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c06");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 6)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c07");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 7)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c08");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 8)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c09");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 9)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c10");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 10)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c11");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 11)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c12");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 12)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c13");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 13)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h01");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 14)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h02");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 15)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h03");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 16)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h04");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 17)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h05");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 18)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h06");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 19)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h07");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 20)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h08");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 21)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h09");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 22)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h10");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 23)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h11");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 24)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h12");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 25)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h13");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 26)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d01");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 27)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d02");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 28)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d03");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 29)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d04");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 30)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d05");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 31)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d06");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 32)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d07");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 33)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d08");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 34)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d09");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 35)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d10");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 36)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d11");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 37)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d12");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 38)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d13");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 39)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s01");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 40)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s02");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 41)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s03");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 42)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s04");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 43)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s05");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 44)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s06");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 45)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s07");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 46)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s08");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 47)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s09");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 48)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s10");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 49)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s11");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 50)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s12");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 51)
            {
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s13");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            return x++;
        }
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
