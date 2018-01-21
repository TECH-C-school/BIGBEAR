using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour {

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
        }
        void Update()
        {
           //Click();
        }
        public void ClickFightButton()
        {

            GameObject cardsObject = GameObject.Find("Cards");
            //Cardsの子要素を消す
            foreach (Transform cardObject in cardsObject.transform)
            {
                Destroy(cardObject.gameObject);
            }
            Debug.Log("FightButtonClick");
            //デッキを作る
            MakeDeck();
            Debug.Log(List[5]); Debug.Log(List[6]); Debug.Log(List[7]);
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
        }
        public void ClickChangeButton()
        {
            int counter = 5;
            Debug.Log("ChangeButtonClick");
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
            Debug.Log("NotChangeButtonClick");
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
            
        }
        
        /// <summary>
        /// クリックした場所にcardSerectを配置する
        /// </summary>
        private void Click() 
        {
            var serectFlame = Resources.Load<GameObject>("Prefabs/Bar04/cardSerect");
            GameObject obj = getClickObject();
            if(obj != null)
            {
                var cardFlame = Instantiate(serectFlame, transform.position, Quaternion.identity);
                if (Input.GetMouseButtonDown(0))
                {
                    //クリックされた位置を取得
                    var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    tapPoint = Input.mousePosition;
                    Vector2 tmp = getObjectPosition();
                    cardFlame.transform.position = tmp;
                }
            }

        }
        /// <summary>
        /// 左クリックされたオブジェクトを取得する
        /// </summary>
        /// <returns></returns>
        private GameObject getClickObject()
        {
            GameObject result = null;
            //左クリックされた場所のオブジェクトを取得
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 tapPoint = Camera.main. ScreenToWorldPoint(Input.mousePosition);
                Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
                if (collition2d)
                {
                    result = collition2d.transform.gameObject;
                }
            }
            return result;
        }
        
        private Vector2 getObjectPosition()
        {
            Vector2 tmp = new Vector2();
            //左クリックされた場所のオブジェクトの座標を取得
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
                if (collition2d)
                {
                    tmp = GameObject.Find("c01").transform.position;
                }
            }
            return tmp;
        }
        /// <summary>
        /// カード選択時のflameをつける
        /// </summary>
        public int Counter(int x,int y)
        {
            var serectFlame = Resources.Load<GameObject>("Prefabs/Bar04/cardSerect");
            var cardFlame = Instantiate(serectFlame, transform.position, Quaternion.identity);
            var flameBox = GameObject.Find("CardFlame");
            if (x == 0)
            {
                //カードを選択する
                cardFlame.transform.parent = flameBox.transform;
                cardFlame.name = "cardSerect" + (y+1);
                cardFlame.transform.position = new Vector3(y * 2.5f - 5, 0.5f, -1);
                x = 1;
            }
            else
            {
                //カードの選択を解除する
                cardFlame = GameObject.Find("cardSerect" + (y+1));
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
            /*List.Add(0);
            List.Add(1);
            List.Add(2);
            List.Add(3);
            List.Add(4);*/
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
        public int LoadCard(int x, int y)
        {
            var RandomCrads = GameObject.Find("RandomCards");
            if (x == 0)
            {
                Debug.Log("Club_1");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c01");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 1)
            {
                Debug.Log("Club_2");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c02");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 2)
            {
                Debug.Log("Club_3");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c03");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 3)
            {
                Debug.Log("Club_4");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c04");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 4)
            {
                Debug.Log("Club_5");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c05");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 5)
            {
                Debug.Log("Club_6");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c06");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 6)
            {
                Debug.Log("Club_7");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c07");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 7)
            {
                Debug.Log("Club_8");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c08");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 8)
            {
                Debug.Log("Club_9");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c09");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 9)
            {
                Debug.Log("Club_10");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c10");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 10)
            {
                Debug.Log("Club_Jack");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c11");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 11)
            {
                Debug.Log("Club_Queen");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c12");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 12)
            {
                Debug.Log("Club_King");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c13");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 13)
            {
                Debug.Log("Heart_1");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h01");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 14)
            {
                Debug.Log("Heart_2");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h02");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 15)
            {
                Debug.Log("Heart_3");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h03");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 16)
            {
                Debug.Log("Heart_4");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h04");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 17)
            {
                Debug.Log("Heart_5");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h05");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 18)
            {
                Debug.Log("Heart_6");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h06");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 19)
            {
                Debug.Log("Heart_7");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h07");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 20)
            {
                Debug.Log("Heart_8");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h08");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 21)
            {
                Debug.Log("Heart_9");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h09");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 22)
            {
                Debug.Log("Heart_10");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h10");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 23)
            {
                Debug.Log("Heart_Jack");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h11");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 24)
            {
                Debug.Log("Heart_Queen");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h12");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 25)
            {
                Debug.Log("Heart_King");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h13");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 26)
            {
                Debug.Log("Diamond_1");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d01");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 27)
            {
                Debug.Log("Diamond_2");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d02");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 28)
            {
                Debug.Log("Diamond_3");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d03");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 29)
            {
                Debug.Log("Diamond_4");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d04");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 30)
            {
                Debug.Log("Diamond_5");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d05");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 31)
            {
                Debug.Log("Diamond_6");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d06");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 32)
            {
                Debug.Log("Diamond_7");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d07");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 33)
            {
                Debug.Log("Diamond_8");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d08");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 34)
            {
                Debug.Log("Diamond_9");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d09");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 35)
            {
                Debug.Log("Diamond_10");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d10");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 36)
            {
                Debug.Log("Diamond_Jack");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d11");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 37)
            {
                Debug.Log("Diamond_Queen");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d12");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 38)
            {
                Debug.Log("Diamond_King");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d13");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 39)
            {
                Debug.Log("Spade_1");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s01");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 40)
            {
                Debug.Log("Spade_2");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s02");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 41)
            {
                Debug.Log("Spade_3");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s03");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 42)
            {
                Debug.Log("Spade_4");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s04");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 43)
            {
                Debug.Log("Spade_5");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s05");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 44)
            {
                Debug.Log("Spade_6");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s06");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 45)
            {
                Debug.Log("Spade_7");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s07");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 46)
            {
                Debug.Log("Spade_8");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s08");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 47)
            {
                Debug.Log("Spade_9");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s09");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 48)
            {
                Debug.Log("Spade_10");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s10");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 49)
            {
                Debug.Log("Spade_Jack");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s11");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 50)
            {
                Debug.Log("Spade_Queen");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s12");
                var cardObject = Instantiate(card, new Vector2(y * 2.5f - 5, 0.5f), Quaternion.identity);
                cardObject.transform.parent = RandomCrads.transform;
            }
            else if (x == 51)
            {
                Debug.Log("Spade_King");
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
