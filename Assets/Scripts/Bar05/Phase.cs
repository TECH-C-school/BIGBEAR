using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour {

    public GameObject card;

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
        card = Resources.Load("Prefabs/Bar05/back") as GameObject;
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

        var cardPrefab = Resources.Load<GameObject>("Prefab/Card");
        var BoardCard = new GameObject("Board");
        var HandCard = new GameObject("Hand");
        var EnemyHand = new GameObject("EnemyHand");

        for (int i = 0;i < 2; i++)
        {
            
            {
                var cardObject = Instantiate(cardPrefab,transform.position,Quaternion.identity);

                cardObject.transform.position = new Vector3();

                //cardObject.transform.parent = CreateCard.transform;
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
