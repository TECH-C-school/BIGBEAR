using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMaster : MonoBehaviour
{
    SpriteRenderer CdSpriteRenderer;
    public enum Mark
    {
        Clover = 0,
        Diamond,
        Heart,
        Spade
    }

    public struct Card
    {
        public int number;
        public Mark mark;
    }



    void Start()
    {
        MakeCard();
    }

    public void MakeCard()
    {
        Card[] setCard = new Card[2];
        Card[] setCard2 = new Card[2];

        for (int i = 0; i < 2; i++)
        {
            int setNum = UnityEngine.Random.Range(1, 14);
            int setMark = UnityEngine.Random.Range(0, 4);
            
            setCard[i].number = setNum;
            setCard2[i].number = setMark;
        }
       
        Sprite cdScripts = null;

        for (int i = 0; i < 2; i++)
        {
            //カードの生成
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var cardsObject = GameObject.Find("cards");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(i * -0.6f,-2.8f,0);
            cardObject.transform.localScale = new Vector3(0.3f, 0.3f, 1);

            SpriteRenderer CdRenderer = cardObject.GetComponent<SpriteRenderer>();

            switch (setCard[i].number)
            {
                case 1:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c01");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d01");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h01");
                        CdRenderer.sprite = cdScripts;
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s01");
                        CdRenderer.sprite = cdScripts;
                    }
                    break;

                case 2:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c02");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d02");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h02");
                        CdRenderer.sprite = cdScripts;
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s02");
                        CdRenderer.sprite = cdScripts;
                    }
                    break;

                case 3:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c03");
                        CdRenderer.sprite = cdScripts;

                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d03");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h03");
                        CdRenderer.sprite = cdScripts;

                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s03");
                        CdRenderer.sprite = cdScripts;
                    }
                    break;

                case 4:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c04");
                        CdRenderer.sprite = cdScripts;

                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d04");
                        CdRenderer.sprite = cdScripts;

                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h04");
                        CdRenderer.sprite = cdScripts;

                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s04");
                        CdRenderer.sprite = cdScripts;

                    }
                    break;

                case 5:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c05");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d05");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h05");
                        CdRenderer.sprite = cdScripts;
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s05");
                        CdRenderer.sprite = cdScripts;
                    }
                    break;

                case 6:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c06");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d06");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h06");
                        CdRenderer.sprite = cdScripts;
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s06");
                        CdRenderer.sprite = cdScripts;
                    }
                    break;

                case 7:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c07");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d07");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h07");
                        CdRenderer.sprite = cdScripts;
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s07");
                        CdRenderer.sprite = cdScripts;
                    }
                    break;

                case 8:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c08");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d08");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h08");
                        CdRenderer.sprite = cdScripts;
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s08");
                        CdRenderer.sprite = cdScripts;
                    }
                    break;

                case 9:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c09");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d09");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h09");
                        CdRenderer.sprite = cdScripts;
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s09");
                        CdRenderer.sprite = cdScripts;
                    }
                    break;

                case 10:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c10");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d10");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h10");
                        CdRenderer.sprite = cdScripts;
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s10");
                        CdRenderer.sprite = cdScripts;
                    }
                    break;

                case 11:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c11");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d11");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h11");
                        CdRenderer.sprite = cdScripts;
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s11");
                        CdRenderer.sprite = cdScripts;
                    }
                    break;

                case 12:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c12");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d12");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h12");
                        CdRenderer.sprite = cdScripts;
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s12");
                        CdRenderer.sprite = cdScripts;
                    }
                    break;

                case 13:
                    if (setCard2[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c13");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d13");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard2[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h13");
                        CdRenderer.sprite = cdScripts;
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s13");
                        CdRenderer.sprite = cdScripts;
                    }
                    break;
            }
            
        }
    }
}