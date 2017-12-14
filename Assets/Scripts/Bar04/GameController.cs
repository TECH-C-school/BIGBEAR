using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04_06
{
    public class GameController : MonoBehaviour {

        public enum suit
        {
            clover,
            dia,
            heart,
            spade,
            joker
        }
        public enum TrumpCards
        {
            c01, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13,
            d01, d02, d03, d04, d05, d06, d07, d08, d09, d10, d11, d12, d13,
            h01, h02, h03, h04, h05, h06, h07, h08, h09, h10, h11, h12, h13,
            s01, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13,
        }



        /// <summary>
        /// カードのシャッフル
        /// </summary>
        //Numberの作成
        public void number() {
            int[] number = new int[51];
            for (int i = 0;i < number.Length; i++)
            {
                number[i] = i;
            }
            //シャッフルす
            int[] ary2 = number.OrderBy(i => Guid.NewGuid()).ToArray();
        }
        /// <summary>
        /// カードを配置する
        /// </summary>

        public void MakeCard()
        {
            int count = 0;
            int[] randomNumbers = MakeRandomNumbers();
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
            var cardsObject = GameObject.Find("Cards");

            for (var i = 0; i < 5; i++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(
                        0, 0);
                if (cardObject(0, 0))
                {
                    for (int j = 1; i < 3; j++)
                    {
                        cardObject.transform.position = new Vector3(
                                j * 2, 0);
                        cardObject.transform.position = new Vector3(
                                j * -2, 0);
                    }
                    cardObject.transform.parent = cardsObject.transform;

                    var card = cardObject.GetComponent<Card>();
                    card.Number = number[count];
                    card.ChangedCards();
                    count++;
                }
            }
        }
        private int[] MakeRandomNumbers() {

            int[] number = new int[51];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = i;
            }
            //シャッフルす
            number = number.OrderBy(i => Guid.NewGuid()).ToArray();
            return number;
        }

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
