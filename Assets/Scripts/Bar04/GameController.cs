using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour {

        public class trunp
        {
            public int Mark;
            public int Number;
        }

        void Start()
        {

            var cardPrefabs = Resources.Load<GameObject>("Prefabs/Bar04/card");
            for (var i = 0; i < 5; i++)
            {
                var cardObbject = Instantiate(cardPrefabs, transform.position, Quaternion.identity);
                cardObbject.transform.position = new Vector3(i * 2.5f - 5, 0.5f, 0);
                cardObbject.transform.parent = transform;
            }
            var FightButton = GameObject.Find("b_s");
            FightButton.transform.position = new Vector3(6.5f,-3.5f,-1);

            MakeDeck();
        }
        
        void Update()
        {
            Click();
            
        }
        private int returnCard(int x)
        {
            var i = 0;
            if (x == 0)
            {
                Debug.Log("Spade_1");
                i = 1;
            }
            else if (x == 1)
            {
                Debug.Log("Spade_2");
                i = 2;
            }
            else if (x == 2)
            {
                Debug.Log("Spade_3");
                i = 3;
            }
            else if (x == 3)
            {
                Debug.Log("Spade_4");
                i = 4;
            }
            else if (x == 4)
            {
                Debug.Log("Spade_5");
                i = 5;
            }
            else if (x == 5)
            {
                Debug.Log("Spade_6");
                i = 6;
            }
            else if (x == 6)
            {
                Debug.Log("Spade_7");
                i = 7;
            }
            else if (x == 7)
            {
                Debug.Log("Spade_8");
                i = 8;
            }
            else if (x == 8)
            {
                Debug.Log("Spade_9");
                i = 9;
            }
            else if (x == 9)
            {
                Debug.Log("Spade_10");
                i = 10;
            }
            else if (x == 10)
            {
                Debug.Log("Spade_Jack");
                i = 11;
            }
            else if (x == 11)
            {
                Debug.Log("Spade_Queen");
                i = 12;
            }
            else if (x == 12)
            {
                Debug.Log("Spade_King");
                i = 13;
            }
            else if (x == 13)
            {
                Debug.Log("Heart_1");
                i = 14;
            }
            else if (x == 14)
            {
                Debug.Log("Heart_2");
                i = 15;
            }
            else if (x == 15)
            {
                Debug.Log("Heart_3");
                i = 16;
            }
            else if (x == 16)
            {
                Debug.Log("Heart_4");
                i = 17;
            }
            else if (x == 17)
            {
                Debug.Log("Heart_5");
                i = 18;
            }
            else if (x == 18)
            {
                Debug.Log("Heart_6");
                i = 19;
            }
            else if (x == 19)
            {
                Debug.Log("Heart_7");
                i = 20;
            }
            else if (x == 20)
            {
                Debug.Log("Heart_8");
                i = 21;
            }
            else if (x == 21)
            {
                Debug.Log("Heart_9");
                i = 22;
            }
            else if (x == 22)
            {
                Debug.Log("Heart_10");
                i = 23;
            }
            else if (x == 23)
            {
                Debug.Log("Heart_Jack");
                i = 24;
            }
            else if (x == 24)
            {
                Debug.Log("Heart_Queen");
                i = 25;
            }
            else if (x == 25)
            {
                Debug.Log("Heart_King");
                i = 26;
            }
            else if (x == 26)
            {
                Debug.Log("Diamond_1");
                i = 27;
            }
            else if (x == 27)
            {
                Debug.Log("Diamond_2");
                i = 28;
            }
            else if (x == 28)
            {
                Debug.Log("Diamond_3");
                i = 29;
            }
            else if (x == 29)
            {
                Debug.Log("Diamond_4");
                i = 30;
            }
            else if (x == 30)
            {
                Debug.Log("Diamond_5");
                i = 31;
            }
            else if (x == 31)
            {
                Debug.Log("Diamond_6");
                i = 32;
            }
            else if (x == 32)
            {
                Debug.Log("Diamond_7");
                i = 33;
            }
            else if (x == 33)
            {
                Debug.Log("Diamond_8");
                i = 34;
            }
            else if (x == 34)
            {
                Debug.Log("Diamond_9");
                i = 35;
            }
            else if (x == 35)
            {
                Debug.Log("Diamond_10");
                i = 36;
            }
            else if (x == 36)
            {
                Debug.Log("Diamond_Jack");
                i = 37;
            }
            else if (x == 37)
            {
                Debug.Log("Diamond_Queen");
                i = 38;
            }
            else if (x == 38)
            {
                Debug.Log("Diamond_King");
                i = 39;
            }
            else if (x == 39)
            {
                Debug.Log("Club_1");
                i = 40;
            }
            else if (x == 40)
            {
                Debug.Log("Club_2");
                i = 41;
            }
            else if (x == 41)
            {
                Debug.Log("Club_3");
                i = 42;
            }
            else if (x == 42)
            {
                Debug.Log("Club_4");
                i = 43;
            }
            else if (x == 43)
            {
                Debug.Log("Club_5");
                i = 44;
            }
            else if (x == 44)
            {
                Debug.Log("Club_6");
                i = 45;
            }
            else if (x == 45)
            {
                Debug.Log("Club_7");
                i = 46;
            }
            else if (x == 46)
            {
                Debug.Log("Club_8");
                i = 47;
            }
            else if (x == 47)
            {
                Debug.Log("Club_9");
                i = 48;
            }
            else if (x == 48)
            {
                Debug.Log("Club_10");
                i = 49;
            }
            else if (x == 49)
            {
                Debug.Log("Club_Jack");
                i = 50;
            }
            else if (x == 50)
            {
                Debug.Log("Club_Queen");
                i = 51;
            }
            else if (x == 51)
            {
                Debug.Log("Club_King");
                i = 52;
            }
            return i;
        }
        private void Click()
        {
            GameObject obj = getClickObject();
            if(obj != null)
            {

            }

        }
        /// <summary>
        /// 山札を作成する(ジョーカー抜き)
        /// </summary>
        private void MakeDeck()
        {
            //Listに0～51までの数値を追加する
            var List = new List<int>();
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

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }

    }
}
