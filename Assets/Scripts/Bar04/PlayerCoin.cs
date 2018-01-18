using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCoin : MonoBehaviour {

    static int HaveCoin;
    static int BetCoin;
    public Text haveCoin;
    public Text betCoin;

    public Text haveCoin2;
    public Text betCoin2;

    public Text haveCoin3;
    public Text betCoin3;


    public Canvas CoinBetCanvas;
    public Canvas CardChangeCanvas;

	// Use this for initialization
	void Start () {
        HaveCoin = 10;
        BetCoin = 0;
	}
	
	// Update is called once per frame
	void Update () {

        haveCoin.text = HaveCoin.ToString();
        betCoin.text = BetCoin.ToString();

        haveCoin2.text = HaveCoin.ToString();
        betCoin2.text = BetCoin.ToString();

        haveCoin3.text = HaveCoin.ToString();
        betCoin3.text = BetCoin.ToString();
    }

    public void PlusCoin()
    {
        if (HaveCoin > 0 && BetCoin < 10)
        {
            HaveCoin -= 1;
            BetCoin += 1;
        }
    }
    public void MinusCoin()
    {
        if (BetCoin > 0 && HaveCoin < 10)
        {
            HaveCoin += 1;
            BetCoin -= 1;
        }
    }

    public void YesButton()
    {
        CoinBetCanvas.gameObject.SetActive(false);
        CardChangeCanvas.gameObject.SetActive(true);
        GameObject.Find("GameController").GetComponent<GameControll>().ChangeCanvas = true;
    }


}
