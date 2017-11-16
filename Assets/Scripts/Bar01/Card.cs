using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Bar01
{
    public class Card : MonoBehaviour
    {
        public enum CardType
        {
            Diamond,
            Clover,
            Heart,
            Spade,
            Joker
        }

        private CardType cardType;
        private int cardNumber;
    }
}

