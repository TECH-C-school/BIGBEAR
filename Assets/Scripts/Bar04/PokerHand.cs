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

    List<int> Card_List = new List<int>();
    List<string> Simbol_List = new List<string>();

    // Use this for initialization
    void Start () {
        CheackSend();
        HandCheack_OnePear();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void HandCheack_OnePear()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(Simbol_List[i] + Card_List[i]);
        }
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


        Card_List.Add(Card1);
        Card_List.Add(Card2);
        Card_List.Add(Card3);
        Card_List.Add(Card4);
        Card_List.Add(Card5);

        Simbol_List.Add(Simbol1);
        Simbol_List.Add(Simbol2);
        Simbol_List.Add(Simbol3);
        Simbol_List.Add(Simbol4);
        Simbol_List.Add(Simbol5);
    }


}
