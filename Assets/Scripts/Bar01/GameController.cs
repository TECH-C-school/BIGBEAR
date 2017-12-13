﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar01 {
    public class GameController : MonoBehaviour {

        private const float screenWidth = 1136;
        private const float screenHight = 640;

        private GameObject deck;
        private GameObject flame;
        private GameObject cardObject;
        private Queue<Card> dackArray = new Queue<Card>();
        private Stack<Card> dackOut = new Stack<Card>();
        private Stack<Card>[] stageArray = new Stack<Card>[7];
        private Stack<Card>[] outArray = new Stack<Card>[4];
        private int[] outArray1 = new int[] { 1,1,1,1};
        private GameObject selectCard;
        private GameObject[] firstPositions = new GameObject[7];
        private Vector3[] outStagePositon = new Vector3[4];
        private GameObject[] dackCards = new GameObject[3];
        private Card[] selectCards;

        public float marginTop = 0;
        public float marginside = 0;
        public Vector3 startPosition = new Vector3(-4.8f, 0.09f, 0);
        public Vector3 endPosition = new Vector3(4.78f, 0.09f, 0);

        private float scrennRatio = 1;

        private void Awake()
        {
            //画面を横にする
            Screen.orientation = ScreenOrientation.Landscape;
            //使用端末解像度と設定解像度の比率計算

            //初期化
            Initialization();
            //カード生成
            CreateCard(startPosition,endPosition,6,0.08f);

        }

        private void Update()
        {
            ClickChackDeck();
            ClickChackCard();
            ClickUpChackCard();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialization()
        {
            GameObject setObject;
            Vector3 setPosition;
            deck = Resources.Load<GameObject>("Prefabs/Bar01/Deck");
            flame = Resources.Load<GameObject>("Prefabs/Bar01/CardFlame");
            //背景の配置
            Sprite backImage = Resources.Load<Sprite>("Images/Bar/bg");
            setObject = new GameObject("BackGround");
            setObject.AddComponent<SpriteRenderer>();
            setObject.GetComponent<SpriteRenderer>().sprite = backImage;
            setObject.transform.localScale *= scrennRatio;
            //カードフレームの配置
            setObject = Instantiate(deck);
            Transform deckTransform = setObject.transform;
            for (int i = 0; i < 3; i++)
            {
                setObject = new GameObject("DackCard" + i);
                setObject.transform.parent = deckTransform;
                setObject.transform.localPosition = Vector3.zero + new Vector3(2.5f + (i * 0.5f), 0, -i);
                dackCards[i] = setObject;
            }
            //カードの保管場所の設置
            Vector3 centerPoint = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
            float space = 1.6f;
            char[] marks = new char[] { 'd', 'c', 'h', 's' };
            for(int i = 0; i < 4; i++)
            {
                setObject = Instantiate(flame);
                setObject.name = "CardFlame";
                setPosition = setObject.transform.position;
                setPosition.x = centerPoint.x + space * i;
                setObject.transform.position = setPosition;
                outStagePositon[i] = setPosition;
                Sprite mark = Resources.Load<Sprite>("Images/Bar/cardflame_" + marks[i]);
                GameObject setMark = new GameObject(marks[i].ToString());
                SpriteRenderer markRenderer = setMark.AddComponent<SpriteRenderer>();
                markRenderer.sprite = mark;
                markRenderer.sortingOrder = 2;
                setMark.transform.parent = setObject.transform;
                setMark.transform.localPosition = Vector2.zero;
                setMark.transform.localScale = new Vector3(1, 1, 1);
                outArray[i] = new Stack<Card>();
            }
        }

        /// <summary>
        /// カードを生成します。
        /// </summary>
        private void CreateCard(Vector3 startPoint, Vector3 endPoint, int sprit, float interval)
        {
            //トランプのすべて
            Card[] allCard = RandomNumber();
            //トランプのカードオブジェクト
            cardObject = Resources.Load<GameObject>("Prefabs/Bar01/Card");
            //場のトランプとトランプの間隔
            float setPostion = (endPosition.x - startPoint.x) /sprit;
            float setPostionX = startPosition.x;
            float setPostionY = startPosition.y;
            //デッキのカード
            for(int i = 0; i < 24; i++)
            {
                allCard[i].dack = true;
                dackArray.Enqueue(allCard[i]);
            }
            //場の初期カード
            int count = 24;
            for(int i = 0; i < 7; i++)
            {
                firstPositions[i] = new GameObject("firstColumn" + i);
                firstPositions[i].AddComponent<BoxCollider2D>();
                firstPositions[i].GetComponent<BoxCollider2D>().size = cardObject.GetComponent<BoxCollider2D>().size;
                firstPositions[i].GetComponent<BoxCollider2D>().isTrigger = true;
                firstPositions[i].transform.position = new Vector3(setPostionX, startPosition.y, 1);
                firstPositions[i].transform.localScale = cardObject.transform.localScale;
                stageArray[i] = new Stack<Card>();
                for(int i2 = 0; i2 < i + 1; i2++)
                {
                    GameObject createObject = Instantiate(cardObject, new Vector3(setPostionX,setPostionY - interval * i2,-i2), Quaternion.identity);
                    Card card = createObject.GetComponent<Card>();
                    card.SetCard(allCard[count]);
                    if (i2 == i)
                    {
                        card.TurnCard(true);
                    }
                    else
                    {
                        card.TurnCard(false);
                    }
                    card.From = createObject.transform.position;
                    card.Column = i;
                    stageArray[i].Push(card);
                    count++;
                }
                setPostionX += setPostion;
            }
        }


        /// <summary>
        /// トランプの種類をシャッフルします。
        /// </summary>
        /// <returns></returns>
        private Card[] RandomNumber()
        {
            Card[] numbers = new Card[52];
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                for(int c = 0; c < 13; c++)
                {
                    numbers[counter] = new Card((Card.CardTypes)i, c + 1);
                    counter++;
                }
            }
            counter = 0;
            while (counter < 52)
            {
                int index = UnityEngine.Random.Range(counter, numbers.Length);
                Card tmp = numbers[counter];
                numbers[counter] = numbers[index];
                numbers[index] = tmp;
                //Debug.Log(numbers[counter].CardType + "," + numbers[counter].CardNumber);
                counter++;
            }
            return numbers;
        }

        /// <summary>
        /// カードをクリックしたとき
        /// </summary>
        private void ClickChackCard()
        {
            //マウスをクリックしたとき
            if (!Input.GetMouseButtonDown(0)) { return; }
            Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (!hit) { return; }
            if (!hit.GetComponent<Card>()) { return; }
            Card card = hit.GetComponent<Card>();
            if (!card.Front) { return; }
            selectCard = hit.gameObject;
            List<Card> selectCardList = new List<Card>();
            //カードが外に出ていた場合
            if (card.OutCard)
            {
                selectCardList.Add(outArray[(int)card.CardType].Pop());
                selectCards = selectCardList.ToArray();
                card.CardSelect();
                return;
            }
            //カードが場のカードだった場合
            if (card.dack)
            {
                selectCardList.Add(card);
                selectCards = selectCardList.ToArray();
                card.CardSelect();
                return;
            }
            //カードがステージ場のカードだった場合
            do
            {
                selectCardList.Add(stageArray[card.Column].Peek());
            } while (card != stageArray[card.Column].Pop());
            selectCards = selectCardList.ToArray();
            for(int i = 0; i < selectCardList.Count; i++)
            {
                selectCardList[i].GetComponent<BoxCollider2D>().enabled = false;
            }
            Debug.Log("selectCardCount" + selectCards.Length);
            card.CardSelect();
        }

        /// <summary>
        /// デッキをクリックしたとき
        /// </summary>
        private void ClickChackDeck()
        {
            //マウスをクリックしたとき
            if (!Input.GetMouseButtonDown(0)) { return; }
            Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (!hit) { return; }
            if(hit.name != "Deck(Clone)") { return; }
            if (dackOut.Count != 0)
            {
                Card[] cards = dackOut.ToArray();
                Debug.Log(cards[0].CardNumber + "" + cards[0].CardType);

                for (int t = cards.Length - 1; t >= 0; t--)
                {
                    cards[t].transform.position = dackCards[0].transform.position + new Vector3(0,0,t);
                }
                Debug.Log(dackOut.Count);
                Debug.Log(dackOut.Peek().CardNumber + "" + dackOut.Peek().CardType);
                //Destroy(desCard);
            }
            for(int i = 0; i < 3; i++)
            {
                if(dackArray.Count == 0)
                {
                    hit.transform.Find("back").GetComponent<SpriteRenderer>().enabled = false;
                    continue;
                }
                GameObject card = Instantiate(cardObject);
                card.transform.position = dackCards[i].transform.position;
                card.GetComponent<Card>().SetCard(dackArray.Dequeue());
                card.GetComponent<Card>().dack = true;
                card.GetComponent<Card>().TurnCard(true);
                dackOut.Push(card.GetComponent<Card>());
            }
        }

        /// <summary>
        /// マウスを離したときに当たり判定のチェック
        /// </summary>
        private void ClickUpChackCard()
        {
            //選択したトランプをチェック
            if (!selectCard) { return; }
            //マウスを離したとき
            if (!Input.GetMouseButtonUp(0)) { return; }
            Card card = selectCard.GetComponent<Card>();
            //マウスを離したときの地点にカードまたは初期の置き場があるか調べる
            Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (!hit)
            {
                selectCard.transform.position = selectCard.GetComponent<Card>().From;
                if (selectCards[0].OutCard)
                {
                    CardsMove(selectCards, outArray[(int)selectCards[0].CardType]);
                }
                else if(selectCards[0].dack)
                {
                    selectCard.transform.position = selectCards[0].From;
                }
                else
                {
                    CardsMove(selectCards, stageArray[selectCards[0].Column]);
                }
                
            }
            else if (hit.GetComponent<Card>())
            {
                Card hitCard = hit.GetComponent<Card>();
                Debug.Log("hit Card is" + hitCard.CardType + "," + hitCard.CardNumber);
                Vector3 setPosition = ChackCard(hitCard);
                if (setPosition != card.From)
                {
                    card.From = setPosition;
                    selectCard.transform.position = card.From;
                    selectCard.transform.parent = hit.transform;
                    if (hitCard.OutCard)
                    {
                        CardsMove(selectCards, outArray[(int)hitCard.CardType]);
                        selectCards[0].OutCard = true;
                    }
                    else
                    {
                        CardsMove(selectCards, stageArray[hitCard.Column]);
                        selectCards[0].OutCard = false;
                        for (int i = 0; i < selectCards.Length; i++)
                        {
                            selectCards[i].Column = hitCard.Column;
                        }
                    }
                }
                else
                {
                    if (selectCards[0].OutCard)
                    {
                        card.From = setPosition;
                        selectCard.transform.position = card.From;
                        CardsMove(selectCards, outArray[(int)selectCards[0].CardType]);
                    }
                    else if (selectCards[0].dack)
                    {
                        card.From = setPosition;
                        selectCard.transform.position = card.From;
                        selectCard.transform.position = selectCards[0].From;
                    }
                    else
                    {
                        card.From = setPosition;
                        selectCard.transform.position = card.From;
                        CardsMove(selectCards, stageArray[selectCards[0].Column]);
                    }
                    
                }
            }
            else if(hit.name.IndexOf("firstColumn") != -1)
            {
                if (selectCard.GetComponent<Card>().CardNumber != 13)
                {
                    selectCard.transform.position = selectCard.GetComponent<Card>().From;
                    if (selectCards[0].dack)
                    {
                        selectCard.transform.position = selectCards[0].From;
                    }
                    else
                    {
                        if (card.OutCard)
                        {
                            CardsMove(selectCards, outArray[(int)card.CardType]);
                        }
                        else
                        {
                            CardsMove(selectCards, stageArray[selectCards[0].Column]);
                        }
                    }
                    
                }
                else
                {
                    int i = 0;
                    for (i = 0; i < firstPositions.Length; i++)
                    {
                        if (hit.transform.position == firstPositions[i].transform.position)
                        {
                            break;
                        }
                    }
                    CardsMove(selectCards, stageArray[i]);
                    if (card.OutCard)
                    {
                        card.OutCard = false;
                    }

                    selectCards[selectCards.Length -1].Column = i;
                    selectCards[selectCards.Length - 1].From = firstPositions[i].transform.position;
                    selectCards[selectCards.Length - 1].gameObject.transform.position = selectCards[selectCards.Length - 1].From;
                    for (int t = 0; t < selectCards.Length -1 ; t++)
                    {
                        selectCards[t].Column = i;
                        selectCards[t].From = firstPositions[i].transform.position;
                    }
                    selectCards[0].gameObject.transform.position += new Vector3(0, 0, -1);
                }
            }
            else if(hit.name == "CardFlame")
            {
                if(selectCards.Length == 1)
                {
                    int boxIndex = 0;
                    switch (hit.transform.GetChild(0).name)
                    {
                        case "d":
                            boxIndex = 0;
                            break;
                        case "c":
                            boxIndex = 1;
                            break;
                        case "h":
                            boxIndex = 2;
                            break;
                        case "s":
                            boxIndex = 3;
                            break;
                    }
                    if (!selectCards[0].OutCard && outArray[boxIndex].Count == 0 && selectCards[0].CardNumber == outArray1[boxIndex] && selectCards[0].CardType == (Card.CardTypes)boxIndex)
                    {
                        outArray1[boxIndex]++;
                        CardsMove(selectCards, outArray[boxIndex]);
                        selectCards[0].OutCard = true;
                        selectCards[0].transform.position = outStagePositon[boxIndex] + new Vector3(0,0,-1);
                        selectCards[0].transform.parent = hit.transform;
                        selectCards[0].From = outStagePositon[boxIndex];
                    }
                    else if (selectCards[0].OutCard)
                    {
                        selectCard.transform.position = selectCard.GetComponent<Card>().From;
                        CardsMove(selectCards, outArray[(int)selectCards[0].CardType]);
                    }
                    else if (selectCards[0].dack)
                    {
                        selectCard.transform.position = selectCards[0].From;
                    }
                    else
                    {
                        selectCard.transform.position = selectCard.GetComponent<Card>().From;
                        CardsMove(selectCards, stageArray[selectCards[0].Column]);
                    }
                }
                else
                {
                    selectCard.transform.position = selectCard.GetComponent<Card>().From;
                    CardsMove(selectCards, stageArray[selectCards[0].Column]);
                }
            }
            else
            {
                selectCard.transform.position = selectCard.GetComponent<Card>().From;
                if (selectCards[0].dack)
                {
                    selectCard.transform.position = selectCards[0].From;
                }else if (selectCards[0].OutCard)
                {
                    CardsMove(selectCards, outArray[(int)selectCards[0].CardType]);
                }
                else
                {
                    CardsMove(selectCards, stageArray[selectCards[0].Column]);
                }
            }
            
            card.CardSelect();
            
            for (int i = 0; i < selectCards.Length; i++)
            {    
                selectCards[i].GetComponent<BoxCollider2D>().enabled = true;
                if (selectCards[i].gameObject.transform.parent && !selectCards[i].OutCard)
                {
                    selectCards[i].From = selectCards[i].gameObject.transform.parent.transform.position + new Vector3(0, -0.3f, -1);
                }
                else if(selectCards[i].gameObject.transform.parent && selectCards[i].OutCard)
                {
                    selectCards[i].From = selectCards[i].gameObject.transform.parent.transform.position + new Vector3(0, 0, -1);
                }      
            }
            selectCard = null;
            return;
        }

        /// <summary>
        /// トランプがその場所に置くことができるか調べる
        /// </summary>
        /// <param name="chackCard">調べ先のカード</param>
        /// <returns>置けますか</returns>
        private Vector3 ChackCard(Card hitCard)
        {
            Card chackCard = hitCard;
            Card card = selectCard.GetComponent<Card>();
            if (chackCard)
            {
                if (!chackCard.Front) { return card.From; }
                if (chackCard.dack) { return card.From; }
                //Debug.Log("chackCard" + chackCard.CardType + "," + chackCard.CardNumber);
                if (chackCard.OutCard)
                {
                    if(selectCards.Length != 1) { return card.From; }
                    if(outArray1[(int)chackCard.CardType] == selectCards[0].CardNumber && selectCards[0].CardType == chackCard.CardType)
                    {
                        outArray1[(int)chackCard.CardType]++;
                        return outArray[(int)chackCard.CardType].Peek().transform.position + new Vector3(0, 0, -1);
                    }
                    return card.From;
                }
                switch (chackCard.CardType)
                {
                    case Card.CardTypes.Clover:
                    case Card.CardTypes.Spade:
                        if (card.CardType == Card.CardTypes.Spade || card.CardType == Card.CardTypes.Clover) { return card.From; }
                        if (card.CardNumber != chackCard.CardNumber - 1) { return card.From; }
                        return chackCard.From + new Vector3(0,-0.3f,-1);
                    case Card.CardTypes.Diamond:
                    case Card.CardTypes.Heart:
                        if (card.CardType == Card.CardTypes.Diamond || card.CardType == Card.CardTypes.Heart) { return card.From; }
                        if (card.CardNumber != chackCard.CardNumber - 1) { return card.From; }
                        return chackCard.From + new Vector3(0, -0.3f, -1);
                    default:
                        return card.From;
                }
            }
            //else if(hitCard.name.IndexOf("firstColumn") != -1)
            //{
            //    if (selectCard.GetComponent<Card>().CardNumber != 13) { return selectCard.GetComponent<Card>().From; }
            //    int i = 0;
            //    for(i = 0; i < firstPositions.Length; i++)
            //    {
            //        if(hit.transform.position == firstPositions[i].transform.position)
            //        {
            //            CardMove(card, stageArray[i]);
            //            break;
            //        }
            //    }
                
            //    return hit.transform.position;
            //}
            //else if(hitCard.name == "CardFlame")
            //{
            //    switch (hit.transform.GetChild(0).name)
            //    {
            //        case "d":
            //            if(card.CardType != Card.CardTypes.Diamond) { return card.From; }
            //            if(card.CardNumber != outArray1[0]) { return card.From; }
            //            outArray1[0]++;
            //            return hit.transform.position;
            //        case "s":
            //            if(card.CardType != Card.CardTypes.Spade) { return card.From; }
            //            if (card.CardNumber != outArray1[1]) { return card.From; }
            //            outArray1[1]++;
            //            return hit.transform.position;
            //        case "h":
            //            if(card.CardType != Card.CardTypes.Heart) { return card.From; }
            //            if (card.CardNumber != outArray1[2]) { return card.From; }
            //            outArray1[2]++;
            //            return hit.transform.position;
            //        case "c":
            //            if(card.CardType != Card.CardTypes.Clover) { return card.From; }
            //            if (card.CardNumber != outArray1[3]) { return card.From; }
            //            outArray1[3]++;
            //            return hit.transform.position;
            //    }
            //    return selectCard.GetComponent<Card>().From;
            //}
            return card.From;
        }
       
        /// <summary>
        /// Cardのデータを更新します。
        /// </summary>
        /// <param name="from">操作元のカード</param>
        /// <param name="to">移動先の列</param>
        private void ChangCardDate(Card from, int to)
        {
            Card[] stagelist = stageArray[from.Column].ToArray();
            Card[] movecards = new Card[30];
            int i = 0;
            for (i = 0; i < stagelist.Length; i++)
            {
                if (stagelist[i] == from)
                {
                    break;
                }
            }
            for (int t = i; t >= 0; t--)
            {
                Card outCard = stageArray[from.Column].Pop();
                if (stageArray[from.Column].Count != 0)
                {
                    outCard = stageArray[from.Column].Peek();
                    outCard.TurnCard(true);
                }
                movecards[i - t] = stagelist[t];
            }
            for (i = 0; movecards[i] != null; i++)
            {
                movecards[i].Column = to;
                stageArray[to].Push(movecards[i]);
            }
            
            Card card;
            if ((card = stageArray[from.Column].Peek()).Front)
            {
                
            }

        }

        /// <summary>
        /// カードデータの移動をします。
        /// </summary>
        /// <param name="fromCard">操作元のカード</param>
        /// <param name="toCardBox">操作後のカードボックス</param>
        private void CardMove(Card fromCard, Stack<Card> toCardBox)
        {
            List<Card> moveCardList = new List<Card>();
            //移動するカードデータを選択
            if (fromCard.dack)
            {
                //Debug.Log("dack");
                //Debug.Log(dackOut.Peek().CardType + "," + dackOut.Peek().CardNumber);
                Card card = dackOut.Pop();
                //Debug.Log(card.From);
                //Debug.Log(dackOut.Peek().CardType + "," + dackOut.Peek().CardNumber);
                card.dack = false;
                moveCardList.Add(card);

            }
            else
            {
                do
                {
                    moveCardList.Add(stageArray[fromCard.Column].Peek());
                } while (fromCard != stageArray[fromCard.Column].Pop());
                if (stageArray[fromCard.Column].Count != 0)
                {
                    stageArray[fromCard.Column].Peek().TurnCard(true);
                }
            }
            for(int i = 0; i < moveCardList.Count; i++)
            {
                toCardBox.Push(moveCardList[i]);
            }
        }

        private void CardsMove(Card[] selectCards, Stack<Card> toCardBox)
        {
            for(int i = selectCards.Length - 1; i >= 0; i--)
            {
                if (selectCards[i].OutCard)
                {
                    outArray1[(int)selectCards[i].CardType]--;
                }
                if (selectCards[i].dack)
                {
                    dackOut.Pop();
                    selectCards[i].dack = false;
                }
                toCardBox.Push(selectCards[i]);
            }
            if (stageArray[selectCards[0].Column].Count != 0)
            {
                stageArray[selectCards[0].Column].Peek().TurnCard(true);
            }
            Debug.Log("To card box last card is" + toCardBox.Peek().CardType + ":" + toCardBox.Peek().CardNumber);
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
