using System;

public class Deck
{
    private Card[] deck;
    private int currentCard;
    private const int CardsNumber = 52;
    private Random ranNum;

    public Deck()
    {
        string[] faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        string[] types = { "Diamonds", "Spades", "Hearts", "Clubs" };
        deck = new Card[CardsNumber];
        currentCard = 0;
        ranNum = Random();
        for(int count =1;count<deck.length; count++)
        {
            deck[count] = new Card(faces % 13, types % 13);
        }
    }
}