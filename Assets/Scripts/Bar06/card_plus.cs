using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class card_plus : MonoBehaviour {
    // Use this for initialization
    void Start () {
        int[] Scards = new int[13];
        for (int i = 0; i < 13; i++)
        {
            var rand = Random.Range(1, 13);
            Scards[i] = rand;
            Debug.Log(Scards[i]);
        }
        int[] Ccards = new int[13];
        for (int i = 0; i < 13; i++)
        {
            var rand = Random.Range(1, 13);
            Ccards[i] = rand;
            Debug.Log(Ccards[i]);
        }
        int[] Dcards = new int[13];
        for (int i = 0; i < 13; i++)
        {
            var rand = Random.Range(1, 13);
            Dcards[i] = rand;
            Debug.Log(Dcards[i]);
        }
        int[] Hcards = new int[13];
        for (int i = 0; i < 13; i++)
        {
            var rand = Random.Range(1, 13);
            Hcards[i] = rand;
            Debug.Log(Hcards[i]);
        }
        /*int[] mycards = new int[12];
        int[] enemycards = new int[12];
        int S = 1;
        int C = 2;
        int D = 3;
        int H = 4;
        for (int i = 0; i < 4; i++)
        {
            var rand = Random.Range(1, 4);
            Hcards[i] = rand;
            Debug.Log(Hcards[i]);
        }
        */
        //GameObject prefab = (GameObject)Resources.Load("Prefabs/Bar06/caeds");
        //var cardsObject = GameObject.Find("Cards");
    }
}
