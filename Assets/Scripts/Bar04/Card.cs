using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int[] numbers;

    string[] type;

    //列挙型...トランプの種類
    public enum PlayingCards
    {
        s = 0,
        h = 1,
        d = 2,
        c = 3,
    }

    //struct内にまとめることで、構造体名(この場合card)+ 関数名(この場合NumberやPlayingCards)でstruct内を読み込むことができる
    public struct toranpucard
    {
        //トランプの種類
        public PlayingCards CardType;
        //トランプの数
        public int Number;
        //トランプのイメージを読み込む
        public Sprite GetImage()
        {
            string cardFileName = "";

            switch (CardType)
            {
                case PlayingCards.s:
                    cardFileName = "s";
                    break;
                case PlayingCards.h:
                    cardFileName = "h";
                    break;
                case PlayingCards.d:
                    cardFileName = "d";
                    break;
                case PlayingCards.c:
                    cardFileName = "c";
                    break;
            }
            //今回の場合imageの名前がs01などとなっており、基本数値が2桁なので、数値が10未満の場合0を10の位に足す処理をする
            if (Number < 10)
            {
                cardFileName += "0";
            }

            cardFileName += Number.ToString();

            Sprite image = Resources.Load<Sprite>("Images/Bar/Cards/" + cardFileName);
            return image;
        }
        //他にもSprite [] image = Resources.LoadAll<Sprite> ();で指定したフォルダから画像をまとめて読み込む
        //例:private Sprite[] image = Resources.LoadAll<Sprite>("Images/Bar/Cards/");
    }

    //ランダムな整数の生成
    public void MakeRandomNumbers()
    {
        numbers = new int[52];

        type = new string[52];

        for (int i = 0; i < 13; i++)  //配列の初期化
        {
            string cardFileName = "";

            numbers[i] = i + 1;

            if (i < 9)
            {
                cardFileName = "0";
            }

            cardFileName = "s" + cardFileName + numbers[i];

            type[i] = cardFileName;
            //numbers[i].CardType = PlayingCards.s;
        }
        for (int i = 13; i < 26; i++)
        {
            string cardFileName = "";

            numbers[i] = i + 1 - 13;

            if (i < 22)
            {
                cardFileName = "0";
            }

            cardFileName = "d" + cardFileName + numbers[i];

            type[i] = cardFileName;
            //numbers[i].CardType = PlayingCards.d;
        }
        for (int i = 26; i < 39; i++)
        {
            string cardFileName = "";

            numbers[i] = i + 1 - 26;

            if (i < 35)
            {
                cardFileName = "0";
            }

            cardFileName = "c" + cardFileName + numbers[i];

            type[i] = cardFileName;
            //numbers[i].CardType = PlayingCards.c;
        }
        for (int i = 39; i < 52; i++)
        {
            string cardFileName = "";

            numbers[i] = i + 1 - 39;

            if (i < 48)
            {
                cardFileName = "0";
            }

            cardFileName = "h" + cardFileName + numbers[i];

            type[i] = cardFileName;
            //numbers[i].CardType = PlayingCards.h;
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
    }
}

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

//structをnewで初期化
card cards = new card();


private void Cardfolder()
{
switch (cards.CardType)
{
    //enum内の要素数(この場合sなど)を数で判断(要素数の数を指定していればその指定した数で判断する)
    //enumでcaseを使う際、case(enumの構造体名(この場合PlayingCards))要素数(この場合s=0としているので0)をするとエラーが出ない
    case (PlayingCards)0:
        for (cards.Number = 1; cards.Number <= 13; ++cards.Number)
        {
            cards.GetImage();
        }
        break;

    case (PlayingCards)1:
        for (cards.Number = 1; cards.Number <= 13; ++cards.Number)
        {
            cards.GetImage();
        }
        break;

    case (PlayingCards)2:
        for (cards.Number = 1; cards.Number <= 13; ++cards.Number)
        {
            cards.GetImage();
        }
        break;

    case (PlayingCards)3:
        for (cards.Number = 1; cards.Number <= 13; ++cards.Number)
        {
            cards.GetImage();
        }
        break;

}
}
*/
