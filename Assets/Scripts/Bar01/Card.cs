using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    private int _number;

    public int Number
    {
        get { return _number; }
        set { _number = value; }
    }


    public void TurnCardFaceUp()
    {
        TurnCard(true);
    }

    public void TurnCardFaceDown()
    {
        TurnCard(false);
    }

    private void TurnCard(bool faceup)
    {
        Sprite CardSprite = null;
        Sprite numberSprite = null;

        if (faceup)
        {
            CardSprite = Resources.Load<Sprite>("Images/card_frontside");
            numberSprite = Resources.Load<Sprite>("Images/" + _number);
        }
        else
        {
            CardSprite = Resources.Load<Sprite>("Images/card_backside");
        }

        var spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CardSprite;

        var numberObject = transform.Find("Nunber");
        var numberSpriteRenderer = numberObject.GetComponent<SpriteRenderer>();
        numberSpriteRenderer.sprite = numberSprite;


    }
}
