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
            GameObject[] array = new GameObject[52];

            for (int k = 0; k < 52; k++)
            {
                GameObject markObject = GameObject.Find("Mark").transform.Find(trump[k].mark).gameObject;
                array[k] = markObject.transform.GetChild(trump[k].num).gameObject;

            }
            var counter = 0;
            while (counter < 52)
            {
                int index = UnityEngine.Random.Range(counter, 52);
                GameObject tmp = array[counter];
                array[counter] = array[index];
                array[index] = tmp;

                //Debug.Log(array[counter]);

                counter++;
            }

            GameObject[] FieldCard = new GameObject[28];
            GameObject[] RemainCard = new GameObject[24];

            var fieldcard = GameObject.Find("FieldCards");
            var remaincard = GameObject.Find("RemainCards");

            counter = 0;
            while (counter < 28)
            {
                FieldCard[counter] = array[counter];
                //Debug.Log(FieldCard[counter]);
                counter++;
            }
            int renum = 0;
            while (renum < 24)
            {
                RemainCard[renum] = array[counter];
                GameObject renumpos = Instantiate(RemainCard[renum], transform.position, Quaternion.identity);
                renumpos.transform.parent = remaincard.transform;
                //Debug.Log(RemainCard[renum]);
                counter++; renum++;
            }


            counter = 1;
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < counter; y++)
                {
                    GameObject cardpos = Instantiate(FieldCard[choice], transform.position, Quaternion.identity);

                    cardpos.transform.position = new Vector3(
                    -0.87f * x + 1.665f * y,
                    3.50f - 0.92f * x,
                    0);

                    cardpos.GetComponent<Renderer>().sortingOrder = counter;
                    cardpos.transform.parent = fieldcard.transform;
                    choice++;
                }
                counter++;
            }
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

            var colidercard = hitObject.collider.GetComponent<BoxCollider2D>();
            OnTriggerStay2D(colidercard);
            if (!colidercard) return;

            //クリックされた位置にflameを装着
            var Flame = GameObject.Find("cardflame");
            Flame.transform.position = hitObject.transform.position;
            
        }
        public void OnTriggerStay2D(Collider2D collision)
        {
            collision.GetComponent<BoxCollider2D>().enabled = false;
        }
        /* public void TransitionToResult()
         {
             SceneManager.LoadScene("Result");
         }*/
    }
}
