

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardArrangement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        MakeRandomNumbers();

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
