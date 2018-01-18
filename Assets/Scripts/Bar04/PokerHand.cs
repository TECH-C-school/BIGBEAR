using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokerHand : MonoBehaviour {

    int Card1;
    int Card2;
    int Card3;
    int Card4;
    int Card5;

    string Simbol1;
    string Simbol2;
    string Simbol3;
    string Simbol4;
    string Simbol5;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheackSend()
    {
        // 数値を持ってくる 手札の
        Card1 = GameObject.Find("GameController").GetComponent<GameControll>().PokerHand_Number1();
        Card2 = GameObject.Find("GameController").GetComponent<GameControll>().PokerHand_Number2();
        Card3 = GameObject.Find("GameController").GetComponent<GameControll>().PokerHand_Number3();
        Card4 = GameObject.Find("GameController").GetComponent<GameControll>().PokerHand_Number4();
        Card5 = GameObject.Find("GameController").GetComponent<GameControll>().PokerHand_Number5();

        Simbol1 = GameObject.Find("GameController").GetComponent<GameControll>().PokerHand_Symbol1();
        Simbol2 = GameObject.Find("GameController").GetComponent<GameControll>().PokerHand_Symbol2();
        Simbol3 = GameObject.Find("GameController").GetComponent<GameControll>().PokerHand_Symbol3();
        Simbol4 = GameObject.Find("GameController").GetComponent<GameControll>().PokerHand_Symbol4();
        Simbol5 = GameObject.Find("GameController").GetComponent<GameControll>().PokerHand_Symbol5();
    }


}
