using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    //ナンバーを持ってきてセットする
    private int _number;

    public int Number
    {
        get { return _number; }
        set { _number = value; }
    }

    //カードのナンバー管理beta版
    string[] Cards1 = { "c01", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "c13", };
    string[] Cards2 = { "d01", "d02", "d03", "d04", "d05", "d06", "d07", "d08", "d09", "d10", "d11", "d12", "d13", };
    string[] Cards3 = { "h01", "h02", "h03", "h04", "h05", "h06", "h07", "h08", "h09", "h10", "h11", "h12", "h13", };
    string[] Cards4 = { "s01", "s02", "s03", "s04", "s05", "s06", "s07", "s08", "s09", "s10", "s11", "s12", "s13", };

    /// <summary>
    /// 割り当てられたナンバーをCardKeyに変換
    /// </summary>
    /// <returns></returns>
    string cardtype()
    {
        //カードのマーク
        double cardMark = _number / 13 + 1;
        cardMark = Math.Floor(cardMark);
        //カードの数字
        int cardNumber = _number % 13;
        //入れ物作って
        string CardKey = null;
        //調べて
        if (cardMark == 1)
        {
            CardKey = Cards1[cardNumber];
        }

        else if (cardMark == 2)
        {
            CardKey = Cards2[cardNumber];
        }

        else if (cardMark == 3)
        {
            CardKey = Cards3[cardNumber];
        }

        else if (cardMark == 4)
        {
            CardKey = Cards4[cardNumber];
        }

        else
        {
            Debug.Log("Cardの読み込みができませんでした");
        }

        //どーん(?)
        return CardKey;
    }

    /// <summary>
    /// カードを表示するよ
    /// </summary>
    public void CardMake()
    {
        Sprite cardSprite = null;
        cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + cardtype());
        var spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cardSprite;
        Debug.Log(cardSprite);
    }

    /// <summary>
    /// カードのナンバー管理のつもりだった
    /// もしかして --> もういらない
    /// </summary>
    private enum CardsNum
    {
        c01 = 0, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13,
        d01, d02, d03, d04, d05, d06, d07, d08, d09, d10, d11, d12, d13,
        h01, h02, h03, h04, h05, h06, h07, h08, h09, h10, h11, h12, h13,
        s01, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13,
    }

}
