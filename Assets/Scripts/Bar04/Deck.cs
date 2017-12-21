using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar04
{


    public class Deck : MonoBehaviour {
　　　　//デッキ作成
        public static Queue<int> MakeCards()
        {
            
            //52枚のカードをランダムに生成
            int[] cards = new int[51];
            for (var i = 0; i < 51; i++)
            {
                cards[i] = i + 1;
            }

                var counter = 0;
                while (counter < 51)
                {
                    var index = Random.Range(counter, cards.Length);
                    var tmp = cards[counter];
                    cards[counter] = cards[index];
                    cards[index] = tmp;

                    counter++;
                }



           //数値に名前を付ける





           //ランダム作成したものを順番に入れる
            Queue<int> decks = new Queue<int>() { };
            for (var i = 0; i < 51; i++)
            {
                decks.Enqueue(cards[i]);
            }

            return decks;
        }



        //// Use this for initialization
        //    void Start() {
        //        MakeCards();
        //    }

        //    // Update is called once per frame
        //    void Update() {



        //    }
    }

}