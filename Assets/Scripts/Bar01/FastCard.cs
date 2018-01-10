using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastCard : MonoBehaviour {

    public List<GameObject> Card;
    public GameObject GameContoroll;

    public void CardOpen() {
        var GameContorollSprict = GameContoroll.GetComponent<Bar0104>();
        for (int i = 0; i < Card.Count; i++) {
            var CardSprict = Card[i].GetComponent<Card>();
            CardSprict.Number = GameContorollSprict.Dack[GameContorollSprict.NextCard];
            CardSprict.TurnCardFaceUp();
            GameContorollSprict.NextCard++;
        }
    }
}
