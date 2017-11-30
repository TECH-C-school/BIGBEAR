using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCards : MonoBehaviour
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
        int y = Random.Range(1, 4);
        string z = "";
        if (y == 1)
        {
            return z = "c";
        }
        else if (y == 2)
        {
            return z = "a";
        }
        else if (y == 3)
        {
            return z = "h";
        }
        else
        {
            return z = "s";
        }
        Debug.Log(z);
    }
}
