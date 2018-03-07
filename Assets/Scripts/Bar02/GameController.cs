using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar02
{
    public enum Mark
    {
        Spade,
        Heart,
        Diamond,
        Clover
    }

    public struct Card
    {
        public int number;
        public Mark mark;

        public string GetPath()
        {
            var fileName = "";

            switch (mark)
            {
                case Mark.Spade:
                    fileName += "s";
                    break;
                case Mark.Heart:
                    fileName += "h";
                    break;
                case Mark.Clover:
                    fileName += "c";
                    break;
                default:
                    fileName += "d";
                    break;
            }

            if (number < 10)
            {
                fileName += "0" + number;
            }
            else
            {
                fileName += number;
            }

            return fileName;
        }
    }

    public class GameController : MonoBehaviour
    {
        private Card[] remaindertrump;
        private int remaindertrump_index = 21;
        private int _nextCardNumber = 1;
        private GameObject Clickcards = null;
        private GameObject Clickcards2 = null;
        private int counter = 0;
        static int number1 = 0;
        static int number2 = 0;


        public void Start()
        {

            int[] cards = new int[52];
            //21枚のカードを用意する
            for (int i = 0; i < 52; i++)
            {
                cards[i] = i + 1;

            }

            var counter = 0;
            while (counter < 52)
            {
                var index = Random.Range(counter, cards.Length);
                var tmp = cards[counter];
                cards[counter] = cards[index];
                cards[index] = tmp;

                counter++;
            }

            Card[] trump = new Card[21];
            for (int i = 0; i < 21; i++)
            {

                //19
                trump[i].number = (cards[i] - 1) % 13 + 1;
                trump[i].mark = (Mark)((cards[i] - 1) / 13);
                //Debug.Log("生成" + trump[i].mark + trump[i].number);
            }

            //残りの31枚のカードを山札にする

            remaindertrump = new Card[52];
            for (int i =21; i < 52; i++)
            {
                
                remaindertrump[i].number = (cards[i] - 1) % 13 + 1;
                remaindertrump[i].mark = (Mark)((cards[i] - 1) / 13);
               //Debug.Log("山札" + remaindertrump[i].mark + remaindertrump[i].number);
            }

            //21枚のカードを表示する
            var counterForTrump = 0;
            var cardsObject = GameObject.Find("Cards").transform;
            foreach (Transform cardObject in cardsObject.transform)
            {
                var fileName = "";

                switch (trump[counterForTrump].mark)
                {
                    case Mark.Spade:
                        fileName += "s";
                        break;
                    case Mark.Heart:
                        fileName += "h";
                        break;
                    case Mark.Clover:
                        fileName += "c";
                        break;
                    default:
                        fileName += "d";
                        break;
                }

                if (trump[counterForTrump].number < 10)
                {
                    fileName += "0" + trump[counterForTrump].number;
                }
                else
                {
                    fileName += trump[counterForTrump].number;
                }



                var cardSpriteRenderer = cardObject.GetComponent<SpriteRenderer>();
                cardSpriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + fileName);

                counterForTrump++;
            }
        }

        void Update()
        {
            ClickCard();
            
        }


        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
            
        }
        
        //山札をクリックしたとき、隣にカードを配置する
        public void Yamahuda()
        {

            //int[] cards = new int[53];

            // for (int i = 21; i < 53; i++)
            // {
            //     cards[i] = i + 1;

            // }

            // var counter = 22;
            // while (counter < 52)
            // {
            //     var index = Random.Range(counter, cards.Length);
            //     var tmp = cards[counter];
            //     cards[counter] = cards[index];
            //     cards[index] = tmp;

            //     counter++;
            // }

            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar02/Card");
            var cardsObject = GameObject.Find("YamahudaCards");
            //Card[] trump = new Card[53];
            //for (int i = 22; i < 53; i++)
            //{

            //    trump[i].number = (cards[i] - 1) % 13 + 1;
            //    trump[i].mark = (Mark)((cards[i] - 1) / 13);
            //}

            for (int i = 0; i < 1; i++)
            {

                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.parent = GameObject.Find("YamahudaCards").transform;
                cardObject.transform.position = new Vector3(
                       5f,
                       -3.5f,
                       0);
                cardObject.transform.parent = cardsObject.transform;

                cardObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + remaindertrump[remaindertrump_index].GetPath());
                remaindertrump_index++;
            }
        }

        //カードを2つクリックして合計値が13ならば、カードが消える処理

        private void ClickCard()
        {
            //マウスクリックの判定
            if (!Input.GetMouseButtonDown(0)) return;

            //クリックされた位置を取得
            var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Collider2D上クリックの判定
            if (!Physics2D.OverlapPoint(tapPoint)) return;

            //クリックした位置のオブジェクトを取得
            var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
            if (!hitObject) return;

            //2つのカードの数字の合計値が13であればそのカードを非表示にする
            if (Clickcards != null)
            {
                Clickcards2 = hitObject.collider.gameObject;
                var card2 = Clickcards2.GetComponent<SpriteRenderer>();
                string spritename2 = card2.sprite.ToString();
                string a2 = spritename2.Substring(1, 2);
                number2 = int.Parse(a2);
                Debug.Log(number2);
                counter++;
            }
            else 
            {
                Clickcards = hitObject.collider.gameObject;
                var card1 = Clickcards.GetComponent<SpriteRenderer>();
                //数字だけ読み込む
                string spritename = card1.sprite.ToString();
                string a = spritename.Substring(1, 2);
                number1 = int.Parse(a);
                Debug.Log(number1);
                counter++;
                if(number1 == 13)
                {
                    MoveCard();
                    number1 = 0;
                    counter = 0;
                }
            } 
            
            
            //var card2 = hitObject.collider.gameObject.GetComponent<SpriteRenderer>();
            
            
            if(counter == 2)
            {
                if (number1 + number2 == 13)
                {
                    Debug.Log("13");
                    MoveCard();
                }

                else
                {
                    Debug.Log("13ではない");

                }
                number1 = 0;
                number2 = 0;
                counter = 0;
                Clickcards = null;
                Clickcards2 = null;


            }
        }
        private void MoveCard()
        {
            Destroy(Clickcards);
            Destroy(Clickcards2);
            /* Clickcards.transform.position = new Vector2(100,100);
             Clickcards2.transform.position = new Vector2(100, 100);*/
           
        }

        
    }

}

