using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ClickCard();
	}

    private void ClickCard()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        var TapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!Physics2D.OverlapPoint(TapPoint))return;

        var Hitcard = Physics2D.Raycast(TapPoint, -Vector2.up);
        if (!Hitcard) return;
        Debug.Log(Hitcard);

        /*
        var CardName = Hitcard.collider.gameObject.GetComponent<Cards>();
        Debug.Log("hit card is" + Cards.Number);
        */
    }
}
