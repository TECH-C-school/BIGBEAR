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
    }
}
