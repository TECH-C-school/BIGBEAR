﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Card1();
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*private void MakePlayerCards()
    {

     }

     */
    private int Card1()
    {
        int x = Random.Range(1, 13);
        return x;
        Debug.Log(x);
    }
    private string Card1t()
    {
        int y = Random.Range(0, 4);
        string z = "";
        if (y == 0) {};
        if (y == 0) { Debug.Log(Deck.diamond)};
    }

        public enum Deck
    {
        diamond,
        clubs,
        hearts,
        spade
    }
    
}
