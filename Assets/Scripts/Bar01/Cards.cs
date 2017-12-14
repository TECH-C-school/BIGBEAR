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

    void Start()
    {
        MakeCardFlame();
        SetRandomCard();
        MakeStartCard();
    }

    /// <summary>
    /// カード置き場の生成
    /// </summary>
    void MakeCardFlame()
    {
        int count = 0;
        var Cardsmake = Resources.Load<GameObject>("Prefabs/Bar01/cardflame");//カード置き場の枠のprefabを参照

        GameObject MarksMake = Resources.Load<GameObject>("Prefabs/Bar01/cardflame_c");//マークのprefabを参照

        var MarkPosition = Instantiate(MarksMake,transform.position,Quaternion.identity);
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
        for (int i = 0; i <52; i++)
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
        //カード置き場にbackカードの生成
        var LoadBackCard = Resources.Load<GameObject>("Prefabs/Bar01/back");
        var BackCheckCard = GameObject.Find("BackCards");
        var FloorCheckCard = GameObject.Find("FloorCards");
        var MakeCard = Instantiate(LoadBackCard, transform.position, Quaternion.identity);
        MakeCard.transform.position = new Vector3(-4.5f, 1.97f, -1);
        MakeCard.transform.parent = BackCheckCard.transform;

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
                    MakeCard.transform.parent = FloorCheckCard.transform;
                    count++;
                    break;
                }
               //先頭以外のカードは裏向きに表示する
                MakeCard = Instantiate(LoadBackCard, transform.position, Quaternion.identity);
                MakeCard.transform.position = new Vector3(-4.5f + 1.5f * i, -0.1f - 0.15f * j, 0 - 1 * j);
                MakeCard.transform.parent = BackCheckCard.transform;

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
}