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
        private int remaindertrump_index = 0;
        private int _nextCardNumber = 1;
        private GameObject Clickcards = null;



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
               // Debug.Log("生成" + trump[i].mark + trump[i].number);
            }

            //残りの31枚のカードを山札にする

            remaindertrump = new Card[31];
            for (int i = 0; i < 31; i++)
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
            var cardsObject = GameObject.Find("Cards");
            //Card[] trump = new Card[53];
            //for (int i = 22; i < 53; i++)
            //{

            //    trump[i].number = (cards[i] - 1) % 13 + 1;
            //    trump[i].mark = (Mark)((cards[i] - 1) / 13);
            //}

            for (int i = 0; i < 1; i++)
            {

                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.parent = GameObject.Find("Cards").transform;
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
            if (Clickcards == null)
            {
                Clickcards = hitObject.collider.gameObject;
                return;
            }
            var card1 = Clickcards.GetComponent<SpriteRenderer>();
            //数字だけ読み込む
            card1.sprite
            int number1 = card1.number;

            int[] number1cards = new int[1];

            var card2 = hitObject.collider.gameObject.GetComponent<SpriteRenderer>();
            int number2 = card2.number;

            if (number1 + number2 == 13)
            {
                Debug.Log("13");
            }

            else
            {
                Debug.Log("13ではない");
            }
            //クリックされたカードスクリプトを取得
            var card = hitObject.collider.gameObject.GetComponent<SpriteRenderer>();

            //次にクリックされるべきカードが判定
            if (_nextCardNumber != card.number) return;






        }

    }

}

