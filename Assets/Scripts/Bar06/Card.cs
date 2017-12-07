using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public void RondomNum()
    {
        System.Random r = new System.Random();
        int[] random = { };
        int i, j, value;
        for (i = 0; i < 45; i++){
            random[i] = i + 1;
        }
        for (i = 0; i < 45; i++){
            i = r.Next(45);
            j = r.Next(45);
            value = random[i];
            random[i] = random[j];
            random[j] = value;
        }
    }

}
