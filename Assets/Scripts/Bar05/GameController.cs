using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * 今回作業 --> フォールドした時のチップバグ修正
 *              チップの賭け方変更(長押しすると連続で賭けられるようにする)(まだ)
 *              
 */

/*
 * 次回作業 --> 
 */

/*
 * 今後実装 --> 相手のAI
 *              アニメーション
 *              両方とも時間切れ。。。
 */

namespace Assets.Scripts.Bar05
{
    public class GameController : MonoBehaviour
    {
        
        private void Start()
        {
            MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            Vector3 pos = transform.position;
            pos.z = 0;
            transform.position = pos;
            InitGame();
            ChipsUpdate();
        }

        private void Update()
        {
            if (Input.GetKeyDown("z") || Input.GetKeyDown("x") || Input.GetKeyDown("c") || Input.GetKeyDown("v") || Input.GetKeyDown("space"))
            {
                Debug.Log("<color=red>--------------------</color>");
                PhaseChange();
            }
            if(Input.GetMouseButtonDown(0))
            {
                if(_Phase == GamePhase.Result || _Phase == GamePhase.Continue)
                {
                    Debug.Log("<color=red>--------------------</color>");
                    PhaseChange();
                }
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
            /**/
            Debug.logger.logEnabled = false;

            //みやすいよね？ね？
            Debug.Log("--------------------");
            //山札を作る
            int deckPlace = 0;
            int[] Deck = Cardsshuffle();

            //イカサマをしよう
            //trueに切り替えて発動
            bool IKASAMAActive = false;

            if (IKASAMAActive)
            {
                int[] IkasamaDeck = { 24, 23, 17, 3, 2, 25, 9, 12, 28};
                for (int i = 0; i < IkasamaDeck.Length; i++)
                {
                    Deck[i] = IkasamaDeck[i];
                }
            }

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
                    for (int x = 1; x < cardsObject1.transform.childCount + 1; x++)
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
                else if (i == 1)
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
                    PlayerCards(Player2Cards, cardList_P2);

                    Debug.Log("<color=red>相手のカード生成完了</color>");
                    Debug.Log("--------------------");
                }
                //場札を生成
                else
                {
                    var cardsObject3 = GameObject.Find("CardStacks");
                    for (int x = 0; x < 5; x++)
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
                    PlayerCards(StackCards, cardList_St);

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
            for (int i = 0; i < 52; i++)
            {
                decks[i] = i;
            }

            int counter = 0;
            while (counter < 52)
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
                switch (i)
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
            /*
            if(IKASAMAActive)
            {
                IKASAMA();
            }
            */
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
            Debug.Log("--------------------");
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
            for (int i = 0; i < Affiliation.Length; i++)
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

        //役の候補になるカードのリスト
        private void CardLists(int[] Player, int[] List, int[] MList)
        {
            for (int i = 0; i < List.Length; i++)
            {
                //プレイヤーの手札
                if (i < Player.Length)
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
                if (CardNum == 0)
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
                switch (List[i])
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
            /**/
            Debug.Log(db2);
            /**/
            Debug.Log("クローバー:ダイヤ:ハート:スペード");
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
                    /**/Debug.Log(str);
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
                    /**/Debug.Log(str);
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
                if (tmp > MarkNum * 13 & tmp <= (MarkNum + 1) * 13)
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
            if (RSFFlag)
            {
                int a = 0;
                int Straight = 0;
                while (a < 8)
                {
                    if (Straight == 5)
                    {
                        RSForSFFlag = true;
                        break;
                    }
                    if (Straight == 0)
                    {
                        if (IListNumManager[0] >= 1)
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

        /* 役一覧(handLevel)                   実装状況(0:未実装(もしくはおかしい) 1:半実装 2:詳細なHandRankまで)
         * ハイカード(0)                       2
         * ワンペア(1)                         2
         * ツーペア(2)                         2
         * スリーカード(3)                     2
         * ストレート(4)                       2
         * フラッシュ(5)                       2
         * フルハウス(6)                       2
         * フォーカード(7)                     2
         * ストレートフラッシュ(8)             2
         * ロイヤルストレートフラッシュ(9)     2(そもそもない)
         * 
         * (デバッグし切ったとは言っていない)
         * 
         */

        //変数置き場

        int Player1HandLevel = 0;
        int Player2HandLevel = 0;
        int[] Player1NumberManager = new int[13];
        int[] Player2NumberManager = new int[13];
        int Playercount = 0;
        int Player1SubHandLevel = 0;
        int Player2SubHandLevel = 0;
        int Player1subsubHandLevel = 0;
        int Player2subsubHandLevel = 0;
        int[] Player1ThreeCard = new int[2];
        int[] Player2ThreeCard = new int[2];
        int[] Player1PairCard = new int[3];
        int[] Player2PairCard = new int[3];
        bool Player1StAceFlag = false;
        bool Player2StAceFlag = false;

        public void CheckHandLevel(int PlayerHandLevel, int[] CardList, int[] NumberManager, int[] Marks)
        {
            NumberManager = new int[13];
            //CardListを1～13の配列に入れてわかりやすくする
            for (int i = 0; i < CardList.Length; i++)
            {
                NumberManager[CardList[i] - 1] = NumberManager[CardList[i] - 1] + 1;
            }
            if(Playercount == 0)
            {
                for(int i = 0; i < NumberManager.Length; i++)
                {
                    Player1NumberManager[i] = NumberManager[i];
                }
            }
            else
            {
                for (int i = 0; i < NumberManager.Length; i++)
                {
                    Player2NumberManager[i] = NumberManager[i];
                }
            }

            //デバッグ用
            string db = "";
            for (int i = 0; i < NumberManager.Length; i++)
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
                    switch (MarkNum)
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
                    Player1subsubHandLevel = MarkNum;
                    break;
                }
                x++;
            }
            //数字を見る
            //ストレートの判定
            x = 12;
            int Straight = 0;
            int StrNum = 0;
            while (x >= 0)
            {
                if (NumberManager[x] >= 1)
                {
                    Straight = Straight + 1;
                }
                else
                {
                    Straight = 0;
                }
                if (Straight == 5)
                {
                    if (PlayerHandLevel < 4)
                    {
                        PlayerHandLevel = 4;
                        if (Playercount == 0)
                        {
                            Player1SubHandLevel = MarkNum;
                            Player1subsubHandLevel = x;
                        }
                        else
                        {
                            Player2SubHandLevel = MarkNum;
                            Player2subsubHandLevel = x;
                        }
                    }
                    StrNum = x + 5;
                    Debug.Log("ストレート:<color=red>" + StrNum + "</color>");
                    SFFlag = SFFlag + 1;
                    break;
                }
                x--;
            }
            //特殊ストレート判定 ロイヤルストレートフラッシュ用
            if (NumberManager[0] >= 1)
            {
                x = 0;
                int RSFcount = 1;
                while (x < 4)
                {
                    int Place = 9 + x;
                    if (NumberManager[Place] == 0)
                    {
                        RSFFlag = false;
                        break;
                    }
                    x++;
                    RSFcount++;
                }
                if (RSFFlag)
                {
                    //A.10.J.Q.Kでマーク違いってストレートになる?
                    //答え:なります             
                    PlayerHandLevel = 4;
                    Debug.Log("特殊ストレート!!");
                    if (Playercount == 0)
                    {
                        Player1StAceFlag = true;
                        Player1SubHandLevel = MarkNum;
                    }
                    else
                    {
                        Player2StAceFlag = true;
                        Player2SubHandLevel = MarkNum;
                    }
                }
                else
                {
                    //Debug.Log("<color=red>" + RSFcount + "</color>");
                }
            }

            //ストレートフラッシュの判定
            if (SFFlag == 2)
            {
                if (Playercount == 0)
                {
                    if (RSForSFDecision(MarkNum, Player1Cards, false))
                    {
                        PlayerHandLevel = 8;
                        Player1SubHandLevel = MarkNum;
                        Debug.Log("ストレートフラッシュ:<color=red>" + StrNum + "</color>");
                    }
                }
                else if (Playercount == 1)
                {
                    if (RSForSFDecision(MarkNum, Player2Cards, false))
                    {
                        PlayerHandLevel = 8;
                        Player2SubHandLevel = MarkNum;
                        Debug.Log("ストレートフラッシュ:<color=red>" + StrNum + "</color>");
                    }
                }
            }
            //ロイヤルストレートフラッシュの判定
            if (RSFFlag)
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
            while (x < NumberManager.Length)
            {
                //フラッシュ以上が確定している場合、それ以上の役はないのでBreak
                if (x == 0 & PlayerHandLevel != 0)
                {
                    break;
                }
                //フォーカードを検出したらそれ以上の役はないのでBreak
                if (NumberManager[x] == 4)
                {
                    PlayerHandLevel = 7;
                    Debug.Log("フォーカード");
                    if(Playercount == 0)
                    {
                        Player1SubHandLevel = x + 1;
                    }
                    else
                    {
                        Player2SubHandLevel = x + 1;
                    }
                    break;
                }
                //スリーカードを検出
                //スリーカードが2組ある場合、フルハウスになる
                if (NumberManager[x] == 3)
                {
                    if(Playercount == 0)
                    {
                        Player1ThreeCard[PHand3] = x + 1;
                    }
                    else
                    {
                        Player2ThreeCard[PHand3] = x + 1;
                    }
                    PHand3 = PHand3 + 1;
                }
                //ペアを見る
                else if (NumberManager[x] == 2)
                {
                    if(Playercount == 0)
                    {
                        Player1PairCard[PHand2] = x + 1;
                    }
                    else
                    {
                        Player2PairCard[PHand2] = x + 1;
                    }
                    PHand2 = PHand2 + 1;
                }
                x++;
            }
            //その他役判定
            if (PlayerHandLevel == 0)
            {
                //フルハウス
                if (PHand3 == 2)
                {
                    PlayerHandLevel = 6;
                    Debug.Log("フルハウス");
                }
                //これもフルハウス
                else if (PHand3 == 1 & PHand2 >= 1)
                {
                    PlayerHandLevel = 6;
                    Debug.Log("フルハウス");
                }
                //スリーカード
                else if (PHand3 == 1)
                {
                    PlayerHandLevel = 3;
                    Debug.Log("スリーカード");
                }
                //ツーペア
                else if (PHand2 >= 2)
                {
                    PlayerHandLevel = 2;
                    Debug.Log("ツーペア");
                }
                //ワンペア
                else if (PHand2 == 1)
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

            if (Playercount == 0)
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

        //WhoWinについて
        //0は負け 1は引き分け 2は勝ち
        //後に掛けたチップ×WhoWinをする
        int WhoWin;

        private void WhoPlayerWin()
        {
            WhoWin = 1;
            //**/Debug.Log("Player1is" + Player1HandLevel);
            //**/Debug.Log("Player2is" + Player2HandLevel);
            if (Player1HandLevel > Player2HandLevel)
            {
                WhoWin = 2;
                Debug.Log("<color=green>Player1Winner</color>");
            }
            else if (Player1HandLevel < Player2HandLevel)
            {
                WhoWin = 0;
                Debug.Log("<color=green>Player2Winner</color>");
            }
            else if (Player1HandLevel == Player2HandLevel)
            {
                Debug.Log("本当に引き分け？？？");
                //ロイヤルストレートフラッシュを持ち合わせた場合引き分け
                if (Player1HandLevel == 9)
                {
                    WhoWin = 1;
                    Debug.Log("<color=green>引き分け</color>");
                }
                //ストレートフラッシュ
                else if (Player1HandLevel == 8)
                {
                    bool DrawFlag = true;
                    bool FirstCome = true;
                    //場札のみで完成されていたら引き分け
                    for (int i = 0; i < 4; i++)
                    {
                        if (i <= 1)
                        {
                            if (Player1Cards[i] + 1 > Player1SubHandLevel * 13 & Player1Cards[i] + 1 <= (Player1SubHandLevel + 1) * 13)
                            {
                                DrawFlag = false;
                                break;
                            }
                        }
                    }
                    if (DrawFlag)
                    {
                        WhoWin = 1;
                        Debug.Log("<color=green>引き分け</color>");
                    }

                    //player1
                    for (int i = 0; i < 2; i++)
                    {
                        if (Player1Cards[i] + 1 > Player1SubHandLevel * 13 & Player1Cards[i] + 1 <= (Player1SubHandLevel + 1) * 13)
                        {
                            if (FirstCome)
                            {
                                Player1HandLevel = Player1Cards[i] % 13 + 1;
                            }
                            else
                            {
                                if (Player1HandLevel != 1 || Player1Cards[i] % 13 == 0 || Player1HandLevel < Player1Cards[i] % 13 + 1)
                                {
                                    Player1HandLevel = Player1Cards[i] % 13 + 1;
                                }
                            }
                        }
                    }
                    Debug.Log("Player1is" + Player1HandLevel);
                    //player2

                    FirstCome = true;
                    for (int i = 0; i < 2; i++)
                    {
                        if (Player2Cards[i] + 1 > Player2SubHandLevel * 13 & Player2Cards[i] + 1 <= (Player2SubHandLevel + 1) * 13)
                        {
                            if (FirstCome)
                            {
                                Player2HandLevel = Player2Cards[i] % 13 + 1;
                            }
                            else
                            {
                                if (Player2HandLevel != 1 || Player2Cards[i] % 13 == 0 || Player2HandLevel < Player2Cards[i] % 13 + 1)
                                {
                                    Player2HandLevel = Player2Cards[i] % 13 + 1;
                                }
                            }
                        }
                    }
                    Debug.Log("Player2is" + Player2HandLevel);

                    //判定
                    if (Player1HandLevel == Player2HandLevel)
                    {
                        WhoWin = 1;
                        Debug.Log("<color=green>引き分け</color>");
                    }
                    else if (Player1HandLevel > Player2HandLevel)
                    {
                        WhoWin = 2;
                        Debug.Log("<color=green>Player1Winner</color>");
                    }
                    else
                    {
                        WhoWin = 0;
                        Debug.Log("<color=green>Player2Winner</color>");
                    }
                }
                //ストレートフラッシュここまで
                //フォーカード
                else if(Player1HandLevel == 7)
                {
                    //場札でフォーカードになっていた場合
                    if(Player1SubHandLevel == Player2SubHandLevel)
                    {
                        HighCard();
                    }
                    //Aを持っていた場合
                    else if(Player1SubHandLevel == 1 || Player2SubHandLevel == 1)
                    {
                        //Aで勝負がつく場合
                        if(Player1SubHandLevel == 1)
                        {
                            WhoWin = 2;
                            Debug.Log("<color=green>Player1Winner</color>");
                        }
                        else
                        {
                            WhoWin = 0;
                            Debug.Log("<color=green>Player2Winner</color>");
                        }
                    }
                    //A以外で勝負がつく場合
                    else if(Player1SubHandLevel > Player2SubHandLevel)
                    {
                        WhoWin = 2;
                        Debug.Log("<color=green>Player1Winner</color>");
                    }
                    else
                    {
                        WhoWin = 0;
                        Debug.Log("<color=green>Player2Winner</color>");
                    }
                }
                //フォーカードここまで
                //フルハウス
                //キッカー勝負はない
                else if(Player1HandLevel == 6)
                {
                    for(int a = 0; a < 2; a++)
                    {
                        if(a == 0)
                        {
                            if(Player1ThreeCard[a] == Player2ThreeCard[a])
                            {
                                //引き分け、次に移る
                            }
                            //Aを見つけた
                            else if(Player1ThreeCard[a] == 1 || Player2ThreeCard[a] == 1)
                            {
                                if(Player1ThreeCard[a] == 1)
                                {
                                    WhoWin = 2;
                                    Debug.Log("<color=green>Player1Winner</color>");
                                }
                                else
                                {
                                    WhoWin = 0;
                                    Debug.Log("<color=green>Player2Winner</color>");
                                }
                            }
                            //A以外で勝負
                            else if(Player1ThreeCard[a] > Player2ThreeCard[a])
                            {
                                WhoWin = 2;
                                Debug.Log("<color=green>Player1Winner</color>");
                            }
                            else
                            {
                                WhoWin = 0;
                                Debug.Log("<color=green>Player2Winner</color>");
                            }
                        }
                        else
                        {
                            //スリーカードが2組出来ていたら
                            if (Player1ThreeCard[a] != 0 || Player2ThreeCard[a] != 0)
                            {
                                //Player1とPlayer2がスリーカード2組
                                if(Player1ThreeCard[a] != 0 & Player2ThreeCard[a] != 0)
                                {
                                    //Aを見つけた
                                    if(Player1ThreeCard[a] == 1 || Player2ThreeCard[a] == 1)
                                    {
                                        //A同士
                                        if(Player1ThreeCard[a] == Player2ThreeCard[a])
                                        {
                                            WhoWin = 1;
                                            Debug.Log("<color=green>引き分け</color>");
                                        }
                                        else if(Player1ThreeCard[a] == 1)
                                        {
                                            WhoWin = 2;
                                            Debug.Log("<color=green>Player1Winner</color>");
                                        }
                                        else
                                        {
                                            WhoWin = 0;
                                            Debug.Log("<color=green>Player2Winner</color>");
                                        }
                                    }
                                    //通常
                                    else
                                    {
                                        if(Player1ThreeCard[a] > Player2ThreeCard[a])
                                        {
                                            WhoWin = 2;
                                            Debug.Log("<color=green>Player1Winner</color>");
                                        }
                                        else
                                        {
                                            WhoWin = 0;
                                            Debug.Log("<color=green>Player2Winner</color>");
                                        }
                                    }
                                }
                                //Player1がスリーカード2組
                                else if(Player1ThreeCard[a] != 0)
                                {
                                    //Aを見つけた
                                    if (Player1ThreeCard[a] == 1 || Player2PairCard[0] == 1)
                                    {
                                        //A同士
                                        if (Player1ThreeCard[a] == Player2PairCard[0])
                                        {
                                            WhoWin = 1;
                                            Debug.Log("<color=green>引き分け</color>");
                                        }
                                        else if (Player1ThreeCard[a] == 1)
                                        {
                                            WhoWin = 2;
                                            Debug.Log("<color=green>Player1Winner</color>");
                                        }
                                        else
                                        {
                                            WhoWin = 0;
                                            Debug.Log("<color=green>Player2Winner</color>");
                                        }
                                    }
                                    //通常
                                    else
                                    {
                                        if (Player1ThreeCard[a] > Player2PairCard[0])
                                        {
                                            WhoWin = 2;
                                            Debug.Log("<color=green>Player1Winner</color>");
                                        }
                                        else
                                        {
                                            WhoWin = 0;
                                            Debug.Log("<color=green>Player2Winner</color>");
                                        }
                                    }
                                }
                                //Player2がスリーカード2組
                                else if (Player2ThreeCard[a] != 0)
                                {
                                    //Aを見つけた
                                    if (Player1PairCard[0] == 1 || Player2ThreeCard[a] == 1)
                                    {
                                        //A同士
                                        if (Player1PairCard[0] == Player2ThreeCard[a])
                                        {
                                            WhoWin = 1;
                                            Debug.Log("<color=green>引き分け</color>");
                                        }
                                        else if (Player1PairCard[0] == 1)
                                        {
                                            WhoWin = 2;
                                            Debug.Log("<color=green>Player1Winner</color>");
                                        }
                                        else
                                        {
                                            WhoWin = 0;
                                            Debug.Log("<color=green>Player2Winner</color>");
                                        }
                                    }
                                    //通常
                                    else
                                    {
                                        if (Player1PairCard[0] > Player2ThreeCard[a])
                                        {
                                            WhoWin = 2;
                                            Debug.Log("<color=green>Player1Winner</color>");
                                        }
                                        else
                                        {
                                            WhoWin = 0;
                                            Debug.Log("<color=green>Player2Winner</color>");
                                        }
                                    }
                                }
                            }
                            //通常
                            //Aを見つけた
                            if (Player1PairCard[0] == 1 || Player2PairCard[0] == 1)
                            {
                                //A同士
                                if (Player1PairCard[0] == Player2PairCard[0])
                                {
                                    WhoWin = 1;
                                    Debug.Log("<color=green>引き分け</color>");
                                }
                                else if (Player1PairCard[0] == 1)
                                {
                                    WhoWin = 2;
                                    Debug.Log("<color=green>Player1Winner</color>");
                                }
                                else
                                {
                                    WhoWin = 0;
                                    Debug.Log("<color=green>Player2Winner</color>");
                                }
                            }
                            //通常
                            else
                            {
                                if (Player1PairCard[0] > Player2ThreeCard[0])
                                {
                                    WhoWin = 2;
                                    Debug.Log("<color=green>Player1Winner</color>");
                                }
                                else
                                {
                                    WhoWin = 0;
                                    Debug.Log("<color=green>Player2Winner</color>");
                                }
                            }
                        }
                    }
                }
                //フルハウスここまで
                //フラッシュ
                else if (Player1HandLevel == 5)
                {
                    Player1SubHandLevel = 0;
                    Player2SubHandLevel = 0;
                    Player1subsubHandLevel = 0;
                    Player2subsubHandLevel = 0;
                    int MarkNum = Player1subsubHandLevel;
                    //Player1
                    for(int i = 0; i < 2; i++)
                    {
                        if (Player1Cards[i] >= MarkNum * 13 || Player1Cards[i] < (MarkNum + 1) * 13)
                        {
                            if(Player1SubHandLevel == 0)
                            {
                                Player1SubHandLevel = Player1Cards[i] % 13 + 1;
                            }
                            else if(Player1SubHandLevel != 1)
                            {
                                if(Player1Cards[i] % 13 + 1 == 1 || Player1Cards[i] % 13 + 1 > Player1SubHandLevel)
                                {
                                    Player1subsubHandLevel = Player1SubHandLevel;
                                    Player1SubHandLevel = Player1Cards[i] % 13 + 1;
                                }
                                else
                                {
                                    Player1subsubHandLevel = Player1Cards[i] % 13 + 1;
                                }
                            }
                            else
                            {
                                Player1subsubHandLevel = Player1Cards[i] % 13 + 1;
                            }
                        }
                    }
                    //Player2
                    for (int i = 0; i < 2; i++)
                    {
                        if (Player2Cards[i] >= MarkNum * 13 || Player2Cards[i] < (MarkNum + 1) * 13)
                        {
                            if (Player2SubHandLevel == 0)
                            {
                                Player2SubHandLevel = Player2Cards[i] % 13 + 1;
                            }
                            else if (Player2SubHandLevel != 1)
                            {
                                if (Player2Cards[i] % 13 + 1 == 1 || Player2Cards[i] % 13 + 1 > Player2SubHandLevel)
                                {
                                    Player2subsubHandLevel = Player2SubHandLevel;
                                    Player2SubHandLevel = Player2Cards[i] % 13 + 1;
                                }
                                else
                                {
                                    Player2subsubHandLevel = Player2Cards[i] % 13 + 1;
                                }
                            }
                            else
                            {
                                Player2subsubHandLevel = Player2Cards[i] % 13 + 1;
                            }
                        }
                    }
                    //判定
                    //どっちも0だったら引き分け
                    if(Player1SubHandLevel == 0 || Player2SubHandLevel == 0)
                    {
                        WhoWin = 1;
                        Debug.Log("<color=green>引き分け</color>");
                    }
                    //Aがあるとき
                    //Aは被らない
                    else if(Player1SubHandLevel == 1 || Player2SubHandLevel == 1)
                    {
                        if(Player1SubHandLevel == 1)
                        {
                            WhoWin = 2;
                            Debug.Log("<color=green>Player1Winner</color>");
                        }
                        else
                        {
                            WhoWin = 0;
                            Debug.Log("<color=green>Player2Winner</color>");
                        }
                    }
                    //Aが無いとき
                    else if(Player1SubHandLevel > Player2SubHandLevel)
                    {
                        WhoWin = 2;
                        Debug.Log("<color=green>Player1Winner</color>");
                    }
                    else
                    {
                        WhoWin = 0;
                        Debug.Log("<color=green>Player2Winner</color>");
                    }
                }
                //フラッシュここまで
                //ストレート
                else if (Player1HandLevel == 4)
                {
                    if(Player1StAceFlag || Player2StAceFlag)
                    {
                        if(Player1StAceFlag)
                        {
                            WhoWin = 2;
                            Debug.Log("<color=green>Player1Winner</color>");
                        }
                        else if(Player2StAceFlag)
                        {
                            WhoWin = 0;
                            Debug.Log("<color=green>Player2Winner</color>");
                        }
                        else
                        {
                            WhoWin = 1;
                            Debug.Log("<color=green>引き分け</color>");
                        }
                    }
                    else
                    {
                        if(Player1subsubHandLevel > Player2subsubHandLevel)
                        {
                            WhoWin = 2;
                            Debug.Log("<color=green>Player1Winner</color>");
                        }
                        else if(Player1subsubHandLevel < Player2subsubHandLevel)
                        {
                            WhoWin = 0;
                            Debug.Log("<color=green>Player2Winner</color>");
                        }
                        else
                        {
                            WhoWin = 1;
                            Debug.Log("<color=green>引き分け</color>");
                        }
                    }
                }
                //ストレートここまで
                //スリーカード
                else if (Player1HandLevel == 3)
                {
                    for (int a = 0; a < 1; a++)
                    {
                        //判定
                        //ペアの数字で勝負が引き分けだった場合
                        if (Player1ThreeCard[a] == Player2ThreeCard[a] & a == 0)
                        {
                            KickerBattle();
                        }
                        //ペアの数字で勝負がつくとき(A)
                        else if (Player1ThreeCard[a] == 1 || Player2ThreeCard[a] == 1)
                        {
                            if (Player1ThreeCard[a] == 1)
                            {
                                WhoWin = 2;
                                Debug.Log("<color=green>Player1Winner</color>");
                            }
                            else
                            {
                                WhoWin = 0;
                                Debug.Log("<color=green>Player2Winner</color>");
                            }
                        }
                        //ペアの数字で勝負がつくとき(A以外)
                        else if (Player1ThreeCard[a] > Player2ThreeCard[a])
                        {
                            WhoWin = 2;
                            Debug.Log("<color=green>Player1Winner</color>");
                        }
                        else
                        {
                            WhoWin = 0;
                            Debug.Log("<color=green>Player2Winner</color>");
                        }
                    }
                }
                //スリーカードここまで
                //ツーペア
                else if (Player1HandLevel == 2)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        //判定
                        //ペアの数字で勝負が引き分けだった場合
                        if (Player1PairCard[a] == Player2PairCard[a] & a == 1)
                        {
                            KickerBattle();
                        }
                        //ペアの数字で勝負がつくとき(A)
                        else if (Player1PairCard[a] == 1 || Player2PairCard[a] == 1)
                        {
                            if (Player1PairCard[a] == 1)
                            {
                                WhoWin = 2;
                                Debug.Log("<color=green>Player1Winner</color>");
                                break;
                            }
                            else if(Player2PairCard[a] == 1)
                            {
                                WhoWin = 0;
                                Debug.Log("<color=green>Player2Winner</color>");
                                break;
                            }
                        }
                        //ペアの数字で勝負がつくとき(A以外)
                        else if (Player1PairCard[a] > Player2PairCard[a])
                        {
                            WhoWin = 2;
                            Debug.Log("<color=green>Player1Winner</color>");
                            break;
                        }
                        else if(Player1PairCard[a] < Player2PairCard[a])
                        {
                            WhoWin = 0;
                            Debug.Log("<color=green>Player2Winner</color>");
                            break;
                        }
                    }
                }
                //ツーペアここまで
                //ワンペア
                else if (Player1HandLevel == 1)
                {
                    //流用できるようにfor文で挟む
                    for(int a = 0; a < 1; a++)
                    {
                        //判定
                        //ペアの数字で勝負が引き分けだった場合
                        if (Player1PairCard[a] == Player2PairCard[a] & a == 0)
                        {
                            KickerBattle();
                        }
                        //ペアの数字で勝負がつくとき(A)
                        else if (Player1PairCard[a] == 1 || Player2PairCard[a] == 1)
                        {
                            if (Player1PairCard[a] == 1)
                            {
                                WhoWin = 2;
                                Debug.Log("<color=green>Player1Winner</color>");
                            }
                            else
                            {
                                WhoWin = 0;
                                Debug.Log("<color=green>Player2Winner</color>");
                            }
                        }
                        //ペアの数字で勝負がつくとき(A以外)
                        else if (Player1PairCard[a] > Player2PairCard[a])
                        {
                            WhoWin = 2;
                            Debug.Log("<color=green>Player1Winner</color>");
                        }
                        else
                        {
                            WhoWin = 0;
                            Debug.Log("<color=green>Player2Winner</color>");
                        }
                    }
                }
                //ワンペアここまで
                //ハイカード
                else if (Player1HandLevel == 0)
                {
                    HighCard();
                }
                //ハイカードここまで
            }
        }

        //ハイカードとかそこらへん
        private void HighCard()
        {
            //Player1
            Player1SubHandLevel = Player1Cards[0] % 13 + 1;
            if (Player1SubHandLevel != 1 & Player1SubHandLevel < Player1Cards[1] % 13 + 1)
            {
                Player1subsubHandLevel = Player1SubHandLevel;
                Player1SubHandLevel = Player1Cards[1] % 13 + 1;
            }
            else
            {
                Player1subsubHandLevel = Player1Cards[1] % 13 + 1;
            }
            Debug.Log(Player1SubHandLevel);

            //Player2
            Player2SubHandLevel = Player2Cards[0] % 13 + 1;
            if (Player2SubHandLevel != 1 & Player2SubHandLevel < Player2Cards[1] % 13 + 1)
            {
                Player2subsubHandLevel = Player2SubHandLevel;
                Player2SubHandLevel = Player2Cards[1] % 13 + 1;
            }
            else
            {
                Player2subsubHandLevel = Player2Cards[1] % 13 + 1;
            }
            Debug.Log(Player2SubHandLevel);

            //判定
            //Aがどっちかに入っている場合
            if (Player1SubHandLevel == 1 || Player2SubHandLevel == 1)
            {
                //どっちもAで引き分けだった場合
                if (Player1SubHandLevel == Player2SubHandLevel)
                {
                    //2枚目どっちかがAだった場合
                    if (Player1subsubHandLevel == 1 || Player2subsubHandLevel == 1)
                    {
                        //2枚目もどちらともAだった場合
                        if (Player1subsubHandLevel == Player2subsubHandLevel)
                        {
                            WhoWin = 1;
                            Debug.Log("<color=green>引き分け</color>");
                        }
                        //2枚目どっちかがAで勝負がつく場合
                        else if (Player1subsubHandLevel == 1)
                        {
                            WhoWin = 2;
                            Debug.Log("<color=green>Player1Winner</color>");
                        }
                        else
                        {
                            WhoWin = 0;
                            Debug.Log("<color=green>Player2Winner</color>");
                        }
                    }
                    //2枚目がAでなくて、引き分けだった場合
                    else if (Player1subsubHandLevel == Player2subsubHandLevel)
                    {
                        WhoWin = 1;
                        Debug.Log("<color=green>引き分け</color>");
                    }
                    //2枚目がAでなくて、勝負がつく場合
                    else if (Player1subsubHandLevel > Player2subsubHandLevel)
                    {
                        WhoWin = 2;
                        Debug.Log("<color=green>Player1Winner</color>");
                    }
                    else
                    {
                        WhoWin = 0;
                        Debug.Log("<color=green>Player2Winner</color>");
                    }
                }
                //Aがどっちかに入っていて、勝負がつく場合
                else if (Player1SubHandLevel == 1)
                {
                    WhoWin = 2;
                    Debug.Log("<color=green>Player1Winner</color>");
                }
                else
                {
                    WhoWin = 0;
                    Debug.Log("<color=green>Player2Winner</color>");
                }
            }
            //1枚目がAではなくて、引き分けだった場合
            else if (Player1HandLevel == Player2HandLevel)
            {
                //2枚目どっちかがAだった場合
                if (Player1subsubHandLevel == 1 || Player2subsubHandLevel == 1)
                {
                    //2枚目もどちらともAだった場合
                    if (Player1subsubHandLevel == Player2subsubHandLevel)
                    {
                        WhoWin = 1;
                        Debug.Log("<color=green>引き分け</color>");
                    }
                    //2枚目どっちかがAで勝負がつく場合
                    else if (Player1subsubHandLevel == 1)
                    {
                        WhoWin = 2;
                        Debug.Log("<color=green>Player1Winner</color>");
                    }
                    else
                    {
                        WhoWin = 0;
                        Debug.Log("<color=green>Player2Winner</color>");
                    }
                }
                //2枚目がAでなくて、引き分けだった場合
                else if (Player1subsubHandLevel == Player2subsubHandLevel)
                {
                    WhoWin = 1;
                    Debug.Log("<color=green>引き分け</color>");
                }
                //2枚目がAでなくて、勝負がつく場合
                else if (Player1subsubHandLevel > Player2subsubHandLevel)
                {
                    WhoWin = 2;
                    Debug.Log("<color=green>Player1Winner</color>");
                }
                else
                {
                    WhoWin = 0;
                    Debug.Log("<color=green>Player2Winner</color>");
                }
            }
            //1枚目がAではなくて、勝負がつく場合
            else if (Player1HandLevel > Player2HandLevel)
            {
                WhoWin = 2;
                Debug.Log("<color=green>Player1Winner</color>");
            }
            else
            {
                WhoWin = 0;
                Debug.Log("<color=green>Player2Winner</color>");
            }
            //なげーよ
        }

        //ペア系・スリーカード系の判定用

        //Player1NumberManager;
        //Player2NumberManager;
        int[] Player1Kickers = new int[5];
        int[] Player2Kickers = new int[5];
        bool Player1AceFlag = false;
        bool Player2AceFlag = false;
        int tgt = 0;
        private void KickerBattle()
        {
            //Player1
            tgt = 0;
            //Aを見る
            if(Player1NumberManager[0] == 1)
            {
                Player1AceFlag = true;
            }
            for(int i = 12; i > 0; i--)
            {
                Debug.Log(Player1NumberManager[i]);
                if(Player1NumberManager[i] == 1)
                {
                    Player1Kickers[tgt] = i + 1;
                    Debug.Log(Player1Kickers[tgt]);
                    tgt++;
                }
            }
            //Player2
            tgt = 0;
            //Aを見る
            if (Player2NumberManager[0] == 1)
            {
                Player2AceFlag = true;
            }
            for (int i = 12; i > 0; i--)
            {
                if (Player2NumberManager[i] == 1)
                {
                    Player2Kickers[tgt] = i + 1;
                    Debug.Log(Player2Kickers[tgt]);
                    tgt++;
                }
            }
            //判定
            //Aがあれば決着
            if(Player1AceFlag || Player2AceFlag)
            {
                if(Player1AceFlag & Player2AceFlag)
                {
                    for(int i = 0; i < Player1Kickers.Length; i++)
                    {
                        if(Player1Kickers[i] > Player2Kickers[i])
                        {
                            WhoWin = 2;
                            Debug.Log("<color=green>Player1Winner</color>");
                            break;
                        }
                        else if(Player1Kickers[i] < Player2Kickers[i])
                        {
                            WhoWin = 0;
                            Debug.Log("<color=green>Player2Winner</color>");
                            break;
                        }
                    }
                }
                else if(Player1AceFlag)
                {
                    WhoWin = 2;
                    Debug.Log("<color=green>Player1Winner</color>");
                }
                else
                {
                    WhoWin = 0;
                    Debug.Log("<color=green>Player2Winner</color>");
                }
            }
            else
            {
                for (int i = 0; i < Player1Kickers.Length; i++)
                {
                    if (Player1Kickers[i] > Player2Kickers[i])
                    {
                        WhoWin = 2;
                        Debug.Log("<color=green>Player1Winner</color>");
                        break;
                    }
                    else if (Player1Kickers[i] < Player2Kickers[i])
                    {
                        WhoWin = 0;
                        Debug.Log("<color=green>Player2Winner</color>");
                        break;
                    }
                }
            }
        }

        
        //役の判定ここまで

        //ゲーム進行ここから

        //チップ処理
        private void ChipsUpdate()
        {
            var ChipInt = GameObject.Find("Num1_Kurai1");
            for (int i = 0; i < 9; i++)
            {
                switch(i)
                {
                    case 0:
                        ChipInt = GameObject.Find("Num1_Kurai1");
                        break;
                    case 1:
                        ChipInt = GameObject.Find("Num1_Kurai2");
                        break;
                    case 2:
                        ChipInt = GameObject.Find("Num1_Kurai3");
                        break;
                    case 3:
                        ChipInt = GameObject.Find("Num2_Kurai1");
                        break;
                    case 4:
                        ChipInt = GameObject.Find("Num2_Kurai2");
                        break;
                    case 5:
                        ChipInt = GameObject.Find("Num2_Kurai3");
                        break;
                    case 6:
                        ChipInt = GameObject.Find("Num3_Kurai1");
                        break;
                    case 7:
                        ChipInt = GameObject.Find("Num3_Kurai2");
                        break;
                    case 8:
                        ChipInt = GameObject.Find("Num3_Kurai3");
                        break;
                }
                var Chips = ChipInt.GetComponent<ChipManager>();
                switch(i)
                {
                    case 0:
                        Chips.SetChip(Chip, 0);
                        break;
                    case 1:
                        Chips.SetChip(Chip, 0);
                        break;
                    case 2:
                        Chips.SetChip(Chip, 0);
                        break;
                    case 3:
                        Chips.SetChip(MyHaveChip, 1);
                        break;
                    case 4:
                        Chips.SetChip(MyHaveChip, 1);
                        break;
                    case 5:
                        Chips.SetChip(MyHaveChip, 1);
                        break;
                    case 6:
                        Chips.SetChip(Pot, 2);
                        break;
                    case 7:
                        Chips.SetChip(Pot, 2);
                        break;
                    case 8:
                        Chips.SetChip(Pot, 2);
                        break;
                }
            }
        }

        int Chip = 0;
        int MyHaveChip = 100;
        int Pot = 0;
        private void ChipBet(int Bet)
        {
            if(Chip + Bet != -1 & MyHaveChip - Bet >= 0)
            {
                Chip = Chip + Bet;
                MyHaveChip = MyHaveChip - Bet;
                ChipsUpdate();
            }
            //Debug.Log("HaveIs" + MyHaveChip);
            //Debug.Log("BetIs" + Chip);
        }

        //初期化処理
        private void InitGame()
        {
            InitValue();
            RemoveCards();
            MakeCards();
            MakeLists();
            CheckhandLevels();
            WhoPlayerWin();
            CheckSubCards();
        }
        //変数の初期化
        private void InitValue()
        {
            //マークを数える配列の初期化をここでしてる
            Playercount = 0;
            Player1Marks = new int[4];
            Player2Marks = new int[4];
            Player1HandLevel = 0;
            Player2HandLevel = 0;
            Player1SubHandLevel = 0;
            Player2SubHandLevel = 0;
            Player1subsubHandLevel = 0;
            Player2subsubHandLevel = 0;
            Player1ThreeCard = new int[2];
            Player2ThreeCard = new int[2];
            Player1PairCard = new int[3];
            Player2PairCard = new int[3];
            Player1Kickers = new int[5];
            Player2Kickers = new int[5];
            Player1StAceFlag = false;
            Player2StAceFlag = false;
            Player1AceFlag = false;
            Player2AceFlag = false;
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

        //var cardObject = GameObject.Find("player1Card" + x + "");
        //var card = cardObject.GetComponent<Card>();

        private void PhaseControll(int PhaseNum)
        {
            var PhaseSwitch = GameObject.Find("PhaseView");
            var Phase = PhaseSwitch.GetComponent<PhaseSwitch>();
            Phase.PhaseChange(PhaseNum);
        }
        
        //Phaseを進める/戻す
        private void PhaseChange()
        {
            Vector3 pos = transform.position;
            _Phase++;
            //Phaseを0に戻して初期化をする
            //PhaseはFirstPhase
            if (_Phase == GamePhase.Return)
            {
                pos.z = 0;
                transform.position = pos;
                _Phase = 0;
                InitGame();
                PhaseControll(0);
            }
            if (_Phase == GamePhase.SecondBet)
            {
                TurnStackCard(1);
                PhaseControll(1);
                //_Phase++;
            }
            if (_Phase == GamePhase.ThirdBet)
            {
                TurnStackCard(2);
                PhaseControll(2);
                //_Phase++;
            }
            if (_Phase == GamePhase.FinalBet)
            {
                TurnStackCard(3);
                PhaseControll(3);
                //_Phase++;
            }
            if (_Phase == GamePhase.Result)
            {
                switch(WhoWin)
                {
                    case 0:
                        MainSpriteRenderer.sprite = Lose;
                        break;
                    case 1:
                        MainSpriteRenderer.sprite = Draw;
                        break;
                    case 2:
                        MainSpriteRenderer.sprite = Win;
                        break;
                }
                pos.z = -1;
                transform.position = pos;
                PhaseControll(4);
                HyouriIttai();
            }
            //続けるかを聞く(チップの返還・Pot処理)
            if (_Phase == GamePhase.Continue)
            {
                MyHaveChip = MyHaveChip + Pot * WhoWin;
                Pot = 0;
                ChipsUpdate();
                RemoveCards();
            }
            Debug.Log(_Phase);
        }

        public void HyouriIttai()
        {
            for(int i = 1; i < 3; i++)
            {
                var cardObject = GameObject.Find("player2Card" + i + "");
                var card = cardObject.GetComponent<Card>();
                card.Hyouri();
            }
        }

        //場札をめくる
        public void TurnStackCard(int PhaseNum)
        {
            //var Stack = GameObject.Find("CardStacks");
            if (PhaseNum == 1)
            {
                for (int i = 1; i < 4; i++)
                {
                    var cardObject = GameObject.Find("StackCard" + i + "");
                    var card = cardObject.GetComponent<Card>();
                    card.StackView(true);
                }
            }
            if (PhaseNum == 2)
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

        //ボタン押した時の挙動
        public void Chip_Plus()
        {
            if(_Phase != GamePhase.Result & _Phase != GamePhase.Continue)
            {
                ChipBet(1);
            }
        }

        public void Chip_Minus()
        {
            if (_Phase != GamePhase.Result & _Phase != GamePhase.Continue)
            {
                ChipBet(-1);
            }
        }

        public void Button_Call()
        {
            if(Chip != 0 & _Phase != GamePhase.Result & _Phase != GamePhase.Continue)
            {
                Pot = Pot + Chip;
                Chip = 0;
                ChipsUpdate();
                Debug.Log("<color=red>--------------------</color>");
                PhaseChange();
            }
        } 

        public void Button_Fold()
        {
            if (_Phase != GamePhase.Result & _Phase != GamePhase.Continue)
            {
                Pot = 0;
                MyHaveChip = MyHaveChip + Chip;
                Chip = 0;
                ChipsUpdate();
                Debug.Log("<color=red>--------------------</color>");
                for (int i = 1; i < 6; i++)
                {
                    var cardObject = GameObject.Find("StackCard" + i + "");
                    var card = cardObject.GetComponent<Card>();
                    card.StackView(true);
                }
                _Phase = GamePhase.FinalBet;
                WhoWin = 0;
                PhaseChange();
            }
        }

        //WinLose表示
        SpriteRenderer MainSpriteRenderer;
        public Sprite Win;
        public Sprite Draw;
        public Sprite Lose;


        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
