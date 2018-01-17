using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public struct sum
    {
        public int first;
        public int second;
    }

    sum Sum = new sum();
    private int Vs = 0;
  

    void Start()
    {
        Invoke("PlayerCard", 0.5f);
        Invoke("Dealercard", 0.7f);
        Invoke("Count",0.5f);
        Invoke("PlayerNum", 1);
    }
    private Card[] setCard = new Card[11];
    private Card[] setCard2 = new Card[6];
    private int[] countcard = new int[11];
    private int[] Dcountcard = new int[6];
    private int puls = 0;
    private int Dpuls = 0;
    private int Ace = 0;
    public void PlayerCard()
    {

        for (int i = 0; i < 2; i++)
        {
            int setNum = UnityEngine.Random.Range(1, 14);
            int setMark = UnityEngine.Random.Range(0, 4);

            if (i == 0)
            {
                setCard[i].number = setNum;
                setCard[i].mark = (Mark)setMark;
            }
            else if (i == 1 && setCard[0].number == setNum && setCard[0].mark == (Mark)setMark)
            {
                while (setCard[0].number == setNum && setCard[0].mark == (Mark)setMark)
                {
                    setNum = UnityEngine.Random.Range(1, 14);
                    setMark = UnityEngine.Random.Range(0, 4);
                }

                setCard[i].number = setNum;
                setCard[i].mark = (Mark)setMark;
            }
            else
            {
                setCard[i].number = setNum;
                setCard[i].mark = (Mark)setMark;
            }
        }

        Sprite cdScripts = null;
        
        for (int i = 0; i < 2; i++)
        {
            //プレイヤーカードの生成
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(i * -0.6f - 0.4f, -2.8f, 0);
            cardObject.transform.localScale = new Vector3(0.3f, 0.3f, 1);

            SpriteRenderer CdRenderer = cardObject.GetComponent<SpriteRenderer>();

            switch (setCard[i].number)
            {
                case 1:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c01");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 1;
                        }
                        else
                        {
                            countcard[1] = 1;
                        }
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d01");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 1;
                        }
                        else
                        {
                            countcard[1] = 1;
                        }
                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h01");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 1;
                        }
                        else
                        {
                            countcard[1] = 1;
                        }
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s01");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 1;
                        }
                        else
                        {
                            countcard[1] = 1;
                        }
                    }
                    break;

                case 2:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c02");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 2;
                        }
                        else
                        {
                            countcard[1] = 2;
                        }
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d02");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 2;
                        }
                        else
                        {
                            countcard[1] = 2;
                        }
                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h02");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 2;
                        }
                        else
                        {
                            countcard[1] = 2;
                        }
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s02");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 2;
                        }
                        else
                        {
                            countcard[1] = 2;
                        }
                    }
                    break;

                case 3:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c03");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 3;
                        }
                        else
                        {
                            countcard[1] = 3;
                        }

                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d03");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 3;
                        }
                        else
                        {
                            countcard[1] = 3;
                        }
                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h03");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 3;
                        }
                        else
                        {
                            countcard[1] = 3;
                        }
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s03");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 3;
                        }
                        else
                        {
                            countcard[1] = 3;
                        }
                    }
                    break;

                case 4:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c04");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 4;
                        }
                        else
                        {
                            countcard[1] = 4;
                        }

                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d04");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 4;
                        }
                        else
                        {
                            countcard[1] = 4;
                        }

                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h04");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 4;
                        }
                        else
                        {
                            countcard[1] = 4;
                        }

                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s04");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 4;
                        }
                        else
                        {
                            countcard[1] = 4;
                        }
                    }
                    break;

                case 5:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c05");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 5;
                        }
                        else
                        {
                            countcard[1] = 5;
                        }
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d05");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 5;
                        }
                        else
                        {
                            countcard[1] = 5;
                        }
                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h05");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 5;
                        }
                        else
                        {
                            countcard[1] = 5;
                        }
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s05");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 5;
                        }
                        else
                        {
                            countcard[1] = 5;
                        }
                    }
                    break;

                case 6:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c06");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 6;
                        }
                        else
                        {
                            countcard[1] = 6;
                        }
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d06");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 6;
                        }
                        else
                        {
                            countcard[1] = 6;
                        }
                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h06");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 6;
                        }
                        else
                        {
                            countcard[1] = 6;
                        }
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s06");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 6;
                        }
                        else
                        {
                            countcard[1] = 6;
                        }
                    }
                    break;

                case 7:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c07");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 7;
                        }
                        else
                        {
                            countcard[1] = 7;
                        }
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d07");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 7;
                        }
                        else
                        {
                            countcard[1] = 7;
                        }
                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h07");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 7;
                        }
                        else
                        {
                            countcard[1] = 7;
                        }
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s07");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 7;
                        }
                        else
                        {
                            countcard[1] = 7;
                        }
                    }
                    break;

                case 8:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c08");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 8;
                        }
                        else
                        {
                            countcard[1] = 8;
                        }
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d08");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 8;
                        }
                        else
                        {
                            countcard[1] = 8;
                        }
                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h08");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 8;
                        }
                        else
                        {
                            countcard[1] = 8;
                        }
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s08");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 8;
                        }
                        else
                        {
                            countcard[1] = 8;
                        }
                    }
                    break;

                case 9:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c09");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 9;
                        }
                        else
                        {
                            countcard[1] = 9;
                        }
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d09");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 9;
                        }
                        else
                        {
                            countcard[1] = 9;
                        }
                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h09");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 9;
                        }
                        else
                        {
                            countcard[1] = 9;
                        }
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s09");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 9;
                        }
                        else
                        {
                            countcard[1] = 9;
                        }
                    }
                    break;

                case 10:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c10");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d10");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h10");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s10");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    break;

                case 11:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c11");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d11");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h11");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s11");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    break;

                case 12:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c12");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d12");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h12");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s12");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    break;

                case 13:
                    if (setCard[i].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c13");
                        CdRenderer.sprite = cdScripts;
                        if (i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    else if (setCard[i].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d13");
                        CdRenderer.sprite = cdScripts;
                        if(i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    else if (setCard[i].mark == Mark.Heart)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h13");
                        CdRenderer.sprite = cdScripts;
                        if(i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    else
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s13");
                        CdRenderer.sprite = cdScripts;
                        if(i == 0)
                        {
                            countcard[0] = 10;
                        }
                        else
                        {
                            countcard[1] = 10;
                        }
                    }
                    break;
            }
        }
    }
    private int I = 2;

    public void Dealercard()
    {
        for (int i = 0; i < 2; i++)
        {
            int setNum = UnityEngine.Random.Range(1, 14);
            int setMark = UnityEngine.Random.Range(0, 4);
            int Cpoint = 0;

            if (i == 0)
            {
                while (Cpoint == 0)
                {
                    if(setCard[0].number != setNum && setCard[0].mark != (Mark)setMark || setCard[0].number == setNum && setCard[0].mark != (Mark)setMark || setCard[0].number != setNum && setCard[0].mark == (Mark)setMark)
                    {
                        if (setCard[1].number != setNum && setCard[1].mark != (Mark)setMark || setCard[1].number == setNum && setCard[1].mark != (Mark)setMark || setCard[1].number != setNum && setCard[1].mark == (Mark)setMark)
                        {
                            break;
                        }
                        else
                        {
                            setNum = UnityEngine.Random.Range(1, 14);
                            setMark = UnityEngine.Random.Range(0, 4);
                        }
                    }
                    else
                    {
                        setNum = UnityEngine.Random.Range(1, 14);
                        setMark = UnityEngine.Random.Range(0, 4);
                    }
                }
               
                setCard2[i].number = setNum;
                setCard2[i].mark = (Mark)setMark;
            }
            else if (i == 1)
            {
                while (Cpoint == 0)
                {
                    if (setCard[0].number != setNum && setCard[0].mark != (Mark)setMark || setCard[0].number == setNum && setCard[0].mark != (Mark)setMark || setCard[0].number != setNum && setCard[0].mark == (Mark)setMark)
                    {
                        if (setCard[1].number != setNum && setCard[1].mark != (Mark)setMark || setCard[1].number == setNum && setCard[1].mark != (Mark)setMark || setCard[1].number != setNum && setCard[1].mark == (Mark)setMark)
                        {
                            if (setCard2[0].number != setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number == setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number != setNum && setCard2[0].mark == (Mark)setMark)
                            {
                                break;
                            }
                            else
                            {
                                setNum = UnityEngine.Random.Range(1, 14);
                                setMark = UnityEngine.Random.Range(0, 4);
                            }
                        }
                        else
                        {
                            setNum = UnityEngine.Random.Range(1, 14);
                            setMark = UnityEngine.Random.Range(0, 4);
                        }
                    }
                    else
                    {
                        setNum = UnityEngine.Random.Range(1, 14);
                        setMark = UnityEngine.Random.Range(0, 4);
                    }
                }
                setCard2[i].number = setNum;
                setCard2[i].mark = (Mark)setMark;
            }
        }

        Sprite DcdScripts = null;

        for (int i = 0; i < 2; i++)
        {
            //ディーラーカードの生成
            var dealercardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var dealercardObject = Instantiate(dealercardPrefab, transform.position, Quaternion.identity);
            dealercardObject.transform.position = new Vector3(i * -0.6f - 0.4f, 3, 0);
            dealercardObject.transform.localScale = new Vector3(0.3f, 0.3f, 1);

            SpriteRenderer dealerCdRenderer = dealercardObject.GetComponent<SpriteRenderer>();
            if (i == 0)
            {
                DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/back");
                dealerCdRenderer.sprite = DcdScripts;

            }
            else if (i == 1)
            {
                switch (setCard2[i].number)
                {
                    case 1:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c01");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 1;
                        }
                        else if (setCard2[i].mark == Mark.Diamond)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d01");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 1;
                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h01");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 1;
                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s01");
                            Dcountcard[1] = 1;
                        }
                        break;

                    case 2:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c02");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 2;
                        }
                        else if (setCard2[i].mark == Mark.Diamond)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d02");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 2;
                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h02");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 2;
                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s02");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 2;
                        }
                        break;

                    case 3:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c03");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 3;

                        }
                        else if (setCard2[i].mark == Mark.Diamond)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d03");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 3;

                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h03");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 3;
                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s03");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 3;
                        }
                        break;

                    case 4:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c04");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 4;

                        }
                        else if (setCard2[i].mark == Mark.Diamond)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d04");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 4;

                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h04");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 4;

                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s04");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 4;
                        }
                        break;

                    case 5:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c05");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 5;
                        }
                        else if (setCard2[i].mark == Mark.Diamond)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d05");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 5;
                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                           DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h05");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 5;
                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s05");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 5;
                        }
                        break;

                    case 6:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c06");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 6;
                        }
                        else if (setCard2[i].mark == Mark.Diamond)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d06");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 6;
                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h06");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 6;
                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s06");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 6;
                        }
                        break;

                    case 7:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c07");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 7;
                        }
                        else if (setCard2[i].mark == Mark.Diamond)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d07");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 7;
                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h07");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 7;
                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s07");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 7;
                        }
                        break;

                    case 8:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c08");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 8;
                        }
                        else if (setCard2[i].mark == Mark.Diamond)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d08");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 8;
                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h08");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 8;
                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s08");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 8;
                        }
                        break;

                    case 9:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c09");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 9;
                        }
                        else if (setCard[i].mark == Mark.Diamond)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d09");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 9;
                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h09");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 9;
                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s09");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 9;
                        }
                        break;

                    case 10:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c10");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        else if (setCard2[i].mark == Mark.Diamond)
                        {
                           DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d10");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h10");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s10");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        break;

                    case 11:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c11");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        else if (setCard2[i].mark == Mark.Diamond)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d11");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h11");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s11");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        break;

                    case 12:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c12");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        else if (setCard2[i].mark == Mark.Diamond)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d12");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h12");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s12");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        break;

                    case 13:
                        if (setCard2[i].mark == Mark.Clover)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c13");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        else if (setCard2[i].mark == Mark.Diamond)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d13");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        else if (setCard2[i].mark == Mark.Heart)
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h13");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        else
                        {
                            DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s13");
                            dealerCdRenderer.sprite = DcdScripts;
                            Dcountcard[1] = 10;
                        }
                        break;
                }
            }
        }
    }
    int J = 2;
    int j = 0;
    int Cpoint2 = 0;
    public void hitCard()
    {

        if (j < 9 && Vs == 0)
        {
            int setNum = UnityEngine.Random.Range(1, 14);
            int setMark = UnityEngine.Random.Range(0, 4);
            if (j == 0)
            {
                while (Cpoint2 == 0)
                {
                    if (setCard[0].number != setNum && setCard[0].mark != (Mark)setMark || setCard[0].number == setNum && setCard[0].mark != (Mark)setMark || setCard[0].number != setNum && setCard[0].mark == (Mark)setMark)
                    {
                        if (setCard[1].number != setNum && setCard[1].mark != (Mark)setMark || setCard[1].number == setNum && setCard[1].mark != (Mark)setMark || setCard[1].number != setNum && setCard[1].mark == (Mark)setMark)
                        {
                            if (setCard2[0].number != setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number == setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number != setNum && setCard2[0].mark == (Mark)setMark)
                            {
                                if (setCard2[1].number != setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number == setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number != setNum && setCard2[1].mark == (Mark)setMark)
                                {
                                    break;
                                }
                                else
                                {
                                    setNum = UnityEngine.Random.Range(1, 14);
                                    setMark = UnityEngine.Random.Range(0, 4);
                                }
                            }
                            else
                            {
                                setNum = UnityEngine.Random.Range(1, 14);
                                setMark = UnityEngine.Random.Range(0, 4);
                            }
                        }
                        else
                        {
                            setNum = UnityEngine.Random.Range(1, 14);
                            setMark = UnityEngine.Random.Range(0, 4);
                        }
                    }
                    else
                    {
                         setNum = UnityEngine.Random.Range(1, 14);
                         setMark = UnityEngine.Random.Range(0, 4);
                    }
                }
                setCard[j + 2].number = setNum;
                setCard[j + 2].mark = (Mark)setMark;
            }
            else if (j == 1)
            {
                while (Cpoint2 == 0)
                {
                    if (setCard[0].number != setNum && setCard[0].mark != (Mark)setMark || setCard[0].number == setNum && setCard[0].mark != (Mark)setMark || setCard[0].number != setNum && setCard[0].mark == (Mark)setMark)
                    {
                        if (setCard[1].number != setNum && setCard[1].mark != (Mark)setMark || setCard[1].number == setNum && setCard[1].mark != (Mark)setMark || setCard[1].number != setNum && setCard[1].mark == (Mark)setMark)
                        {
                            if (setCard2[0].number != setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number == setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number != setNum && setCard2[0].mark == (Mark)setMark)
                            {
                                if (setCard2[1].number != setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number == setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number != setNum && setCard2[1].mark == (Mark)setMark)
                                {
                                    if (setCard[2].number != setNum && setCard[2].mark != (Mark)setMark || setCard[2].number == setNum && setCard[2].mark != (Mark)setMark || setCard[2].number != setNum && setCard[2].mark == (Mark)setMark)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        setNum = UnityEngine.Random.Range(1, 14);
                                        setMark = UnityEngine.Random.Range(0, 4);
                                    }
                                }
                                else
                                {
                                    setNum = UnityEngine.Random.Range(1, 14);
                                    setMark = UnityEngine.Random.Range(0, 4);
                                }
                            }
                            else
                            {
                                setNum = UnityEngine.Random.Range(1, 14);
                                setMark = UnityEngine.Random.Range(0, 4);
                            }
                        }
                        else
                        {
                            setNum = UnityEngine.Random.Range(1, 14);
                            setMark = UnityEngine.Random.Range(0, 4);
                        }
                    }
                    else
                    {
                        setNum = UnityEngine.Random.Range(1, 14);
                        setMark = UnityEngine.Random.Range(0, 4);
                    }
                }
                setCard[j + 2].number = setNum;
                setCard[j + 2].mark = (Mark)setMark;
            }
            else if (j == 2)
            {
                while (Cpoint2 == 0)
                {
                    if (setCard[0].number != setNum && setCard[0].mark != (Mark)setMark || setCard[0].number == setNum && setCard[0].mark != (Mark)setMark || setCard[0].number != setNum && setCard[0].mark == (Mark)setMark)
                    {
                        if (setCard[1].number != setNum && setCard[1].mark != (Mark)setMark || setCard[1].number == setNum && setCard[1].mark != (Mark)setMark || setCard[1].number != setNum && setCard[1].mark == (Mark)setMark)
                        {
                            if (setCard2[0].number != setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number == setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number != setNum && setCard2[0].mark == (Mark)setMark)
                            {
                                if (setCard2[1].number != setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number == setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number != setNum && setCard2[1].mark == (Mark)setMark)
                                {
                                    if (setCard[2].number != setNum && setCard[2].mark != (Mark)setMark || setCard[2].number == setNum && setCard[2].mark != (Mark)setMark || setCard[2].number != setNum && setCard[2].mark == (Mark)setMark)
                                    {
                                        if (setCard[3].number != setNum && setCard[3].mark != (Mark)setMark || setCard[3].number == setNum && setCard[3].mark != (Mark)setMark || setCard[3].number != setNum && setCard[3].mark == (Mark)setMark)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            setNum = UnityEngine.Random.Range(1, 14);
                                            setMark = UnityEngine.Random.Range(0, 4);
                                        }
                                    }
                                    else
                                    {
                                        setNum = UnityEngine.Random.Range(1, 14);
                                        setMark = UnityEngine.Random.Range(0, 4);
                                    }
                                }
                                else
                                {
                                    setNum = UnityEngine.Random.Range(1, 14);
                                    setMark = UnityEngine.Random.Range(0, 4);
                                }
                            }
                            else
                            {
                                setNum = UnityEngine.Random.Range(1, 14);
                                setMark = UnityEngine.Random.Range(0, 4);
                            }
                        }
                        else
                        {
                            setNum = UnityEngine.Random.Range(1, 14);
                            setMark = UnityEngine.Random.Range(0, 4);
                        }
                    }
                    else
                    {
                        setNum = UnityEngine.Random.Range(1, 14);
                        setMark = UnityEngine.Random.Range(0, 4);
                    }
                }
                setCard[j + 2].number = setNum;
                setCard[j + 2].mark = (Mark)setMark;
            }
            else if (j == 3)
            {
                while (Cpoint2 == 0)
                {
                    if (setCard[0].number != setNum && setCard[0].mark != (Mark)setMark || setCard[0].number == setNum && setCard[0].mark != (Mark)setMark || setCard[0].number != setNum && setCard[0].mark == (Mark)setMark)
                    {
                        if (setCard[1].number != setNum && setCard[1].mark != (Mark)setMark || setCard[1].number == setNum && setCard[1].mark != (Mark)setMark || setCard[1].number != setNum && setCard[1].mark == (Mark)setMark)
                        {
                            if (setCard2[0].number != setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number == setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number != setNum && setCard2[0].mark == (Mark)setMark)
                            {
                                if (setCard2[1].number != setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number == setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number != setNum && setCard2[1].mark == (Mark)setMark)
                                {
                                    if (setCard[2].number != setNum && setCard[2].mark != (Mark)setMark || setCard[2].number == setNum && setCard[2].mark != (Mark)setMark || setCard[2].number != setNum && setCard[2].mark == (Mark)setMark)
                                    {
                                        if (setCard[3].number != setNum && setCard[3].mark != (Mark)setMark || setCard[3].number == setNum && setCard[3].mark != (Mark)setMark || setCard[3].number != setNum && setCard[3].mark == (Mark)setMark)
                                        {
                                            if (setCard[4].number != setNum && setCard[4].mark != (Mark)setMark || setCard[4].number == setNum && setCard[4].mark != (Mark)setMark || setCard[4].number != setNum && setCard[4].mark == (Mark)setMark)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                setNum = UnityEngine.Random.Range(1, 14);
                                                setMark = UnityEngine.Random.Range(0, 4);
                                            }
                                        }
                                        else
                                        {
                                            setNum = UnityEngine.Random.Range(1, 14);
                                            setMark = UnityEngine.Random.Range(0, 4);
                                        }
                                    }
                                    else
                                    {
                                        setNum = UnityEngine.Random.Range(1, 14);
                                        setMark = UnityEngine.Random.Range(0, 4);
                                    }
                                }
                                else
                                {
                                    setNum = UnityEngine.Random.Range(1, 14);
                                    setMark = UnityEngine.Random.Range(0, 4);
                                }
                            }
                            else
                            {
                                setNum = UnityEngine.Random.Range(1, 14);
                                setMark = UnityEngine.Random.Range(0, 4);
                            }
                        }
                        else
                        {
                            setNum = UnityEngine.Random.Range(1, 14);
                            setMark = UnityEngine.Random.Range(0, 4);
                        }
                    }
                    else
                    {
                        setNum = UnityEngine.Random.Range(1, 14);
                        setMark = UnityEngine.Random.Range(0, 4);
                    }
                }
                setCard[j + 2].number = setNum;
                setCard[j + 2].mark = (Mark)setMark;
            }
            else if (j == 4)
            {
                while (Cpoint2 == 0)
                {
                    if (setCard[0].number != setNum && setCard[0].mark != (Mark)setMark || setCard[0].number == setNum && setCard[0].mark != (Mark)setMark || setCard[0].number != setNum && setCard[0].mark == (Mark)setMark)
                    {
                        if (setCard[1].number != setNum && setCard[1].mark != (Mark)setMark || setCard[1].number == setNum && setCard[1].mark != (Mark)setMark || setCard[1].number != setNum && setCard[1].mark == (Mark)setMark)
                        {
                            if (setCard2[0].number != setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number == setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number != setNum && setCard2[0].mark == (Mark)setMark)
                            {
                                if (setCard2[1].number != setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number == setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number != setNum && setCard2[1].mark == (Mark)setMark)
                                {
                                    if (setCard[2].number != setNum && setCard[2].mark != (Mark)setMark || setCard[2].number == setNum && setCard[2].mark != (Mark)setMark || setCard[2].number != setNum && setCard[2].mark == (Mark)setMark)
                                    {
                                        if (setCard[3].number != setNum && setCard[3].mark != (Mark)setMark || setCard[3].number == setNum && setCard[3].mark != (Mark)setMark || setCard[3].number != setNum && setCard[3].mark == (Mark)setMark)
                                        {
                                            if (setCard[4].number != setNum && setCard[4].mark != (Mark)setMark || setCard[4].number == setNum && setCard[4].mark != (Mark)setMark || setCard[4].number != setNum && setCard[4].mark == (Mark)setMark)
                                            {
                                                if (setCard[5].number != setNum && setCard[5].mark != (Mark)setMark || setCard[5].number == setNum && setCard[5].mark != (Mark)setMark || setCard[5].number != setNum && setCard[5].mark == (Mark)setMark)
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    setNum = UnityEngine.Random.Range(1, 14);
                                                    setMark = UnityEngine.Random.Range(0, 4);
                                                }
                                            }
                                            else
                                            {
                                                setNum = UnityEngine.Random.Range(1, 14);
                                                setMark = UnityEngine.Random.Range(0, 4);
                                            }
                                        }
                                        else
                                        {
                                            setNum = UnityEngine.Random.Range(1, 14);
                                            setMark = UnityEngine.Random.Range(0, 4);
                                        }
                                    }
                                    else
                                    {
                                        setNum = UnityEngine.Random.Range(1, 14);
                                        setMark = UnityEngine.Random.Range(0, 4);
                                    }
                                }
                                else
                                {
                                    setNum = UnityEngine.Random.Range(1, 14);
                                    setMark = UnityEngine.Random.Range(0, 4);
                                }
                            }
                            else
                            {
                                setNum = UnityEngine.Random.Range(1, 14);
                                setMark = UnityEngine.Random.Range(0, 4);
                            }
                        }
                        else
                        {
                            setNum = UnityEngine.Random.Range(1, 14);
                            setMark = UnityEngine.Random.Range(0, 4);
                        }
                    }
                    else
                    {
                        setNum = UnityEngine.Random.Range(1, 14);
                        setMark = UnityEngine.Random.Range(0, 4);
                    }
                }
                setCard[j + 2].number = setNum;
                setCard[j + 2].mark = (Mark)setMark;
            }
            else if (j == 5)
            {
                while (Cpoint2 == 0)
                {
                    if (setCard[0].number != setNum && setCard[0].mark != (Mark)setMark || setCard[0].number == setNum && setCard[0].mark != (Mark)setMark || setCard[0].number != setNum && setCard[0].mark == (Mark)setMark)
                    {
                        if (setCard[1].number != setNum && setCard[1].mark != (Mark)setMark || setCard[1].number == setNum && setCard[1].mark != (Mark)setMark || setCard[1].number != setNum && setCard[1].mark == (Mark)setMark)
                        {
                            if (setCard2[0].number != setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number == setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number != setNum && setCard2[0].mark == (Mark)setMark)
                            {
                                if (setCard2[1].number != setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number == setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number != setNum && setCard2[1].mark == (Mark)setMark)
                                {
                                    if (setCard[2].number != setNum && setCard[2].mark != (Mark)setMark || setCard[2].number == setNum && setCard[2].mark != (Mark)setMark || setCard[2].number != setNum && setCard[2].mark == (Mark)setMark)
                                    {
                                        if (setCard[3].number != setNum && setCard[3].mark != (Mark)setMark || setCard[3].number == setNum && setCard[3].mark != (Mark)setMark || setCard[3].number != setNum && setCard[3].mark == (Mark)setMark)
                                        {
                                            if (setCard[4].number != setNum && setCard[4].mark != (Mark)setMark || setCard[4].number == setNum && setCard[4].mark != (Mark)setMark || setCard[4].number != setNum && setCard[4].mark == (Mark)setMark)
                                            {
                                                if (setCard[5].number != setNum && setCard[5].mark != (Mark)setMark || setCard[5].number == setNum && setCard[5].mark != (Mark)setMark || setCard[5].number != setNum && setCard[5].mark == (Mark)setMark)
                                                {
                                                    if (setCard[6].number != setNum && setCard[6].mark != (Mark)setMark || setCard[6].number == setNum && setCard[6].mark != (Mark)setMark || setCard[6].number != setNum && setCard[6].mark == (Mark)setMark)
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        setNum = UnityEngine.Random.Range(1, 14);
                                                        setMark = UnityEngine.Random.Range(0, 4);
                                                    }
                                                }
                                                else
                                                {
                                                    setNum = UnityEngine.Random.Range(1, 14);
                                                    setMark = UnityEngine.Random.Range(0, 4);
                                                }
                                            }
                                            else
                                            {
                                                setNum = UnityEngine.Random.Range(1, 14);
                                                setMark = UnityEngine.Random.Range(0, 4);
                                            }
                                        }
                                        else
                                        {
                                            setNum = UnityEngine.Random.Range(1, 14);
                                            setMark = UnityEngine.Random.Range(0, 4);
                                        }
                                    }
                                    else
                                    {
                                        setNum = UnityEngine.Random.Range(1, 14);
                                        setMark = UnityEngine.Random.Range(0, 4);
                                    }
                                }
                                else
                                {
                                    setNum = UnityEngine.Random.Range(1, 14);
                                    setMark = UnityEngine.Random.Range(0, 4);
                                }
                            }
                            else
                            {
                                setNum = UnityEngine.Random.Range(1, 14);
                                setMark = UnityEngine.Random.Range(0, 4);
                            }
                        }
                        else
                        {
                            setNum = UnityEngine.Random.Range(1, 14);
                            setMark = UnityEngine.Random.Range(0, 4);
                        }
                    }
                    else
                    {
                        setNum = UnityEngine.Random.Range(1, 14);
                        setMark = UnityEngine.Random.Range(0, 4);
                    }
                }
                setCard[j + 2].number = setNum;
                setCard[j + 2].mark = (Mark)setMark;
            }
            else if (j == 6)
            {
                while (Cpoint2 == 0)
                {
                    if (setCard[0].number != setNum && setCard[0].mark != (Mark)setMark || setCard[0].number == setNum && setCard[0].mark != (Mark)setMark || setCard[0].number != setNum && setCard[0].mark == (Mark)setMark)
                    {
                        if (setCard[1].number != setNum && setCard[1].mark != (Mark)setMark || setCard[1].number == setNum && setCard[1].mark != (Mark)setMark || setCard[1].number != setNum && setCard[1].mark == (Mark)setMark)
                        {
                            if (setCard2[0].number != setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number == setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number != setNum && setCard2[0].mark == (Mark)setMark)
                            {
                                if (setCard2[1].number != setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number == setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number != setNum && setCard2[1].mark == (Mark)setMark)
                                {
                                    if (setCard[2].number != setNum && setCard[2].mark != (Mark)setMark || setCard[2].number == setNum && setCard[2].mark != (Mark)setMark || setCard[2].number != setNum && setCard[2].mark == (Mark)setMark)
                                    {
                                        if (setCard[3].number != setNum && setCard[3].mark != (Mark)setMark || setCard[3].number == setNum && setCard[3].mark != (Mark)setMark || setCard[3].number != setNum && setCard[3].mark == (Mark)setMark)
                                        {
                                            if (setCard[4].number != setNum && setCard[4].mark != (Mark)setMark || setCard[4].number == setNum && setCard[4].mark != (Mark)setMark || setCard[4].number != setNum && setCard[4].mark == (Mark)setMark)
                                            {
                                                if (setCard[5].number != setNum && setCard[5].mark != (Mark)setMark || setCard[5].number == setNum && setCard[5].mark != (Mark)setMark || setCard[5].number != setNum && setCard[5].mark == (Mark)setMark)
                                                {
                                                    if (setCard[6].number != setNum && setCard[6].mark != (Mark)setMark || setCard[6].number == setNum && setCard[6].mark != (Mark)setMark || setCard[6].number != setNum && setCard[6].mark == (Mark)setMark)
                                                    {
                                                        if (setCard[7].number != setNum && setCard[7].mark != (Mark)setMark || setCard[7].number == setNum && setCard[7].mark != (Mark)setMark || setCard[7].number != setNum && setCard[7].mark == (Mark)setMark)
                                                        {
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            setNum = UnityEngine.Random.Range(1, 14);
                                                            setMark = UnityEngine.Random.Range(0, 4);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        setNum = UnityEngine.Random.Range(1, 14);
                                                        setMark = UnityEngine.Random.Range(0, 4);
                                                    }
                                                }
                                                else
                                                {
                                                    setNum = UnityEngine.Random.Range(1, 14);
                                                    setMark = UnityEngine.Random.Range(0, 4);
                                                }
                                            }
                                            else
                                            {
                                                setNum = UnityEngine.Random.Range(1, 14);
                                                setMark = UnityEngine.Random.Range(0, 4);
                                            }
                                        }
                                        else
                                        {
                                            setNum = UnityEngine.Random.Range(1, 14);
                                            setMark = UnityEngine.Random.Range(0, 4);
                                        }
                                    }
                                    else
                                    {
                                        setNum = UnityEngine.Random.Range(1, 14);
                                        setMark = UnityEngine.Random.Range(0, 4);
                                    }
                                }
                                else
                                {
                                    setNum = UnityEngine.Random.Range(1, 14);
                                    setMark = UnityEngine.Random.Range(0, 4);
                                }
                            }
                            else
                            {
                                setNum = UnityEngine.Random.Range(1, 14);
                                setMark = UnityEngine.Random.Range(0, 4);
                            }
                        }
                        else
                        {
                            setNum = UnityEngine.Random.Range(1, 14);
                            setMark = UnityEngine.Random.Range(0, 4);
                        }
                    }
                    else
                    {
                        setNum = UnityEngine.Random.Range(1, 14);
                        setMark = UnityEngine.Random.Range(0, 4);
                    }
                }
                setCard[j + 2].number = setNum;
                setCard[j + 2].mark = (Mark)setMark;
            }
            else if (j == 7)
            {
                while (Cpoint2 == 0)
                {
                    if (setCard[0].number != setNum && setCard[0].mark != (Mark)setMark || setCard[0].number == setNum && setCard[0].mark != (Mark)setMark || setCard[0].number != setNum && setCard[0].mark == (Mark)setMark)
                    {
                        if (setCard[1].number != setNum && setCard[1].mark != (Mark)setMark || setCard[1].number == setNum && setCard[1].mark != (Mark)setMark || setCard[1].number != setNum && setCard[1].mark == (Mark)setMark)
                        {
                            if (setCard2[0].number != setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number == setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number != setNum && setCard2[0].mark == (Mark)setMark)
                            {
                                if (setCard2[1].number != setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number == setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number != setNum && setCard2[1].mark == (Mark)setMark)
                                {
                                    if (setCard[2].number != setNum && setCard[2].mark != (Mark)setMark || setCard[2].number == setNum && setCard[2].mark != (Mark)setMark || setCard[2].number != setNum && setCard[2].mark == (Mark)setMark)
                                    {
                                        if (setCard[3].number != setNum && setCard[3].mark != (Mark)setMark || setCard[3].number == setNum && setCard[3].mark != (Mark)setMark || setCard[3].number != setNum && setCard[3].mark == (Mark)setMark)
                                        {
                                            if (setCard[4].number != setNum && setCard[4].mark != (Mark)setMark || setCard[4].number == setNum && setCard[4].mark != (Mark)setMark || setCard[4].number != setNum && setCard[4].mark == (Mark)setMark)
                                            {
                                                if (setCard[5].number != setNum && setCard[5].mark != (Mark)setMark || setCard[5].number == setNum && setCard[5].mark != (Mark)setMark || setCard[5].number != setNum && setCard[5].mark == (Mark)setMark)
                                                {
                                                    if (setCard[6].number != setNum && setCard[6].mark != (Mark)setMark || setCard[6].number == setNum && setCard[6].mark != (Mark)setMark || setCard[6].number != setNum && setCard[6].mark == (Mark)setMark)
                                                    {
                                                        if (setCard[7].number != setNum && setCard[7].mark != (Mark)setMark || setCard[7].number == setNum && setCard[7].mark != (Mark)setMark || setCard[7].number != setNum && setCard[7].mark == (Mark)setMark)
                                                        {
                                                            if (setCard[8].number != setNum && setCard[8].mark != (Mark)setMark || setCard[8].number == setNum && setCard[8].mark != (Mark)setMark || setCard[8].number != setNum && setCard[8].mark == (Mark)setMark)
                                                            {
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                setNum = UnityEngine.Random.Range(1, 14);
                                                                setMark = UnityEngine.Random.Range(0, 4);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            setNum = UnityEngine.Random.Range(1, 14);
                                                            setMark = UnityEngine.Random.Range(0, 4);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        setNum = UnityEngine.Random.Range(1, 14);
                                                        setMark = UnityEngine.Random.Range(0, 4);
                                                    }
                                                }
                                                else
                                                {
                                                    setNum = UnityEngine.Random.Range(1, 14);
                                                    setMark = UnityEngine.Random.Range(0, 4);
                                                }
                                            }
                                            else
                                            {
                                                setNum = UnityEngine.Random.Range(1, 14);
                                                setMark = UnityEngine.Random.Range(0, 4);
                                            }
                                        }
                                        else
                                        {
                                            setNum = UnityEngine.Random.Range(1, 14);
                                            setMark = UnityEngine.Random.Range(0, 4);
                                        }
                                    }
                                    else
                                    {
                                        setNum = UnityEngine.Random.Range(1, 14);
                                        setMark = UnityEngine.Random.Range(0, 4);
                                    }
                                }
                                else
                                {
                                    setNum = UnityEngine.Random.Range(1, 14);
                                    setMark = UnityEngine.Random.Range(0, 4);
                                }
                            }
                            else
                            {
                                setNum = UnityEngine.Random.Range(1, 14);
                                setMark = UnityEngine.Random.Range(0, 4);
                            }
                        }
                        else
                        {
                            setNum = UnityEngine.Random.Range(1, 14);
                            setMark = UnityEngine.Random.Range(0, 4);
                        }
                    }
                    else
                    {
                        setNum = UnityEngine.Random.Range(1, 14);
                        setMark = UnityEngine.Random.Range(0, 4);
                    }
                }
                setCard[j + 2].number = setNum;
                setCard[j + 2].mark = (Mark)setMark;
            }
            else if (j == 8)
            {
                while (Cpoint2 == 0)
                {
                    if (setCard[0].number != setNum && setCard[0].mark != (Mark)setMark || setCard[0].number == setNum && setCard[0].mark != (Mark)setMark || setCard[0].number != setNum && setCard[0].mark == (Mark)setMark)
                    {
                        if (setCard[1].number != setNum && setCard[1].mark != (Mark)setMark || setCard[1].number == setNum && setCard[1].mark != (Mark)setMark || setCard[1].number != setNum && setCard[1].mark == (Mark)setMark)
                        {
                            if (setCard2[0].number != setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number == setNum && setCard2[0].mark != (Mark)setMark || setCard2[0].number != setNum && setCard2[0].mark == (Mark)setMark)
                            {
                                if (setCard2[1].number != setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number == setNum && setCard2[1].mark != (Mark)setMark || setCard2[1].number != setNum && setCard2[1].mark == (Mark)setMark)
                                {
                                    if (setCard[2].number != setNum && setCard[2].mark != (Mark)setMark || setCard[2].number == setNum && setCard[2].mark != (Mark)setMark || setCard[2].number != setNum && setCard[2].mark == (Mark)setMark)
                                    {
                                        if (setCard[3].number != setNum && setCard[3].mark != (Mark)setMark || setCard[3].number == setNum && setCard[3].mark != (Mark)setMark || setCard[3].number != setNum && setCard[3].mark == (Mark)setMark)
                                        {
                                            if (setCard[4].number != setNum && setCard[4].mark != (Mark)setMark || setCard[4].number == setNum && setCard[4].mark != (Mark)setMark || setCard[4].number != setNum && setCard[4].mark == (Mark)setMark)
                                            {
                                                if (setCard[5].number != setNum && setCard[5].mark != (Mark)setMark || setCard[5].number == setNum && setCard[5].mark != (Mark)setMark || setCard[5].number != setNum && setCard[5].mark == (Mark)setMark)
                                                {
                                                    if (setCard[6].number != setNum && setCard[6].mark != (Mark)setMark || setCard[6].number == setNum && setCard[6].mark != (Mark)setMark || setCard[6].number != setNum && setCard[6].mark == (Mark)setMark)
                                                    {
                                                        if (setCard[7].number != setNum && setCard[7].mark != (Mark)setMark || setCard[7].number == setNum && setCard[7].mark != (Mark)setMark || setCard[7].number != setNum && setCard[7].mark == (Mark)setMark)
                                                        {
                                                            if (setCard[8].number != setNum && setCard[8].mark != (Mark)setMark || setCard[8].number == setNum && setCard[8].mark != (Mark)setMark || setCard[8].number != setNum && setCard[8].mark == (Mark)setMark)
                                                            {
                                                                if (setCard[9].number != setNum && setCard[9].mark != (Mark)setMark || setCard[9].number == setNum && setCard[9].mark != (Mark)setMark || setCard[9].number != setNum && setCard[9].mark == (Mark)setMark)
                                                                {
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    setNum = UnityEngine.Random.Range(1, 14);
                                                                    setMark = UnityEngine.Random.Range(0, 4);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                setNum = UnityEngine.Random.Range(1, 14);
                                                                setMark = UnityEngine.Random.Range(0, 4);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            setNum = UnityEngine.Random.Range(1, 14);
                                                            setMark = UnityEngine.Random.Range(0, 4);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        setNum = UnityEngine.Random.Range(1, 14);
                                                        setMark = UnityEngine.Random.Range(0, 4);
                                                    }
                                                }
                                                else
                                                {
                                                    setNum = UnityEngine.Random.Range(1, 14);
                                                    setMark = UnityEngine.Random.Range(0, 4);
                                                }
                                            }
                                            else
                                            {
                                                setNum = UnityEngine.Random.Range(1, 14);
                                                setMark = UnityEngine.Random.Range(0, 4);
                                            }
                                        }
                                        else
                                        {
                                            setNum = UnityEngine.Random.Range(1, 14);
                                            setMark = UnityEngine.Random.Range(0, 4);
                                        }
                                    }
                                    else
                                    {
                                        setNum = UnityEngine.Random.Range(1, 14);
                                        setMark = UnityEngine.Random.Range(0, 4);
                                    }
                                }
                                else
                                {
                                    setNum = UnityEngine.Random.Range(1, 14);
                                    setMark = UnityEngine.Random.Range(0, 4);
                                }
                            }
                            else
                            {
                                setNum = UnityEngine.Random.Range(1, 14);
                                setMark = UnityEngine.Random.Range(0, 4);
                            }
                        }
                        else
                        {
                            setNum = UnityEngine.Random.Range(1, 14);
                            setMark = UnityEngine.Random.Range(0, 4);
                        }
                    }
                    else
                    {
                        setNum = UnityEngine.Random.Range(1, 14);
                        setMark = UnityEngine.Random.Range(0, 4);
                    }
                }
                setCard[j + 2].number = setNum;
                setCard[j + 2].mark = (Mark)setMark;
            }

            Sprite cdScripts = null;

            //カードの生成
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3((j + 1) * 0.6f - 0.4f, -2.8f, 0);
            cardObject.transform.localScale = new Vector3(0.3f, 0.3f, 1);

            SpriteRenderer CdRenderer = cardObject.GetComponent<SpriteRenderer>();

            switch (setCard[j + 2].number)
            {
                case 1:
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c01");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d01");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c02");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d02");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c03");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d03");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c04");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d04");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c05");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d05");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c06");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d06");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c07");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d07");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c08");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d08");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c09");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d09");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c10");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d10");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c11");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d11");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c12");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d12");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
                    if (setCard[j + 2].mark == Mark.Clover)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c13");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Diamond)
                    {
                        cdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d13");
                        CdRenderer.sprite = cdScripts;
                    }
                    else if (setCard[j + 2].mark == Mark.Heart)
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
        puls = 0;
        I++;
        j++;
    }
    public void vs()
    {
        if (Vs == 0)
        {

            Sprite DcdScripts = null;
            var dealercardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var dealercardObject = Instantiate(dealercardPrefab, transform.position, Quaternion.identity);
            dealercardObject.transform.position = new Vector3(-0.4f, 3, 0);
            dealercardObject.transform.localScale = new Vector3(0.3f, 0.3f, 1);

            SpriteRenderer dealerCdRenderer = dealercardObject.GetComponent<SpriteRenderer>();
            switch (setCard2[0].number)
            {
                case 1:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c01");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 1;
                    }
                    else if (setCard2[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d01");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 1;
                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h01");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 1;
                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s01");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 1;
                    }
                    break;

                case 2:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c02");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 2;
                    }
                    else if (setCard2[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d02");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 2;
                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h02");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 2;
                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s02");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 2;
                    }
                    break;

                case 3:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c03");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 3;

                    }
                    else if (setCard2[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d03");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 3;
                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h03");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 3;
                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s03");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 3;
                    }
                    break;

                case 4:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c04");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 4;

                    }
                    else if (setCard2[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d04");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 4;

                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h04");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 4;

                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s04");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 4;
                    }
                    break;

                case 5:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c05");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 5;
                    }
                    else if (setCard2[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d05");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 5;
                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h05");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 5;
                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s05");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 5;
                    }
                    break;

                case 6:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c06");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 6;
                    }
                    else if (setCard2[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d06");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 6;
                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h06");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 6;
                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s06");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 6;
                    }
                    break;

                case 7:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c07");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 7;
                    }
                    else if (setCard2[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d07");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 7;
                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h07");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 7;
                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s07");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 7;
                    }
                    break;

                case 8:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c08");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 8;
                    }
                    else if (setCard2[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d08");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 8;
                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h08");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 8;
                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s08");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 8;
                    }
                    break;

                case 9:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c09");
                        dealerCdRenderer.sprite = DcdScripts;
                        Dcountcard[0] = 9;
                    }
                    else if (setCard[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d09");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h09");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s09");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    break;

                case 10:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c10");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else if (setCard2[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d10");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h10");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s10");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    break;

                case 11:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c11");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else if (setCard2[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d11");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h11");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s11");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    break;

                case 12:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c12");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else if (setCard2[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d12");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h12");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s12");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    break;

                case 13:
                    if (setCard2[0].mark == Mark.Clover)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/c13");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else if (setCard2[0].mark == Mark.Diamond)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/d13");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else if (setCard2[0].mark == Mark.Heart)
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/h13");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    else
                    {
                        DcdScripts = Resources.Load<Sprite>("Images/Bar/Cards/s13");
                        dealerCdRenderer.sprite = DcdScripts;
                    }
                    break;
            }
            Sprite DnumScripts = null;

            for (int i = 0; i <= J; i++)
            {
                Dpuls = Dcountcard[i] + Dpuls;
            }

            if (Dpuls / 2 >= 5)
            {
                if (Dpuls >= 10 && Dpuls < 20)
                {
                    Sum.second = Dpuls - 10;
                    Sum.first = Dpuls - Sum.second - 9;
                }
                else if (puls == 20)
                {
                    Sum.second = 0;
                    Sum.first = Dpuls - 18;
                }
                else if (puls > 20)
                {
                    Sum.second = Dpuls - 20;
                    Sum.first = Dpuls - Sum.second - 19;
                }

                var numPrefab = Resources.Load<GameObject>("Prefabs/Bar06/num");
                var numObject = Instantiate(numPrefab, transform.position, Quaternion.identity);
                numObject.transform.position = new Vector3(0.5f, 1.8f, 0);
                numObject.transform.localScale = new Vector3(1, 1, 1);
                SpriteRenderer NumRenderer = numObject.GetComponent<SpriteRenderer>();

                switch (Sum.first)
                {
                    case 1:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_1");
                        NumRenderer.sprite = DnumScripts;
                        break;
                    case 2:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_2");
                        NumRenderer.sprite = DnumScripts;
                        break;
                }

                var numPrefab2 = Resources.Load<GameObject>("Prefabs/Bar06/num");
                var numObject2 = Instantiate(numPrefab2, transform.position, Quaternion.identity);
                numObject2.transform.position = new Vector3(0.9f, 1.8f, 0);
                numObject2.transform.localScale = new Vector3(1, 1, 1);
                SpriteRenderer NumRenderer2 = numObject2.GetComponent<SpriteRenderer>();

                switch (Sum.second)
                {
                    case 0:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_0");
                        NumRenderer2.sprite = DnumScripts;
                        break;
                    case 1:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_1");
                        NumRenderer2.sprite = DnumScripts;
                        break;
                    case 2:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_2");
                        NumRenderer2.sprite = DnumScripts;
                        break;
                    case 3:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_3");
                        NumRenderer2.sprite = DnumScripts;
                        break;
                    case 4:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_4");
                        NumRenderer2.sprite = DnumScripts;
                        break;
                    case 5:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_5");
                        NumRenderer2.sprite = DnumScripts;
                        break;
                    case 6:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_6");
                        NumRenderer2.sprite = DnumScripts;
                        break;
                    case 7:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_7");
                        NumRenderer2.sprite = DnumScripts;
                        break;
                    case 8:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_8");
                        NumRenderer2.sprite = DnumScripts;
                        break;
                    case 9:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_9");
                        NumRenderer2.sprite = DnumScripts;
                        break;
                }

            }
            else
            {
                var numPrefab = Resources.Load<GameObject>("Prefabs/Bar06/num");
                var numObject = Instantiate(numPrefab, transform.position, Quaternion.identity);
                numObject.transform.position = new Vector3(0.75f, 1.8f, 0);
                numObject.transform.localScale = new Vector3(1, 1, 1);
                SpriteRenderer NumRenderer = numObject.GetComponent<SpriteRenderer>();

                switch (Dpuls)
                {
                    case 2:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_2");
                        NumRenderer.sprite = DnumScripts;
                        break;
                    case 3:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_3");
                        NumRenderer.sprite = DnumScripts;
                        break;
                    case 4:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_4");
                        NumRenderer.sprite = DnumScripts;
                        break;
                    case 5:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_5");
                        NumRenderer.sprite = DnumScripts;
                        break;
                    case 6:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_6");
                        NumRenderer.sprite = DnumScripts;
                        break;
                    case 7:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_7");
                        NumRenderer.sprite = DnumScripts;
                        break;
                    case 8:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_8");
                        NumRenderer.sprite = DnumScripts;
                        break;
                    case 9:
                        DnumScripts = Resources.Load<Sprite>("Images/Bar/t_9");
                        NumRenderer.sprite = DnumScripts;
                        break;
                }
            }
        }
        Vs = 1;
    }
    public void Count()
    {
        var countPrefab = Resources.Load<GameObject>("Prefabs/Bar06/Count");
        var countObject = Instantiate(countPrefab, transform.position, Quaternion.identity);
        countObject.transform.position = new Vector3(1.9f * 0.6f - 0.4f, -4, 0);
        countObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);

        var dealercountPrefab = Resources.Load<GameObject>("Prefabs/Bar06/Count");
        var dealercountObject = Instantiate(countPrefab, transform.position, Quaternion.identity);
        dealercountObject.transform.position = new Vector3(1.9f * 0.6f -0.4f, 1.8f, 0);
        dealercountObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
    }

    public void PlayerNum()
    {

        Sprite numScripts = null;

        for (int i = 0; i <= I; i++)
        {
            puls = countcard[i] + puls;
        }

        if (puls / 2 >= 5)
        {
            if (puls >= 10 && puls < 20)
            {
                Sum.second = puls - 10;
                Sum.first = puls - Sum.second - 9;
            }
            else if (puls == 20)
            {
                Sum.second = 0;
                Sum.first = puls - 18;
            }
            else if (puls > 20)
            {
                Sum.second = puls - 20;
                Sum.first = puls - Sum.second - 19;
            }

            var numPrefab = Resources.Load<GameObject>("Prefabs/Bar06/num");
            var numObject = Instantiate(numPrefab, transform.position, Quaternion.identity);
            numObject.transform.position = new Vector3(0.5f, -4, 0);
            numObject.transform.localScale = new Vector3(1, 1, 1);
            SpriteRenderer NumRenderer = numObject.GetComponent<SpriteRenderer>();

            switch (Sum.first)
            {
                case 1:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_1");
                    NumRenderer.sprite = numScripts;
                    break;
                case 2:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_2");
                    NumRenderer.sprite = numScripts;
                    break;
            }

            var numPrefab2 = Resources.Load<GameObject>("Prefabs/Bar06/num");
            var numObject2 = Instantiate(numPrefab2, transform.position, Quaternion.identity);
            numObject2.transform.position = new Vector3(0.9f, -4, 0);
            numObject2.transform.localScale = new Vector3(1, 1, 1);
            SpriteRenderer NumRenderer2 = numObject2.GetComponent<SpriteRenderer>();

            switch (Sum.second)
            {
                case 0:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_0");
                    NumRenderer2.sprite = numScripts;
                    break;
                case 1:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_1");
                    NumRenderer2.sprite = numScripts;
                    break;
                case 2:
                    numScripts= Resources.Load<Sprite>("Images/Bar/t_2");
                    NumRenderer2.sprite = numScripts;
                    break;
                case 3:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_3");
                    NumRenderer2.sprite = numScripts;
                    break;
                case 4:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_4");
                    NumRenderer2.sprite = numScripts;
                    break;
                case 5:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_5");
                    NumRenderer2.sprite = numScripts;
                    break;
                case 6:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_6");
                    NumRenderer2.sprite = numScripts;
                    break;
                case 7:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_7");
                    NumRenderer2.sprite = numScripts;
                    break;
                case 8:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_8");
                    NumRenderer2.sprite = numScripts;
                    break;
                case 9:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_9");
                    NumRenderer2.sprite = numScripts;
                    break;
            }

        }
        else
        {
            var numPrefab = Resources.Load<GameObject>("Prefabs/Bar06/num");
            var numObject = Instantiate(numPrefab, transform.position, Quaternion.identity);
            numObject.transform.position = new Vector3(0.75f, -4, 0);
            numObject.transform.localScale = new Vector3(1, 1, 1);
            SpriteRenderer NumRenderer = numObject.GetComponent<SpriteRenderer>();

            switch (puls)
            {
                case 2:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_2");
                    NumRenderer.sprite = numScripts;
                    break;
                case 3:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_3");
                    NumRenderer.sprite = numScripts;
                    break;
                case 4:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_4");
                    NumRenderer.sprite = numScripts;
                    break;
                case 5:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_5");
                    NumRenderer.sprite = numScripts;
                    break;
                case 6:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_6");
                    NumRenderer.sprite = numScripts;
                    break;
                case 7:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_7");
                    NumRenderer.sprite = numScripts;
                    break;
                case 8:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_8");
                    NumRenderer.sprite = numScripts;
                    break;
                case 9:
                    numScripts = Resources.Load<Sprite>("Images/Bar/t_9");
                    NumRenderer.sprite = numScripts;
                    break;
            }
        }
    }
}

       