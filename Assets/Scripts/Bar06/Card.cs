using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    // Use this for initialization
    public int _number;
    public string _mark;
    public Sprite cardSprite = null;

    public int Number
    {
        get { return _number; }
        set { _number = value; }
    }
    public string mark
    {
        get { return _mark; }
        set { _mark = value; }
    }
    
    public void Mark()
    {
        
        if (_number < 10) { cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/"+mark+"0"+ _number); }
        else { cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + mark  + _number); }

        var spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cardSprite;

        
    }
    public void nMark()
    {
        Sprite cardSprite = null;
        cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
        var spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cardSprite;


    }
    public void OnClick()
    {
        Mark();

    }
}
