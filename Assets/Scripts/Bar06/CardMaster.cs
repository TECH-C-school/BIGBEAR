using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMaster : MonoBehaviour
{
    void Start()
    {
        MakeCard();
    }

    public void MakeCard()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("CardObjects");

        Sprite[] sprites = Resources.LoadAll<Sprite>("Images/Cards");

        foreach(GameObject cds in cards)
        {
            SpriteRenderer cdsObRender = cds.GetComponent<SpriteRenderer>();

            int[] textureNum = cds.GetComponent<CardNum_und_Mark>().setCard;
            int[] textureNum2 = cds.GetComponent<CardNum_und_Mark>().setCard2;

            for (int i = 0; i < 2; i++)
            {
                switch (textureNum[i])
                {
                    case 1:
                        if (textureNum2[i] == 1)
                        {
                            cdsObRender.sprite = sprites[1];
                        }
                        else if (textureNum2[i] == 2)
                        {
                            cdsObRender.sprite = sprites[14];
                        }
                        else if (textureNum2[i] == 3)
                        {
                            cdsObRender.sprite = sprites[27];
                        }
                        else
                        {
                            cdsObRender.sprite = sprites[41];
                        }
                        break;

                    case 2:
                        if (textureNum2[i] == 1)
                        {
                            cdsObRender.sprite = sprites[2];
                        }
                        else if (textureNum2[i] == 2)
                        {
                            cdsObRender.sprite = sprites[15];
                        }
                        else if (textureNum2[i] == 3)
                        {
                            cdsObRender.sprite = sprites[28];
                        }
                        else
                        {
                            cdsObRender.sprite = sprites[42];
                        }
                        break;

                    case 3:
                        if (textureNum2[i] == 1)
                        {
                            cdsObRender.sprite = sprites[3];
                        }
                        else if (textureNum2[i] == 2)
                        {
                            cdsObRender.sprite = sprites[16];
                        }
                        else if (textureNum2[i] == 3)
                        {
                            cdsObRender.sprite = sprites[29];
                        }
                        else
                        {
                            cdsObRender.sprite = sprites[43];
                        }
                        break;

                    case 4:
                        if (textureNum2[i] == 1)
                        {
                            cdsObRender.sprite = sprites[4];
                        }
                        else if (textureNum2[i] == 2)
                        {
                            cdsObRender.sprite = sprites[17];
                        }
                        else if (textureNum2[i] == 3)
                        {
                            cdsObRender.sprite = sprites[30];
                        }
                        else
                        {
                            cdsObRender.sprite = sprites[44];
                        }
                        break;
                }
            }
        }
    }
}
