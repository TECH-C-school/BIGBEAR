using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastCard : MonoBehaviour {

    public List<GameObject> Card;

    public void CardOpen() {
        for (int i = 0; i < Card.Count; i++) {
            var CardSprict = Card[i].GetComponent<Card>();
            CardSprict.TurnCardFaceUp();
        }
    }
}
