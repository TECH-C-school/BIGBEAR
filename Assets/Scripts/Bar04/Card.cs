using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //列挙型...トランプの種類
    public enum PlayingCards
    {
        s = 0,
        h = 1,
        d = 2,
        c = 3,
    }

    //struct内にまとめることで、構造体名(この場合card)[].関数名(この場合NumberやPlayingCards)でstruct内を読み込むことができる
    private struct card
    {
        //トランプの種類
        public PlayingCards CardType;
        //トランプの数
        public int Number;

    }
    //structをnewで初期化
    card cards = new card();


    private void Cardfolder()
    {
        switch (cards.CardType)
        {
            //enum内の要素数(この場合sなど)を数で判断(要素数の数を指定していればその指定した数で判断する)
            //enumでcaseを使う際、case(enumの構造体名(この場合PlayingCards))要素数(この場合s=0としているので0)をするとエラーが出ない
            case (PlayingCards)0:
                if (cards.Number == 1) {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s01");
                }
                else if (cards.Number == 2)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s02");
                }
                else if (cards.Number == 3)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s03");
                }
                else if (cards.Number == 4)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s04");
                }
                else if (cards.Number == 5)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s05");
                }
                else if (cards.Number == 6)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s06");
                }
                else if (cards.Number == 7)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s07");
                }
                else if (cards.Number == 8)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s08");
                }
                else if (cards.Number == 9)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s09");
                }
                else if (cards.Number == 10)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s10");
                }
                else if (cards.Number == 11)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s11");
                }
                else if (cards.Number == 12)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s12");
                }
                else if (cards.Number == 13)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/s13");
                }
                break;
                
            case (PlayingCards)1:
                if (cards.Number == 14)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h01");
                }
                else if (cards.Number == 15)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h02");
                }
                else if (cards.Number == 16)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h03");
                }
                else if (cards.Number == 17)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h04");
                }
                else if (cards.Number == 18)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h05");
                }
                else if (cards.Number == 19)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h06");
                }
                else if (cards.Number == 20)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h07");
                }
                else if (cards.Number == 21)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h08");
                }
                else if (cards.Number == 22)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h09");
                }
                else if (cards.Number == 23)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h10");
                }
                else if (cards.Number == 24)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h11");
                }
                else if (cards.Number == 25)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h12");
                }
                else if (cards.Number == 26)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/h13");
                }
                break;

            case (PlayingCards)2:
                if (cards.Number == 27)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d01");
                }
                else if (cards.Number == 28)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d02");
                }
                else if (cards.Number == 29)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d03");
                }
                else if (cards.Number == 30)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d04");
                }
                else if (cards.Number == 31)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d05");
                }
                else if (cards.Number == 32)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d06");
                }
                else if (cards.Number == 33)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d07");
                }
                else if (cards.Number == 34)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d08");
                }
                else if (cards.Number == 35)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d09");
                }
                else if (cards.Number == 36)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d10");
                }
                else if (cards.Number == 37)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d11");
                }
                else if (cards.Number == 38)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d12");
                }
                else if (cards.Number == 39)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/d13");
                }
                break;

            case (PlayingCards)3:
                if (cards.Number == 40)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c01");
                }
                else if (cards.Number == 41)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c02");
                }
                else if (cards.Number == 42)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c03");
                }
                else if (cards.Number == 43)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c04");
                }
                else if (cards.Number == 44)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c05");
                }
                else if (cards.Number == 45)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c06");
                }
                else if (cards.Number == 46)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c07");
                }
                else if (cards.Number == 47)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c08");
                }
                else if (cards.Number == 48)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c09");
                }
                else if (cards.Number == 49)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c10");
                }
                else if (cards.Number == 50)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c11");
                }
                else if (cards.Number == 51)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c12");
                }
                else if (cards.Number == 52)
                {
                    Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/c13");
                }
                break;
        }
    }

    //ランダムな整数の生成
    private int[] MakeRandomNumbers()
        {
            int[] numbers = new int[52];

            for (int i = 0; i < numbers.Length; i++)  //配列の初期化
            {
                numbers[i] = i + 1;
            }
            var counter = 0;
            while (counter < 52)
            {
                var index = Random.Range(counter, numbers.Length);
                var tmp = numbers[counter];
                numbers[counter] = numbers[index];
                numbers[index] = tmp;

                counter++;
            }
            return numbers;
        }

    //Sprite [] image = Resources.LoadAll<Sprite> ();で指定したフォルダから画像をまとめて読み込む
    //private Sprite[] image = Resources.LoadAll<Sprite>("Images/Bar/Cards/");

    /* public Card(int number,PlayingCards s)
    {

     Number = number;
     CardType = s;

    }

    private void Start()
    {
        //C# tostring 書式で調べる
        //string path = CardType.ToString() + Number.ToString("d2");
        //Debug.Log(path);
    }
    */
}