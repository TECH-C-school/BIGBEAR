using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MakeCards();
	}

	private void MakeCards()
    {
        var cardprefab = Resources.Load<GameObject>("Prefabs/Bar04/Card");

        for (int i = 0; i < 5; i++)
        {
            var cardObject = Instantiate(cardprefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(i * 1.27f - 3.84f,0);
            cardObject.transform.parent = cardObject.transform;
        }
    }
		
	// Update is called once per frame
	void Update () {
		
	}
}
