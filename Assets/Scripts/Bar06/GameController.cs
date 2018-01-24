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
        static int counter = 1;
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
            CardNum();
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
        //Cardsオブジェクトに入るcard(clone)をDebug.Log()で表示させる
        public void CardNum()
        {
            GameObject obj = GameObject.Find("Cards");
            GameObject[] objs = new GameObject[obj.transform.childCount];
            for(int i = 0; i < objs.Length; ++i)
            {
                objs[i] = obj.transform.GetChild(i).gameObject;
                Debug.Log(objs[i].name);
            }
            //Debug.Log(obj.name);
        }

       
        //カードの合計を出す
        public void Cardsum()
        {
             
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
            if (counter < 5)
            {
                int x = cards[y];
                var Card = Resources.Load<GameObject>("Prefabs/Bar06/Cards/" + CardsName[x - 1]);
                Card = Instantiate(Card, new Vector2((-y + 3) - 0.5f, -1f), Quaternion.identity);
                var card = GameObject.Find("Cards");
                Card.transform.parent = card.transform;
                y++;
                counter++;
                Debug.Log(x);
            }
        }
        // クリックしたら勝負をあきらめる
        public void ClickSurrenderButton()
        {
            Initgame();
        }
        public void Initgame()
        {
            RemoveGames();
            MakeDeck();
        }
        public void RemoveGames()
        {

        }
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
