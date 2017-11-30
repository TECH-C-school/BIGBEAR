using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MakeCards();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
/// <summary>
/// カード生成(104枚)
/// </summary>
    private void MakeCards()
    {
        /// <summary>
        /// 上のカード生成(54枚)
        /// </summary>
        for (int i = 0; i < 4; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(i * 1.745f - 7.85f, 2.00f, 0);
        }
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(i * 1.745f - 7.85f, j * 0.32f - -2.30f, 0);
            }
        }
        /// <summary>
        /// DECKのカード生成(50枚)
        /// </summary>
         for (int i = 0; i < 50; i++)
         {
             var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar03/Card");
             var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
             cardObject.transform.position = new Vector3(0 - 7.87f, -2.85f, 0);
         }      
    }
}
