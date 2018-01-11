using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{
    public class GameController : MonoBehaviour
    {

        int[] cards = new int[52];
        void Start()
        {
            MakeDeck();
            Dealcards();
            int x = 0;
            for (var i = 0; i < 2; i++)
            { 
                for (var j = 0; j < 2; j++)
                {
                    if(i == 1)
                    {
                        i++;
                        x = 1;
                    }
                    LoadCards(cards[i + j], i - x, j);
                }
            } 
        }
        private void Update()
        {
            BattleButton();
            AddCardButton();
            SurrenderButton();
            BetplusButton();
            BetmainusButton();
        }

        // 山札をシャッフルで作る
        private void MakeDeck()
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = i + 1;
            }
            System.Random rng = new System.Random();
            int n = cards.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int tmp = cards[k];
                cards[k] = cards[n];
                cards[n] = tmp;
                
            }
        }
        // カードを２枚ずつ配る
        private void Dealcards()
        {
            for(int i = 0; i < 4; i++)
            {
                Debug.Log(cards[i]);
            } 
        }
        // カードを表示する
        private void LoadCards(int x, int y,int z)
        {
            if (x == 1)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s01");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 2)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s02");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 3)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s03");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 4)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s04");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 5)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s05");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 6)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s06");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 7)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s07");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 8)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s08");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 9)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s09");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 10)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s10");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 11)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s11");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 12)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s12");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 13)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Spade/s13");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 14)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d01");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 15)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d02");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 16)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d03");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 17)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d04");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 18)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d05");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 19)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d06");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 20)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d07");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 21)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d08");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 22)   
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d09");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
                }
            if (x == 23)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d10");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 24)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d11");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 25)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d12");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                 var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 26)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Diamond/d13");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 27)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c01");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 28)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c02");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 29)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c03");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 30)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c04");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 31)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c05");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 32)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c06");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 33)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c07");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 34)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c08");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 35)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c09");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 36)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c10");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 37)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c11");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 38)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c12");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 39)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Clover/c13");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 40)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h01");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 41)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h02");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 42)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h03");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 43)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h04");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 44)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h05");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 45)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h06");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 46)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h07");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 47)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h08");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 48)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h09");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 49)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h10");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 50)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h11");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 51)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h12");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
            if (x == 52)
            {
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Heart/h13");
                Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
            }
        }
        // ディーラー側のカードに裏向きのカードをかぶせる
        private void LoadCard()
        {
         
        }
        // クリックしたら勝負する
        private void BattleButton()
        {

        }
        // クリックしたらカードを追加する
        private void AddCardButton()
        {

        }
        // クリックしたら勝負をあきらめる
        private void SurrenderButton()
        {

        }
        // クリックしたら掛け金を増やす
        private void BetplusButton()
        {

        }
        // クリックしたら掛け金を減らす
        private void BetmainusButton()
        {

        }
        //メニューを呼び出す
        private void MenuButton()
        {
          
        } 
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
