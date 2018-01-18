using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{
    public class GameController : MonoBehaviour
    {
        static int[] cards = new int[52];
        int[] PlayerCards = new int[11];
        static int y = 4;
        string[] CardsName = 
            {
            "c01","c02","c03","c04","c05","c06","c07","c08","c09","c10","c11","c12","c13",
            "h01","h02","h03","h04","h05","h06","h07","h08","h09","h10","h11","h12","h13",
            "d01","d02","d03","d04","d05","d06","d07","d08","d09","d10","d11","d12","d13",
            "s01","s02","s03","s04","s05","s06","s07","s08","s09","s10","s11","s12","s13",
            };
       
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
                    if(cards[i + j] % 13 >10 || cards[i + j] % 13 == 0)
                    {
                        PlayerCards[i + j] = 10;
                    }
                    else
                    {
                        PlayerCards[i + j] = cards[i + j] % 13;
                    }
                    Debug.Log("Num_is" + PlayerCards[i + j]);
                }
            } 
        }
        public void Update()
        {
            
        }
        // 山札をシャッフルで作る
        public void MakeDeck()
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
        public void Dealcards()
        {
            for(int i = 0; i < 4; i++)
            {
               //Debug.Log(cards[i]);
            } 
        }
        // カードを表示する
        public void LoadCards(int x, int y,int z)
        {
            var Card = Resources.Load<GameObject>("Prefabs/Bar06/Cards/" + CardsName[x-1]);
            Card = Instantiate(Card, new Vector2(y - 0.5f, z * 2 - 1f), Quaternion.identity);   // x % 13
            var card = GameObject.Find("Cards");
            Card.transform.parent = card.transform;
        }
        //カードの合計を出す
        public void Cardsum()
        {
            for (var abc = 0; abc < PlayerCards.Length; abc++)
            {
                Debug.Log("合計は" + abc);
            }
        }
        //役の判定
        public void Role()
        {

        }
        // クリックしたら勝負する
        public void ClickBattleButton()
        {

        }
        // クリックしたらカードを追加する(プレイヤー側)
        public void ClickAddCardButton()
        {
            int x = cards[y]; 
            var Card = Resources.Load<GameObject>("Prefabs/Bar06/Cards/" + CardsName[x - 1]);
            Card = Instantiate(Card, new Vector2( (-y + 3) - 0.5f,-1f), Quaternion.identity);
            var card = GameObject.Find("Cards");
            Card.transform.parent = card.transform;
            y++;
           /* if (x == 1 || x == 14 || x == 27 || x == 40) { x = 1; }else if (x == 15 || x == 28 || x == 41) { x = 2; }else if (x == 16 || x == 29 || x == 42) { x = 3; }else if (x == 17 || x == 30 || x == 43) { x = 4; }else if (x == 18 || x == 31 || x == 44) { x = 5; }else if (x == 19 || x == 32 || x == 45) { x = 6; }else if (x == 20 || x == 33 || x == 46) { x = 7; }else if (x == 21 || x == 34 || x == 47) { x = 8; }else if (x == 22 || x == 35 || x == 48) { x = 9; }else if (x == 23 || x == 36 || x == 49) { x = 10; }else if (x == 11 || x == 24 || x == 37 || x == 50) { x = 10; }else if (x == 12 || x == 25 || x == 38 || x == 51) { x = 10; }else if (x == 13 || x == 26 || x == 39 || x == 52) { x = 10; }
            Debug.Log(x);*/
        }
        // カードを追加する(ディーラー側)
        // クリックしたら勝負をあきらめる
        public void ClickSurrenderButton()
        {

        }
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
