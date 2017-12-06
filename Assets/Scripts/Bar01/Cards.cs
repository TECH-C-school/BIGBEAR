using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    enum x
    {
        s01 = 1,s02,s03,s04,s05,s06,s07,s08,s09,s10,s11,s12,s13,
        d01,d02,d03,d04,d05,d06,d07,d08,d09,d10,d11,d12,d13,
        h01,h02,h03,h04,h05,h06,h07,h08,h09,h10,h11,h12,h13,
        c01,c02,c03,c04,c05,c06,c07,c08,c09,c10,c11,c12,c13

    }

    void Start()
    {
        MakeCardFlame();
        MakeStartCard();
        hogehoge();
    }


    void Update()
    {

    }

    void hogehoge()
    {
        int counter = 0;
        int fugafuga = MakeRandomNumber();s
        for (int i = 0; i < 52; i++)
        {
            Debug.Log(fugafuga[counter]);
            counter++;
        }
    }
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
    void MakeStartCard()
    {
        var LoadCard = Resources.Load<GameObject>("Prefabs/Bar01/back");
        var CheckCard = GameObject.Find("Cards");

        var MakeCard = Instantiate(LoadCard, transform.position, Quaternion.identity);
        MakeCard.transform.position = new Vector3(-4.5f, 1.97f, -1);
        MakeCard.transform.parent = CheckCard.transform;

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                MakeCard = Instantiate(LoadCard, transform.position, Quaternion.identity);

                MakeCard.transform.position = new Vector3(-4.5f + 1.5f * i, 0 - 0.1f * j, 0 - 0.1f * j);
                MakeCard.transform.parent = CheckCard.transform;
                if (i == j)
                    break;
            }

        }
    }
    string[] MakeRandomNumber()
    {
        int[] card = new int[13];
        char[] mark = new char[4];
        string[] cardmark = new string[52];

        mark[0] = 'c';
        mark[1] = 'd';
        mark[2] = 'h';
        mark[3] = 's';

        for (int i = 0; i < 13; i++)
        {
            card[i] = i + 1;
        }

        int count = 0;
        int x = 0;
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                int index = Random.Range(i, card.Length);
                var tmp = card[i];
                card[i] = card[index];
                card[index] = tmp;

                int memory = Random.Range(j, mark.Length);
                char storage = mark[j];
                mark[j] = mark[memory];
                mark[memory] = storage;

                cardmark[count] = mark[j].ToString() + card[i].ToString();
                x++;
            }
            count++;
            x = 0;
        }
        return cardmark;
    }
}