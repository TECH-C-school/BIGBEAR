using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{

    private int _number;
    private string _string;
    public int Number
    {
        get { return _number; }
        set { _number = value; }
    }


    public string String
    {
        get { return _string; }
        set { _string = value; }
    }

    //ターンカードのfaceUpをtrueにする関数(表)
    public void TurnCardFaceUp()
    {
        TurnCard(true);
    }

    //ターンカードのfaceUpをtrueにする関数(表)
    public void TurnCardFaceDown()
    {
        TurnCard(false);
    }
    //カードをターンする関数（private）
    private void TurnCard(bool faceUp)
    {
        Sprite cardSprite = null;

        if (faceUp)
        {
            cardSprite = Resources.Load<Sprite>("images/Bar/Cards/" + _string);
        }
        else
        {
            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
        }
        var spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cardSprite;
        
    }
}
