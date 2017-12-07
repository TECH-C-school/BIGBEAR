using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * 次回作業 --> 役判定の作成(続き)
 */

/*
 * 今回作業 --> Player1CardListのカード一覧をわかりやすく把握出来るようにする
 *              Player1CardList内のカードのマーク内訳を取り出す関数作成
 *              ついでに相手の方も実装しといた
 *              役判定の作成(フラッシュ)
 *              NumberManager(それぞれの数字の枚数を表示する)の作成
 */

namespace Assets.Scripts.Bar05 {
    public class GameController : MonoBehaviour {

        private void Start()
        {
            MakeCards();
            MakeLists();
            CHL();
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("mouseLeftKeyDown");
            }
        }

        //カード周りここから
        

        /// <summary>
        /// 自分と相手のカードを配置する
        /// forのiはプレイヤー人数によって変更(i = プレイヤー人数 + 1)
        /// いつか変数で管理したい
        /// </summary>
        public void MakeCards()
        {
            //みやすいよね？ね？
            Debug.Log("--------------------");
            //山札を作る
            int deckPlace = 0;
            int[] Deck = Cardsshuffle();

            //デバッグ用
            //**/for(int i = 0; i < Deck.Length; i++){Debug.Log(Deck[i]);}

            //PrefabをLoadする
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar05/Card");
            for (int i = 0; i < 3; i++)
            {
                //自分のカード生成
                if (i == 0)
                {
                    var cardsObject1 = GameObject.Find("Player1_Cards");
                    for (int x = 0; x < 2; x++)
                    {
                        //カードを表示
                        var cardObject = Instantiate(cardPrefab);
                        //カードの位置を指定
                        cardObject.transform.position = new Vector3((x * 2 - 1), -3.4f, 0);
                        //親を指定
                        cardObject.transform.parent = cardsObject1.transform;
                        //カードのナンバー指定
                        var card = cardObject.GetComponent<Card>();
                        card.Number = Deck[deckPlace];
                        //カードの名前を変更する
                        int ObjCount = cardsObject1.transform.childCount;
                        cardObject.name = "player1Card" + ObjCount;
                        //カード出すよ
                        card.CardMake();
                        //山札1枚減るよ
                        deckPlace++;
                        Debug.Log("<color=green>自分のカード生成</color>" + (x + 1) + "枚目");
                    }
                    //プレイヤーもしくは場札のカードリストを作る
                    string[] cardList_p1 = new string[cardsObject1.transform.childCount];
                    for(int x = 1; x < cardsObject1.transform.childCount + 1; x++)
                    {
                        //なんか("player1Card" + x + 1 + "")にするとぬるぽしちゃったから
                        //こうなってる すまんな俺
                        var cardObject = GameObject.Find("player1Card" + x + "");
                        var card = cardObject.GetComponent<Card>();
                        var cardNumber = card.Number;
                        string cardNum = cardNumber.ToString();
                        //めんどくさいというか分かりづらいね
                        cardList_p1[x - 1] = cardNum;
                    }
                    //役を判定する関数にカードリストを渡す
                    PlayerCards(Player1Cards, cardList_p1);

                    //デバッグ
                    //毎回アルファベッド+数字に戻したほうがわかりやすいかね
                    //**/for (int x = 0; x < cardList_p1.Length; x++){Debug.Log(cardList_p1[x]);}

                    Debug.Log("<color=blue>自分のカード生成完了</color>");
                    Debug.Log("--------------------");
                }
                //相手のカード生成
                else if(i == 1)
                {
                    var cardsObject2 = GameObject.Find("Player2_Cards");
                    for (int x = 0; x < 2; x++)
                    {
                        var cardObject = Instantiate(cardPrefab);
                        cardObject.transform.position = new Vector3((x * 2 - 1), 3.4f, 0);
                        cardObject.transform.parent = cardsObject2.transform;
                        var card = cardObject.GetComponent<Card>();
                        card.Number = Deck[deckPlace];
                        int ObjCount = cardsObject2.transform.childCount;
                        cardObject.name = "player2Card" + ObjCount;
                        card.CardMake();
                        deckPlace++;
                        Debug.Log("<color=green>相手のカード生成</color>" + (x + 1) + "枚目");
                    }

                    string[] cardList_P2 = new string[cardsObject2.transform.childCount];
                    for (int x = 1; x < cardsObject2.transform.childCount + 1; x++)
                    {
                        var cardObject = GameObject.Find("player2Card" + x + "");
                        var card = cardObject.GetComponent<Card>();
                        var cardNumber = card.Number;
                        string cardNum = cardNumber.ToString();
                        cardList_P2[x - 1] = cardNum;
                    }
                    PlayerCards(Player2Cards, cardList_P2);

                    Debug.Log("<color=red>相手のカード生成完了</color>");
                    Debug.Log("--------------------");
                }
                //場札を生成
                else
                {
                    var cardsObject3 = GameObject.Find("CardStacks");
                    for(int x = 0; x < 5; x++)
                    {
                        var cardObject = Instantiate(cardPrefab);
                        cardObject.transform.position = new Vector3((x * 2 - 4), 0, 0);
                        cardObject.transform.parent = cardsObject3.transform;
                        var card = cardObject.GetComponent<Card>();
                        card.Number = Deck[deckPlace];
                        int ObjCount = cardsObject3.transform.childCount;
                        cardObject.name = "StackCard" + ObjCount;
                        card.CardMake();
                        deckPlace++;
                        Debug.Log("<color=green>場札のカード生成</color>" + (x + 1) + "枚目");
                    }

                    string[] cardList_St = new string[cardsObject3.transform.childCount];
                    for (int x = 1; x < cardsObject3.transform.childCount + 1; x++)
                    {
                        var cardObject = GameObject.Find("StackCard" + x + "");
                        var card = cardObject.GetComponent<Card>();
                        var cardNumber = card.Number;
                        string cardNum = cardNumber.ToString();
                        cardList_St[x - 1] = cardNum;
                    }
                    PlayerCards(StackCards, cardList_St);

                    Debug.Log("<color=yellow>場札のカード生成完了</color>");
                    Debug.Log("--------------------");
                }
            }
        }
        
