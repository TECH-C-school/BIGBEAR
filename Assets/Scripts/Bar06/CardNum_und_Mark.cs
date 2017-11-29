using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardNum_und_Mark : MonoBehaviour {

    public int[] setCard = new int[2];
    public int[] setCard2 = new int[2];

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            int setNum = Random.Range(1, 14);
            int setMark = Random.Range(1, 5);
            setCard[i] = setNum;
            setCard2[i] = setMark;
        }
    }
         
}
