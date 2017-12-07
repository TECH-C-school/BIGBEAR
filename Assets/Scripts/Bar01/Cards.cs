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

    void Start()
    {
        MakeCardFlame();
        MakeStartCard();
    }


    void Update()
    {

    }


    /// <summary>
    /// カード置き場の生成
    /// </summary>
    void MakeCardFlame()
    {
        int count = 0;

        var Cardsmake = Resources.Load<GameObject>("Prefabs/Bar01/cardflame");
        var Marksmake_C = Resources.Load<GameObject>("Prefabs/Bar01/cardflame_c");
        var Marksmake_D = Resources.Load<GameObject>("Prefabs/Bar01/cardflame_d");
        var Marksmake_S = Resources.Load<GameObject>("Prefabs/Bar01/cardflame_s");
        var Marksmake_H = Resources.Load<GameObject>("Prefabs/Bar01/cardflame_h");

        var MarkPosition_C = Instantiate(Marksmake_C, transform.position, Quaternion.identity);
        var MarkPosition_D = Instantiate(Marksmake_D, transform.position, Quaternion.identity);
        var MarkPosition_S = Instantiate(Marksmake_S, transform.position, Quaternion.identity);
        var MarkPosition_H = Instantiate(Marksmake_H, transform.position, Quaternion.identity);

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
                    MarkPosition_D.transform.position = CardsObjectPosition.transform.position;
                    break;
                case 2:
                    CardsObjectPosition.transform.position = new Vector3(1.5f, 1.97f, 0);
                    MarkPosition_C.transform.position = CardsObjectPosition.transform.position;
                    break;
                case 3:
                    CardsObjectPosition.transform.position = new Vector3(3, 1.97f, 0);
                    MarkPosition_H.transform.position = CardsObjectPosition.transform.position;
                    break;
                case 4:
                    CardsObjectPosition.transform.position = new Vector3(4.5f, 1.97f, 0);
                    MarkPosition_S.transform.position = CardsObjectPosition.transform.position;
                    break;
            }
            count += 1;
        }
    }
    /// <summary>
    /// カードの生成
    /// </summary>
    void MakeStartCard()
    {
        //カード置き場にbackカードの生成
        var LoadCard = Resources.Load<GameObject>("Prefabs/Bar01/back");
        var CheckCard = GameObject.Find("Cards");

        int count = 0;
        int[] random = MakeRandomNumber();

        var MakeCard = Instantiate(LoadCard, transform.position, Quaternion.identity);
        MakeCard.transform.position = new Vector3(-4.5f, 1.97f, -1);
        MakeCard.transform.parent = CheckCard.transform;

        //場にカードをランダムに生成
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                //ランダムな数字と同じ列挙型の中にある値を呼び出す
                var Number = (Card)random[count];

                LoadCard = Resources.Load<GameObject>("Prefabs/Bar01/" + Number);
                MakeCard = Instantiate(LoadCard, transform.position, Quaternion.identity);

                MakeCard.transform.position = new Vector3(-4.5f + 1.5f * i, -0.1f - 0.1f * j, 0 - 0.1f * j);
                MakeCard.transform.parent = CheckCard.transform;

                count++;

                if (i == j)
                    break;
            }

        }
        //カード置き場にカードを生成
        for (int x = 0; x < 24; x++)
        {
            var Number = (Card)random[count];
            LoadCard = Resources.Load<GameObject>("Prefabs/Bar01/" + Number);
            MakeCard = Instantiate(LoadCard, transform.position, Quaternion.identity);

            MakeCard.transform.position = new Vector3(-4.5f, 1.97f, -1);
            MakeCard.transform.parent = CheckCard.transform;
            count++;
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