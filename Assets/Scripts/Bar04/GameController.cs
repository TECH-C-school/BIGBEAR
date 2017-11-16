using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04_06
{
    public class GameController : MonoBehaviour {
        enum TrumpCards
        {
            c01, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13,
            d01, d02, d03, d04, d05, d06, d07, d08, d09, d10, d11, d12, d13,
            h01, h02, h03, h04, h05, h06, h07, h08, h09, h10, h11, h12, h13,
            s01, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13,
            joker,
        }
        /// <summary>
        /// enumの中身をシャッフルする
        /// </summary>

        /// <summary>
        /// シャッフルされたカードを上から配っていく
        /// </summary>


        /// <summary>
        /// クリックしたカードをHoldし、クリックされていないカードを捨て場に送る
        /// </summary>



        /// <summary>
        /// 捨て場に送った枚数分手札に加える
        /// </summary>



        /// <summary>
        /// 所持しているカードの役を判別する
        /// </summary>
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
