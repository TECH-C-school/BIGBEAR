using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class start : MonoBehaviour
{

    List<Cards> Row = new List<Cards>();
    List<Cards> Row2 = new List<Cards>();
    List<Cards> Row3 = new List<Cards>();
    List<Cards> Row4 = new List<Cards>();
    List<Cards> Row5 = new List<Cards>();
    List<Cards> Row6 = new List<Cards>();
    List<Cards> Row7 = new List<Cards>();
    List<Cards> Row8 = new List<Cards>();
    List<Cards> Row9 = new List<Cards>();
    List<Cards> Row10 = new List<Cards>();
    List<Cards> Beck = new List<Cards>();

    public enum Mark { Heart, Spade, Dia, Clover };

    public struct Cards
    {
        public int Number;
        public Mark mark;
        public bool Decision;
    }

    public string GetCards(int Number, Mark mark)
    {
        string fileName = "";

        switch (mark)
        {
            case Mark.Clover:
                fileName += "c";
                break;
            case Mark.Dia:
                fileName += "d";
                break;
            case Mark.Spade:
                fileName += "s";
                break;
            case Mark.Heart:
                fileName += "h";
                break;
        }

        if (Number < 10)
        {
            fileName += "0" + Number;
        }
        else
        {
            fileName += Number;
        }

        return fileName;
    }



    // Use this for initialization
    void Start()
    {
        Cards[] Deck = new Cards[104];
        var DeckCounter = 0;

        for (var j = 0; j < 2; j++)
        {
            for (var i = 1; i <= 13; i++)
            {
                Cards student = new Cards();
                student.Number = i;
                student.mark = Mark.Clover;
                student.Decision = true;

                Deck[DeckCounter] = student;
                DeckCounter++;

            }

            for (var i = 1; i <= 13; i++)
            {
                Cards student = new Cards();
                student.Number = i;
                student.mark = Mark.Dia;
                student.Decision = true;

                Deck[DeckCounter] = student;
                DeckCounter++;
            }

            for (var i = 1; i <= 13; i++)
            {
                Cards student = new Cards();
                student.Number = i;
                student.mark = Mark.Heart;
                student.Decision = true;

                Deck[DeckCounter] = student;
                DeckCounter++;
            }

            for (var i = 1; i <= 13; i++)
            {
                Cards student = new Cards();
                student.Number = i;
                student.mark = Mark.Spade;
                student.Decision = true;

                Deck[DeckCounter] = student;
                DeckCounter++;
            }
        }


        for (var i = 0; i < Deck.Length; i++)
        {
            int rnd = UnityEngine.Random.Range(i, Deck.Length);
            var temp = Deck[i];
            Deck[i] = Deck[rnd];
            Deck[rnd] = temp;
        }

        MakeRow(Deck);
        MakeCards();
    }

    // Update is called once per frame
    void Update()
    {
        ClickCard();
    }

    /// <summary>
    /// カード生成(104枚)
    /// </summary>
    private void MakeCards()
    {

        /// <summary>
        /// 上のカード生成(54枚)
        /// </summary>

        for (int i = 0; i < 6; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-7.85f, i * 0.31f - -2.05f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            if (i == 0)
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + GetCards(Row[i].Number, Row[i].mark));
            }
            else
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            }

        }
        for (int i = 0; i < 6; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-6.11f, i * 0.31f - -2.05f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            if (i == 0)
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + GetCards(Row2[i].Number, Row2[i].mark));
            }
            else
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            }

        }
        for (int i = 0; i < 6; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-4.37f, i * 0.31f - -2.05f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            if (i == 0)
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + GetCards(Row3[i].Number, Row3[i].mark));
            }
            else
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            }

        }
        for (int i = 0; i < 6; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-2.633f, i * 0.31f - -2.05f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            if (i == 0)
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + GetCards(Row4[i].Number, Row4[i].mark));
            }
            else
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            }

        }
        for (int i = 0; i < 5; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-0.87f, i * 0.31f - -2.362f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            if (i == 0)
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + GetCards(Row5[i].Number, Row5[i].mark));
            }
            else
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            }

        }
        for (int i = 0; i < 5; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(0.87f, i * 0.31f - -2.362f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            if (i == 0)
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + GetCards(Row6[i].Number, Row6[i].mark));
            }
            else
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            }

        }
        for (int i = 0; i < 5; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(2.62f, i * 0.31f - -2.362f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            if (i == 0)
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + GetCards(Row7[i].Number, Row7[i].mark));
            }
            else
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            }

        }
        for (int i = 0; i < 5; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(4.37f, i * 0.31f - -2.362f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            if (i == 0)
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + GetCards(Row8[i].Number, Row8[i].mark));
            }
            else
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            }

        }
        for (int i = 0; i < 5; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(6.11f, i * 0.31f - -2.362f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            if (i == 0)
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + GetCards(Row9[i].Number, Row9[i].mark));
            }
            else
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            }

        }
        for (int i = 0; i < 5; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(7.85f, i * 0.31f - -2.362f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            if (i == 0)
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + GetCards(Row10[i].Number, Row10[i].mark));
            }
            else
            {
                renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            }

        }
        for (int i = 0; i < 50; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-7.85f, 0 - 2.85f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
        }

    }




    private void MakeRow(Cards[] Deck)
    {


        for (int i = 0; i < 6; i++)
        {
            Row.Add(Deck[i]);
        }


        for (int i = 0; i < 6; i++)
        {
            Row2.Add(Deck[6 + i]);
        }


        for (int i = 0; i < 6; i++)
        {
            Row3.Add(Deck[12 + i]);
        }


        for (int i = 0; i < 6; i++)
        {
            Row4.Add(Deck[18 + i]);
        }


        for (int i = 0; i < 5; i++)
        {
            Row5.Add(Deck[24 + i]);
        }


        for (int i = 0; i < 5; i++)
        {
            Row6.Add(Deck[29 + i]);
        }


        for (int i = 0; i < 5; i++)
        {
            Row7.Add(Deck[34 + i]);
        }


        for (int i = 0; i < 5; i++)
        {
            Row8.Add(Deck[39 + i]);
        }



        for (int i = 0; i < 5; i++)
        {
            Row9.Add(Deck[44 + i]);
        }


        for (int i = 0; i < 5; i++)
        {
            Row10.Add(Deck[49 + i]);
        }


        for (int i = 0; i < 50; i++)
        {
            Beck.Add(Deck[54 + i]);
        }
    }
    private void ClickCard()
    {
        //マウスクリックの判定
        if (Input.GetMouseButtonDown(0)) return;

        //クリックされた位置を取得
        var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Collider2D上クリックの判定
        if (!Physics2D.OverlapPoint(tapPoint)) return;

    }



}