using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cards : MonoBehaviour
{
    /// <summary>
    /// カードと同じ名前の列挙型
    /// </summary>
    public enum Card
    {
        s01 = 1, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13,
        d01, d02, d03, d04, d05, d06, d07, d08, d09, d10, d11, d12, d13,
        c01, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13,
        h01, h02, h03, h04, h05, h06, h07, h08, h09, h10, h11, h12, h13

    }
    GameObject[] FloorCardHolder = new GameObject[28];//場に置かれるカード
    GameObject[] DeckcardHolder = new GameObject[25];//山札に置かれるカード
    GameObject[] MemoryCards = new GameObject[24];//山札からめっくったカードを記録する
    GameObject[] SecondLine = new GameObject[2];//2列目のオブジェクトの配列
    GameObject[] ThirdLine = new GameObject[3];//3列目のオブジェクトの配列
    GameObject[] FourthLine = new GameObject[4];//4列目のオブジェクトの配列
    GameObject[] FifthLine = new GameObject[5];//5列目のオブジェクトの配列
    GameObject[] SixthLine = new GameObject[6];//6列目のオブジェクトの配列
    GameObject[] SeventhLine = new GameObject[7];//7列目のオブジェクトの配列

    int[] Card_Character = new int[52];//カードの名前を調べるときに使う配列

    private GameObject Horld;
    private GameObject deckbackcard;
    private GameObject selectCred;//マウスで選択してつかんだオブジェクト
    private Vector3 RecordPosition;// マウスで選択したつかんだオブジェクトの元々の場所を記録する
    private GameObject LoadBackCard;//裏向きのカードを読み込むときに使う変数
    private GameObject BackCheckCard;
    private GameObject FloorCheckCard;
    //private GameObject TurnDeckCard;
    private GameObject MakeCard;//場に出すカードを読み込むときに使う変数
    private GameObject MemoryDeckBackCard;//デッキの裏向きのカードを読み込むときに使う変数
    private GameObject Memory_Select_Cards;//重ねられるオブジェクトを入れる変数
    private GameObject Children_Card;//選択されたオブジェクトの子供を入れる変数

    private int deckcount;//デッキの中身をカウントする変数
    private int memory_deck_count; //場び出た山札のカードを記録する
    private int display_deck_card_count;
    private int display_deck_count;
    private int SelectCardNamber;//選択したカードのナンバーを入れる変数
    private int Memory_Card_Namber;//場に置かれてるカードのナンバーを入れる変数
    private int SecondLine_Count = 1;//2列目のオブジェクトの配列カウント
    private int ThirdLine_Count = 2;//3列目のオブジェクトの配列カウント
    private int FourthLine_Count = 3;//4列目のオブジェクトの配列カウント
    private int FifthLine_Count = 4;//5列目のオブジェクトの配列カウント
    private int SixthLine_Count = 5;//6列目のオブジェクトの配列カウント
    private int SeventhLine_Count = 6;//7列目のオブジェクトの配列カウント
    private int Clover_Next_Number = 27;
    private int Heart_Next_Number = 40;
    private int Diamond_Next_Number = 14;
    private int Spade_Next_NUmber = 1;
    private int FloorCardHolder_Count;
    private int gaga;
    private int gennkai;

    private bool OverlaidOK;//重ねていいならtrueになる変数
    private bool SetOK;
    private bool exception;
    private bool is_King;
    private bool Mystery;
    private bool stop;
    private bool Cancell;

    void Start()
    {
        gennkai++;
        MakeCardFlame();
        SetRandomCard();
        MakeStartCard();
        OverlaidOK = false;
    }

    void Update()
    {
        ClickCard();
        if (selectCred)
        {
            Vector3 setPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            setPosition.z = -70;
            selectCred.transform.position = setPosition;
        }
        if (0 < deckcount)
        {
            if (exception == false)
            {
                if (memory_deck_count != 0)
                {
                    MemoryCards[memory_deck_count - 1].GetComponent<BoxCollider2D>().enabled = true;
                    //Debug.Log(MemoryCards[memory_deck_count - 1]);
                }
            }
            //Debug.Log(display_deck_card_count);
            if (display_deck_card_count == 0)
            {
                //Debug.Log(display_deck_card_count);
                for (int x = 0; x < 3; x++)
                {
                    //Debug.Log("hoge");
                    //Debug.Log(DeckcardHolder[deckcount -1]);
                    if (DeckcardHolder[deckcount - 1] != null)
                    {
                        Debug.Log("hpge");
                        break;
                    }

                    if (memory_deck_count < 0)
                    {
                        Debug.Log("hpge");
                        break;
                    }

                    if (display_deck_count == 0)
                    {
                        Debug.Log("hpge");
                        break;
                    }
                    Debug.Log(MemoryCards[memory_deck_count]);
                    if (MemoryCards[memory_deck_count - x - 1] == null)
                    {
                        Debug.Log("hpge");
                        break;
                    }
                    Debug.Log("hoge");
                    MemoryCards[memory_deck_count - x - 1].transform.position = new Vector3(-3f + 0.6f - 0.2f * x, 1.97f, -5 + 1 * x);
                    display_deck_card_count++;
                    Debug.Log(display_deck_count);
                }
            }
        }
        ReturnCard();
    }

    /// <summary>
    /// カード置き場の生成
    /// </summary>
    private void MakeCardFlame()
    {
        int count = 0;
        var Cardsmake = Resources.Load<GameObject>("Prefabs/Bar01/cardflame");//カード置き場の枠のprefabを参照

        GameObject MarksMake = Resources.Load<GameObject>("Prefabs/Bar01/cardflame_c");//マークのprefabを参照

        var MarkPosition = Instantiate(MarksMake, transform.position, Quaternion.identity);
        for (int i = 0; i < 5; i++)
        {
            Cardsmake = Resources.Load<GameObject>("Prefabs/Bar01/cardflame");
            var CardsObjectPosition = Instantiate(Cardsmake, transform.position, Quaternion.identity);
            switch (count)
            {
                case 0:
                    Cardsmake = Resources.Load<GameObject>("Prefabs/Bar01/deck_cardflame");
                    CardsObjectPosition = Instantiate(Cardsmake, transform.position, Quaternion.identity);
                    CardsObjectPosition.transform.position = new Vector3(-4.5f, 1.97f, 0);
                    break;
                case 1:
                    CardsObjectPosition.transform.position = new Vector3(0, 1.97f, 0);
                    MarkPosition = Instantiate(MarksMake, transform.position, Quaternion.identity);
                    MarkPosition.transform.position = CardsObjectPosition.transform.position;
                    break;
                case 2:
                    CardsObjectPosition.transform.position = new Vector3(1.5f, 1.97f, 0);
                    MarksMake = Resources.Load<GameObject>("Prefabs/Bar01/cardflame_d");
                    MarkPosition = Instantiate(MarksMake, transform.position, Quaternion.identity);
                    MarkPosition.transform.position = CardsObjectPosition.transform.position;
                    break;
                case 3:
                    CardsObjectPosition.transform.position = new Vector3(3, 1.97f, 0);
                    MarksMake = Resources.Load<GameObject>("Prefabs/Bar01/cardflame_s");
                    MarkPosition = Instantiate(MarksMake, transform.position, Quaternion.identity);
                    MarkPosition.transform.position = CardsObjectPosition.transform.position;
                    break;
                case 4:
                    CardsObjectPosition.transform.position = new Vector3(4.5f, 1.97f, 0);
                    MarksMake = Resources.Load<GameObject>("Prefabs/Bar01/cardflame_h");
                    MarkPosition = Instantiate(MarksMake, transform.position, Quaternion.identity);
                    MarkPosition.transform.position = CardsObjectPosition.transform.position;
                    break;
            }
            count += 1;
        }
    }

    /// <summary>
    /// 52枚のカードの情報を取得
    /// </summary>
    private void SetRandomCard()
    {
        var CheckCard = GameObject.Find("FloorCards");
        var DeckCheckCard = GameObject.Find("DeckCards");
        int count = 0;
        int deckcount = 0;
        int[] random = MakeRandomNumber();
        GameObject LoadCard = null;

        //カードをランダムに場と山札に置くfor文
        for (int i = 0; i < 52; i++)
        {
            var Number = (Card)random[count];
            //countが28から山札に置くif文
            if (27 < count)
            {
                LoadCard = Resources.Load<GameObject>("Prefabs/Bar01/" + Number);
                DeckcardHolder[deckcount] = LoadCard;
                //Debug.Log(DeckcardHolder[deckcount]);
                deckcount++;
            }
            //countが27までの場に置かれるカードのif文
            if (count < 28)
            {
                LoadCard = Resources.Load<GameObject>("Prefabs/Bar01/" + Number);
                FloorCardHolder[count] = LoadCard;
                //Debug.Log(FloorCardHolder[count]);
            }
            count++;
        }
    }

    /// <summary>
    /// 場にカードの生成
    /// </summary>
    public void MakeStartCard()
    {
        BackCheckCard = GameObject.Find("BackCards");
        FloorCheckCard = GameObject.Find("FloorCards");
        //カード置き場にbackカードの生成
        MemoryDeckBackCard = Resources.Load<GameObject>("Prefabs/Bar01/deckback");
        //MemoryDeckBackCard.transform.position = new Vector3(-4.5f,1.97f,5);
        //Debug.Log(MemoryDeckBackCard.transform.position);
        MakeCard = Instantiate(MemoryDeckBackCard, transform.position, Quaternion.identity);
        MakeCard.transform.position = new Vector3(-4.5f, 1.97f, -1);
        MemoryDeckBackCard.SetActive(true);
        LoadBackCard = Resources.Load<GameObject>("Prefabs/Bar01/back");

        //表のカードを生成する
        int count = 0;
        //場にカードを生成
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                //場のカードの列の先頭に表のカードを表示する
                if (i == j)
                {
                    MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
                    MakeCard.transform.position = new Vector3(-4.5f + 1.5f * i, -0.1f - 0.15f * j, 0 - 1 * j);
                    if (i == 1)
                    {
                        SecondLine[j] = MakeCard;
                    }
                    if (i == 2)
                    {
                        ThirdLine[j] = MakeCard;
                    }
                    if (i == 3)
                    {
                        FourthLine[j] = MakeCard;
                    }
                    if (i == 4)
                    {
                        FifthLine[j] = MakeCard;
                    }
                    if (i == 5)
                    {
                        SixthLine[j] = MakeCard;
                    }
                    if (i == 6)
                    {
                        SeventhLine[j] = MakeCard;
                    }
                    FloorCardHolder_Count++;
                    break;
                }
                //先頭以外のカードは裏向きに表示する
                MakeCard = Instantiate(LoadBackCard, transform.position, Quaternion.identity);
                MakeCard.transform.position = new Vector3(-4.5f + 1.5f * i, -0.1f - 0.15f * j, 0 - 1 * j);

                if (i == 1)
                {
                    SecondLine[j] = MakeCard; ;
                }
                if (i == 2)
                {
                    ThirdLine[j] = MakeCard;
                }
                if (i == 3)
                {
                    FourthLine[j] = MakeCard;
                }
                if (i == 4)
                {
                    FifthLine[j] = MakeCard;
                }
                if (i == 5)
                {
                    SixthLine[j] = MakeCard;
                }
                if (i == 6)
                {
                    SeventhLine[j] = MakeCard;
                }
            }
        }
    }

    /// <summary>
    /// ランダムな数字を生成
    /// </summary>
    int[] MakeRandomNumber()
    {
        int[] card = new int[52];

        for (int i = 0; i < 52; i++)
        {
            card[i] = i + 1;

            Card_Character[i] = i + 1;

        }

        int count = 0;
        for (int i = 0; i < 52; i++)
        {
            int index = Random.Range(i, card.Length);
            var tmp = card[i];
            card[i] = card[index];
            card[index] = tmp;
            count++;
        }
        return card;
    }

    /// <summary>
    ///クリック中にオブジェクトを移動するスクリプト
    /// </summary>
    private void ClickCard()
    {
        string x = "deckback(Clone)";
        string y = "deck_cardflame(Clone)";

        var InputPosition = Input.mousePosition;

        if (!Input.GetMouseButtonDown(0)) return;

        var TapPoint = Camera.main.ScreenToWorldPoint(InputPosition);
        Debug.Log(TapPoint);

        if (!Physics2D.OverlapPoint(TapPoint)) return;
        Debug.Log("hogehoge");

        var HitObject = Physics2D.Raycast(TapPoint, -Vector3.up);
        Debug.Log(HitObject.transform.name);
        TapPoint.z = -14;
        if (!HitObject) return;

        if (HitObject.transform.name == x)
        {
            if (DeckcardHolder[deckcount] == null)
            {
                HitObject.transform.position = new Vector3(-40.5f, 50, -1);
                Horld = HitObject.transform.gameObject;
                return;
            }

            DeckTrunCards();
            return;
        }

        selectCred = HitObject.transform.gameObject;
        //ResetDeckCard();
        investigateCard_select();

        if (Cancell == true)
        {
            if (selectCred.transform.name == y)
            {
                if (DeckcardHolder[deckcount] == null)
                {
                    ResetDeckCard();
                }
            }
            selectCred = null;
            Cancell = false;
            return;
        }

        RecordPosition = HitObject.transform.position;
        Debug.Log(selectCred.transform.gameObject.name);
        selectCred.GetComponent<BoxCollider2D>().enabled = false;
        var hoge = selectCred.GetComponentsInChildren<Transform>();
        foreach (Transform child in hoge)
        {
            Children_Card = child.transform.gameObject;
            Children_Card.GetComponent<BoxCollider2D>().enabled = false;
            exception = true;

        }

    }

    /// <summary>
    /// クリックボタンを離したときにオブジェクトを元に戻すスクリプト
    /// </summary>
    private void ReturnCard()
    {
        var InputPosition = Input.mousePosition;

        if (!Input.GetMouseButtonUp(0)) return;
        if (!selectCred) return;
        var TapPoint = Camera.main.ScreenToWorldPoint(InputPosition);
        if (Physics2D.OverlapPoint(TapPoint))
        {
            var HitObject = Physics2D.Raycast(TapPoint, -Vector3.up);
            Memory_Select_Cards = HitObject.transform.gameObject;
            Debug.Log(Memory_Select_Cards);

            //Debug.Log(Memory_Select_Cards.transform.name);
            InvestigateCard();
            Debug.Log("hoge");
            OverlaidCard();
            Debug.Log("hoge");
            SetMarkPlace();
            Debug.Log("hoge");
            SetKingPosition();
            Debug.Log("hoge");
            if (OverlaidOK)
            {
                selectCred.transform.position = new Vector3(HitObject.transform.position.x, HitObject.transform.position.y - 0.17f, HitObject.transform.position.z - 1);
                selectCred.transform.parent = HitObject.transform;
                selectCred.GetComponent<BoxCollider2D>().enabled = true;
                SearchCard();
                TurnBackCard();

                if (Mystery)
                {
                    if (MemoryCards[memory_deck_count - 1] != null)
                    {
                        if (selectCred.transform.gameObject == MemoryCards[memory_deck_count - 1].transform.gameObject)
                        {
                            MemoryCards[memory_deck_count - 1] = null;
                            memory_deck_count--;
                            display_deck_card_count--;
                            //Debug.Log(display_deck_card_count);
                        }
                    }
                }
                exception = false;
                selectCred = null;
                OverlaidOK = false;
                return;
            }
            if (SetOK)
            {
                selectCred.transform.position = new Vector3(HitObject.transform.position.x, HitObject.transform.position.y, HitObject.transform.position.z - 10 - gaga);
                SearchCard();
                TurnBackCard();
                if (Mystery)
                {
                    if (selectCred.transform.gameObject == MemoryCards[memory_deck_count - 1].transform.gameObject)
                    {
                        MemoryCards[memory_deck_count - 1] = null;
                        memory_deck_count--;
                        display_deck_card_count--;
                        //Debug.Log(display_deck_card_count);
                    }
                }
                selectCred = null;
                SetOK = false;
                exception = false;
                gaga++;
                return;
            }
            if (is_King)
            {
                selectCred.transform.position = new Vector3(HitObject.transform.position.x, HitObject.transform.position.y, HitObject.transform.position.z - 1);
                SearchCard();
                selectCred.GetComponent<BoxCollider2D>().enabled = true;
                TurnBackCard();
                if (Mystery)
                {
                    if (selectCred.transform.gameObject == MemoryCards[memory_deck_count - 1].transform.gameObject)
                    {
                        MemoryCards[memory_deck_count - 1] = null;
                        memory_deck_count--;
                        display_deck_card_count--;
                        //Debug.Log(display_deck_card_count);
                    }
                }
                selectCred = null;
                is_King = false;
                exception = false;
                return;
            }
        }

        selectCred.transform.position = RecordPosition;
        selectCred.GetComponent<BoxCollider2D>().enabled = true;
        Children_Card.GetComponent<BoxCollider2D>().enabled = true;

        //ResetDeckCard();
        exception = false;
        selectCred = null;
        Children_Card = null;

    }

    /// <summary>
    /// 山札からカードを生成する
    /// </summary>
    private void DeckTrunCards()
    {
        Mystery = true;
        stop = true;
        display_deck_card_count = 0;
        //Debug.Log(display_deck_card_count);
        for (int x = 0; x < memory_deck_count; x++)
        {
            if (MemoryCards[x] == null)
                break;
            //Debug.Log("hoge");
            MemoryCards[x].transform.position = new Vector3(100, 100, 0);
            //Debug.Log(MemoryCards[x].transform.name);
        }
        for (int x = 0; x < deckcount; x++)
        {
            //Debug.Log("hoge");
            if (MemoryCards[x] == null)
                break;
            MemoryCards[x].GetComponent<BoxCollider2D>().enabled = false;
        }
        for (int i = 0; i < 3; i++)
        {
            if (DeckcardHolder[deckcount] == null)
                return;

            MakeCard = Instantiate(DeckcardHolder[deckcount], transform.position, Quaternion.identity);
            MakeCard.transform.position = new Vector3(-3f + 0.2f * i, 1.97f, -10 - i);
            MemoryCards[memory_deck_count] = MakeCard;
            MemoryCards[memory_deck_count].GetComponent<BoxCollider2D>().enabled = false;
            DeckcardHolder[deckcount] = null;

            //Debug.Log(MemoryCards[deckcount].transform.name);
            deckcount++;
            memory_deck_count++;
            display_deck_card_count++;
            display_deck_count++;
            //Debug.Log(display_deck_card_count);
            stop = false;
            //Debug.Log(deckcount);
        }
    }

    /// <summary>
    /// カードを調べる
    /// </summary>
    private void InvestigateCard()
    {
        for (int x = 0; x < 52; x++)
        {
            string huga = "(Clone)";
            //string xx ;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < gennkai; i++) sb.Append("(Clone)");
            huga = huga.Replace("(Clone)", sb.ToString());
            //Debug.Log(huga);
            var y = (Card)Card_Character[x];
            string hoge = y.ToString() + "(Clone)";
            string gehogeho = y.ToString() + huga;
            //Debug.Log(hoge);
            if (hoge == Memory_Select_Cards.transform.name)
            {
                Memory_Card_Namber = (int)(Card)Card_Character[x];
                Debug.Log(Memory_Card_Namber);

            }
            if (gehogeho == Memory_Select_Cards.transform.name)
            {
                Memory_Card_Namber = (int)(Card)Card_Character[x];
                Debug.Log(Memory_Card_Namber);

            }
        }
    }


    private void investigateCard_select()
    {
        for (int x = 0; x < 52; x++)
        {
            string huga = "(Clone)";
            //string xx ;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < gennkai; i++) sb.Append("(Clone)");
            huga = huga.Replace("(Clone)", sb.ToString());
            //Debug.Log(huga);
            var y = (Card)Card_Character[x];
            string hoge = y.ToString() + "(Clone)";
            string gehogeho = y.ToString() + huga;
            //Debug.Log(hoge);
            if (hoge == selectCred.transform.name)
            {
                ///Debug.Log(Memory_Select_Cards.transform.name);
                SelectCardNamber = (int)(Card)Card_Character[x];
                return;
                //Debug.Log(SelectCardNamber);
            }
            if (gehogeho == selectCred.transform.name)
            {
                ///Debug.Log(Memory_Select_Cards.transform.name);
                SelectCardNamber = (int)(Card)Card_Character[x];
                return;
            }
        }
        Cancell = true;
    }
    /// <summary>
    /// 重ねていいか調べる
    /// </summary>
    private void OverlaidCard()
    {
        //Debug.Log("hoge");
        if (0 < SelectCardNamber)
        {
            if (SelectCardNamber < 14)
            {
                if (Memory_Card_Namber == SelectCardNamber + 14)
                {
                    //Debug.Log("hogehoge");
                    OverlaidOK = true;
                }
                if (Memory_Card_Namber == SelectCardNamber + 40)
                {
                    //Debug.Log("hogehoge");
                    OverlaidOK = true;
                }
            }

        }
        if (13 < SelectCardNamber)
        {
            if (SelectCardNamber < 27)
            {
                if (Memory_Card_Namber == SelectCardNamber - 12)
                {
                    //Debug.Log("hogehoge");
                    OverlaidOK = true;
                }
                if (Memory_Card_Namber == SelectCardNamber + 14)
                {
                    //Debug.Log("hogehoge");
                    OverlaidOK = true;
                }
            }

        }
        if (26 < SelectCardNamber)
        {
            if (SelectCardNamber < 40)
            {
                if (Memory_Card_Namber == SelectCardNamber - 12)
                {
                    //Debug.Log("hogehoge");
                    OverlaidOK = true;
                }
                if (Memory_Card_Namber == SelectCardNamber + 14)
                {
                    //Debug.Log("hogehoge");
                    OverlaidOK = true;
                }
            }
        }
        if (39 < SelectCardNamber)
        {
            if (Memory_Card_Namber == SelectCardNamber - 12)
            {
                //Debug.Log("hogehoge");
                OverlaidOK = true;
            }
            if (Memory_Card_Namber == SelectCardNamber - 38)
            {
                //Debug.Log("hogehoge");
                OverlaidOK = true;
            }
        }
    }

    /// <summary>
    /// 場にあるカードが移動したときに裏カードの次のカードだったら配列からカードを消す
    /// </summary>
    private void SearchCard()
    {
        //Debug.Log("hogehoge");
        for (int x = 0; x < SecondLine.Length; x++)
        {
            if (SecondLine[x] == selectCred)
            {
                Debug.Log("hogehoge");
                SecondLine[x] = null;
            }
        }
        for (int y = 0; y < ThirdLine.Length; y++)
        {
            if (ThirdLine[y] == selectCred)
            {
                Debug.Log("hogehoge");
                ThirdLine[y] = null;
            }
        }
        for (int z = 0; z < FourthLine.Length; z++)
        {
            if (FourthLine[z] == selectCred)
            {
                Debug.Log("hogehoge");
                FourthLine[z] = null;
            }

        }
        for (int o = 0; o < FifthLine.Length; o++)
        {
            if (FifthLine[o] == selectCred)
            {
                Debug.Log("hogehoge");
                FifthLine[o] = null;
            }
        }
        for (int v = 0; v < SixthLine.Length; v++)
        {
            if (SixthLine[v] == selectCred)
            {
                Debug.Log("hogehoge");
                SixthLine[v] = null;
            }
        }
        for (int c = 0; c < SeventhLine.Length; c++)
        {
            if (SeventhLine[c] == selectCred)
            {
                Debug.Log("hogehoge");
                SeventhLine[c] = null;
            }
        }

    }

    /// <summary>
    /// 裏向きのカードを表にする
    /// </summary>
    private void TurnBackCard()
    {
        if (SecondLine[SecondLine_Count] == null)
        {
            if (0 < SecondLine_Count)
            {
                SecondLine_Count--;
                MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
                MakeCard.transform.position = SecondLine[SecondLine_Count].transform.position;
                Destroy(SecondLine[SecondLine_Count]);
                SecondLine[SecondLine_Count] = MakeCard;
                FloorCardHolder_Count++;
            }
        }
        if (ThirdLine[ThirdLine_Count] == null)
        {
            if (0 < ThirdLine_Count)
            {
                ThirdLine_Count--;
                MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
                MakeCard.transform.position = ThirdLine[ThirdLine_Count].transform.position;
                Destroy(ThirdLine[ThirdLine_Count]);
                ThirdLine[ThirdLine_Count] = MakeCard;
                FloorCardHolder_Count++;
            }
        }
        if (FourthLine[FourthLine_Count] == null)
        {
            if (FourthLine_Count > 0)
            {
                FourthLine_Count--;
                MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
                MakeCard.transform.position = FourthLine[FourthLine_Count].transform.position;
                Destroy(FourthLine[FourthLine_Count]);
                FourthLine[FourthLine_Count] = MakeCard;
                FloorCardHolder_Count++;
            }
        }
        if (FifthLine[FifthLine_Count] == null)
        {
            if (FifthLine_Count > 0)
            {
                FifthLine_Count--;
                MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
                MakeCard.transform.position = FifthLine[FifthLine_Count].transform.position;
                Destroy(FifthLine[FifthLine_Count]);
                FifthLine[FifthLine_Count] = MakeCard;
                FloorCardHolder_Count++;
            }
        }
        if (SixthLine[SixthLine_Count] == null)
        {
            if (SixthLine_Count > 0)
            {
                SixthLine_Count--;
                MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
                MakeCard.transform.position = SixthLine[SixthLine_Count].transform.position;
                Destroy(SixthLine[SixthLine_Count]);
                SixthLine[SixthLine_Count] = MakeCard;
                FloorCardHolder_Count++;
            }
        }
        if (SeventhLine[SeventhLine_Count] == null)
        {
            if (SeventhLine_Count > 0)
            {
                SeventhLine_Count--;
                MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
                MakeCard.transform.position = SeventhLine[SeventhLine_Count].transform.position;
                Destroy(SeventhLine[SeventhLine_Count]);
                SeventhLine[SeventhLine_Count] = MakeCard;
                FloorCardHolder_Count++;
            }
        }
    }

    /// <summary>
    ///　マーク置き場に置くカードと持っているカードが一致しているか調べる
    /// </summary>
    private void SetMarkPlace()
    {
        if (Memory_Select_Cards.transform.name == "cardflame_c(Clone)")
        {
            if (SelectCardNamber == Clover_Next_Number)
            {
                SetOK = true;
                if (Clover_Next_Number < 40)
                    Clover_Next_Number++;
            }
        }
        if (Memory_Select_Cards.transform.name == "cardflame_d(Clone)")
        {
            if (SelectCardNamber == Diamond_Next_Number)
            {
                SetOK = true;
                if (Diamond_Next_Number < 27)
                    Diamond_Next_Number++;
            }
        }
        if (Memory_Select_Cards.transform.name == "cardflame_s(Clone)")
        {
            if (SelectCardNamber == Spade_Next_NUmber)
            {
                SetOK = true;
                if (Spade_Next_NUmber < 14)
                    Spade_Next_NUmber++;
            }
        }
        if (Memory_Select_Cards.transform.name == "cardflame_h(Clone)")
        {
            if (SelectCardNamber == Heart_Next_Number)
            {
                SetOK = true;
                Heart_Next_Number++;
            }
        }
    }

    /// <summary>
    /// 13のカードのみ反応するようにする関数
    /// </summary>
    private void SetKingPosition()
    {
        if (Memory_Select_Cards.transform.name == "King Place")
        {
            if (SelectCardNamber == 13)
            {
                is_King = true;
            }
            if (SelectCardNamber == 26)
            {
                is_King = true;
            }
            if (SelectCardNamber == 39)
            {
                is_King = true;
            }
            if (SelectCardNamber == 52)
            {
                is_King = true;
            }
        }
    }

    /// <summary>
    /// 場に出ているカードをデッキに戻す
    /// </summary>
    private void ResetDeckCard()
    {
        if (selectCred.transform.name == "deck_cardflame(Clone)")
        {
            if (DeckcardHolder[deckcount] == null)
            {
                for (int x = 0; x < memory_deck_count; x++)
                {
                    DeckcardHolder[x] = MemoryCards[x];
                    Debug.Log(DeckcardHolder[x].transform.name);
                    MemoryCards[x].transform.position = new Vector3(100, 100, 0);
                    MemoryCards[x] = null;
                }
                deckcount = 0;
                memory_deck_count = 0;
                display_deck_card_count = 0;
                display_deck_count = 0;
                Horld.transform.position = new Vector3(-4.5f, 1.97f, -1);
                selectCred.transform.position = new Vector3(-4.5f, 1.97f, 0);
                Horld = null;
                //exception = true;
                gennkai++;
            }
        }
    }
}