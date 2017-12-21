using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour {

        public int count = 0;
        public void ClickChangeButton()
        {
            
            Debug.Log("ChangeButtonClick");
        }
        public void ClickFightButton()
        {
            

            var cardsObject = GameObject.Find("Cards");
            foreach (Transform cardObject in cardsObject.transform)
            {
                Destroy(cardObject.gameObject);
            }
            Debug.Log("FightButtonClick");
            
            //Listに0～51までの数値を追加する
            List<int> List = new List<int>();
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
            //山札の上から5枚を配る
            for (var j = 0; j < 5; j++)
            {
                var counter = LoadCard(List[j], j);
                Debug.Log(counter);
            }
            gameObject.SetActive(false);

        }
        void Start()
        {
            var Card = GameObject.Find("Cards");
            var cardPrefabs = Resources.Load<GameObject>("Prefabs/Bar04/card");
            for (var i = 0; i < 5; i++)
            {
                var cardObbject = Instantiate(cardPrefabs, transform.position, Quaternion.identity);
                cardObbject.transform.position = new Vector2(i * 2.5f - 5, 0.5f);
                cardObbject.transform.parent = Card.transform;
            }
       
        }
        void Update()
        {
            //Click();
            
        }
        public int LoadCard(int x,int y)
        {
            var RandomCrads = GameObject.Find("RandomCrads");
            var i = 0;
            if (x == 0)
            {
                Debug.Log("Club_1");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c01");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 1;
            }
            else if (x == 1)
            {
                Debug.Log("Club_2");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c02");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 2;
            }
            else if (x == 2)
            {
                Debug.Log("Club_3");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c03");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 3;
            }
            else if (x == 3)
            {
                Debug.Log("Club_4");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c04");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 4;
            }
            else if (x == 4)
            {
                Debug.Log("Club_5");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c05");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 5;
            }
            else if (x == 5)
            {
                Debug.Log("Club_6");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c06");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 6;
            }
            else if (x == 6)
            {
                Debug.Log("Club_7");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c07");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 7;
            }
            else if (x == 7)
            {
                Debug.Log("Club_8");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c08");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 8;
            }
            else if (x == 8)
            {
                Debug.Log("Club_9");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c09");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 9;
            }
            else if (x == 9)
            {
                Debug.Log("Club_10");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c10");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 10;
            }
            else if (x == 10)
            {
                Debug.Log("Club_Jack");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c11");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 11;
            }
            else if (x == 11)
            {
                Debug.Log("Club_Queen");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c12");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 12;
            }
            else if (x == 12)
            {
                Debug.Log("Club_King");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Club/c13");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 13;
            }
            else if (x == 13)
            {
                Debug.Log("Heart_1");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h01");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 14;
            }
            else if (x == 14)
            {
                Debug.Log("Heart_2");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h02");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 15;
            }
            else if (x == 15)
            {
                Debug.Log("Heart_3");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h03");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 16;
            }
            else if (x == 16)
            {
                Debug.Log("Heart_4");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h04");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 17;
            }
            else if (x == 17)
            {
                Debug.Log("Heart_5");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h05");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 18;
            }
            else if (x == 18)
            {
                Debug.Log("Heart_6");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h06");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 19;
            }
            else if (x == 19)
            {
                Debug.Log("Heart_7");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h07");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 20;
            }
            else if (x == 20)
            {
                Debug.Log("Heart_8");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h08");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 21;
            }
            else if (x == 21)
            {
                Debug.Log("Heart_9");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h09");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 22;
            }
            else if (x == 22)
            {
                Debug.Log("Heart_10");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h10");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 23;
            }
            else if (x == 23)
            {
                Debug.Log("Heart_Jack");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h11");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 24;
            }
            else if (x == 24)
            {
                Debug.Log("Heart_Queen");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h12");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 25;
            }
            else if (x == 25)
            {
                Debug.Log("Heart_King");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Haert/h13");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 26;
            }
            else if (x == 26)
            {
                Debug.Log("Diamond_1");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d01");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 27;
            }
            else if (x == 27)
            {
                Debug.Log("Diamond_2");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d02");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 28;
            }
            else if (x == 28)
            {
                Debug.Log("Diamond_3");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d03");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 29;
            }
            else if (x == 29)
            {
                Debug.Log("Diamond_4");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d04");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 30;
            }
            else if (x == 30)
            {
                Debug.Log("Diamond_5");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d05");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 31;
            }
            else if (x == 31)
            {
                Debug.Log("Diamond_6");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d06");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 32;
            }
            else if (x == 32)
            {
                Debug.Log("Diamond_7");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d07");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 33;
            }
            else if (x == 33)
            {
                Debug.Log("Diamond_8");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d08");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 34;
            }
            else if (x == 34)
            {
                Debug.Log("Diamond_9");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d09");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 35;
            }
            else if (x == 35)
            {
                Debug.Log("Diamond_10");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d10");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 36;
            }
            else if (x == 36)
            {
                Debug.Log("Diamond_Jack");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d11");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 37;
            }
            else if (x == 37)
            {
                Debug.Log("Diamond_Queen");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d12");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 38;
            }
            else if (x == 38)
            {
                Debug.Log("Diamond_King");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Diamond/d13");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 39;
            }
            else if (x == 39)
            {
                Debug.Log("Spade_1");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s01");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 40;
            }
            else if (x == 40)
            {
                Debug.Log("Spade_2");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s02");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 41;
            }
            else if (x == 41)
            {
                Debug.Log("Spade_3");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s03");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 42;
            }
            else if (x == 42)
            {
                Debug.Log("Spade_4");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s04");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 43;
            }
            else if (x == 43)
            {
                Debug.Log("Spade_5");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s05");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 44;
            }
            else if (x == 44)
            {
                Debug.Log("Spade_6");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s06");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 45;
            }
            else if (x == 45)
            {
                Debug.Log("Spade_7");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s07");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 46;
            }
            else if (x == 46)
            {
                Debug.Log("Spade_8");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s08");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 47;
            }
            else if (x == 47)
            {
                Debug.Log("Spade_9");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s09");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 48;
            }
            else if (x == 48)
            {
                Debug.Log("Spade_10");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s10");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 49;
            }
            else if (x == 49)
            {
                Debug.Log("Spade_Jack");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s11");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 50;
            }
            else if (x == 50)
            {
                Debug.Log("Spade_Queen");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s12");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 51;
            }
            else if (x == 51)
            {
                Debug.Log("Spade_King");
                var card = Resources.Load<GameObject>("Prefabs/Bar04/Spade/s13");
                var cardObject = Instantiate(card, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(y * 2.5f - 5, 0.5f);
                cardObject.transform.parent = RandomCrads.transform;
                i = 52;
            }
            
            return i;
        }
        /*private void Click()
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

        }*/
        /// <summary>
        /// 山札を作成する(ジョーカー抜き)
        /// </summary>
        public void MakeDeck()
        {
            //Listに0～51までの数値を追加する
            List<int> List = new List<int>();
            for (int i = 0; i < 52; i++)
            {
                List.Add(i);
                Debug.Log(List[i]);
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
                Debug.Log(List[n]);
            }
        }


        /// <summary>
        /// 左クリックされたオブジェクトを取得する関数
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
            Vector2 result = new Vector2();
            //左クリックされた場所のオブジェクトの座標を取得
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
                if (collition2d)
                {
                    result = GameObject.Find("RandomCards/").transform.position;
                }
            }
            return result;
        }
        private int Counter(int x)
        {
            if (x == 0)
            {
                //カードを選択する
                var serectFlame = Resources.Load<GameObject>("Prefabs/Bar04/cardSerect");
                var cardFlame = Instantiate(serectFlame, transform.position, Quaternion.identity);
                cardFlame.transform.position = new Vector3(-5, 0.5f, -1);
                x = 1;
            }
            else
            {
                //カードの選択を解除する
                var cardFlame = GameObject.Find("cardSerect");
                Destroy(cardFlame.gameObject);
                x = 0;
            }
            return x;
        }
        public void SerectButton()
        {
            count = Counter(count);
            
        }
        
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }

    }
}
