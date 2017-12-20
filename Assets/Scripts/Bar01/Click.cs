using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

	
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
        float Range = 100f;

        var MousePosition = Input.mousePosition;

        if (!Input.GetMouseButtonDown(0)) return;

        var TapPoint = Camera.main.ScreenToWorldPoint(MousePosition);
        Debug.Log(gameObject.name);

        RaycastHit hit = new RaycastHit();
        /*
                if (Physics.Raycast(TapPoint, out hit, Range))
                {

                }

                RaycastHit Hit = new RaycastHit();
                Debug.Log(Hit);
                Debug.Log(Hit.collider);
                Hit.collider.gameObject.transform.position = TapPoint;

                var Hitcard = Physics2D.Raycast(TapPoint, -Vector2.up);
                if (!Hitcard) return;




                var CardName = Hitcard.collider.gameObject.GetComponent<Cards>();
                Debug.Log("hit card is" + Cards.Number);
                */
    }
}
