using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //列挙型...トランプの種類
    public enum PalayingCards
    {
        s,
        h,
        d,
        c,

    }

    //トランプの種類
    public PalayingCards CardType;
    //トランプの数
    public int Number;



    //Sprite [] image = Resources.LoadAll<Sprite> ();で指定したフォルダから画像をまとめて読み込む
    // private Sprite[] image = Resources.LoadAll<Sprite>("Images/Bar/Cards/");

     /*public Card(int number,PalayingCards s)
    {
     Number = number;
     CardType = s;

    }

     private void Start()
    {
     //C# tostring 書式で調べる
     string path = CardType.ToString() + Number.ToString("d2");
     Debug.Log(path);*/
}