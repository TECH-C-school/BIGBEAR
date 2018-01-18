using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Debug.Log(cardName);
        makeShuffledDeck();

        for (int i = 1; i < 52; i++)
        {
            string v = Enum.GetName(typeof(Cards), i);
            Debug.Log(v);
        }

        MakeCards();
    }

    // Update is called once per frame
    void Update() {

    }
    public enum Cards
    {
        c01 = 1, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13,
        d01, d02, d03, d04, d05, d06, d07, d08, d09, d10, d11, d12, d13,
        a01, a02, a03, a04, a05, a06, a07, a08, a09, a10, a11, a12, a13,
        s01, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13
    }
    private string cardName = Enum.GetName(typeof(Cards), 1);

    public int[] makeShuffledDeck()
    {
        int[] numbers = new int[52];
        for (int i = 0; i < 52; i++)
        {
            numbers[i] = i + 1;
        }

        var counter = 0;
        while (counter < 52)
        {
            var index = UnityEngine.Random.Range(counter, numbers.Length);
            var tmp = numbers[counter];
            numbers[counter] = numbers[index];
            numbers[index] = tmp;
            counter++;
        }

        for (int i = 0; i < 52; i++)
        {
            Debug.Log(numbers[i]);
        }
        return numbers;
    }

    private void MakeCards()
    {
        var cardPrefab = Resources.Load<GameObject>("Images/Bar/Cards/ + _cardName");
        var cardsObject = GameObject.Find("Card");

        var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
        cardObject.transform.position = new Vector3(
            1, 1, 0);

    }
}