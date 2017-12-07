using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar05
{
    public class Card : MonoBehaviour
    {
        public int number;

        public string cardStrPath;

        public GameObject selectCard;

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
            selectCard = (GameObject)Resources.Load("Prefabs/Bar05/cardselect");
            //selectCard = gameObject.transform.FindChild("cardselect").gameObject;
            
            selectCard.transform.position = gameObject.transform.position;
            selectCard.SetActive(false);
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

        private void SelectCard()
        {
            selectCard = transform.FindChild("cardselect").gameObject;
            if (selectCard.activeSelf == false)
            {
                selectCard.SetActive(true);
            }
            else if (selectCard.activeSelf == true)
            {
                selectCard.SetActive(false);
            }
        }
    }
}
