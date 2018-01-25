using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamebed : MonoBehaviour {
    int coin=0;
    int playercoin;
    int bankecoin;
    int dawrcoin;
    int totalcoin;
   public GameObject[] playercoins;
    public GameObject[] bankercoins;
    public GameObject[] dawrcoins;
    public GameObject prefab;
    public Text zandaka;
    public Text goukeibat;
    
    // Use this for initialization
    void Start() {
        totalcoin = 10;
        zandaka.text = totalcoin.ToString();
    }
    
    

    
	// Update is called once per frame
	void Update () {
		
	}
    public void Playerwin()
    {
        totalcoin += playercoin + (playercoin);
        totalcoin += bankecoin + (bankecoin);
        totalcoin += dawrcoin + (dawrcoin);
    }
    public void GamecoinOnclick(int Buttontrpe)
    {
        
        if (Buttontrpe == 0)
        {
            if (playercoin < 3)
            {
                totalcoin -= 1;
                
                zandaka.text = totalcoin.ToString();
                playercoins[playercoin].SetActive(true);
                playercoin++;
            }
        }
        else if(Buttontrpe ==1)
        {
            if (bankecoin < 3)
            {
                totalcoin -= 1;
                zandaka.text = totalcoin.ToString();
                bankercoins[bankecoin].SetActive(true);
                bankecoin++;
            }
        }
        else if (Buttontrpe ==2)

        {
            if (dawrcoin < 3)
            {
                totalcoin -= 1;
                zandaka.text = totalcoin.ToString();
                dawrcoins[dawrcoin].SetActive(true);
                dawrcoin++;
            }
        }


        goukeibat.text = (playercoin + bankecoin + dawrcoin).ToString();
    }
}
