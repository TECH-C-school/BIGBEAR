using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * 次回作業 --> Player1CardListのカード一覧をわかりやすく把握出来るようにする
 *              Player1CardList内のカードのマーク内訳を取り出す関数作成
 *              その他慣性でおなしゃす
 */

namespace Assets.Scripts.Bar05 {
    public class GameController : MonoBehaviour {

        private void Start()
        {
            MakeCards();
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
            //山札を作る
            int deckPlace = 0;
            int[] Deck = Cardsshuffle();

            //デバッグ用
            //**/for(int i = 0; i < Deck.Length; i++){Debug.Log(Deck[i]);} Debug.Log("--------------------");

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
                    Debug.Log("<color=red>相手のカード生成完了</color>");
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
                        //めんどくさいというか分かりづらいね
                        cardList_St[x - 1] = cardNum;
                    }
                    //役を判定する関数にカードリストを渡す
                    PlayerCards(StackCards, cardList_St);

                    Debug.Log("<color=yellow>場札のカード生成完了</color>");
                }
            }
        }
        /// <summary>
        /// カードのナンバー管理
        /// ここいる？
        /// </summary>
        private enum CardsNum
        {
            c01 = 0, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13,
            d01, d02, d03, d04, d05, d06, d07, d08, d09, d10, d11, d12, d13,
            h01, h02, h03, h04, h05, h06, h07, h08, h09, h10, h11, h12, h13,
            s01, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13,
        }
        /// <summary>
        /// カードをシャッフルする
        /// </summary>
        /// <returns></returns>
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

            //仮入れ
            CardLists(Player1Cards, Player1CardList);
        }

        //プレイヤーの役を作るための準備

        //変数置き場
        int[] Player1CardList = new int[7];
        int[] Player2CardList = new int[7];

        private void CardLists(int[]Player, int[] List)
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
            for(int i = 0; i < List.Length; i++)
            {
                Debug.Log(List[i]);
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
 * 判定アルゴリズム雑記
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
