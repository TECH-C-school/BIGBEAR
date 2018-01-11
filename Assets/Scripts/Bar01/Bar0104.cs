using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar0104 : MonoBehaviour {

    GameObject Catch;

    int m_NextCard = 0;
    public int[] Dack;
    
    public int NextCard {
        get { return m_NextCard; }
        set { m_NextCard = value; }
    }

    // Use this for initialization
    void Start () { Dack = MakeRandomNunbers(); }
	// Update is called once per frame
	void Update () {}

    private int[] MakeRandomNunbers()
    {
        int[] values = new int[52];
        for(int i = 0; i < 52; i++){
            values[i] = i;
        }
        var counter = 0;
        while (counter < 52)
        {
            var index = Random.Range(counter, values.Length);
            var tmp = values[counter];
            values[counter] = values[index];
            values[index] = tmp;
            counter++;
        }
        return values;
    }

    private void ClickCards()
    {
        //マウスクリックの判定
        if (!Input.GetMouseButtonDown(0)) return;

        //クリックされた位置を取得
        var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Collider2D上のクリックの判定
        if (!Physics2D.OverlapPoint(tapPoint)) return;
        Debug.Log("hogehoge");
        //クリックした位置のオブジェクトを取得
        var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
        Debug.Log(hitObject);
        if (!hitObject) return;

        Catch = hitObject.transform.gameObject;
        Debug.Log(Catch);

        //クリックされたカードスクリプトを取得
        //var card = hitObject.collider.gameObject.GetComponent<Card>();
        //Debug.Log("hit object is " + card.Number);                            
    }
}
