using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour{


    public void TurnCardFaceUp(){
        TurnCard(true);
    }

    public void TurnCardFaceDown(){
        TurnCard(false);
    }

    private void TurnCard(bool faceUp)
    {
        Sprite cardSprite = null;

        if (faceUp){
            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/c01");
        }else{
            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
        }
        var spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cardSprite;
    }




}
public class deck{
    
    static public int[] randomnum = new int[52];
    static public string[] randommark = new string[52];
    static private int i, j, k, value;
    static private string val;

    static public void RondomNum()
    {                                           //数字の整列
        System.Random r = new System.Random();
        for (i = 0,j = 0; i < 52; i++){
            if (i < 13){                        //マーク
                randommark[i] = "s";
            }else if(i < 26){
                randommark[i] = "h";
            }else if(i < 39){
                randommark[i] = "c";
            }else{
                randommark[i] = "d";
            }
            if (j + 1 >= 14){
                j = 0;
            }
            
            randomnum[i] = j + 1;
            j++;
        }
        for (i = 0; i < 52; i++){               //ランダム化
            j = r.Next(52);
            k = r.Next(52);
            value = randomnum[j];
            randomnum[j] = randomnum[k];
            randomnum[k] = value;
            val = randommark[j];
            randommark[j] = randommark[k];
            randommark[k] = val;
        }
    }
}