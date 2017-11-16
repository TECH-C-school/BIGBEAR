using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar0404
{

    public class trump_cards_bar0404{
        //トランプの列挙型を作成
        public enum trumpCard
        {
            c01 =1, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13,
            d01, d02, d03, d04, d05, d06, d07, d08, d09, d10, d11, d12, d13,
            h01, h02, h03, h04, h05, h06, h07, h08, h09, h10, h11, h12, h13,
            s01, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13,
            joker

        }


        public int[] shuffleCards()
        {
            int[] values = new int[53];
            for (int a = 0; a < 53; a++)
            {
                values[a] = a + 1;
            }
            for (int i = 0; i < 53; i++)
            {
                int abc = UnityEngine.Random.Range(0, values.Length);
                int xyz;
                xyz = values[i];
                values[i] = values[abc];
                values[abc] = xyz;
            }

            return values;
        }

    }
}