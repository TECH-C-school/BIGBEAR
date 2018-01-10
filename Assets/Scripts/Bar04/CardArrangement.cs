

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardArrangement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var cards = MakeRandomNumbers();
        var eachCard = cards[0];

        string cardString = eachCard.CardString();

        var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/Card");
        var cardObject = Instantiate(cardPrefab, new Vector3(0, 1.5f, 0), Quaternion.identity);
        var spriteRenderer = cardObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + cardString);


        
    }

    public enum Mark
    {
        Clover,
        Diamond,
        Heart,
        Spade
    }

    public struct Card
    {
        public int number;
        public Mark mark;

        public string CardString()
        {
            string cardString = "";
            switch (mark)
            {
                case Mark.Clover:
                    cardString = "c";
                    break;
                case Mark.Diamond:
                    cardString = "d";
                    break;
                case Mark.Heart:
                    cardString = "h";
                    break;
                case Mark.Spade:
                    cardString = "s";
                    break;

            }

            if (number < 10)
            {
                cardString += "0";
            }

            cardString += number.ToString();

            return cardString;
        }
    }


    //プレハブを変数に代入
    public GameObject cardback;


    //オブジェクトの座標
    //private void MakeCard()
    //{
    //    int count = 0;
    //    int[] randomNumbers = MakeRandomNumbers();
    //    var cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
    //    var cardsObject = GameObject.Find("Cards");

    //    for (var i = 0; i < 5; i++)
    //    {
    //        for (var j = 0; j < 5; j++)
    //        {
    //            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
    //            cardObject.transform.position = new Vector3(
    //                i * 1.27f - 3.87f,
    //                j * 1.27f - 2.54f,
    //                0);
    //            cardObject.transform.parent = cardsObject.transform;

    //            var card = cardObject.GetComponent<Card>();
    //            card.Number = randomNumbers[count];
    //            card.TurnCardFaceDown();
    //            count++;

    //        }
    //    }
    //}


    private Card[] MakeRandomNumbers()
    {
        //０から５１まで引き出しあるよ
        Card[] cards = new Card[52];

        //クローバー1～13のカードを用意する
        int number = 1;
        for (var i = 0; i < 13; i++)
        {
            cards[i].mark = Mark.Clover;
            cards[i].number = number;
            number++;
        }

        //ハート1～13のカードを用意する
        number = 1;
        for (var i = 13; i < 26; i++)
        {
            cards[i].mark = Mark.Heart;
            cards[i].number = number;
            number++;
        }

        //ダイヤ1～13のカードを用意する
        number = 1;
        for (var i = 26; i < 39; i++)
        {
            cards[i].mark = Mark.Diamond;
            cards[i].number = number;
            number++;
        }

        //スペード１～１３のカードを用意する
        number = 1;
        for (var i = 39; i < 52; i++)
        {
            cards[i].mark = Mark.Spade;
            cards[i].number = number;
            number++;
        }
        var counter = 0;
        while (counter < 52)
        {
            //51までのランダムな数字を作ることを指示（０に1から52を代入するから51である）
            var index = Random.Range(counter, cards.Length);
            //数字を51まで作り、ぐちゃぐちゃランダムにしている
            var tmp = cards[counter];
            cards[counter] = cards[index];
            cards[index] = tmp;

            counter++;
        }
        //Sprite c01 = Resources.Load<Sprite>("Images/Bar/Cards/c01");
        //Sprite c02 = Resources.Load<Sprite>("Images/Bar/Cards/c02");
        //Sprite c03 = Resources.Load<Sprite>("Images/Bar/Cards/c03");
        //Sprite c04 = Resources.Load<Sprite>("Images/Bar/Cards/c04");
        //Sprite c05 = Resources.Load<Sprite>("Images/Bar/Cards/c05");
        //Sprite c06 = Resources.Load<Sprite>("Images/Bar/Cards/c06");
        //Sprite c07 = Resources.Load<Sprite>("Images/Bar/Cards/c07");
        //Sprite c08 = Resources.Load<Sprite>("Images/Bar/Cards/c08");
        //Sprite c09 = Resources.Load<Sprite>("Images/Bar/Cards/c09");
        //Sprite c10 = Resources.Load<Sprite>("Images/Bar/Cards/c10");
        //Sprite c11 = Resources.Load<Sprite>("Images/Bar/Cards/c11");
        //Sprite c12 = Resources.Load<Sprite>("Images/Bar/Cards/c12");
        //Sprite c13 = Resources.Load<Sprite>("Images/Bar/Cards/c13");
        //Sprite d01 = Resources.Load<Sprite>("Images/Bar/Cards/d01");
        //Sprite d02 = Resources.Load<Sprite>("Images/Bar/Cards/d02");
        //Sprite d03 = Resources.Load<Sprite>("Images/Bar/Cards/d03");
        //Sprite d04 = Resources.Load<Sprite>("Images/Bar/Cards/d04");
        //Sprite d05 = Resources.Load<Sprite>("Images/Bar/Cards/d05");
        //Sprite d06 = Resources.Load<Sprite>("Images/Bar/Cards/d06");
        //Sprite d07 = Resources.Load<Sprite>("Images/Bar/Cards/d07");
        //Sprite d08 = Resources.Load<Sprite>("Images/Bar/Cards/d08");
        //Sprite d09 = Resources.Load<Sprite>("Images/Bar/Cards/d09");
        //Sprite d10 = Resources.Load<Sprite>("Images/Bar/Cards/d10");
        //Sprite d11 = Resources.Load<Sprite>("Images/Bar/Cards/d11");
        //Sprite d12 = Resources.Load<Sprite>("Images/Bar/Cards/d12");
        //Sprite d13 = Resources.Load<Sprite>("Images/Bar/Cards/d13");
        //Sprite h01 = Resources.Load<Sprite>("Images/Bar/Cards/h01");
        //Sprite h02 = Resources.Load<Sprite>("Images/Bar/Cards/h02");
        //Sprite h03 = Resources.Load<Sprite>("Images/Bar/Cards/h03");
        //Sprite h04 = Resources.Load<Sprite>("Images/Bar/Cards/h04");
        //Sprite h05 = Resources.Load<Sprite>("Images/Bar/Cards/h05");
        //Sprite h06 = Resources.Load<Sprite>("Images/Bar/Cards/h06");
        //Sprite h07 = Resources.Load<Sprite>("Images/Bar/Cards/h07");
        //Sprite h08 = Resources.Load<Sprite>("Images/Bar/Cards/h08");
        //Sprite h09 = Resources.Load<Sprite>("Images/Bar/Cards/h09");
        //Sprite h10 = Resources.Load<Sprite>("Images/Bar/Cards/h10");
        //Sprite h11 = Resources.Load<Sprite>("Images/Bar/Cards/h11");
        //Sprite h12 = Resources.Load<Sprite>("Images/Bar/Cards/h12");
        //Sprite h13 = Resources.Load<Sprite>("Images/Bar/Cards/h13");
        //Sprite s01 = Resources.Load<Sprite>("Images/Bar/Cards/s01");
        //Sprite s02 = Resources.Load<Sprite>("Images/Bar/Cards/s02");
        //Sprite s03 = Resources.Load<Sprite>("Images/Bar/Cards/s03");
        //Sprite s04 = Resources.Load<Sprite>("Images/Bar/Cards/s04");
        //Sprite s05 = Resources.Load<Sprite>("Images/Bar/Cards/s05");
        //Sprite s06 = Resources.Load<Sprite>("Images/Bar/Cards/s06");
        //Sprite s07 = Resources.Load<Sprite>("Images/Bar/Cards/s07");
        //Sprite s08 = Resources.Load<Sprite>("Images/Bar/Cards/s08");
        //Sprite s09 = Resources.Load<Sprite>("Images/Bar/Cards/s09");
        //Sprite s10 = Resources.Load<Sprite>("Images/Bar/Cards/s10");
        //Sprite s11 = Resources.Load<Sprite>("Images/Bar/Cards/s11");
        //Sprite s12 = Resources.Load<Sprite>("Images/Bar/Cards/s12");
        //Sprite s13 = Resources.Load<Sprite>("Images/Bar/Cards/s13");

        

       /* var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
        cardObject.transform.position = new Vector3(
            i * 1.27f - 3.87f,
            j * 1.27f - 2.54f,
            0);
        cardObject.transform.parent = cardsObject.transform;*/

        for (int i = 0; i < 52; i++)
        {
            Debug.Log(cards[i].mark + ":" + cards[i].number);
        }

        return cards;
    }


    public GameObject obj;






    /*          public class ObjectGenerator : MonoBehaviour
          {
              [SerializeField]
              GameObject prefab;

              void Start()
              {
                  float x = Random.Range(0f, 9f);
                  float y = 0;
                  float zRandom.Range(0f, 9f);
                  Vector3 position = new Vector3(x, y, z);
                  Instantiate(prefab, new Vector3.Zero);
              }
          }*/
}
