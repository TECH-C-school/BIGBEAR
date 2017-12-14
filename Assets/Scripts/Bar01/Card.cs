using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class Card : MonoBehaviour {

    Renderer Cardcorol;

    string[] Cards = {
            "c01","c02","c03","c04","c05","c06","c07","c08","c09","c10","c11","c12","c13",
            "h01","h02","h03","h04","h05","h06","h07","h08","h09","h10","h11","h12","h13",
            "d01","d02","d03","d04","d05","d06","d07","d08","d09","d10","d11","d12","d13",
            "s01","s02","s03","s04","s05","s06","s07","s08","s09","s10","s11","s12","s13",           
        };

    int[] CardsNumber = {
            1,2,3,4,5,6,7,8,9,10,11,12,13,
            1,2,3,4,5,6,7,8,9,10,11,12,13,
            1,2,3,4,5,6,7,8,9,10,11,12,13,
            1,2,3,4,5,6,7,8,9,10,11,12,13,            
        };

    string[] CardsCollar = {
           "Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak",
           "Red","Red","Red","Red","Red","Red","Red","Red","Red","Red","Red","Red","Red",
           "Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak","Blcak",
           "Red","Red","Red","Red","Red","Red","Red","Red","Red","Red","Red","Red","Red",
       };

    int n_Number;

    public int Number
    {
        get { return n_Number; }
        set { n_Number = value; }
    }
    public void TurnCardFaceUp()
    {
        TurnCard(true);
    }

    public void TurnCardFaceDown()
    {
        TurnCard(false);
    }

    private void TurnCard(bool FaceUp)
    {
        Sprite Cardsprite = null;

        if (FaceUp)
        {
            Cardsprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Cards[n_Number]);
        }
        else
        {
            Cardsprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
        }
        var spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Cardsprite;
    }   
}
