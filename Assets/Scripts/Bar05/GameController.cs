using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * 今回作業 --> 
 */

/*
 * 次回作業 --> 
 */

/*
 * 今後実装 -->ストレートフラッシュとロイヤルストレートフラッシュの判定の修正
 *             同役の時の処理
 *             PhaseViewの修正(Prefabにしなきゃいけない?)
 *             チップを掛ける
 */

namespace Assets.Scripts.Bar05 {
    public class GameController : MonoBehaviour {

        private void Start()
        {
            InitGame();
            Debug.Log(_Phase);
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("<color=red>--------------------</color>");
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
                        Debug.Log(ParentObject.transform.childCount);
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
            Debug.Log("<color=blue>自分と場札のカード内訳</color>");
            CardLists(Player1Cards, Player1CardList, Player1Marks);
            Debug.Log("--------------------");
            Debug.Log("<color=red>相手と場札のカード内訳</color>");
            CardLists(Player2Cards, Player2CardList, Player2Marks);
            Debug.Log("--------------------");
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

        /* 役一覧(handLevel)                   実装状況(0:未実装 1:実装 2:おかしい)
         * ハイカード(0)                       1
         * ワンペア(1)                         1
         * ツーペア(2)                         1
         * スリーカード(3)                     1
         * ストレート(4)                       1
         * フラッシュ(5)                       1
         * フルハウス(6)                       1
         * フォーカード(7)                     1
         * ストレートフラッシュ(8)             2
         * ロイヤルストレートフラッシュ(9)     2
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

            //ストレートフラッシュ以上の判定用フラグ(のつもり)
            int SFFlag = 0;
            bool RSFFlag = true;
            //マークを見る
            //それぞれのマークの枚数が5枚以上ならフラッシュ(5)
            int x = 0;
            while (x < Marks.Length)
            {
                if (Marks[x] >= 5)
                {
                    PlayerHandLevel = 5;
                    Debug.Log("フラッシュ");
                    SFFlag = SFFlag + 1;
                    break;
                }
                x++;
            }
            //数字を見る
            //ストレートの判定
            x = 0;
            int Straight = 0;
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
                    Debug.Log("ストレート");
                    SFFlag = SFFlag + 1;
                    break;
                }
                x++;
            }
            //特殊ストレート判定
            if(NumberManager[0] >= 1)
            {
                x = 0;
                while(x < 4)
                {
                    int Place = 9 + x;
                    if(NumberManager[Place] == 0)
                    {
                        RSFFlag = false;
                        break;
                    }
                    x++;
                }
            }
            //(ロイヤル)ストレートフラッシュの判定
            if (SFFlag == 2)
            {
                if(RSFFlag)
                {
                    PlayerHandLevel = 9;
                    Debug.Log("ロイヤルストレートフラッシュ");
                }
                else
                {
                    PlayerHandLevel = 8;
                    Debug.Log("ストレートフラッシュ");
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
                else if(PHand3 == 1 & PHand2 >= 1)
                {
                    PlayerHandLevel = 6;
                    Debug.Log("フルハウス");
                }
                else if(PHand3 == 1)
                {
                    PlayerHandLevel = 3;
                    Debug.Log("スリーカード");
                }
                else if(PHand2 == 2)
                {
                    PlayerHandLevel = 2;
                    Debug.Log("ツーペア");
                }
                else if(PHand2 == 1)
                {
                    PlayerHandLevel = 1;
                    Debug.Log("ワンペア");
                }
                else
                {
                    Debug.Log("ノーペア");
                }
            }
            //デバッグ用
            Debug.Log("ペア" + PHand2 + ":スリーカード" + PHand3 + ":HandLevel" + PlayerHandLevel);
        }
        
        //役の判定ここまで

        //ゲーム進行ここから

        //初期化処理
        private void InitGame()
        {
            RemoveCards();
            MakeCards();
            MakeLists();
            CheckhandLevels();
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
            }
            if (_Phase == GamePhase.ThirdBet)
            {
                TurnStackCard(2);
                //PhaseView(3);
            }
            if (_Phase == GamePhase.FinalBet)
            {
                TurnStackCard(3);
                //PhaseView(4);
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
            Debug.Log(_Phase);
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
