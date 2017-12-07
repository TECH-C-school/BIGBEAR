using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour {
        
        struct card
        {
            public int number;
            public int mark;
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

            var c01 = Resources.Load<GameObject>("Images/Bar/Cards/joker");
            var card = Instantiate(c01, transform.position, Quaternion.identity);
            card.transform.position = new Vector3(6.0f, 0.5f, -1);
        }
        
        void Update()
        {
            Click();
            
        }
        private void returnCard(int x, int y)
        {
            int Joker = UnityEngine.Random.Range(1, 54);
            if (Joker == 1)
            {
                Debug.Log("Joker");
            }
            else if (x == 1 && y == 1)
            {
                Debug.Log("Spade_1");
            }
            else if (x == 2 && y == 1)
            {
                Debug.Log("Spade_2");
            }
            else if (x == 3 && y == 1)
            {
                Debug.Log("Spade_3");
            }
            else if (x == 4 && y == 1)
            {
                Debug.Log("Spade_4");
            }
            else if (x == 5 && y == 1)
            {
                Debug.Log("Spade_5");
            }
            else if (x == 6 && y == 1)
            {
                Debug.Log("Spade_6");
            }
            else if (x == 7 && y == 1)
            {
                Debug.Log("Spade_7");
            }
            else if (x == 8 && y == 1)
            {
                Debug.Log("Spade_8");
            }
            else if (x == 9 && y == 1)
            {
                Debug.Log("Spade_9");
            }
            else if (x == 10 && y == 1)
            {
                Debug.Log("Spade_10");
            }
            else if (x == 11 && y == 1)
            {
                Debug.Log("Spade_Jack");
            }
            else if (x == 12 && y == 1)
            {
                Debug.Log("Spade_Queen");
            }
            else if (x == 13 && y == 1)
            {
                Debug.Log("Spade_King");
            }
            else if (x == 1 && y == 2)
            {
                Debug.Log("Heart_1");
            }
            else if (x == 2 && y == 2)
            {
                Debug.Log("Heart_2");
            }
            else if (x == 3 && y == 2)
            {
                Debug.Log("Heart_3");
            }
            else if (x == 4 && y == 2)
            {
                Debug.Log("Heart_4");
            }
            else if (x == 5 && y == 2)
            {
                Debug.Log("Heart_5");
            }
            else if (x == 6 && y == 2)
            {
                Debug.Log("Heart_6");
            }
            else if (x == 7 && y == 2)
            {
                Debug.Log("Heart_7");
            }
            else if (x == 8 && y == 2)
            {
                Debug.Log("Heart_8");
            }
            else if (x == 9 && y == 2)
            {
                Debug.Log("Heart_9");
            }
            else if (x == 10 && y == 2)
            {
                Debug.Log("Heart_10");
            }
            else if (x == 11 && y == 2)
            {
                Debug.Log("Heart_Jack");
            }
            else if (x == 12 && y == 2)
            {
                Debug.Log("Heart_Queen");
            }
            else if (x == 13 && y == 2)
            {
                Debug.Log("Heart_King");
            }
            else if (x == 1 && y == 3)
            {
                Debug.Log("Diamond_1");
            }
            else if (x == 2 && y == 3)
            {
                Debug.Log("Diamond_2");
            }
            else if (x == 3 && y == 3)
            {
                Debug.Log("Diamond_3");
            }
            else if (x == 4 && y == 3)
            {
                Debug.Log("Diamond_4");
            }
            else if (x == 5 && y == 3)
            {
                Debug.Log("Diamond_5");
            }
            else if (x == 6 && y == 3)
            {
                Debug.Log("Diamond_6");
            }
            else if (x == 7 && y == 3)
            {
                Debug.Log("Diamond_7");
            }
            else if (x == 8 && y == 3)
            {
                Debug.Log("Diamond_8");
            }
            else if (x == 9 && y == 3)
            {
                Debug.Log("Diamond_9");
            }
            else if (x == 10 && y == 3)
            {
                Debug.Log("Diamond_10");
            }
            else if (x == 11 && y == 3)
            {
                Debug.Log("Diamond_Jack");
            }
            else if (x == 12 && y == 3)
            {
                Debug.Log("Diamond_Queen");
            }
            else if (x == 13 && y == 3)
            {
                Debug.Log("Diamond_King");
            }
            else if (x == 1 && y == 4)
            {
                Debug.Log("Club_1");
            }
            else if (x == 2 && y == 4)
            {
                Debug.Log("Club_2");
            }
            else if (x == 3 && y == 4)
            {
                Debug.Log("Club_3");
            }
            else if (x == 4 && y == 4)
            {
                Debug.Log("Club_4");
            }
            else if (x == 5 && y == 4)
            {
                Debug.Log("Club_5");
            }
            else if (x == 6 && y == 4)
            {
                Debug.Log("Club_6");
            }
            else if (x == 7 && y == 4)
            {
                Debug.Log("Club_7");
            }
            else if (x == 8 && y == 4)
            {
                Debug.Log("Club_8");
            }
            else if (x == 9 && y == 4)
            {
                Debug.Log("Club_9");
            }
            else if (x == 10 && y == 4)
            {
                Debug.Log("Club_10");
            }
            else if (x == 11 && y == 4)
            {
                Debug.Log("Club_Jack");
            }
            else if (x == 12 && y == 4)
            {
                Debug.Log("Club_Queen");
            }
            else if (x == 13 && y == 4)
            {
                Debug.Log("Club_King");
            }
        }
        private void Click()
        {
            GameObject obj = getClickObject();
            if(obj != null)
            {

            }

        }
        private void MakeDeck()
        {
            int[] Deck = new int[52];
            for (int i = 0; i < 52; i++)
            {
                card deck = new card();
                deck.number = UnityEngine.Random.Range(0, 13);
                deck.mark = UnityEngine.Random.Range(0, 4);
                
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
