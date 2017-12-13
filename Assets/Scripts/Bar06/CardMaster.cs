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

    public struct MarkOut
    {
        public int number;
        public int mark;
    }

    int j = 0;

    void Start()
    {
        Invoke("MakeCard", 0.5f);
    }

    public Card[] setCard = new Card[2];
    public Card[] setCard2 = new Card[2];
    public MarkOut[] Markout = new MarkOut[16];

    public void MakeCard()
    {
       
        int check = 0;
        for (int i = 0; i < 2; i++)
        {
            int setNum = UnityEngine.Random.Range(1, 14);
            int setMark = UnityEngine.Random.Range(0, 4);
            if (i == 1)
            {
                while (Markout[j - 2].number == setNum && Markout[j - 2].mark == setMark && check == 0)
                {
                    setMark = UnityEngine.Random.Range(0, 4);
                    if (Markout[0].number == setNum && Markout[0].mark != setMark)
                    {
                        if (Markout[1].number == setNum && Markout[1].mark != setMark)
                        {
                            if (Markout[2].number == setNum && Markout[2].mark != setMark)
                            {
                                break;
                            }
                        }
                        else if (Markout[2].mark == 0)
                        {
                            break;
                        }
                    }
                    else if (Markout[1].mark == 0 && Markout[2].mark == 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                while (Markout[j].number == setNum && Markout[j].mark == setMark && check == 0)
                {
                    setMark = UnityEngine.Random.Range(0, 4);
                    if (Markout[0].number == setNum && Markout[0].mark != setMark)
                    {
                        if (Markout[1].number == setNum && Markout[1].mark != setMark)
                        {
                            if (Markout[2].number == setNum && Markout[2].mark != setMark)
                            {
                                break;
                            }
                        }
                        else if (Markout[2].mark == 0)
                        {
                            break;
                        }
                    }
                    else if (Markout[1].mark == 0 && Markout[2].mark == 0)
                    {
                        break;
                    }
                }
            }

            Markout[j].number = setNum;
            Markout[j].mark = setMark;
            if (i == 1)
            {

            }
            else
            {
                j++;
            }

            setCard[i].number = setNum;
            setCard[i].mark = (Mark)setMark;

            setNum = UnityEngine.Random.Range(1, 14);
            setMark = UnityEngine.Random.Range(0, 4);
            if (i == 1)
            {
                while (Markout[j - 2].number == setNum && Markout[j - 2].mark == setMark && check == 0)
                {
                    setMark = UnityEngine.Random.Range(0, 4);
                    if (Markout[0].number == setNum && Markout[0].mark != setMark)
                    {
                        if (Markout[1].number == setNum && Markout[1].mark != setMark)
                        {
                            if (Markout[2].number == setNum && Markout[2].mark != setMark)
                            {
                                break;
                            }
                        }
                        else if (Markout[2].mark == 0)
                        {
                            break;
                        }
                    }
                    else if (Markout[1].mark == 0 && Markout[2].mark == 0)
                    {
                        break;
                    }

                }
            }
            else
            {
                while (Markout[j - 1].number == setNum && Markout[j - 1].mark == setMark && check == 0)
                {
                    setMark = UnityEngine.Random.Range(0, 4);
                    if (Markout[0].number == setNum && Markout[0].mark != setMark)
                    {
                        if (Markout[1].number == setNum && Markout[1].mark != setMark)
                        {
                            if (Markout[2].number == setNum && Markout[2].mark != setMark)
                            {
                                break;
                            }
                        }
                        else if (Markout[2].mark == 0)
                        {
                            break;
                        }
                    }
                    else if (Markout[1].mark == 0 && Markout[2].mark == 0)
                    {
                        break;
                    }

                }
            }


            Markout[j].number = setNum;
            Markout[j].mark = setMark;

            if (i == 1)
            {

            }
            else
            {
                j++;
            }

            setCard2[i].number = setNum;
            setCard2[i].mark = (Mark)setMark;
        }

        Sprite cdScripts = null;

        for (int i = 0; i < 2; i++)
        {
            //カードの生成
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            //var cardsObject = GameObject.Find("cards");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            Vector3 move = transform.localPosition;
            cardObject.transform.position = new Vector3(i * -0.6f, -2.8f, 0);
            cardObject.transform.localScale = new Vector3(0.3f, 0.3f, 1);

            SpriteRenderer CdRenderer = cardObject.GetComponent<SpriteRenderer>();

            switch (setCard[i].number)
            {
                case 1:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c01");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d01");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c02");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d02");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c03");
                        CdRenderer.sprite = cdScripts;

                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d03");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c04");
                        CdRenderer.sprite = cdScripts;

                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d04");
                        CdRenderer.sprite = cdScripts;

                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c05");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d05");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c06");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d06");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c07");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d07");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c08");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d08");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c09");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d09");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c10");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d10");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c11");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d11");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c12");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d12");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c13");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d13");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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

    public void hitCard()
    {
        int check = 0;
        for (int i = 0; i < 2; i++)
        {
            int setNum = UnityEngine.Random.Range(1, 14);
            int setMark = UnityEngine.Random.Range(0, 4);
            if (i == 1)
            {
                while (Markout[j - 2].number == setNum && Markout[j - 2].mark == setMark && check == 0)
                {
                    setMark = UnityEngine.Random.Range(0, 4);
                    if (Markout[0].number == setNum && Markout[0].mark != setMark)
                    {
                        if (Markout[1].number == setNum && Markout[1].mark != setMark)
                        {
                            if (Markout[2].number == setNum && Markout[2].mark != setMark)
                            {
                                break;
                            }
                        }
                        else if (Markout[2].mark == 0)
                        {
                            break;
                        }
                    }
                    else if (Markout[1].mark == 0 && Markout[2].mark == 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                while (Markout[j].number == setNum && Markout[j].mark == setMark && check == 0)
                {
                    setMark = UnityEngine.Random.Range(0, 4);
                    if (Markout[0].number == setNum && Markout[0].mark != setMark)
                    {
                        if (Markout[1].number == setNum && Markout[1].mark != setMark)
                        {
                            if (Markout[2].number == setNum && Markout[2].mark != setMark)
                            {
                                break;
                            }
                        }
                        else if (Markout[2].mark == 0)
                        {
                            break;
                        }
                    }
                    else if (Markout[1].mark == 0 && Markout[2].mark == 0)
                    {
                        break;
                    }
                }
            }

            Markout[j].number = setNum;
            Markout[j].mark = setMark;
            if (i == 1)
            {

            }
            else
            {
                j++;
            }

            setCard[i].number = setNum;
            setCard[i].mark = (Mark)setMark;

            setNum = UnityEngine.Random.Range(1, 14);
            setMark = UnityEngine.Random.Range(0, 4);
            if (i == 1)
            {
                while (Markout[j - 2].number == setNum && Markout[j - 2].mark == setMark && check == 0)
                {
                    setMark = UnityEngine.Random.Range(0, 4);
                    if (Markout[0].number == setNum && Markout[0].mark != setMark)
                    {
                        if (Markout[1].number == setNum && Markout[1].mark != setMark)
                        {
                            if (Markout[2].number == setNum && Markout[2].mark != setMark)
                            {
                                break;
                            }
                        }
                        else if (Markout[2].mark == 0)
                        {
                            break;
                        }
                    }
                    else if (Markout[1].mark == 0 && Markout[2].mark == 0)
                    {
                        break;
                    }

                }
            }
            else
            {
                while (Markout[j - 1].number == setNum && Markout[j - 1].mark == setMark && check == 0)
                {
                    setMark = UnityEngine.Random.Range(0, 4);
                    if (Markout[0].number == setNum && Markout[0].mark != setMark)
                    {
                        if (Markout[1].number == setNum && Markout[1].mark != setMark)
                        {
                            if (Markout[2].number == setNum && Markout[2].mark != setMark)
                            {
                                break;
                            }
                        }
                        else if (Markout[2].mark == 0)
                        {
                            break;
                        }
                    }
                    else if (Markout[1].mark == 0 && Markout[2].mark == 0)
                    {
                        break;
                    }

                }
            }


            Markout[j].number = setNum;
            Markout[j].mark = setMark;

            if (i == 1)
            {

            }
            else
            {
                j++;
            }

            setCard2[i].number = setNum;
            setCard2[i].mark = (Mark)setMark;
        }

        Sprite cdScripts = null;

        for (int i = 0; i < 2; i++)
        {
            //カードの生成
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            //var cardsObject = GameObject.Find("cards");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            Vector3 move = transform.localPosition;
            cardObject.transform.position = new Vector3(i * -0.6f, -2.8f, 0);
            cardObject.transform.localScale = new Vector3(0.3f, 0.3f, 1);

            SpriteRenderer CdRenderer = cardObject.GetComponent<SpriteRenderer>();

            switch (setCard[i].number)
            {
                case 1:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c01");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d01");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c02");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d02");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c03");
                        CdRenderer.sprite = cdScripts;

                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d03");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c04");
                        CdRenderer.sprite = cdScripts;

                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d04");
                        CdRenderer.sprite = cdScripts;

                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c05");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d05");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c06");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d06");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c07");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d07");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c08");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d08");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c09");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d09");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c10");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d10");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c11");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d11");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c12");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d12");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c13");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d13");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[i].mark == Mark.Heart)
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

    public void Update()
    {
        
      
    }
}