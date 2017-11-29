using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar05
{
    public class Card : MonoBehaviour
    {
        public int number;

        public enum Suit
        {
            Spade,
            Heart,
            Club,
            Diamond,
            Joker,
        }

        public Suit suit;


        void Start()
        {
            GameObject card = (GameObject)Resources.Load("Prefabs/Bar_05/back");
            var Card = GameObject.Find("Card");
        }

        // Update is called once per frame
        void Update()
        {

        }

        string CardInfo(string cardInfo)
        {
            string card = ""+ cardInfo;

            return card;
        }
    }
}
