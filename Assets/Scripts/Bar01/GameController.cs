using System.Collections;
using System.Collections.Generic;
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
            ChackCard();
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
                stageArray[i] = new Stack<Card>();
                for(int i2 = 0; i2 < i + 1; i2++)
                {
                    stageArray[i].Push(allCard[count]);
                    GameObject createObject = Instantiate(cardObject, new Vector3(setPostionX,setPostionY - interval * i2,-i2), Quaternion.identity);
                    Card card = createObject.GetComponent<Card>();
                    card.SetCard(allCard[count]);
                    if (i2 == i)
                    {
                        card.TurnCard(true);
                    }
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
                int index = Random.Range(counter, numbers.Length);
                Card tmp = numbers[counter];
                numbers[counter] = numbers[index];
                numbers[index] = tmp;
                //Debug.Log(numbers[counter].CardType + "," + numbers[counter].CardNumber);
                counter++;
            }
            return numbers;
        }

        private void ChackCard()
        {
            if (!Input.GetMouseButtonDown(0)) { return; }
            Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (!hit) { return; }
            if (!hit.GetComponent<Card>()) { return; }
            Card card = hit.GetComponent<Card>();
            card.CardSelect();   
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
