using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject cardPrefab;
    public Transform playerTrans, enemyTrans, bankerTrans;

    CurrCard[] defaultCardsArray, shuffeledArray;
    CurrCard[] playerArray, enemyArray, bankerArray;

    int usedIndex = 0;
    bool isGiven = false;

    class CurrCard
    {
        public Cards cardValue;
        public Transform cardTrans;

        public CurrCard(Cards cardValue, Transform cardTrans)
        {
            this.cardValue = cardValue;
            this.cardTrans = cardTrans;
        }
    }
    enum Cards
    {
        c01 = 1, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13,
        d01, d02, d03, d04, d05, d06, d07, d08, d09, d10, d11, d12, d13,
        h01, h02, h03, h04, h05, h06, h07, h08, h09, h10,ha11, h12, h13,
        s01, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13
    }
    void Start()
    {
        int deckLength = Enum.GetNames(typeof(Cards)).Length;
        defaultCardsArray = new CurrCard[deckLength];

        CreateDefaultDeck();
        shuffeledArray = makeShuffledDeck(defaultCardsArray);
    }  
    // Update is called once per frame
    void Update()
    {
        if(!isGiven && Input.GetMouseButtonDown(0))
        {
            GiveCards(playerTrans, 2);
            GiveCards(enemyTrans, 2);
            GiveCards(bankerTrans, 5);
            isGiven = true;
        }
    }
   
    void CreateDefaultDeck()
    {
        //Putting cards into shuffledArray.
        int i = 0;
        foreach(Cards card in Enum.GetValues(typeof(Cards)))
        {
            Sprite sprite = Resources.Load("Images/Bar/Cards/" + card, typeof(Sprite)) as Sprite;
            GameObject newObj = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            newObj.GetComponent<SpriteRenderer>().sprite = sprite;
            //Debug.Log(sprite);
            CurrCard currCard = new CurrCard(card, newObj.transform);
            defaultCardsArray[i] = currCard;
            defaultCardsArray[i].cardTrans.gameObject.SetActive(false);
            i++;
        }
    }

    CurrCard[] makeShuffledDeck(CurrCard[] shuffledArray)
    {
        int counter = 0;
        while(counter < 52)
        {
            int index = UnityEngine.Random.Range(counter, shuffledArray.Length);
            Cards tmp = shuffledArray[counter].cardValue;
            shuffledArray[counter] = shuffledArray[index];
            shuffledArray[index].cardValue = tmp;
            counter++;
        }
        return shuffledArray;
    }

   void GiveCards(Transform target, int noOfCards)
    {
        CurrCard[] tempArray = new CurrCard[noOfCards];

        for(int i = 0; i < noOfCards; i++)
        {
            int temp = usedIndex + 1;
            tempArray[i] = shuffeledArray[temp];
        }
        usedIndex += noOfCards;

        if (target.name == "PlayerPos") playerArray = tempArray;
        else if (target.name == "EnemyPos") enemyArray = tempArray;
        else bankerArray = tempArray;

        for(int i = 0; i < noOfCards; i++)
        {
            tempArray[i].cardTrans.position = target.position;
            tempArray[i].cardTrans.gameObject.SetActive(true);
        }
    }
}