        // カードをシャッフルする
        private int[] Cardsshuffle()
        {
            int[] decks = new int[52];
            for(int i = 0; i < 52; i++)
            {
                decks[i] = i;
            }

            int counter = 0;
            while(counter < 52)
            {
                int index = UnityEngine.Random.Range(counter, decks.Length);
                int tmp = decks[counter];
                decks[counter] = decks[index];
                decks[index] = tmp;
                counter++;
            }
            return decks;
        }

        //カード周りここまで

        //役の判定ここから

        //関数群ここから

        //リストを作る関数群
        public void MakeLists()
        {
            Debug.Log("<color=blue>自分と場札のカード内訳</color>");
            CardLists(Player1Cards, Player1CardList, Player1Marks);
            Debug.Log("--------------------");
            Debug.Log("<color=red>相手と場札のカード内訳</color>");
            CardLists(Player2Cards, Player2CardList, Player2Marks);
            Debug.Log("--------------------");
        }

        //役の判定関数群
        public void CHL()
        {
            CheckHandLevel(Player1HandLevel, Player1CardList, Player1NumberManager, Player1Marks);
            Debug.Log("--------------------");
            CheckHandLevel(Player2HandLevel, Player2CardList, Player2NumberManager, Player2Marks);
            Debug.Log("--------------------");
        }


        //関数群ここまで

        //各プレイヤー・場札のカードをリスト化

        //変数置き場
        int[] Player1Cards = new int[2];
        int[] Player2Cards = new int[2];
        int[] StackCards = new int[5];

        private void PlayerCards(int[] Affiliation, string[] List)
        {
            for(int i = 0; i < Affiliation.Length; i++)
            {
                var ListX = List[i];
                Affiliation[i] = int.Parse(ListX);
            }
            //デバッグ用
            //**/for(int i=0;i<Affiliation.Length;i++){Debug.Log(Affiliation[i]);}
        }

        //プレイヤーの役を作るための準備

        //変数置き場
        int[] Player1CardList = new int[7];
        int[] Player2CardList = new int[7];
        int[] Player1Marks = new int[4];
        int[] Player2Marks = new int[4];

        //役の候補になるカードのリスト
        private void CardLists(int[]Player, int[] List, int[] MList)
        {
            for(int i = 0; i < List.Length; i++)
            {
                if(i < Player.Length)
                {
                    List[i] = Player[i];
                }
                else
                {
                    List[i] = StackCards[i - 2];
                }
            }

            //ここまでだと数字しか出なくて分かりづらいので、絵柄:数字 みたいにする

            for (int i = 0; i < List.Length; i++)
            {
                int ListX = List[i];
                int CardNum = (ListX + 1) % 13;
                if(CardNum == 0)
                {
                    CardNum = 13;
                }
                List[i] = CardNum;
                //ここでマークと数字を分解してそれぞれで管理しても問題ないと思った
                int CardMark = (ListX - CardNum + 1) / 13 + 1;
                switch (CardMark)
                {
                    case 1:
                        //**/Debug.Log("クローバー");
                        MList[0] = MList[0] + 1;
                        break;
                    case 2:
                        //**/Debug.Log("ダイヤ");
                        MList[1] = MList[1] + 1;
                        break;
                    case 3:
                        //**/Debug.Log("ハート");
                        MList[2] = MList[2] + 1;
                        break;
                    case 4:
                        //**/Debug.Log("スペード");
                        MList[3] = MList[3] + 1;
                        break;
                }
            }

            //デバッグ用
            // /*
            string db = "";
            for (int i = 0; i < List.Length; i++)
            {
                switch(List[i])
                {
                    case 1:
                        db = db + "A" + ":";
                        break;
                    case 11:
                        db = db + "J" + ":";
                        break;
                    case 12:
                        db = db + "Q" + ":";
                        break;
                    case 13:
                        db = db + "K" + ":";
                        break;
                    default:
                        db = db + List[i] + ":";
                        break;
                }
            }
            Debug.Log(db);

            string db2 = "";
            for (int i = 0; i < MList.Length; i++)
            {
                db2 = db2 + MList[i] + ":";
            }
            Debug.Log(db2);
            Debug.Log("クローバー:ダイヤ:ハート:スペード");

            // */
        }

