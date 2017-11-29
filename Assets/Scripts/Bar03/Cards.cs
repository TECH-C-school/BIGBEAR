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

    //publicはGameControllerから呼び出せる
    public void TurnCardFaceUp()
    {
        TurnCard(true);
    }

    public void TurnCardFaceDown()
    {
        TurnCard(false);
    }
    //privateは呼び出せない
    private void TurnCard(bool faceUp)
    {
        Sprite cardSprite = null;

        if (faceUp)
        {
            cardSprite = Resources.Load<Sprite>(_string);
        }
        else
        {
            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
        }
        var spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cardSprite;
        }
}
