﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar03 {
    public class GameController : MonoBehaviour
    {
        private string _nextCardString = "c01";
        private int _nextCardNumber = 1;
        private int[] _deckMaxNumber = new int[20];
        private Vector3  thisHit;
        private int[] _deckCard = new int[104];

        private int _buttonState = 0;
        private Cards TappedCard　= null;


        void Start()
        {
            //MakeBackCards();
            CardsSet();
            BackGroundMake();
        }  
        void Update()
        {
            ClickCard();
        }
        //多分リザルト
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
        /// <summary>
        /// カードをセットする関数
        /// </summary>
        //裏面のカードをセットする関数
        /*private void MakeBackCards()
        {
            int count = 0;
            string[] cardMarkNumber = new string[104];
            cardMarkNumber = AryRamdomTwo(cardSetMN(cardMarkNumber));

            Transform parentObject = GameObject.Find("Cards").transform;
            Transform deckCard = GameObject.Find("Deck").transform;
            GameObject cardPrefabs = Resources.Load<GameObject>("Prefabs/Bar03/Back");
            for (int x = 0; x < 10; x++)
            {
                int n = 4;
                if( x < 4)
                {
                    n = 5;
                }
                
                for (int y = 0; y < n + 1; y++)
                {
                    if (y < n)
                    {
                        var cardObject = Instantiate(cardPrefabs, transform.position, Quaternion.identity);
                        cardObject.transform.position = new Vector3(
                            x * 1.76f - 7.97f,
                            -y * 0.31f + 3.66f,
                            -y * 0.1f);
                        cardObject.transform.parent = GameObject.Find("Cards" + x.ToString()).transform;
                        Cards cardSet = cardObject.GetComponent<Cards>();
                        cardSet.String = cardMarkNumber[count];
                        cardSet.Deck = x;
                        _deckMaxNumber[x] = y;
                        cardSet.TurnCardFaceDown();
                        count++;
                    }
                    else
                    {
                        var cardObject = Instantiate(cardPrefabs, transform.position, Quaternion.identity);
                        cardObject.transform.position = new Vector3(
                            x * 1.76f - 7.97f,
                            -y * 0.31f + 3.66f,
                            -y * 0.1f);
                        cardObject.transform.parent = GameObject.Find("Cards" + x.ToString()).transform;
                        Cards cardSet = cardObject.GetComponent<Cards>();
                        cardSet.String = cardMarkNumber[count];
                        cardSet.Deck = x;
                        _deckMaxNumber[x] = y;
                        cardSet.TurnCardFaceUp();
                        Debug.Log(cardMarkNumber[count]);
                        count++;
                    }
                }
            }
            while (count < 104)
            {
                var cardObject = Instantiate(cardPrefabs, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(-7.97f, -2.9f, 0);
                cardObject.transform.parent = deckCard;
                Cards cardSet = cardObject.GetComponent<Cards>();
                cardSet.String = cardMarkNumber[count];
                cardSet.TurnCardFaceDown();
                count++;
            }
        }*/

        /// <summary>
        /// カードをセットする関数
        /// </summary>
        private void CardsSet()
        {
            int count = 0;
            string[] cardMarkNumber = new string[104];
            cardMarkNumber = AryRamdomTwo(cardSetMN(cardMarkNumber));

            Transform parentObject = GameObject.Find("Cards").transform;
            Transform deckCard = GameObject.Find("Deck").transform;
            GameObject cardPrefabs = Resources.Load<GameObject>("Prefabs/Bar03/Back");
            Vector3 cardTransform = GameObject.Find("Deck").transform.position;
            for (int x = 0; x < 10; x++)
            {
                int n = 4;
                if (x < 4)
                {
                    n = 5;
                }

                for (int y = 0; y < n + 1; y++)
                {
                    if (y < n)
                    {
                        var cardObject = Instantiate(cardPrefabs, transform.position, Quaternion.identity);
                        cardTransform = GameObject.Find("Cards" + x).transform.position;
                        cardObject.transform.position = new Vector3(cardTransform.x, cardTransform.y - y * 0.31f, cardTransform.z - y * 0.1f);
                        cardObject.transform.parent = GameObject.Find("Cards" + x.ToString()).transform;
                        Cards cardSet = cardObject.GetComponent<Cards>();
                        cardSet.String = cardMarkNumber[count];
                        cardSet.Deck = x;
                        cardSet.DeckNum = y;
                        _deckMaxNumber[x] = y;
                        _deckCard[count] = 0;
                        cardSet.Count = count;
                        cardSet.TurnCardFaceDown();
                        count++;
                    }
                    else
                    {
                        var cardObject = Instantiate(cardPrefabs, transform.position, Quaternion.identity);
                        cardTransform = GameObject.Find("Cards" + x).transform.position;
                        cardObject.transform.position = new Vector3(cardTransform.x, cardTransform.y - y * 0.31f, cardTransform.z - y * 0.1f);
                        cardObject.transform.parent = GameObject.Find("Cards" + x.ToString()).transform;
                        Cards cardSet = cardObject.GetComponent<Cards>();
                        cardSet.String = cardMarkNumber[count];
                        cardSet.Deck = x;
                        cardSet.DeckNum = y;
                        _deckMaxNumber[x] = y;
                        _deckCard[count] = 0;
                        cardSet.Count = count;
                        cardSet.TurnCardFaceUp();
                        Debug.Log(cardMarkNumber[count]);
                        count++;
                    }
                }
            }
            while (count < 104)
            {
                var cardObject = Instantiate(cardPrefabs, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(-7.97f, -2.9f, 0);
                cardObject.transform.parent = deckCard;
                Cards cardSet = cardObject.GetComponent<Cards>();
                cardSet.String = cardMarkNumber[count];
                _deckCard[count] = 1;
                cardSet.Count = count;
                cardSet.TurnCardFaceDown();
                count++;
            }
        }
        //randomにカードを配列にいれる関数(1デッキ)
        private string[] cardSetMN(string[] values)
        {
            int[] card = new int[52];
            for (int i = 0; i < card.Length; i++)
            {
                card[i] = i;
            }
            for (int i = 0; i < card.Length; i++)
            {
                int ransu = Random.Range(1,52);
                int kari = card[i];
                card[i] = card[ransu];
                card[ransu] = kari;
            }
            int kazu = 0;
            string[] mark = new string[] { "h", "d", "s", "c" };
            for (int i = 0; i < card.Length; i++)
            {
                kazu = card[i] % 13 + 1;
                if (kazu < 10)
                {
                    values[i] += mark[card[i] / 13] + "0" + kazu.ToString();
                }
                else
                {
                    values[i] += mark[card[i] / 13] + kazu.ToString();
                }
            }
            return values;
            }
        /// <summary>
        /// 背景を作る関数
        /// </summary>
        //背景を作る関数
        private void BackGroundMake()
        {
            Transform parentObject1 = GameObject.Find("UpCardFlame").transform;
            Transform parentObject2 = GameObject.Find("DownCardFlame").transform;
            GameObject UpCardFlamePrefabs = Resources.Load<GameObject>("Prefabs/Bar03/UpCardFlame");
            GameObject DownCardFlamePrefabs = Resources.Load<GameObject>("Prefabs/Bar03/DownCardFlame");
            int y = 0;
            for (int x = 0; x < 10; x++)
            {
                var UpCardFlameObject = Instantiate(UpCardFlamePrefabs, transform.position, Quaternion.identity);
                UpCardFlameObject.transform.position = new Vector3(
                    x * 1.76f - 7.97f, 1.12f + 0.5724931f,
                    0);
                UpCardFlameObject.transform.parent = parentObject1;
                if (x != 1)
                {
                    var DownCardFlameObject = Instantiate(DownCardFlamePrefabs, transform.position, Quaternion.identity);
                    DownCardFlameObject.transform.position = new Vector3(
                        x * 1.76f - 7.97f, -3.47f + 0.5724931f,
                        0);
                    DownCardFlameObject.transform.parent = parentObject2;
                }
            }
        }
        //ランダムな数字の配列を作る関数(シャッフル)
        private int[] MakeRandomNumbers()
        {
            int[] values = new int[104];
            for (int n = 0; n < 104; n++)
            {
                values[n] += n + 1;
            }
            var counter = 0;
            while (counter < 104)
            {
                var index = Random.Range(counter, values.Length);
                var tmp = values[counter];
                values[counter] = values[index];
                values[index] = tmp;

                counter++;
            }
            
            return values;
        }
        //配列を二つ作ってランダムに入れ替える関数
        private string[] AryRamdomTwo(string[] values)
        {
            string[] ary = new string[104];
            for(int i = 0; i < 104; i++)
            {
                
                if (i < 52)
                {
                    ary[i] = values[i];
                }
                else
                {
                    ary[i] = values[i-52];
                }
                
            }
            var counter = 0;
            while (counter < 104)
            {
                var index = Random.Range(counter, values.Length);
                var tmp = ary[counter];
                ary[counter] = ary[index];
                ary[index] = tmp;

                counter++;
            }
            return ary;

        }
        /// <summary>
        /// クリックしたときカードを判定する関数
        /// </summary>
        //マウスでクリックしたときにカードを判定する関数
        private void ClickCard()
        {
            //マウスクリックの判定 GetMouse--Down
            if (!Input.GetMouseButtonDown(0)) return;

            //クリックされた位置を取得
            var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Collider2D上クリックの判定
            if (!Physics2D.OverlapPoint(tapPoint)) return;

            //クリックされた位置のオブジェクトを取得
            var hitObject = Physics2D.Raycast(tapPoint, -Vector3.up);
            if (!hitObject) return;

            //クリックされたカードスクリプトを取得
            var card = hitObject.collider.gameObject.GetComponent<Cards>();

            
            //クリックされたカードの位置を取得
            Vector3 hitTransform = hitObject.transform.position;
            
            //クリックされたカードを数字にする
            int numValue = 0;

            //クリックされたカードがデッキのカードだったら
            if(_deckCard[card.Count] == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    _deckCard[card.Count] = 0;
                    int y = _deckMaxNumber[i]+1;
                    Vector3 cardPosition = GameObject.Find("Cards" + i).transform.position;
                    card.transform.parent = GameObject.Find("Cards" + i.ToString()).transform;
                    card.transform.position = new Vector3(cardPosition.x, cardPosition.y - y * 0.31f, cardPosition.z - y * 0.1f);
                    _deckMaxNumber[i]++;
                    card.DeckNum = _deckMaxNumber[i];
                    card.Deck = i;
                    card.TurnCardFaceUp();
                    if (!Physics2D.OverlapPoint(tapPoint)) return;
                    hitObject = Physics2D.Raycast(tapPoint, -Vector3.up);
                    if (!hitObject) return;
                    card = hitObject.collider.gameObject.GetComponent<Cards>();

                }
                return;
            }

            //カードから数字のみをとりだす
            bool parsed = System.Int32.TryParse(card.String.Substring(1, 2), out numValue);

            Debug.Log("このデッキのMAX"+_deckMaxNumber[card.Deck]);
            Debug.Log("このカードのｙ" + card.DeckNum);


            //前回クリックカード+1と今回クリックしたカードが同じ
            if (_nextCardNumber == numValue && card.DeckNum == _deckMaxNumber[card.Deck] && TappedCard != null) {
                Debug.Log("OK");
                TappedCard.transform.position = new Vector3(hitTransform.x,hitTransform.y - 0.31f, hitTransform.z - 0.1f);
                var cardchange = Physics2D.Raycast(tapPoint, -Vector3.up);
                _deckMaxNumber[card.Deck]++;
                _deckMaxNumber[TappedCard.Deck]--;
                TappedCard.DeckNum = _deckMaxNumber[card.Deck];
                TappedCard.Deck = card.Deck;
            }

            //カードをクリックして一番上にあり裏だったらそのカードを表にする
            if(_deckMaxNumber[card.Deck] == card.DeckNum && !card.IsFront)
            {
                Debug.Log("クリックしたカードを表にします。");
                card.TurnCardFaceUp();
            }
            
            

            //次のカードを判明させる。13だったら変えない
            if (numValue != 13) {
                _nextCardNumber = numValue + 1;
                Debug.Log("次は" + _nextCardNumber + "のカードを押してください");
            }
            else
            {
                _nextCardNumber = numValue;
                Debug.Log("次のカードはないです");
            }
            //前回のカードを覚えさせる
            if (card.DeckNum == _deckMaxNumber[card.Deck])
            {
                if (TappedCard == null)
                {
                    TappedCard = card;
                }
                else
                {
                    TappedCard = null;
                }
            }
            
        }
        /// <summary>
        /// ボタンが押された時メニューを開く関数
        /// </summary>
        public void ButtonPush()
        {
            if (_buttonState == 0)
            {
                _buttonState = 1;
                Vector2 buttonPosition = GetComponent<RectTransform>().anchoredPosition;
                buttonPosition.x /= 2;
                GetComponent<RectTransform>().anchoredPosition = buttonPosition;
                Debug.Log("もう一回押すとメニューが開きます");
            }
            else
            {
                _buttonState = 0;
                Debug.Log("メニューを開きます");
            }
        }
        public void DeckCardCheck()
        {
            for(int x = 0;x < 10; x++)
            {
                var deckCheck = GameObject.Find("Cards"+x).transform;
                
            }


        }
        public void DragMouse()
        {
            
            if (Input.GetMouseButtonDown(0)) 
            {
                Ray ray = new Ray();
                RaycastHit hit = new RaycastHit();
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray.origin, ray.direction,out hit, Mathf.Infinity))
                {
                    if (hit.collider.gameObject)
                    {

                    }
                }
            }
        }
        
    }

}