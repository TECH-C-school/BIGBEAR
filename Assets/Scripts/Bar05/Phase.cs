using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour {

    public GameObject card;
    public GameObject selectCard;

    public enum PhaseEnum
    {
        プリフロップ,
        フロップ,
        ターン,
        リバー,
        ショーダウン
    }

    public PhaseEnum phase;


    public string[] CardStr =
    {
            "s01", "s02", "s03", "s04", "s05", "s06", "s07", "s08", "s09", "s10", "s11", "s12", "s13",
        "h01", "h02", "h03", "h04", "h05", "h06", "h07", "h08", "h09", "h10", "h11", "h12", "h13",
        "d01", "d02", "d03", "d04", "d05", "d06", "d07", "d08", "d09", "d10", "d11", "d12", "d13",
        "c01", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "c13",

        };

    void Start()
    {
        MakeCard();
    }

	void Update ()
    {
        if (phase == PhaseEnum.プリフロップ)
        {
            
        }
	}

    private void MakeCard()
    {
        int[] randomNumbers = MakeRandomNumbers();

        var BoardCard = new GameObject("Board");
        var HandCard = new GameObject("Hand");
        var EnemyHand = new GameObject("EnemyHand");

        for (int i = 1;i <= 9; i++)
        {
            {
                var cardObject = Instantiate(card,transform.position,Quaternion.identity);
                var selCard = Instantiate(selectCard);
                selCard.name = selectCard.name;
                selCard.transform.parent = cardObject.transform;

                switch (i)
                {
                    case 1 :
                        cardObject.name = "Hand" + i;
                        cardObject.transform.position = new Vector3(-0.7f,-2.08f,-0.01f);
                        break;
                    case 2 :
                        cardObject.name = "Hand" + i;
                        cardObject.transform.position = new Vector3(0.65f, -2.08f, -0.01f);
                        break;
                    case 3:
                        cardObject.name = "Board 1";
                        cardObject.transform.position = new Vector3(-2.7f, 0, -0.01f);
                        break;
                    case 4:
                        cardObject.name = "Board 2";
                        cardObject.transform.position = new Vector3(-1.35f, 0, -0.01f);
                        break;
                    case 5:
                        cardObject.name = "Board 3";
                        cardObject.transform.position = new Vector3(0f, 0, -0.01f);
                        break;
                    case 6:
                        cardObject.name = "Board 4";
                        cardObject.transform.position = new Vector3(1.35f, 0, -0.01f);
                        break;
                    case 7:
                        cardObject.name = "Board 5";
                        cardObject.transform.position = new Vector3(2.7f, 0, -0.01f);
                        break;
                    case 8:
                        cardObject.name = "EnemyHand 1";
                        cardObject.transform.position = new Vector3(-0.7f, 2.08f, -0.01f);
                        break;
                    case 9:
                        cardObject.name = "EnemyHand 2";
                        cardObject.transform.position = new Vector3(0.65f, 2.08f, -0.01f);
                        break;
                }
            }
        }
    }

    public int[] MakeRandomNumbers()
    {
        int[] numbers = new int[52];
        return numbers;
    }

    void CreateCard()
    {
        
    }

    void handDeal()
    {
        
    }

}
