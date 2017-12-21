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
        h01, h02, h03, h04, h05, h06, h07, h08, h09, h10, h11, h12, h13,
        c01, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13

    }
    GameObject[] FloorCardHolder = new GameObject[28];//場に置かれるカード
    GameObject[] DeckcardHolder = new GameObject[24];//山札に置かれるカード
    GameObject[] MemoryCards = new GameObject[24];
    private GameObject selectCred;
    private Vector3 RecordPosition;
    private GameObject LoadBackCard;
    private GameObject BackCheckCard;
    private GameObject FloorCheckCard;
    private GameObject TurnDeckCard;
    private GameObject MakeCard;
    private GameObject MemoryDeckBackCard;
    private int deckcount;
    private int memory_deck_count;


    void Start()
    {
        MakeCardFlame();
        SetRandomCard();
        MakeStartCard();
    }

    void Update()
    {
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
        MakeCard = Instantiate(MemoryDeckBackCard, transform.position, Quaternion.identity);
        MakeCard.transform.position = new Vector3(-4.5f, 1.97f, -1);
        MemoryDeckBackCard.gameObject.SetActive(true);
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
                    MakeCard = Instantiate(FloorCardHolder[count], transform.position, Quaternion.identity);
                    MakeCard.transform.position = new Vector3(-4.5f + 1.5f * i, -0.1f - 0.15f * j, 0 - 1 * j);
                    //MakeCard.transform.parent = FloorCheckCard.transform;
                    count++;
                    break;
                }
                //先頭以外のカードは裏向きに表示する
                MakeCard = Instantiate(LoadBackCard, transform.position, Quaternion.identity);
                MakeCard.transform.position = new Vector3(-4.5f + 1.5f * i, -0.1f - 0.15f * j, 0 - 1 * j);
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
            //Debug.Log(MemoryDeckBackCard);
            DeckTrunCards();
            //Debug.Log("hogehoge");
            return;
        }

        RecordPosition = HitObject.transform.position;
        selectCred = HitObject.transform.gameObject;

    }

    /// <summary>
    /// クリックボタンを離したときにオブジェクトを元に戻すスクリプト
    /// </summary>
    private void ReturnCard()
    {
        if (!Input.GetMouseButtonUp(0)) return;
        if (!selectCred) return;
        selectCred.transform.position = RecordPosition;

        selectCred = null;

    }

    /// <summary>
    /// 山札からカードを生成する
    /// </summary>
    private void DeckTrunCards()
    {
        TurnDeckCard = GameObject.Find("DeckCards");
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
        for (int i = 0; i < 3; i++)
        {
            if (DeckcardHolder[deckcount] == null)
            {
                //MemoryDeckBackCard.gameObject.SetActive(false);
                Debug.Log("hogehoge");
                return;
            }
            MakeCard = Instantiate(DeckcardHolder[deckcount], transform.position, Quaternion.identity);
            MakeCard.transform.position = new Vector3(-3f + 0.2f * i, 1.97f, -14 - i);
            MemoryCards[deckcount] = MakeCard;
            Debug.Log(MemoryCards[deckcount]);
            deckcount++;

        }
    }
}