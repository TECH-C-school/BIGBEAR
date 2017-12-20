using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar03 {
    public class GameController : MonoBehaviour
    {
        private string _nextCardString = "c01";
        private int _nextCardNumber = 1;
        private int _select = 0;

        void Start()
        {
            MakeBackCards();
            BackGroundMake();
            DeckCardCheck();
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
        private void MakeBackCards()
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
        }
        //randomにカードを配列にいれる関数
        private string[] cardSetMN(string[] values)
        {
            int[] card = new int[52];
            for (int i = 0; i < card.Length; i++)
            {
                card[i] = i;
            }
            Random random = new Random();
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
        //ランダムな数字の配列を作る関数
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
            var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
            if (!hitObject) return;

            //クリックされたカードスクリプトを取得
            var card = hitObject.collider.gameObject.GetComponent<Cards>();

            Debug.Log(card);

            //if (Resources.Load<GameObject>("Prefabs/Bar03/Back") == card) ;
            //クリックされたカードを数字にする
            int numValue = 0;
            bool parsed = System.Int32.TryParse(card.String.Substring(1,2), out numValue);
            
            

            if (_nextCardNumber == numValue) Debug.Log("OK");

            _nextCardNumber = numValue + 1;
            Debug.Log("次は" + _nextCardNumber + "のカードを押してください");

            Debug.Log("これはデッキ" + card.Deck + "のカードです");
            //Debug.Log("hit object is" + card.String);

            //次にクリックされるカードが判明
            //if (_nextCardString != card.String) return;
        }
        public void ButtonPush()
        {
            Debug.Log("ButtonPush");
        }
        public void DeckCardCheck()
        {
            for(int x = 0;x < 10; x++)
            {
                var deckCheck = GameObject.Find("Cards"+x).transform;
                Debug.Log(deckCheck);
            }


        }
    }

}
