using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace Assets.Scripts.Bar02
{
    public class GameController : MonoBehaviour
    {
        public enum Gamestate
        {
            Prepare = 1,
            Start,
            Finish
        }

        public int choice = 0;
        public int[] cardnum = new int[52];
        void Start()
        {
            MakeCards();
            SettingCards();
        }
        void Update()
        {
            ClickCard();
        }
        public class cardy
        {
            public string mark;
            public int num;
        }
        public void MakeCards()
        {
            cardy[] trump = new cardy[52];
            for (int k = 0; k < 52; k++)
            {
                trump[k] = new cardy();
            }

            for (int i = 0; i < 13; i++)
            {
                trump[i + 0].mark = "s";
                trump[i + 13].mark = "d";
                trump[i + 26].mark = "h";
                trump[i + 39].mark = "c";

                trump[i + 0].num = i;
                trump[i + 13].num = i;
                trump[i + 26].num = i;
                trump[i + 39].num = i;
            }
            int[] values = new int[52];


            var counter = 0;
            //マークと数字をバラバラに
            while (counter < 52)
            {
                int index = UnityEngine.Random.Range(counter, values.Length);
                var tmp = trump[counter].mark;
                trump[counter].mark = trump[index].mark;
                trump[index].mark = tmp;

                counter++;
            }
            counter = 0;
            while (counter < 52)
            {
                int index = UnityEngine.Random.Range(counter, values.Length);
                var tmp = trump[counter].num;
                trump[counter].num = trump[index].num;
                trump[index].num = tmp;

                counter++;
            }

            var fieldcard = GameObject.Find("FieldCards");
            var twenycard = GameObject.Find("TwentyCards");

            for (int k = 0; k < 52; k++)
            {
                GameObject markObject = GameObject.Find("Mark").transform.Find(trump[k].mark).gameObject;
                var numberObject = markObject.transform.GetChild(trump[k].num).gameObject;
                GameObject cardObject = Instantiate(numberObject, transform.position, Quaternion.identity);
                cardObject.transform.parent = fieldcard.transform;
                cardnum[k] = trump[k].num;
            }
            counter = 1;
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < counter; y++)
                {                    
                    var numpos = fieldcard.transform.GetChild(choice).gameObject;
                    GameObject cardpos = Instantiate(numpos, transform.position, Quaternion.identity);
                    
                    cardpos.transform.position = new Vector3(
                    -0.64f * x + 1.32f * y,
                    2.90f - 0.80f * x,
                    0);

                    cardpos.GetComponent<Renderer>().sortingOrder = counter;
                    cardpos.transform.parent = twenycard.transform;
                    choice++;
                }
                counter++;
            }
        }

        public void SettingCards()
        {
            GameObject backCard = GameObject.Find("Back");

            backCard.transform.position = new Vector3(
            6.0f,
            3.9f,
            0);

        }

        public void ClickCard()
        {

            //マウスクリックの判定
            if (!Input.GetMouseButtonDown(0)) return; //左クリックされていなければreturn

            //クリックされた位置を取得
            var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tapPoint.z = 0;
            //ScreenToWorldPoint(位置(Vector3)):スクリーン座標をワールド座標に変換する


            //Collinder2D上のクリックの判定
            if (!Physics2D.OverlapPoint(tapPoint)) return;

            //クリックした位置のオブジェクトを取得
            var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
            if (!hitObject) return;

            //クリックされたカードスクリプトを取得
            var cardTrans = hitObject.collider.gameObject.GetComponent<>();
            
            //クリックされた位置にflameを装着
            var Flame = GameObject.Find("cardflame");
            Flame.transform.position = hitObject.transform.position;




        }
        /* public void TransitionToResult()
         {
             SceneManager.LoadScene("Result");
         }*/
    }
}
