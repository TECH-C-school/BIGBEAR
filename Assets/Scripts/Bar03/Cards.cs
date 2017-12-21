using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    private int _number;
    private string _string;
    public string String
    {
        get { return _string; }
        set { _string = value; }
    }
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


    private void TurnCard(bool faceUp)
    {
        Sprite Cardsprite = null;
        Sprite Numbersprite = null;

        if (faceUp)
        {
            Numbersprite = Resources.Load<Sprite>("Images/Bar/" + _number);
        }
        else
        {
            Cardsprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
        }
        var spriteRederer = transform.GetComponent<SpriteRenderer>();
        spriteRederer.sprite = Cardsprite;
        var numberObject = transform.Find("GameController");
        var numberSpriteRenderer = numberObject.GetComponent<SpriteRenderer>();
        numberSpriteRenderer.sprite = Numbersprite;
    }
}
