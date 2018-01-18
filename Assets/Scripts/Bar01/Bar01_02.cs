using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar01_02 : MonoBehaviour
{
    public enum card
    {
        c01 = 1, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13,
        d01, d02, d03, d04, d05, d06, d07, d08, d09, d10, d11, d12, d13,
        s01, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13,
        h01, h02, h03, h04, h05, h06, h07, h08, h09, h10, h11, h12, h13
    }
    void Start()
    {

    }

    void Update()
    {

    }

    //カードのシャッフル
    private int[] MakeNumberShufflecard()
    {
        int[] card = new int[52];

        for (int i = 0; i < card.Length; i++)
        {
            card[i] = i + 1;
        }

        for (int j = 0; j < card.Length; j++)
        {
            int index = Random.Range(j, card.Length);
            int tmp = card[j];
            card[j] = card[index];
            card[index] = card[j];
        }
        return card;
    }

    //場にカードを並べる
    private void MakeCard()
    {

    }
    //裏のカードを表にする

    //
}