        //役判定するゾ～

        /* 役一覧(handLevel)
         * ハイカード(0)
         * ワンペア(1)
         * ツーペア(2)
         * スリーカード(3)
         * ストレート(4)
         * フラッシュ(5)
         * フルハウス(6)
         * フォーカード(7)
         * ストレートフラッシュ(8)
         * ロイヤルストレートフラッシュ(9)
         */

        //変数置き場
        int Player1HandLevel = 0;
        int Player2HandLevel = 0;
        int[] Player1NumberManager = new int[13];
        int[] Player2NumberManager = new int[13];

        public void CheckHandLevel(int PlayerHandLevel, int[]CardList, int[]NumberManager, int[]Marks)
        {
            //CardListを1～13の配列に入れてわかりやすくする
            for (int i = 0; i < CardList.Length; i++)
            {
                NumberManager[CardList[i] - 1] = NumberManager[CardList[i] - 1] + 1;
            }

            //デバッグ用
            string db = "";
            for(int i = 0; i < NumberManager.Length; i++)
            {
                db = db + NumberManager[i] + ":";
            }
            Debug.Log(db);

            //それぞれのマークの枚数が5枚以上ならフラッシュ(5)
            int x = 0;
            while (x < Marks.Length)
            {
                if(Marks[x] >= 5)
                {
                    PlayerHandLevel = 5;
                    Debug.Log("フラッシュ");
                    break;
                }
                x++;
            }
            //その後はストレートフラッシュ以上を軽く見るだけ
            if(PlayerHandLevel == 5)
            {
                //処理
            }
            
        }



        //役の判定ここまで

        //ゲーム進行ここから

        private enum GamePhase
        {
            FirstBet = 0,
            SecondBet,
            ThirdBet,
            FinalBet,
            Result,
        }
        
        //ゲーム進行ここまで

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}

/*
 * 判定アルゴリズム雑記(のはずだった)
 * 
 * ルールはご存知の通り手札+場札の7枚の内最適な5枚の役で勝負する
 * ではどうやってその役を見分けるか
 * 
 * 役一覧(昇順)
 * ハイカード(ノーペア)
 * ワンペア
 * ツーペア
 * スリーカード
 * ストレート
 * フラッシュ
 * フルハウス
 * フォーカード
 * ストレートフラッシュ
 * ロイヤルストレートフラッシュ
 * 
 * 同じ数字が揃わない役はハイカード・ストレート・フラッシュ、ストレートフラッシュ、ロイヤルストレートフラッシュ
 * 裏を返せば他の役は同じ数字が揃うので、最初はペアの有無を見て判定を進める
 * 
 * ペアある組
 * ワンペア
 * ツーペア
 * スリーカード
 * フルハウス
 * フォーカード
 * 
 * まずはフォーカードの判定 (Y = フォーカード)
 * 次にスリーカードがあるかを判定し、ある場合更にペアが無いかを探す(Y = フルハウス;N =スリーカード)
 * スリーカードが無かった場合、最初のペア以外にペアがあるかを探す(Y = ツーペア;N =ワンペア)
 * 
 * ペアない組
 * ハイカード
 * ストレート
 * フラッシュ
 * ストレートフラッシュ
 * ロイヤルストレートフラッシュ
 * 
 * ペアがあった場合でも判定は通す
 * まずはロイヤルストレートフラッシュのみあるか判定(Y = ロイヤルストレートフラッシュ)
 * 次にフラッシュの判定
 * あったらそれがストレートがどうかを判定(Y = ストレートフラッシュ;N = フラッシュ)
 * もう一回ストレートの判定(Y = ストレート; N = ハイカード)
 * 両方無かったらハイカード確定
 * 多分な
 */
