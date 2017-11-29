using System.Collections;
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
        private Queue<Card> dackArray = new Queue<Card>();
        private Stack<Card>[] stageArray = new Stack<Card>[7];
        private Stack<Card>[] outArray = new Stack<Card>[4];
        private int[] outArray1 = new int[] { 1,1,1,1};
        private GameObject selectCard;
        private GameObject[] firstPositions = new GameObject[7];

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
                Sprite mark = Resources.Load<Sprite>("Images/Bar/cardflame_" + marks[i]);
                GameObject setMark = new GameObject(marks[i].ToString());
                SpriteRenderer markRenderer = setMark.AddComponent<SpriteRenderer>();
                markRenderer.sprite = mark;
                markRenderer.sortingOrder = 2;
                setMark.transform.parent = setObject.transform;
                setMark.transform.localPosition = Vector2.zero;
                setMark.transform.localScale = new Vector3(1, 1, 1);
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
            GameObject cardObject = Resources.Load<GameObject>("Prefabs/Bar01/Card");
            //場のトランプとトランプの間隔
            float setPostion = (endPosition.x - startPoint.x) /sprit;
            float setPostionX = startPosition.x;
            float setPostionY = startPosition.y;
            //デッキのカード
            for(int i = 0; i < 24; i++)
            {
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
            for(int i = 0; i < selectCard.transform.childCount; i++)
            {
                selectCard.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
            }
            card.CardSelect();
        }

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
                card.CardSelect();
                selectCard.transform.position = selectCard.GetComponent<Card>().From;
                for (int i = 0; i < selectCard.transform.childCount; i++)
                {
                    selectCard.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
                }
                selectCard = null;
                return;
            }
            Debug.Log(hit.name);
            Vector3 setPosition = ChackCard(hit);
            selectCard.transform.position = setPosition;
            if (setPosition != card.From)
            {
                selectCard.transform.parent = hit.transform;
                card.From = setPosition;
            }
            card.CardSelect();
            for (int i = 0; i < selectCard.transform.childCount; i++)
            {
                selectCard.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
            }
            selectCard = null;
            return;
        }

        /// <summary>
        /// トランプがその場所に置くことができるか調べる
        /// </summary>
        /// <param name="chackCard">調べ先のカード</param>
        /// <returns>置けますか</returns>
        private Vector3 ChackCard(Collider2D hit)
        {
            Card chackCard = hit.GetComponent<Card>();
            Card card = selectCard.GetComponent<Card>();
            if (hit.GetComponent<Card>())
            {
                Debug.Log("chackCard" + chackCard.CardType + "," + chackCard.CardNumber);
                switch (chackCard.CardType)
                {
                    case Card.CardTypes.Clover:
                    case Card.CardTypes.Spade:
                        if (card.CardType == Card.CardTypes.Spade || card.CardType == Card.CardTypes.Clover) { return card.From; }
                        if (card.CardNumber != chackCard.CardNumber - 1) { return card.From; }
                        CardMove(card, stageArray[chackCard.Column]);
                        return chackCard.From + new Vector3(0,-0.3f,-1);
                    case Card.CardTypes.Diamond:
                    case Card.CardTypes.Heart:
                        if (card.CardType == Card.CardTypes.Diamond || card.CardType == Card.CardTypes.Heart) { return card.From; }
                        if (card.CardNumber != chackCard.CardNumber - 1) { return card.From; }
                        CardMove(card, stageArray[chackCard.Column]);
                        card.Column = chackCard.Column;
                        return chackCard.From + new Vector3(0, -0.3f, -1);
                    default:
                        return card.From;
                }
            }
            else if(hit.name.IndexOf("firstColumn") != -1)
            {
                if (selectCard.GetComponent<Card>().CardNumber != 13) { return selectCard.GetComponent<Card>().From; }
                int i = 0;
                for(i = 0; i < firstPositions.Length; i++)
                {
                    if(hit.transform.position == firstPositions[i].transform.position)
                    {
                        break;
                    }
                }
                ChangCardDate(selectCard.GetComponent<Card>(), i);
                return hit.transform.position;
            }
            else if(hit.name == "CardFlame")
            {
                switch (hit.transform.GetChild(0).name)
                {
                    case "d":
                        if(card.CardType != Card.CardTypes.Diamond) { return card.From; }
                        if(card.CardNumber != outArray1[0]) { return card.From; }
                        outArray1[0]++;
                        return hit.transform.position;
                    case "s":
                        if(card.CardType != Card.CardTypes.Spade) { return card.From; }
                        if (card.CardNumber != outArray1[1]) { return card.From; }
                        outArray1[1]++;
                        return hit.transform.position;
                    case "h":
                        if(card.CardType != Card.CardTypes.Heart) { return card.From; }
                        if (card.CardNumber != outArray1[2]) { return card.From; }
                        outArray1[2]++;
                        return hit.transform.position;
                    case "c":
                        if(card.CardType != Card.CardTypes.Clover) { return card.From; }
                        if (card.CardNumber != outArray1[3]) { return card.From; }
                        outArray1[3]++;
                        return hit.transform.position;
                }
                return selectCard.GetComponent<Card>().From;
            }
            return card.From;
        }

        /// <summary>
        /// Cardのデータを更新します。
        /// </summary>
        /// <param name="from">操作元のカード</param>
        /// <param name="to">移動先のカード</param>
        private void ChangCardDate(Card from, Card to)
        {
            Card[] stagelist = stageArray[from.Column].ToArray();
            Card[] movecards = new Card[30];
            int i = 0;
            for(i = 0; i < stagelist.Length; i++)
            {
                if(stagelist[i] == from)
                {
                    break;
                }
            }
            for(int t = i; t >= 0; t--)
            {
                Debug.Log("hogehoge");
                Debug.Log("ho" + stageArray[from.Column].Peek().CardNumber + "," + stageArray[from.Column].Peek().CardType);
                Card outCard = stageArray[from.Column].Pop();
                if (stageArray[from.Column].Count != 0)
                {
                    outCard = stageArray[from.Column].Peek();
                    outCard.TurnCard(true);
                }
                movecards[i - t] = stagelist[t];
            }
            for(i = 0; movecards[i] != null; i++)
            {
                movecards[i].Column = to.Column;
                stageArray[to.Column].Push(movecards[i]);
            }
            Debug.Log("de" + stageArray[from.Column].Peek().CardNumber + "," + stageArray[from.Column].Peek().CardType);
            Debug.Log(stageArray[to.Column].Peek().CardNumber + "," + stageArray[to.Column].Peek().CardType);
            Card card;
            if ((card = stageArray[from.Column].Peek()).Front)
            {
                Debug.Log(card.CardNumber + "," + card.CardType);
            }
            
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
                Debug.Log("hogehoge");
                Debug.Log("ho" + stageArray[from.Column].Peek().CardNumber + "," + stageArray[from.Column].Peek().CardType);
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
            Debug.Log("de" + stageArray[from.Column].Peek().CardNumber + "," + stageArray[from.Column].Peek().CardType);
            Debug.Log(stageArray[to].Peek().CardNumber + "," + stageArray[to].Peek().CardType);
            Card card;
            if ((card = stageArray[from.Column].Peek()).Front)
            {
                Debug.Log(card.CardNumber + "," + card.CardType);
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
            do
            {
                moveCardList.Add(stageArray[fromCard.Column].Peek());
            } while (fromCard != stageArray[fromCard.Column].Pop());
            if (stageArray[fromCard.Column].Count != 0)
            {
                Debug.Log("de" + stageArray[fromCard.Column].Peek().CardNumber + "," + stageArray[fromCard.Column].Peek().CardType);
                stageArray[fromCard.Column].Peek().TurnCard(true);
            }
            
            for(int i = 0; i < moveCardList.Count; i++)
            {
                toCardBox.Push(moveCardList[i]);
            }

        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
