﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MakeCards();
        MakeRandomNumbers();
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
    /// <summary>
    /// カードをランダムにする。
    /// </summary>
    private string[] MakeRandomNumbers()
    {
        string[] numbers = {"c01", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "c13",
                            "d01", "d02", "d03", "d04", "d05", "d06", "d07", "d08", "d09", "d10", "d11", "d12", "d13",
                            "h01", "h02", "h03", "h04", "h05", "h06", "h07", "h08", "h09", "h10", "h11", "h12", "h13",
                            "s01", "s02", "s03", "s04", "s05", "s06", "s07", "s08", "s09", "s10", "s11", "s12", "s13"};
        System.Random random = new System.Random();
        int rnd = UnityEngine.Random.Range(1, 53);
        for (var i = 0; i < numbers.Length; i++)
        {
            var temp = numbers[i];
            numbers[i] = numbers[rnd];
            numbers[rnd] = temp;
        }
        return numbers;

    }
}
