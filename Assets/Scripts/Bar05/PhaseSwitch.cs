using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseSwitch : MonoBehaviour {

    //Phase画像の表示
    SpriteRenderer MainSpriteRenderer;
    public Sprite PreFlop;
    public Sprite Flop;
    public Sprite Turn;
    public Sprite River;
    public Sprite ShowDown;

    // Use this for initialization
    void Start () {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log("hoge");
    }
    public void PhaseChange(int PhaseNum)
    {
        Debug.Log("Phase is" + PhaseNum);
        if(PhaseNum == 0)
        {
            MainSpriteRenderer.sprite = PreFlop;
        }
        else if (PhaseNum == 1)
        {
            MainSpriteRenderer.sprite = Flop;
        }
        else if (PhaseNum == 2)
        {
            MainSpriteRenderer.sprite = Turn;
        }
        else if (PhaseNum == 3)
        {
            MainSpriteRenderer.sprite = River;
        }
        else if (PhaseNum == 4)
        {
            MainSpriteRenderer.sprite = ShowDown;
        }
    }
}
