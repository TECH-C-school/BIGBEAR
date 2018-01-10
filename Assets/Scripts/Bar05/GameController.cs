using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * 今回作業 --> 
 */

/*
 * 次回作業 --> 同役の時の処理
 */

/*
 * 今後実装 --> PhaseViewの修正(Prefabにしなきゃいけない?)
 *              チップを掛ける
 *              レイアウト等
 */

namespace Assets.Scripts.Bar05 {
    public class GameController : MonoBehaviour {

        private void Start()
        {
            InitGame();
            //Debug.Log(_Phase);
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("z") || Input.GetKeyDown("x") || Input.GetKeyDown("c") || Input.GetKeyDown("v") || Input.GetKeyDown("space")  )
            {
                //Debug.Log("<color=red>--------------------</color>");
                PhaseChange();
            }
        }

        //カード周りここから
        

        /// <summary>
        /// 自分と相手のカードを配置する
        /// forのiはプレイヤー人数によって変更(i = プレイヤー人数 + 1)
        /// いつか変数で管理したい
        /// </summary>
        private void MakeCards()
        {
            //MakeCards内のDebug.LogをOFFにしています
            /**/Debug.logger.logEnabled = false;

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
                        //Debug.Log("<color=green>自分のカード生成</color>" + (x + 1) + "枚目");
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
                    /**/PlayerCards(Player1Cards, cardList_p1);

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
                        //Debug.Log("<color=green>相手のカード生成</color>" + (x + 1) + "枚目");
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
                    /**/PlayerCards(Player2Cards, cardList_P2);

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
                        //Debug.Log("<color=green>場札のカード生成</color>" + (x + 1) + "枚目");
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
                    /**/PlayerCards(StackCards, cardList_St);

                    Debug.Log("<color=yellow>場札のカード生成完了</color>");
                    Debug.Log("--------------------");
                }
            }
            Debug.logger.logEnabled = true;
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

        //初期化する時にカードを削除する
        private void RemoveCards()
        {
            var ParentObject = GameObject.Find("Player1_Cards");
            for (int i = 0; i < 3; i++)
            {
                switch(i)
                {
                    case 0:
                        ParentObject = GameObject.Find("Player1_Cards");
                        //Debug.Log(ParentObject.transform.childCount);
                        break;
                    case 1:
                        ParentObject = GameObject.Find("Player2_Cards");
                        break;
                    case 2:
                        ParentObject = GameObject.Find("CardStacks");
                        break;
                    default:
                        Debug.Log("迷子");
                        break;
                }
                foreach (Transform cardobject in ParentObject.transform)
                {
                    Destroy(cardobject.gameObject);
                }
            }
        }

        //カード周りここまで

        //役の判定ここから

        //関数群ここから

        //リストを作る関数群
        private void MakeLists()
        {
            //イカサマ
            //**/IKASAMA();
            //Debug.Log("<color=blue>自分と場札のカード内訳</color>");
            CardLists(Player1Cards, Player1CardList, Player1Marks);
            //Debug.Log("--------------------");
            //Debug.Log("<color=red>相手と場札のカード内訳</color>");
            CardLists(Player2Cards, Player2CardList, Player2Marks);
            //Debug.Log("--------------------");
        }

        //役を判定する関数群
        private void CheckhandLevels()
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

        //変数置き場/初期化処理
        int[] Player1CardList = new int[7];
        int[] Player2CardList = new int[7];
        int[] Player1Marks = new int[4];
        int[] Player2Marks = new int[4];
     
        //イカサマをしよう
        private void IKASAMA()
        {
            Player1Cards = new int[] { 0, 1 };
            Player2Cards = new int[] { 43, 9 };
            //**/StackCards = new int[] { 2, 3, 4, 5, 6 };
            /**/StackCards = new int[] { 4, 9, 10, 11, 12 };
        }

        //役の候補になるカードのリスト
        private void CardLists(int[]Player, int[] List, int[] MList)
        {
            for (int i = 0; i < List.Length; i++)
            {
                //プレイヤーの手札
                if(i < Player.Length)
                {
                    List[i] = Player[i];
                }
                //場札
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
            //**/Debug.Log(db);

            string db2 = "";
            int db3 = 0;
            for (int i = 0; i < MList.Length; i++)
            {
                db2 = db2 + MList[i] + ":";
                db3 = db3 + MList[i];
            }
            /**/Debug.Log(db2);
            /**/Debug.Log("クローバー:ダイヤ:ハート:スペード");
            //**/Debug.Log("マーク合計:" + db3);

            // */
        }

        //やっぱり数字だけの塊作るわ
        string str = null;
        int[] Player1NumHands = new int[7];
        int[] Player2NumHands = new int[7];
        private void CheckSubCards()
        {            
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    str = null;                    
                    for (int x = 0; x < 7; x++)
                    {
                        if (x <= 1)
                        {
                            Player1NumHands[x] = Player1Cards[x];
                            str = str + Player1Cards[x] + ":";
                        }
                        else
                        {
                            Player1NumHands[x] = StackCards[x - 2];
                            str = str + StackCards[x - 2] + ":";
                        }
                    }
                    Debug.Log(str);
                }
                else if (i == 1)
                {
                    str = null;
                    for (int x = 0; x < 7; x++)
                    {
                        if (x <= 1)
                        {
                            Player2NumHands[x] = Player2Cards[x];
                            str = str + Player2Cards[x] + ":";
                        }
                        else
                        {
                            Player2NumHands[x] = StackCards[x - 2];
                            str = str + StackCards[x - 2] + ":";
                        }
                    }
                    Debug.Log(str);
                }
            }
        }

        //ロイヤルストレートフラッシュとストレートフラッシュ用にリストを作る関数
        //処理軽減のために判定をする時のみ実行
        int tmp = 0;
        int[] IList = new int[7];
        int Seets = 0;
        int[] IListNumManager = new int[13];

        //ストレートフラッシュとロイヤルストレートフラッシュを判定する関数
        private bool RSForSFDecision(int MarkNum, int[] PlayerCards, bool RSFFlag)
        {
            bool RSForSFFlag = false;
            tmp = 0;
            IList = new int[7];
            Seets = 0;
            IListNumManager = new int[13];
            for (int i = 0; i < 7; i++)
            {
                //手札と場札を取得
                //プレイヤーの手札
                if (i < PlayerCards.Length)
                {
                    tmp = PlayerCards[i] + 1;
                    //Debug.Log(tmp);
                }
                //場札
                else
                {
                    tmp = StackCards[i - 2] + 1;
                }
                //MarkNumに合っている数字だけ出す
                if(tmp > MarkNum * 13 & tmp <= (MarkNum + 1) * 13)
                {
                    IList[Seets] = tmp - MarkNum * 13;
                    //Debug.Log(IList[Seets]);
                    Seets++;
                }
            }
            //IListNumManagerに入れる
            for (int x = 0; x < IList.Length; x++)
            {
                if (IList[x] != 0)
                {
                    IListNumManager[IList[x] - 1] = IListNumManager[IList[x] - 1] + 1;
                }
            }
            //ここからデバッグ用
            //*/
            string db = "";
            for (int x = 0; x < IListNumManager.Length; x++)
            {
                db = db + IListNumManager[x] + ":";
            }
            //Debug.Log(db);
            //デバッグ用ここまで
            //*/

            //ロイヤルストレートフラッシュ用
            if(RSFFlag)
            {                
                int a = 0;
                int Straight = 0;
                while (a < 8)
                {                 
                    if(Straight == 5)
                    {
                        RSForSFFlag = true;
                        break;
                    }
                    if(Straight == 0)
                    {
                        if(IListNumManager[0] >= 1)
                        {
                            Straight++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (IListNumManager[a + 8] >= 1)
                        {
                            Straight++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    a++;
                }
            }
            //ストレートフラッシュ用
            else
            {
                int a = 0;
                int Straight = 0;
                while (a < IListNumManager.Length)
                {
                    if (IListNumManager[a] >= 1)
                    {
                        Straight = Straight + 1;
                    }
                    else
                    {
                        Straight = 0;
                    }
                    if (Straight == 5)
                    {
                        RSForSFFlag = true;
                        break;
                    }
                    a++;
                }
            }
            return RSForSFFlag;
        }


        //役判定するゾ～

        /* 役一覧(handLevel)                   実装状況(0:未実装 1:半実装 2:詳細なHandRankまで)
         * ハイカード(0)                       1
         * ワンペア(1)                         1
         * ツーペア(2)                         1
         * スリーカード(3)                     1
         * ストレート(4)                       1
         * フラッシュ(5)                       1
         * フルハウス(6)                       1
         * フォーカード(7)                     1
         * ストレートフラッシュ(8)             1
         * ロイヤルストレートフラッシュ(9)     1
         */

        //変数置き場

        int Player1HandLevel = 0;
        int Player2HandLevel = 0;
        //int DebugHandLevel = 0;
        int[] Player1NumberManager = new int[13];
        int[] Player2NumberManager = new int[13];
        //int[] DebugNumberManager = new int[13];
        int Playercount = 0;
        int[] Player1SubHandLevels = new int[6];
        int[] Player2SubHandLevels = new int[6];

        public void CheckHandLevel(int PlayerHandLevel, int[]CardList, int[]NumberManager, int[]Marks)
        {            
            NumberManager = new int[13];
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

            //ストレートフラッシュ以上の判定用フラグ(のつもり)
            int SFFlag = 0;
            bool RSFFlag = true;
            int MarkNum = 0;
            string Markstr = "";
            //マークを見る
            //それぞれのマークの枚数が5枚以上ならフラッシュ(5)
            int x = 0;
            while (x < Marks.Length)
            {
                if (Marks[x] >= 5)
                {
                    //Debug.Logでマークを出す
                    MarkNum = x;
                    switch(MarkNum)
                    {
                        case 0:
                            Markstr = "クローバー";
                            break;
                        case 1:
                            Markstr = "ダイヤ";
                            break;
                        case 2:
                            Markstr = "ハート";
                            break;
                        case 3:
                            Markstr = "スペード";
                            break;
                    }
                    PlayerHandLevel = 5;
                    Debug.Log("フラッシュ:<color=red>" + Markstr + "</color>");
                    SFFlag = SFFlag + 1;
                    SubHandLevelCheck(0, Playercount, MarkNum);
                    break;
                }
                x++;
            }
            //数字を見る
            //ストレートの判定
            x = 0;
            int Straight = 0;
            int StrNum = 0;
            while (x < NumberManager.Length)
            {
                if(NumberManager[x] >= 1)
                {
                    Straight = Straight + 1;
                }
                else
                {
                    Straight = 0;
                }
                if(Straight == 5)
                {
                    if(PlayerHandLevel < 4)
                    {
                        PlayerHandLevel = 4;
                    }
                    StrNum = x - 3;
                    Debug.Log("ストレート:<color=red>" + StrNum + "</color>");
                    SFFlag = SFFlag + 1;
                    break;
                }
                x++;
            }
            //特殊ストレート判定 ロイヤルストレートフラッシュ用
            if(NumberManager[0] >= 1)
            {
                x = 0;
                int RSFcount = 1;
                while(x < 4)
                {
                    int Place = 9 + x;
                    if(NumberManager[Place] == 0)
                    {
                        RSFFlag = false;
                        break;
                    }
                    x++;
                    RSFcount++;
                }
                if(RSFFlag)
                {
                    //A.10.J.Q.Kでマーク違いってストレートになる?
                    //答え:なります             
                    PlayerHandLevel = 5;
                    Debug.Log("特殊ストレート!!");
                }
                else
                {
                    //Debug.Log("<color=red>" + RSFcount + "</color>");
                }
            }
            //ストレートフラッシュの判定
            if (SFFlag == 2)
            {
                if(Playercount == 0)
                {
                    if(RSForSFDecision(MarkNum, Player1Cards, false))
                    {
                        PlayerHandLevel = 8;
                        Debug.Log("ストレートフラッシュ:<color=red>" + StrNum + "</color>");
                    }
                }
                else if(Playercount == 1)
                {
                    if(RSForSFDecision(MarkNum, Player2Cards, false))
                    {
                        PlayerHandLevel = 8;
                        Debug.Log("ストレートフラッシュ:<color=red>" + StrNum + "</color>");
                    }
                }
            }
            //ロイヤルストレートフラッシュの判定
            if(RSFFlag)
            {
                if (Playercount == 0)
                {
                    if (RSForSFDecision(MarkNum, Player1Cards, true))
                    {
                        PlayerHandLevel = 9;
                        Debug.Log("ロイヤルストレートフラッシュ:<color=red></color>");
                    }
                }
                else if (Playercount == 1)
                {
                    if (RSForSFDecision(MarkNum, Player2Cards, true))
                    {
                        PlayerHandLevel = 9;
                        Debug.Log("ロイヤルストレートフラッシュ:<color=red></color>");
                    }
                }
            }
            //ペア・スリーカード・フォーカードが何個あるか数える
            int PHand2 = 0;
            int PHand3 = 0;
            x = 0;
            while(x < NumberManager.Length)
            {
                //フラッシュ以上が確定している場合、それ以上の役はないのでBreak
                if(x == 0 & PlayerHandLevel != 0)
                {
                    break;
                }
                //フォーカードを検出したらそれ以上の役はないのでBreak
                if(NumberManager[x] == 4)
                {
                    PlayerHandLevel = 7;
                    Debug.Log("フォーカード");
                    break;
                }
                //スリーカードを検出
                //スリーカードが2組ある場合、フルハウスになる
                if(NumberManager[x] == 3)
                {
                    PHand3 = PHand3 + 1;
                }
                //ペアを見る
                else if(NumberManager[x] == 2)
                {
                    PHand2 = PHand2 + 1;
                }
                x++;
            }
            //その他役判定
            if(PlayerHandLevel == 0)
            {
                //フルハウス
                if(PHand3 == 2)
                {
                    PlayerHandLevel = 6;
                    Debug.Log("フルハウス");
                }
                //これもフルハウス
                else if(PHand3 == 1 & PHand2 >= 1)
                {
                    PlayerHandLevel = 6;
                    Debug.Log("フルハウス");
                }
                //スリーカード
                else if(PHand3 == 1)
                {
                    PlayerHandLevel = 3;
                    Debug.Log("スリーカード");
                }
                //ツーペア
                else if(PHand2 >= 2)
                {
                    PlayerHandLevel = 2;
                    Debug.Log("ツーペア");
                }
                //ワンペア
                else if(PHand2 == 1)
                {
                    PlayerHandLevel = 1;
                    Debug.Log("ワンペア");
                }
                //ノーペア
                else
                {
                    Debug.Log("ノーペア");
                }
            }

            if(Playercount == 0)
            {
                Player1HandLevel = PlayerHandLevel;
            }
            else
            {
                Player2HandLevel = PlayerHandLevel;
            }

            Playercount++;
            //デバッグ用
            Debug.Log("ペア" + PHand2 + ":スリーカード" + PHand3 + ":HandLevel" + PlayerHandLevel);

        }

        //どっちのプレイヤーが勝ちかを調べる

        int WhoWin;

        private void WhoPlayerWin()
        {
            Debug.Log(Player1HandLevel);
            Debug.Log(Player2HandLevel);
            if (Player1HandLevel > Player2HandLevel)
            {
                WhoWin = 1;
                Debug.Log("<color=green>Player1Winner</color>");
            }
            else if(Player1HandLevel < Player2HandLevel)
            {
                WhoWin = 2;
                Debug.Log("<color=green>Player2Winner</color>");
            }
            else if(Player1HandLevel == Player2HandLevel)
            {
                Debug.Log("引き分け？？？");
            }
        }

        public void SubHandLevelCheck(int ModeNum, int TargetPlayer, int SubSet)
        {
            //フラッシュ
            if(ModeNum == 0)
            {
                int ArrayNum = 0;
                int tgt = SubSet * 13;
                if(TargetPlayer == 0)
                {
                    Player1SubHandLevels[ArrayNum] = SubSet;
                    ArrayNum++;
                    for(int i = 14; i > 1; i--)
                    {
                        //ここでの14はAと同等
                        if(i == 14)
                        {
                            //Aを探す
                            for(int x = 0; x < 7; x++)
                            {
                                if(Player1NumHands[x] == tgt)
                                {
                                    Debug.Log("Aを見つけた");
                                    Player1SubHandLevels[ArrayNum] = i;
                                    ArrayNum++;
                                    break;
                                }
                            }
                            tgt = tgt + 13;
                        }
                        //その他を探す
                        else
                        {
                            tgt--;
                            for (int x = 0; x < 7; x++)
                            {
                                if (Player1NumHands[x] == tgt)
                                {
                                    Player1SubHandLevels[ArrayNum] = i;
                                    Debug.Log(Player1SubHandLevels[ArrayNum]);
                                    ArrayNum++;
                                    break;
                                }
                            }
                            if(ArrayNum == 6)
                            {
                                break;
                            }
                        }
                    }
                    //デバッグ用
                    string str = null;
                    for (int i = 0; i < Player1SubHandLevels.Length; i++)
                    {
                        str = str + Player1SubHandLevels[i] + ":";
                    }
                    Debug.Log(str);
                }
            }
        }

        //役の判定ここまで

        //ゲーム進行ここから

        //初期化処理
        private void InitGame()
        {
            //マークを数える配列の初期化をここでしてる
            Playercount = 0;
            Player1Marks = new int[4];
            Player2Marks = new int[4];
            RemoveCards();
            MakeCards();
            MakeLists();
            Player1HandLevel = 0;
            Player2HandLevel = 0;
            CheckhandLevels();
            WhoWin = 0;
            WhoPlayerWin();
            CheckSubCards();
        }

        private enum GamePhase
        {
            FirstBet = 0,
            SecondBet,
            ThirdBet,
            FinalBet,
            Result,
            Continue,
            Return,
        }
        
        private GamePhase _Phase = 0;

        //Phaseを進める/戻す
        private void PhaseChange()
        {
            _Phase++;
            //Phaseを0に戻して初期化をする
            //PhaseはFirstPhase
            if(_Phase == GamePhase.Return)
            {
                _Phase = 0;
                InitGame();
                //PhaseView(1);
            }
            if(_Phase == GamePhase.SecondBet)
            {
                TurnStackCard(1);
                //PhaseView(2);
                _Phase++;
            }
            if (_Phase == GamePhase.ThirdBet)
            {
                TurnStackCard(2);
                //PhaseView(3);
                _Phase++;
            }
            if (_Phase == GamePhase.FinalBet)
            {
                TurnStackCard(3);
                //PhaseView(4);
                _Phase++;
            }
            if (_Phase == GamePhase.Result)
            {
                //PhaseView(5);
            }
            //続けるかを聞く(間を入れているだけ)
            if (_Phase == GamePhase.Continue)
            {
                RemoveCards();
            }
            //Debug.Log(_Phase);
        }

        /*
        //Phase画像の表示
        public void PhaseView(int PhaseNum)
        {
            var PhaseImage = Resources.Load<GameObject>("Images/Bar/f_word5");
            switch (PhaseNum)
            {
                case 1:
                    PhaseImage = Resources.Load<GameObject>("Images/Bar/f_word5");
                    break;
                case 2:
                    PhaseImage = Resources.Load<GameObject>("Images/Bar/f_word6");
                    break;
                case 3:
                    PhaseImage = Resources.Load<GameObject>("Images/Bar/f_word7");
                    break;
                case 4:
                    PhaseImage = Resources.Load<GameObject>("Images/Bar/f_word8");
                    break;
                case 5:
                    PhaseImage = Resources.Load<GameObject>("Images/Bar/f_word9");
                    break;
                default:
                    Debug.Log("ExPhase");
                    break;
            }
            var PhaseObject = Instantiate(PhaseImage, transform.position, Quaternion.identity);
            PhaseObject.transform.position = new Vector3(-1, -1, 0);
        }

        */

        //場札をめくる
        public void TurnStackCard(int PhaseNum)
        {
            //var Stack = GameObject.Find("CardStacks");
            if(PhaseNum == 1)
            {
                for(int i = 1; i < 4; i++)
                {
                    var cardObject = GameObject.Find("StackCard" + i + "");
                    var card = cardObject.GetComponent<Card>();
                    card.StackView(true);
                }
            }
            if(PhaseNum == 2)
            {
                var cardObject = GameObject.Find("StackCard4");
                var card = cardObject.GetComponent<Card>();
                card.StackView(true);
            }
            if (PhaseNum == 3)
            {
                var cardObject = GameObject.Find("StackCard5");
                var card = cardObject.GetComponent<Card>();
                card.StackView(true);
            }
        }

        //ゲーム進行ここまで

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
