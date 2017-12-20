using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar0104 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}    

    private void ClickCard()
    {
        //マウスクリックの判定
        if (!Input.GetMouseButtonDown(0)) return;

        //クリックされた位置を取得
        var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Collider2D上のクリックの判定
        if (!Physics2D.OverlapPoint(tapPoint)) return;

        //クリックした位置のオブジェクトを取得
        var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
        if (!hitObject) return;

        //クリックされたカードスクリプトを取得
        var card = hitObject.collider.gameObject.GetComponent<Card>();
        Debug.Log("hit object is " + card.Number);                            
    }
}
