using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    GameObject enemyHand;
    GameObject betWord;
    GameObject duelWord;
    public GameObject cardPrefab;
    public Transform playerTrans, enemyTrans, bankerTrans;
    public float cardOffset = 0.5f;
    //public Transform test;

    /*
    public List<string> playerCards = new List<string>();
    public List<string> enemyCards = new List<string>();
    public List<string> bankerCards = new List<string>();
    */

    //public string playerCards[] = new string[];
    public string x;

    CurrCard[] defaultCardsArray, shuffeledArray, cardBack;
    CurrCard[] playerArray, enemyArray, bankerArray;

    int maxCardsPerRound = 9;
    bool isGiven = false;
    bool isOpened = false;

    class CurrCard
    {
        public Cards cardValue;
        public Transform cardTrans;

        public CurrCard(Transform cardTrans)
        {
            this.cardTrans = cardTrans;
        }

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
        h01, h02, h03, h04, h05, h06, h07, h08, h09, h10, h11, h12, h13,
        s01, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13
    }

    void Start()
    {
        playerArray = new CurrCard[2];
        enemyArray = new CurrCard[2];
        bankerArray = new CurrCard[5];

        int deckLength = Enum.GetNames(typeof(Cards)).Length;
        defaultCardsArray = new CurrCard[deckLength];

        CreateDefaultDeck();
        shuffeledArray = makeShuffledDeck(defaultCardsArray);
        //Debug.Log(playerArray[0].cardValue);
    }

    void Update()
    {
        if (!isGiven && Input.GetMouseButtonDown(0)) GiveCards(); betWording();
        //if (!isOpened &&Input.GetMouseButtonDown(1)) flipEnemyCard();
    }

    void CreateDefaultDeck()
    {
        //Putting cards into shuffledArray.
        int i = 0;
        foreach (Cards card in Enum.GetValues(typeof(Cards)))
        {
            Sprite sprite = Resources.Load("Images/Bar/Cards/" + card, typeof(Sprite)) as Sprite;
            GameObject newObj = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            newObj.GetComponent<SpriteRenderer>().sprite = sprite;
            newObj.name = sprite.name;
            //Debug.Log(sprite);
            CurrCard currCard = new CurrCard(card, newObj.transform);
            defaultCardsArray[i] = currCard;
            defaultCardsArray[i].cardTrans.gameObject.SetActive(false);
            i++;
        }
    }

    CurrCard[] makeShuffledDeck(CurrCard[] shuffledArray)
    {
        System.Random r = new System.Random();
        for (int n = shuffledArray.Length - 1; n > 0; --n)
        {
            int k = r.Next(n + 1);
            CurrCard temp = shuffledArray[n];
            shuffledArray[n] = shuffledArray[k];
            shuffledArray[k] = temp;
        }
        return shuffledArray;
    }

    void GiveCards()
    {
        for (int i = 0; i < maxCardsPerRound; i++)
        {
            if (i < 2) // 0 till 1
            {
                playerArray[i] = shuffeledArray[i];
                playerArray[i].cardTrans.position = playerTrans.position;
                Debug.Log("player " + playerArray[i].cardValue);

                //playerCards.Add(playerArray[i].cardValue);
                x = playerArray[i].cardValue.ToString();

                Vector3 pos = playerArray[i].cardTrans.position;
                pos.x += i * cardOffset;
                playerArray[i].cardTrans.position = pos;
                playerArray[i].cardTrans.gameObject.SetActive(true);
            }
            else if (i < 4) // 2 till 3
            {
                int index = i - 2;
                enemyArray[index] = shuffeledArray[i];
                enemyArray[index].cardTrans.position = enemyTrans.position;
                Debug.Log("enemy " + enemyArray[index].cardValue);

                Vector3 pos = enemyArray[index].cardTrans.position;
                pos.x += index * cardOffset;
                enemyArray[index].cardTrans.position = pos;

                Sprite sprite = Resources.Load("Images/Bar/Cards/back/", typeof(Sprite)) as Sprite;
                GameObject newObj = Instantiate(cardPrefab, pos, Quaternion.identity);
                newObj.name = "back";
                cardBack = new CurrCard[2];
                cardBack[index] = new CurrCard(newObj.transform);
            }
            else // 4 till 8
            {
                int index = i - 4;
                bankerArray[index] = shuffeledArray[i];
                bankerArray[index].cardTrans.position = bankerTrans.position;
                Debug.Log("banker " + bankerArray[index].cardValue);

                Vector3 pos = bankerArray[index].cardTrans.position;
                pos.x += index * cardOffset;
                bankerArray[index].cardTrans.position = pos;
                bankerArray[index].cardTrans.gameObject.SetActive(true);
            }
        }
        isGiven = true;
    }

     public void flipEnemyCard()
    {
        duelWording();
        enemyHand = GameObject.Find("back");
        Debug.Log(enemyHand);
        enemyHand.gameObject.SetActive(false);

        for (int i = 0; i < enemyArray.Length; i++)
        {
            enemyArray[i].cardTrans.gameObject.SetActive(true);
        }
    }

    void betWording()
    {
        betWord = GameObject.Find("betword1");
        //Debug.Log(betWord);
        //betWord.gameObject.SetActive(true);
    }

    void duelWording()
    {
        duelWord = GameObject.Find("duelword");
        //Debug.Log(duelWord);
        //betWord.gameObject.SetActive(false);
        //duelWord.gameObject.SetActive(true);
    }
    /*
        CurrCard[] makeShuffledDeck(CurrCard[] shuffledArray)
        {
            int counter = 0, maxCard = shuffledArray.Length;
            while(counter < 52)
            {
                int index = UnityEngine.Random.Range(counter, shuffledArray.Length);
                Transform cardTrans = shuffledArray[counter].cardTrans;
                Cards cardValue = shuffledArray[counter].cardValue;
                shuffledArray[counter] = shuffledArray[index];
                shuffledArray[index].cardTrans = cardTrans;
                shuffledArray[index].cardValue = cardValue;
                counter++;
                maxCard--;
            }
            return shuffledArray;
        }


        void GiveCards(Transform target, int noOfCards)
        {
            CurrCard[] tempArray = new CurrCard[noOfCards];
    
            for(int i = 0; i < noOfCards; i++)
            {
                int temp = usedIndex + i;
                tempArray[i] = shuffeledArray[temp];
    //            Debug.Log("Within " + shuffeledArray[temp].cardValue);
            }
            usedIndex += noOfCards;
    
            if (target.name == "PlayerPos") playerArray = tempArray;
            else if (target.name == "EnemyPos") enemyArray = tempArray;
            else bankerArray = tempArray;
    
            for(int i = 0; i < noOfCards; i++)
            {
                //tempArray[i].cardTrans.position = target.position;
                if (target.name == "PlayerPos") tempArray[i].cardTrans.position = new Vector3(0.01f, -3.52f, 0);
                else if (target.name == "EnemyPos") tempArray[i].cardTrans.position = new Vector3(0.01f, 3.52f, 0);
                else tempArray[i].cardTrans.position = new Vector3(0.01f, 0.02f, 0);
                tempArray[i].cardTrans.gameObject.SetActive(true);
            }
        }
    */
}