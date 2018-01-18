using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Bar01
{
    
    public class Card : MonoBehaviour
    {
        public Card()
        {

            cardType = CardTypes.None;
            cardNumber = 1;
            front = false;
            dack = false;
        }

        public enum CardTypes
        {
            None = -1,
            Diamond,
            Clover,
            Heart,
            Spade
        }
        [SerializeField]
        private Sprite frontSprite;
        private Sprite backSprite;
        private SpriteRenderer cardRenderer;
        [SerializeField]
        private Vector3 fromPosition;
        private int column;
        private bool select = false;
        private bool front = false;
        [SerializeField]
        private bool outCard = false;
        [SerializeField]
        private CardTypes cardType;
        [SerializeField]
        private int cardNumber;
        public bool dack;

        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        public bool Front
        {
            get { return front; }
        }

        public Vector3 From
        {
            get { return fromPosition; }
            set { fromPosition = value; }
        }
        
        public CardTypes CardType
        {
            set { cardType = value; }
            get { return cardType; }
        }
        
        public int CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        public bool OutCard
        {
            get{ return outCard; }
            set{ outCard = value; }
        }

        public Card(CardTypes mack, int number)
        {
            cardType = mack;
            cardNumber = number;
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
            if (!cardRenderer)
            {
                cardRenderer = GetComponent<SpriteRenderer>();
            }
            front = true;
            if (!frontSprite)
            {
                char[] markChar = new char[] { 'd', 'c', 'h', 's' };
                frontSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + markChar[(int)cardType] + cardNumber.ToString("d2"));
            }
            cardRenderer.sprite = frontSprite;
        }

        public void CardFront(bool chang = true)
        {
            if (!cardRenderer)
            {
                cardRenderer = GetComponent<SpriteRenderer>();
            }
            front = true;
            if (chang)
            {
                char[] markChar = new char[] { 'd', 'c', 'h', 's' };
                frontSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + markChar[(int)cardType] + cardNumber.ToString("d2"));
            }
            cardRenderer.sprite = frontSprite;
        }

        private void CardBack()
        {
            front = false;
        }

        public void CardSelect()
        {
            select = !select;
            if (select)
            {
                fromPosition = transform.position;
            }
            GetComponent<BoxCollider2D>().enabled = !select;
        }
    }
}

