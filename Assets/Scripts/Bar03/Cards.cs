using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{

    [SerializeField]
    private int _number;
    [SerializeField]
    private string _string;
    [SerializeField]
    private int _deckNumber;
    [SerializeField]
    private bool _isFront;

    public int Deck
    {
        get { return _number; }
        set { _number = value; }
    }

    public int DeckNum
    {
        get { return _deckNumber; }
        set { _deckNumber = value; }
    }
    public string String
    {
        get { return _string; }
        set { _string = value; }
    }

    public bool IsFront
    {
        get
        {
            return _isFront;
        }

        set
        {
            _isFront = value;
        }
    }

    //ターンカードのfaceUpをtrueにする関数(表)
    public void TurnCardFaceUp()
    {
        TurnCard(true);
        _isFront = true;
    }

    //ターンカードのfaceUpをtrueにする関数(表)
    public void TurnCardFaceDown()
    {
        TurnCard(false);
        _isFront = false;
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
    public void cardSelect()
    {
        GameObject cardPrefabs = Resources.Load<GameObject>("Prefabs/Bar03/Select");
    }
}
