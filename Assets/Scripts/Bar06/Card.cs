using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public void TurnCardFaceUp()
    {
        TurnCard(true);
    }

    public void TurnCardFaceDown()
    {
        TurnCard(false);
    }

    private void TurnCard(bool faceUp)
    {
        Sprite cardSprite = null;

        if (faceUp)
        {
            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/c01");
        }
        else
        {
            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
        }

        var spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cardSprite;
    }




    /* static public void RondomNum()
     {
         System.Random r = new System.Random();
         int[] random = new int[45];
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
     }*/

}