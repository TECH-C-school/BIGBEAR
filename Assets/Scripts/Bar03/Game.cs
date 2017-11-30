using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NewBehaviourScript : MonoBehaviour
{    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // カードの生成
    public void MakeCards()
    {
        int count = 0;
        int[] randomCards = MakeRandomCards();
        
        var CardPrefab = Resources.Load("Prefabs/Bar03/Cards");
        var CardObject = GameObject.Find("Cards");

        for(var a = 0; a < 4; a++)
        {
            for(var b = 0; b < 5; b++)
            {
                var cardObject = Instantiate(CardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(
                    a * 1.8f - 5.3f,
                    b * 1.8f - 3.5f,
                    0);
              
            }
        }

        for(var c = 0; c < 6; c++)
        {
            for(var d = 0; d < 4; d++)
            {
                var cardObject2 = Instantiate(CardPrefab, transform.position, Quaternion.identity);
                cardObject2.transform.position = new Vector3(

                    );   
            }
        }

        for(var e = 0; e < 10; e++)
        {
            
        }
    }

    private int[] MakeRandomCards()
    {
        int[] values = new int[13];
        for (int a = 0; a < 13; a++)
        {
            values[a] = a + 1;
        }

        var counter = 0;
        while (counter < 13)
        {
            var index = UnityEngine.Random.Range(counter, values.Length);
            var tmp = values[counter];
            values[counter] = values[index];
            values[index] = tmp;

            counter++;
        }
        return values;
    }

    public void ClickCards()
    {

    }


   
}
