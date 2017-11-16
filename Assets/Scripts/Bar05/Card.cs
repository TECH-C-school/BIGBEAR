using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar05
{
    public class Card : MonoBehaviour
    {
        public enum Suit
        {
            Spade,
            Heart,
            Club,
            Diamond,
            Joker,
        }

        public Suit suit;

        public int number;

        public string[] CardStr =
        {
            "SA", "S2", "S3", "S4", "S5", "S6", "S7", "S8", "S9", "S10", "SJ", "SQ", "SK",
        "HA", "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "HJ", "HQ", "HK",
        "DA", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D10", "DJ", "DQ", "DK",
        "CA", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10", "CJ", "CQ", "CK",
        "J0", "J1"
        };

        void Start()
        {
            GameObject card = (GameObject)Resources.Load("Prefab/Bar_05");
            var Card = GameObject.Find("Card");
            GameObject[] cards = new GameObject[53];
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
