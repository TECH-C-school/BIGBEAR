using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace Assets.Scripts.Bar02
{
    public class GameController : MonoBehaviour
    {
        private GameObject hogehoge = null;
        private int num = 0;
        public GameObject Cleartext;

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
            OpenCard();
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
            //var backcards = GameObject.Find("BackCards");
            //var backPrefab = Resources.Load<GameObject>("Prefabs/Bar02/Back");

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

                    //GameObject backpos = Instantiate(backPrefab, transform.position, Quaternion.identity);

                    //backpos.transform.position = new Vector3(
                    //-0.87f * x + 1.665f * y,
                    //3.50f - 0.92f * x,
                    //0);

                    cardpos.GetComponent<Renderer>().sortingOrder = counter;
                    //backpos.GetComponent<Renderer>().sortingOrder = 0;

                    cardpos.transform.parent = fieldcard.transform;
                    //backpos.transform.parent = backcards.transform;
                    var card = cardpos.GetComponent<Cards>();
                    //CardスクリプトのNumberにMakeRandomの値代入
                    card.Number = num;
                    card.TurnCardFaceDown();
                    choice++; num++;
                }
                counter++;
            }
            var judgecard = GameObject.Find("RemainCards");
            string once = "";

            for (int i = 0; i < 24; i++)
            {

                var one = judgecard.transform.GetChild(i).gameObject;
                string ones = one.ToString();
                if (ones.IndexOf("1") == 1)
                {

                    once = ones.Substring(1, 2);
                }
                else
                {
                    once = ones.Substring(2, 1);
                }

                int stringnum = System.Int32.Parse(once);
                var card = one.GetComponent<Cards>();
                card.Number = num;
                card.CardNumber = stringnum;
            }
        }



        public void ClickCard()
        {

            var Flame = GameObject.Find("cardflame");
            var homepos = new Vector3(100, 0, 0);
            var x = GameObject.Find("FieldCards");
            var FirstCard = x.transform.GetChild(0).gameObject;

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


            var card = hitObject.collider.gameObject.GetComponent<Cards>();
            //Debug.Log("一つ目のカード" + card.CardNumber);

            if (hogehoge != null)
            {
                var card2 = hogehoge.GetComponent<Cards>();
                if (card2.CardNumber + card.CardNumber == 13)
                {
                    hogehoge.SetActive(false);
                    hitObject.collider.gameObject.SetActive(false);
                    hogehoge = null;
                    Flame.transform.position = homepos;
                }
                else
                {
                    hogehoge = null;
                    Flame.transform.position = homepos;
                }

            }
            else
            {
                hogehoge = hitObject.collider.gameObject;
                Flame.transform.position = hitObject.transform.position;
                Debug.Log("選んでいるカード" + card.CardNumber);
                if (card.CardNumber != 13) return;
                hitObject.collider.gameObject.SetActive(false);
                Flame.transform.position = homepos;
            }
            if ( FirstCard.activeSelf == false )
            {
                Debug.Log("Clear!!");
                Cleartext.SetActive(true);
            }
            return;
            ////クリックされた位置にflameを装着
            

        }
        /*public void OnTriggerStay2D(Collider2D collision)
        {
            collision.GetComponent<BoxCollider2D>().enabled = false;
        }*/
        /* public void TransitionToResult()
         {
             SceneManager.LoadScene("Result");
         }*/

        public void OpenCard()
        {
            var judgecard = GameObject.Find("FieldCards");
            num = 0; int counter = 1;
            string once = "";

            for (int i = 1; i < 8; i++)
            {
                for (int j = 0; j < counter; j++)
                {
                    var one = judgecard.transform.GetChild(num).gameObject;
                    string ones = one.ToString();
                    if (ones.IndexOf("1") == 1)
                    {

                        once = ones.Substring(1, 2);
                    }
                    else
                    {
                        once = ones.Substring(2, 1);
                    }

                    int stringnum = System.Int32.Parse(once);

                    if (num > 20)
                    {
                        CardJudge(one, stringnum, true);
                    }
                    else
                    {
                        var two = judgecard.transform.GetChild(num + i).gameObject;
                        var three = judgecard.transform.GetChild(num + i + 1).gameObject;

                        if (two.activeSelf == false)
                        {
                            if (three.activeSelf == false)
                            {
                                CardJudge(one, stringnum, true);
                            }
                        }
                        else
                        {
                            CardJudge(one, stringnum, false);
                        }
                    }
                    num++;
                }
                counter++;
            }

        }
        public void CardJudge(GameObject faceon, int mojinum, bool turn)
        {
            faceon.GetComponent<BoxCollider2D>().enabled = turn;
            var card = faceon.GetComponent<Cards>();
            card.CardNumber = mojinum;
            card.Number = num;
            card.TurnCard(turn);

        }

    }
}


