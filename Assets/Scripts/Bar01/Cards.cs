using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    class Makecard
    {
        public int[] c = new int[13];
        public int[] d = new int[13];
        public int[] h = new int[13];
        public int[] s = new int[13];
    }

    void Start()
    {
        MakeCardFlame();
        MakeStartCard();
    }


    void Update()
    {

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
        int counter = 0;
        int array = 0;
        for (int i = 0; i < 8; i++)
        {
            var MakeCard = Instantiate(LoadCard, transform.position, Quaternion.identity);
            switch (counter)
            {
                case 0:
                    MakeCard.transform.position = new Vector3(-4.5f, 1.97f, -1);
                    break;
                case 1:
                    MakeCard.transform.position = new Vector3(-4.5f, 0, 0);
                    break;
                case 2:
                        MakeCard.transform.position = new Vector3(-3, 0, 0);     
                    break;
                case 3:
                    MakeCard.transform.position = new Vector3(-1.5f, 0, 0);
                    break;
                case 4:
                    MakeCard.transform.position = new Vector3(0, 0, 0);
                    break;
                case 5:
                    MakeCard.transform.position = new Vector3(1.5f, 0, 0);
                    break;
                case 6:
                    MakeCard.transform.position = new Vector3(3, 0, 0);
                    break;
                case 7:
                    MakeCard.transform.position = new Vector3(4.5f, 0, 0);
                    break;
            }
            counter += 1;
        }
    }
    int[] MakeRandomNumber()
    {
        int[] number = new int[13];
        for (int i = 0; i < 13; i++)
        {
            number[i] = i + 1;
        }
        int count = 0;
        while (count < 13)
        {
            var index = Random.Range(count, number.Length);
            var tmp = number[count];
            number[count] = number[index];
            number[index] = tmp;

            count++;
        }
        return number;
    }
}
