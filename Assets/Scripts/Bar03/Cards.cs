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
    [SerializeField]
    private int _cardCount;
    [SerializeField]
    bool _selecting = false;
    [SerializeField]
    private int _parering;
    private Cards[] _parentAry = new Cards[13];

    //カードのｘ
    public int X
    {
        get { return _number; }
        set { _number = value; }
    }

    //カードのｙ
    public int Y
    {
        get { return _deckNumber; }
        set { _deckNumber = value; }
    }

    //カードのマーク＆数字(文字列)
    public string String
    {
        get { return _string; }
        set { _string = value; }
    }

    //カードの置かれた順番デッキからカードを送るのにつかわれる
    public int Count
    {
        get { return _cardCount; }
        set { _cardCount = value; }
    }
    //カードか表かどうか確認する
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

    //カードがつながっているか
    public int pareCard
    {

        get { return _parering; }
        set { _parering = value; }
    }

    //なんで作ったのかよくわかんないやつ
    public Cards[] pareAry
    {
        get { return _parentAry; }
        set { _parentAry = value; }
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
        GameObject selectCard = Resources.Load<GameObject>("Prefabs/Bar03/Select");
        if (!_selecting)
        {
            _selecting = true;
            selectCard.SetActive(true);
        }
        else
        {
            _selecting = false;
            selectCard.SetActive(false);
        }
    }
}
