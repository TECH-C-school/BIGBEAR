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
        int[] setCard = new int[2];
        int[] setCard2 = new int[2];

        for (int i = 0; i < 2; i++)
        {
            int setNum = UnityEngine.Random.Range(1, 14);
            int setMark = UnityEngine.Random.Range(1, 5);
            setCard[i] = setNum;
            setCard2[i] = setMark;
        }

        Sprite[] sprites = Resources.LoadAll<Sprite>("Images/Bar/Cards");

        Sprite cdScripts = null;

        for (int i = 0; i < 2; i++)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var cardsObject = GameObject.Find("cards");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(i * -3,-3,0);

           


            switch (setCard[i])
            {
                case 1:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c01");

                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d01");
                    }
                    else if (setCard2[i] == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h01");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s01");
                    }
                    break;

                case 2:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c02");
                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d02");
                    }
                    else if (setCard2[i] == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h02");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s02");
                    }
                    break;

                case 3:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c03");
                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d03");
                    }
                    else if (setCard2[i] == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h03");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s03");
                    }
                    break;

                case 4:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c04");
                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d04");
                    }
                    else if (setCard2[i] == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h04");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s04");
                    }
                    break;

                case 5:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c05");
                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d05");
                    }
                    else if (setCard2[i] == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h05");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s05");
                    }
                    break;

                case 6:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c06");
                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d06");
                    }
                    else if (setCard2[i] == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h06");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s06");
                    }
                    break;

                case 7:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c07");
                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d07");
                    }
                    else if (setCard2[i] == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h07");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s07");
                    }
                    break;

                case 8:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c08");
                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d08");
                    }
                    else if (setCard2[i] == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h08");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s08");
                    }
                    break;

                case 9:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c09");
                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d09");
                    }
                    else if (setCard2[i] == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h09");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s09");
                    }
                    break;

                case 10:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c10");
                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d10");
                    }
                    else if (setCard2[i] == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h10");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s10");
                    }
                    break;

                case 11:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c11");
                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d11");
                    }
                    else if (setCard2[i]  == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h11");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s11");
                    }
                    break;

                case 12:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c12");
                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d12");
                    }
                    else if (setCard2[i] == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h12");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s12");
                    }
                    break;

                case 13:
                    if (setCard2[i] == 1)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c13");
                    }
                    else if (setCard2[i] == 2)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d13");
                    }
                    else if (setCard2[i] == 3)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h13");
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s13");
                    }
                    break;
            }
        }
    }
}

public static class RectTransformExt
{
    public static float GetWidth(this RectTransform cardsize)
    {
        return cardsize.sizeDelta.x;
    }

    public static float GetHeight(this RectTransform cardsize)
    {
        return cardsize.sizeDelta.y;
    }

    public static void SetWidth(this RectTransform cardsize, float width)
    {
        var size = cardsize.sizeDelta;
        size.x = 348;
        cardsize.sizeDelta = size;
    }

    public static void SetHeight(this RectTransform cardsize, float height)
    {
        var size = cardsize.sizeDelta;
        size.y = 539;
        cardsize.sizeDelta = size;
    }

    public static void SetSize(this RectTransform cardsize, float width, float height)
    {
        cardsize.sizeDelta = new Vector2(width, height);
    }
}

