using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar01_04 : MonoBehaviour {

	// Use this for initialization
	void Start (){
        //シャッフルする配列
        int[] ary = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        //Fisher-Yatesアルゴリズムでシャッフルする
        System.Random rng = new System.Random();
        int n = ary.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int tmp = ary[k];
            ary[k] = ary[n];
            ary[n] = tmp;
            Debug.Log(k);      
        }        
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
