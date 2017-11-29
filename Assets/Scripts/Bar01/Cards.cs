using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    class Makecard
    {
        static public int[] c = new int[13];
        public int[] d = new int[13];
        public int[] h = new int[13];
        public int[] s = new int[13];
    }

    void Start()
    {
        var cardsObject = GameObject.Find("back");
        cardsObject.transform.position = new Vector3(0, 0, 0);
    }


    void Update()
    {

    }

    int[] MakeRandomNumber()
    {
        int[] number = new int[13];
        for (int i = 0; i < 13; i++)
        {
            number[i] = i + 1;
        }
        int count = 0;
        while ( count < 13)
        {
            var index = Random.Range(count, number.Length);
            var tmp = number[count];
            number[count] = number[index];
            number[index] = tmp;

            count++;
        }
        return number;
    }
}
