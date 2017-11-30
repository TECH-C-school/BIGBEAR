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
            var cardObject = Instantiate(gameObject, transform.position, Quaternion.identity);
        }
    }
		
	// Update is called once per frame
	void Update () {
		
	}
}
