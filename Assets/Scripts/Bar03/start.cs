using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class start : MonoBehaviour {

    List<string> Row = new List<string>();
    List<string> Row2 = new List<string>();
    List<string> Row3 = new List<string>();
    List<string> Row4 = new List<string>();
    List<string> Row5 = new List<string>();
    List<string> Row6 = new List<string>();
    List<string> Row7 = new List<string>();
    List<string> Row8 = new List<string>();
    List<string> Row9 = new List<string>();
    List<string> Row10 = new List<string>();
    List<string> Beck = new List<string>();

    struct Cards
    {
        public int Number;
        public string Mark;
        public bool Decision;
    }


    // Use this for initialization
    void Start() {
        string[] numbers = MakeRandomNumbers();
        MakeRow(numbers);
        MakeCards();

        for(var i = 0; i < 13; i++)
        {
            Cards student = new Cards();
            student.Number = i;
            student.Mark = "c";
            student.Decision = true;
        }

        for (var i = 0; i < 13; i++)
        {
            Cards student = new Cards();
            student.Number = i;
            student.Mark = "d";
            student.Decision = true;
        }

        for (var i = 0; i < 13; i++)
        {
            Cards student = new Cards();
            student.Number = i;
            student.Mark = "h";
            student.Decision = true;
        }

        for (var i = 0; i < 13; i++)
        {
            Cards student = new Cards();
            student.Number = i;
            student.Mark = "s";
            student.Decision = true;
        }

        for (var i = 0; i < 13; i++)
        {
            Cards student = new Cards();
            student.Number = i;
            student.Mark = "c";
            student.Decision = true;
        }

        for (var i = 0; i < 13; i++)
        {
            Cards student = new Cards();
            student.Number = i;
            student.Mark = "d";
            student.Decision = true;
        }

        for (var i = 0; i < 13; i++)
        {
            Cards student = new Cards();
            student.Number = i;
            student.Mark = "h";
            student.Decision = true;
        }

        for (var i = 0; i < 13; i++)
        {
            Cards student = new Cards();
            student.Number = i;
            student.Mark = "s";
            student.Decision = true;
        }

    }

    // Update is called once per frame
    void Update() {

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
            renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Row[i]);
        }
        for (int i = 0; i < 6; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-6.11f, i * 0.31f - -2.05f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Row2[i]);
        }
        for (int i = 0; i < 6; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-4.37f, i * 0.31f - -2.05f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Row3[i]);
        }
        for (int i = 0; i < 6; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-2.633f, i * 0.31f - -2.05f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Row4[i]);
        }
        for (int i = 0; i < 5; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-0.87f, i * 0.31f - -2.362f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Row5[i]);
        }
        for (int i = 0; i < 5; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(0.87f, i * 0.31f - -2.362f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Row6[i]);
        }
        for (int i = 0; i < 5; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(2.62f, i * 0.31f - -2.362f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Row7[i]);
        }
        for (int i = 0; i < 5; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(4.37f, i * 0.31f - -2.362f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Row8[i]);
        }
        for (int i = 0; i < 5; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(6.11f, i * 0.31f - -2.362f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Row9[i]);
        }
        for (int i = 0; i < 5; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(7.85f, i * 0.31f - -2.362f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Row10[i]);
        }
        for (int i = 0; i < 50; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-7.85f, 0 - 2.85f, 0);
            var renderer = cardObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Beck[i]);
        }

    }


    /// <summary>
    /// カードをランダムにする。
    /// </summary>
    private string[] MakeRandomNumbers()
    {
        string[] numbers = {"c01", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "c13",
                            "d01", "d02", "d03", "d04", "d05", "d06", "d07", "d08", "d09", "d10", "d11", "d12", "d13",
                            "h01", "h02", "h03", "h04", "h05", "h06", "h07", "h08", "h09", "h10", "h11", "h12", "h13",
                            "s01", "s02", "s03", "s04", "s05", "s06", "s07", "s08", "s09", "s10", "s11", "s12", "s13",
                            "c01", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "c13",
                            "d01", "d02", "d03", "d04", "d05", "d06", "d07", "d08", "d09", "d10", "d11", "d12", "d13",
                            "h01", "h02", "h03", "h04", "h05", "h06", "h07", "h08", "h09", "h10", "h11", "h12", "h13",
                            "s01", "s02", "s03", "s04", "s05", "s06", "s07", "s08", "s09", "s10", "s11", "s12", "s13" };
        System.Random random = new System.Random();
        for (var i = 0; i < numbers.Length; i++)
        {
            int rnd = UnityEngine.Random.Range(i, numbers.Length);
            var temp = numbers[i];
            numbers[i] = numbers[rnd];
            numbers[rnd] = temp;        
        }
        return numbers;

    }
    private void MakeRow(string[] numbers)
    {

        for(int i = 0; i < 6; i++)
        {
            Row.Add(numbers[i]);
        }


        for (int i = 0; i < 6; i++)
        {
            Row2.Add(numbers[6 + i]);
        }


        for (int i = 0; i < 6; i++)
        {
            Row3.Add(numbers[12 + i]);
        }


        for (int i = 0; i < 6; i++)
        {
            Row4.Add(numbers[18 + i]);
        }


        for (int i = 0; i < 5; i++)
        {
            Row5.Add(numbers[24 + i]);
        }


        for (int i = 0; i < 5; i++)
        {
            Row6.Add(numbers[29 + i]);
        }


        for (int i = 0; i < 5; i++)
        {
            Row7.Add(numbers[34 + i]);
        }


        for (int i = 0; i < 5; i++)
        {
            Row8.Add(numbers[39 + i]);
        }



        for (int i = 0; i < 5; i++)
        {
            Row9.Add(numbers[44 + i]);
        }


        for (int i = 0; i < 5; i++)
        {
            Row10.Add(numbers[49 + i]);
        }


        for (int i = 0; i < 50; i++)
        {
            Beck.Add(numbers[54 + i]);
        }
    }
}
