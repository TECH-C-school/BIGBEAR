using System.Collections;
using System.Collections.Generic;
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
    private int memory_deck_count;
    private int SelectCardNamber;//選択したカードのナンバーを入れる変数
    private int Memory_Card_Namber;//場に置かれてるカードのナンバーを入れる変数
    private int SecondLine_Count;//2列目のオブジェクトの配列カウント
    private int ThirdLine_Count;//3列目のオブジェクトの配列カウント
    private int FourthLine_Count;//4列目のオブジェクトの配列カウント
    private int FifthLine_Count;//5列目のオブジェクトの配列カウント
    private int SixthLine_Count;//6列目のオブジェクトの配列カウント
    private int SeventhLine_Count;//7列目のオブジェクトの配列カウント
    private int FloorCardHolder_Count;

    private bool OverlaidOK;//重ねていいならtrueになる変数


    void Start()
    {
        MakeCardFlame();
        SetRandomCard();
        MakeStartCard();
        OverlaidOK = false;
    }

    void Update()
    {
        if (0 < deckcount)
        {
            MemoryCards[deckcount - 1].GetComponent<BoxCollider2D>().enabled = true;
        }
        ClickCard();
        if (selectCred)
        {
            Vector3 setPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            setPosition.z = -14;
            selectCred.transform.position = setPosition;
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
            var CardsObjectPosition = Instantiate(Cardsmake, transform.position, Quaternion.identity);
            switch (count)
            {
                case 0:
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
                    //MakeCard.transform.parent = FloorCheckCard.transform;
                    if (i == 1)
                    {
                        SecondLine[j] = MakeCard;
                        SecondLine_Count++;
                    }
                    if (i == 2)
                    {
                        ThirdLine[j] = MakeCard;
                        ThirdLine_Count++;
                    }
                    if (i == 3)
                    {
                        FourthLine[j] = MakeCard;
                        FourthLine_Count++;
                    }
                    if (i == 4)
                    {
                        FifthLine[j] = MakeCard;
                        FifthLine_Count++;
                    }
                    if (i == 5)
                    {
                        SixthLine[j] = MakeCard;
                        SixthLine_Count++;
                    }
                    if (i == 6)
                    {
                        SeventhLine[j] = MakeCard;
                        SeventhLine_Count++;
                    }
                    FloorCardHolder_Count++;
                    break;
                }
                //先頭以外のカードは裏向きに表示する
                MakeCard = Instantiate(LoadBackCard, transform.position, Quaternion.identity);
                MakeCard.transform.position = new Vector3(-4.5f + 1.5f * i, -0.1f - 0.15f * j, 0 - 1 * j);
                if (i == 1)
                {
                    SecondLine[j] = MakeCard;
                    SecondLine_Count++;
                }
                if (i == 2)
                {
                    ThirdLine[j] = MakeCard;
                    ThirdLine_Count++;
                }
                if (i == 3)
                {
                    FourthLine[j] = MakeCard;
                    FourthLine_Count++;
                }
                if (i == 4)
                {
                    FifthLine[j] = MakeCard;
                    FifthLine_Count++;
                }
                if (i == 5)
                {
                    SixthLine[j] = MakeCard;
                    SixthLine_Count++;
                }
                if (i == 6)
                {
                    SeventhLine[j] = MakeCard;
                    SeventhLine_Count++;
                }
                //MakeCard.transform.parent = BackCheckCard.transform;

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

        var InputPosition = Input.mousePosition;

        if (!Input.GetMouseButtonDown(0)) return;

        var TapPoint = Camera.main.ScreenToWorldPoint(InputPosition);
        //Debug.Log(TapPoint);

        if (!Physics2D.OverlapPoint(TapPoint)) return;
        //Debug.Log("hogehoge");

        var HitObject = Physics2D.Raycast(TapPoint, -Vector3.up);
        //Debug.Log(HitObject.transform.name);
        TapPoint.z = -14;
        if (!HitObject) return;

        if (HitObject.transform.name == x)
        {
            if (DeckcardHolder[deckcount] == null)
            {
                HitObject.transform.position = new Vector3(-40.5f, 50, -1);
            }
            DeckTrunCards();
            return;
        }

        //if (HitObject == MemoryCards)
        RecordPosition = HitObject.transform.position;
        selectCred = HitObject.transform.gameObject;
        selectCred.GetComponent<BoxCollider2D>().enabled = false;
        var hoge = selectCred.GetComponentsInChildren<Transform>();
        foreach (Transform child in hoge)
        {
            //Debug.Log(child.name);
            Children_Card = child.transform.gameObject;
            Children_Card.GetComponent<BoxCollider2D>().enabled = false;

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


            //Debug.Log(Memory_Select_Cards.transform.name);
            InvestigateCard();
            OverlaidCard();
            if (OverlaidOK)
            {
                selectCred.transform.position = new Vector3(HitObject.transform.position.x, HitObject.transform.position.y - 0.3f, HitObject.transform.position.z - 1);
                selectCred.transform.parent = HitObject.transform;
                selectCred.GetComponent<BoxCollider2D>().enabled = true;
                SearchCard();
                TurnBackCard();
                selectCred = null;
                OverlaidOK = false;
                return;
            }
        }

        selectCred.transform.position = RecordPosition;
        selectCred.GetComponent<BoxCollider2D>().enabled = true;
        Children_Card.GetComponent<BoxCollider2D>().enabled = true;
        
        
        selectCred = null;
        Children_Card = null;


    }

    /// <summary>
    /// 山札からカードを生成する
    /// </summary>
    private void DeckTrunCards()
    {
        //TurnDeckCard = GameObject.Find("DeckCards");
        if (2 < deckcount)
        {
            /*
            for (int i = 0; i < 2; i++)
            {
                MemoryCards[memory_deck_count].transform.position = new Vector3(-10, 0, 0);
                //Debug.Log(MemoryCards[memory_deck_count].transform.position);
                memory_deck_count++;
            }

            MemoryCards[memory_deck_count].transform.position = new Vector3(-3f, 1.97f, -13);
            //Debug.Log(MemoryCards[memory_deck_count].transform.position);
            memory_deck_count++;

            /*
            TurnDeckCard.transform.position = new Vector3(-3f, 1.97f, 0 + - 1 * counter);
            counter++;
            MakeCard.transform.parent = TurnDeckCard.transform;

            Debug.Log(TurnDeckCard.transform.position);
            */
        }
        for (int x = 0; x < deckcount; x++)
        {
            MemoryCards[x].GetComponent<BoxCollider2D>().enabled = false;
        }
        for (int i = 0; i < 3; i++)
        {
            if (DeckcardHolder[deckcount] == null)
            {
                //MemoryDeckBackCard.SetActive(false);
                /*
                MemoryDeckBackCard.transform.position = new Vector3(100, 0, 1);
                Debug.Log(MemoryDeckBackCard.transform.position);
                */

                //MakeCard = Instantiate(MemoryDeckBackCard, transform.position, Quaternion.identity);
                //Debug.Log(MakeCard);
                //MakeCard.transform.position = new Vector3(-40.5f, 50, -1);

                //Destroy(MemoryDeckBackCard);
                //Debug.Log("hogehoge");
                return;
            }
            MakeCard = Instantiate(DeckcardHolder[deckcount], transform.position, Quaternion.identity);
            MakeCard.transform.position = new Vector3(-3f + 0.2f * i, 1.97f, -14 - i);
            MemoryCards[deckcount] = MakeCard;
            MemoryCards[deckcount].GetComponent<BoxCollider2D>().enabled = false;

            //Debug.Log(MemoryCards[deckcount]);
            deckcount++;
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
            var y = (Card)Card_Character[x];
            string hoge = y.ToString() + "(Clone)";
            //Debug.Log(hoge);
            if (hoge == Memory_Select_Cards.transform.name)
            {
                Memory_Card_Namber = (int)(Card)Card_Character[x];
                //Debug.Log(Memory_Card_Namber);

            }
            if (hoge == selectCred.transform.name)
            {
                ///Debug.Log(Memory_Select_Cards.transform.name);
                SelectCardNamber = (int)(Card)Card_Character[x];
                //Debug.Log(SelectCardNamber);
            }
        }
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
        Debug.Log("hogehoge");
        for (int x = 0; x < SecondLine.Length; x++)
        {
            if (SecondLine[x] == selectCred)
            {
                Debug.Log("hogehoge");
                SecondLine[x] = null;
            }
        }
            if (ThirdLine[x] == selectCred)
            {
                Debug.Log("hogehoge");
                ThirdLine[x] = null;
            }
            if (FourthLine[x] == selectCred)
            {
                Debug.Log("hogehoge");
                FourthLine[x] = null;
            }
            if (FifthLine[x] == selectCred)
            {
                Debug.Log("hogehoge");
                FifthLine[x] = null;
            }
            if (SixthLine[x] == selectCred)
            {
                Debug.Log("hogehoge");
                SixthLine[x] = null;
            }
            if (SeventhLine[x] == selectCred)
            {
                Debug.Log("hogehoge");
                SeventhLine[x] = null;
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
            MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
            MakeCard.transform.position = SecondLine[SecondLine_Count - 1].transform.position;
            SecondLine[SecondLine_Count - 1] = MakeCard;
            SecondLine_Count--;
            FloorCardHolder_Count++;
        }
        if (ThirdLine[ThirdLine_Count] == null)
        {
            MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
            MakeCard.transform.position = ThirdLine[ThirdLine_Count-1].transform.position;
            ThirdLine[ThirdLine_Count - 1] = MakeCard;
            ThirdLine_Count--;
            FloorCardHolder_Count++;
        }
        if (FourthLine[FourthLine_Count] == null)
        {
            MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
            MakeCard.transform.position = FourthLine[FourthLine_Count - 1].transform.position;
            FourthLine[FourthLine_Count-1] = MakeCard;
            FourthLine_Count--;
            FloorCardHolder_Count++;
        }
        if (FifthLine[FifthLine_Count] == null)
        {
            MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
            MakeCard.transform.position = FifthLine[FifthLine_Count].transform.position;
            FifthLine[FifthLine_Count-1] = MakeCard;
            FifthLine_Count--;
            FloorCardHolder_Count++;
        }
        if (SixthLine[SixthLine_Count] == null)
        {
            MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
            MakeCard.transform.position = SixthLine[SixthLine_Count - 1].transform.position;
            SixthLine[SixthLine_Count-1] = MakeCard;
            SixthLine_Count--;
            FloorCardHolder_Count++;
        }
        if (SeventhLine[SeventhLine_Count] == null)
        {
            MakeCard = Instantiate(FloorCardHolder[FloorCardHolder_Count], transform.position, Quaternion.identity);
            MakeCard.transform.position = SeventhLine[SeventhLine_Count].transform.position;
            SeventhLine[SeventhLine_Count-1] = MakeCard;
            SeventhLine_Count--;
            FloorCardHolder_Count++;
        }
    }
}