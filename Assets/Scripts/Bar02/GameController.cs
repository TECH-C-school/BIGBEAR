﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar02 {

    public enum Mark
    {
        Spade,
        Heart,
        Diamond,
        Clover
    }

    public struct Card
    {
        public int number;
        public Mark mark;
    }

    public class GameController : MonoBehaviour {
        public void Start()
        {
            int[] cards = new int[52];
            //21枚のカードを用意する
            for (int i = 0; i < 52; i++)
            {
                cards[i] = i + 1;
            }

            var counter = 0;
            while (counter < 52)
            {
                var index = Random.Range(counter, cards.Length);
                var tmp = cards[counter];
                cards[counter] = cards[index];
                cards[index] = tmp;

                counter++;
            }

            Card[] trump = new Card[21];
            for (int i = 0; i < 21; i++)
            {
                //19
                trump[i].number = ????;
                trump[i].mark = ???;
            }



            //21枚のカードを表示する
            var cardsObject = GameObject.Find("Cards").transform;
            foreach (Transform cardObject in cardsObject.transform)
            {
                var cardSpriteRenderer = cardObject.GetComponent<SpriteRenderer>();
                cardSpriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/c02");
            }
            

        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
