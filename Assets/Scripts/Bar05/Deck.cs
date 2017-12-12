using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEck : MonoBehaviour {

    public class Cards
    {
        public enum CardType
        {
            Spade = 0,
            Clover,
            Diamonds,
            Hearts
        }

        public CardType cardType;
        public int number;

        public Cards(CardType cardType,  int number)
        {
            this.cardType = cardType;
            this.number = number;
        }
    }

    public class HoldingCard
    {
        public Transform cardTrans;
        public Text typeText;
        public Text numberText;

        public HoldingCard(Transform cardTrans, Text typeText, Text numberText)
        {
            this.cardTrans = cardTrans;
            this.typeText = typeText;
            this.numberText = numberText;
        }
    }


    public GameObject cardPrefab;

    public List<Cards> cardList = new List<Cards>();
    public List<HoldingCard> holdingCardList = new List<HoldingCard>();

    List<Cards> defaultCardList = new List<Cards>();


    void Start()
    {
        // Create 52 cards.
        int count = System.Enum.GetValues(typeof(Cards.CardType)).Length;
        for (int i = 0; i < count; i++)
        {
            for (int j = 1; j < 14; j++)
            {
                Cards.CardType cardType = (Cards.CardType)i;
                Cards card = new Cards(cardType, j);
                cardList.Add(card);
            }
        }
        defaultCardList = cardList;
        //		Debug.Log(defaultCardList.Count);

        Transform canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        for (int i = 0; i < canvas.childCount; i++)
        {
            Transform child = canvas.GetChild(i);
            Transform childOfChild = null;
            Text type = null, number = null;

            if (child.name == "LeftCard" || child.name == "RightCard")
            {
                for (int j = 0; j < child.childCount; j++)
                {
                    childOfChild = child.GetChild(j);

                    if (childOfChild.name == "Type") type = childOfChild.GetComponent<Text>();
                    else if (childOfChild.name == "Number") number = childOfChild.GetComponent<Text>();
                }
            }
            HoldingCard holdingCard = new HoldingCard(child, type, number);
            holdingCardList.Add(holdingCard);
        }
        GiveOutCards();
    }

    void Update()
    {

    }

    void GiveOutCards()
    {
        int index = Random.Range(0, cardList.Count + 1);
        holdingCardList[0].cardTrans.gameObject.SetActive(true);
        holdingCardList[0].typeText.text = cardList[index].cardType.ToString();
        holdingCardList[0].numberText.text = cardList[index].number.ToString();
        cardList.RemoveAt(index);

        index = Random.Range(0, cardList.Count + 1);
        holdingCardList[1].cardTrans.gameObject.SetActive(true);
        holdingCardList[1].typeText.text = cardList[index].cardType.ToString();
        holdingCardList[1].numberText.text = cardList[index].number.ToString();
        cardList.RemoveAt(index);
    }
}
