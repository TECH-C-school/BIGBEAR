using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{

    // Use this for initialization
    void Start() { }




    /*private int[] MakeRandomNumbers() {
        int[] numbers = new int[52];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
        }
        var counter = 0;
        while (counter < 52)
        {
            var index = Random.Range(counter, numbers.Length);
            var tmp = numbers[counter];
            numbers[counter] = numbers[index];
            numbers[index] = tmp;


            counter++;
        }
    }*/
}
            public enum mark
            {
                S = 0,
                C = 1,
                H = 2,
                D = 3
            }
            

    
