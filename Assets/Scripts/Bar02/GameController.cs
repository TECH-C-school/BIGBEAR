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

            //OpenCard();
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
            int num = 0;
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
                    var card = cardpos.GetComponent<Cards>();
                    //CardスクリプトのNumberにMakeRandomの値代入
                    card.Number = num;
                    card.TurnCardFaceDown();
                    choice++; num++;
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
            //tapPoint.z = 0;
            //ScreenToWorldPoint(位置(Vector3)):スクリーン座標をワールド座標に変換する


            //Collinder2D上のクリックの判定
            if (!Physics2D.OverlapPoint(tapPoint)) return;

            //クリックした位置のオブジェクトを取得
            var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
            if (!hitObject) return;

            /*var colidercard = hitObject.collider.GetComponent<BoxCollider2D>();
            OnTriggerStay2D(colidercard);
            if (!colidercard) return;*/

            //クリックされた位置にflameを装着
            var Flame = GameObject.Find("cardflame");
            Flame.transform.position = hitObject.transform.position;

        }
        /*public void OnTriggerStay2D(Collider2D collision)
        {
            collision.GetComponent<BoxCollider2D>().enabled = false;
        }*/
        /* public void TransitionToResult()
         {
             SceneManager.LoadScene("Result");
         }*/

        //    public void OpenCard()
        //    {
        //        int counter = 2;
        //        int num = 0;
        //        var a = GameObject.Find("FieldCards");
        //        GameObject[] b = new GameObject[28];
        //        var empty = GameObject.Find("Empty");
        //        GameObject[] d = new GameObject[35];
        //        for (int i = 0; i < 7; i++)
        //        {
        //            for (int j = 0; j < counter; j++)
        //            {
        //                d[counter] = Instantiate(empty, transform.position, Quaternion.identity);
        //                d[counter].transform.position = new Vector3(
        //                -0.87f * (i + 1) + 1.665f * (j + 1),
        //                3.50f - 0.92f * (i + 1),
        //                0);

        //                d[counter].transform.parent = empty.transform;
        //            }
        //            counter++;
        //        }
        //        counter = 1;
        //        for (int i = 0; i < 7; i++)
        //        {
        //            for (int j = 0; j < counter; j++)
        //            {
        //                b[counter-1] = a.transform.GetChild(num).gameObject;
        //                if (num > 1)
        //                {
        //                    if (d[i * counter + j].transform.position == b[counter].transform.position
        //                        && d[i + j * counter].transform.position == b[counter+1].transform.position)
        //                    {
        //                        b[counter-1].GetComponent<BoxCollider2D>().enabled = false;
        //                    }
        //                    else
        //                    {
        //                        var cardd = GetComponent<Cards>();
        //                        cardd.TurnCardFaceUp();
        //                        Destroy(d.gameObject);
        //                    }
        //                }
        //                num++;
        //            }
        //            counter++;
        //        }
        //    }
        //}
    }
}

