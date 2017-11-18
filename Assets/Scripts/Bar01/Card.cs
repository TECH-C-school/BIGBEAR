using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Bar01
{
    public class Card : MonoBehaviour
    {

        [SerializeField]
        private Sprite frontSprite;
        private Sprite backSprite;
        private SpriteRenderer cardRenderer;
        private bool select = false; 

        public enum CardTypes
        {
            Diamond,
            Clover,
            Heart,
            Spade
        }

        private void Start()
        {
            backSprite = cardRenderer.sprite;
        }

        private void Update()
        {
            if (!select) { return; }
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = -14;
            transform.position = mousePosition;
        }

        [SerializeField]
        private CardTypes cardType;

        public CardTypes CardType
        {
            get { return cardType; }
        }
        [SerializeField]
        private int cardNumber;

        public int CardNumber
        {
            get { return cardNumber; }
        }

        public Card(CardTypes mack, int number)
        {
            cardType = mack;
            cardNumber = number;
        }

        public void SetCard(Card setCard)
        {
            cardNumber = setCard.CardNumber;
            cardType = setCard.CardType;
            cardRenderer = GetComponent<SpriteRenderer>();
        }

        public void TurnCard(bool front)
        {
            if (front)
            {
                CardFront();
            }
            else
            {
                CardBack();
            }
        }

        private void CardFront()
        {
            if (!frontSprite)
            {
                char[] markChar = new char[] { 'd', 'c', 'h', 's' };
                string cardString = "";
                if(cardNumber < 10)
                {
                    cardString = "0";
                }
                frontSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + markChar[(int)cardType] + cardString + cardNumber);
            }
            cardRenderer.sprite = frontSprite;
        }

        private void CardBack()
        {

        }

        public void CardSelect()
        {
            select = !select;
        }
    }
}

