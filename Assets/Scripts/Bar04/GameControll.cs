using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControll : MonoBehaviour {

    List<string> Card_List = new List<string>();
    List<GameObject> Player_Card = new List<GameObject>();
    List<string> Destroy_Card = new List<string>();
    GameObject[] Player_CardList;

    bool Card1 = false;
    bool Card2 = false;
    bool Card3 = false;
    bool Card4 = false;
    bool Card5 = false;
    List<int> CardChangePos = new List<int>();
    
    [SerializeField][Range(1, 52)]
    public int aaa;
    int Card_pos = -20;
    int seiseiNo = 0;

    bool DrowBool = true;
    bool CoroutineBool = true;
    public bool ChangeCanvas = false;

    public Image Card_1;
    public Image Card_2;
    public Image Card_3;
    public Image Card_4;
    public Image Card_5;



    // Use this for initialization
    void Start () {
        CardInput();

    }
    // Update is called once per frame
    void Update () {
        if (ChangeCanvas == true)
        {
            CardPass();
            if (Card_pos > 20)
            {
                Card_pos = -20;
            }

            ButtonChange();
        }
        
    }

    void ButtonChange()
    {
        if(Card1 == true)
        {
            Card_1.color = new Color(1f, 1f, 1f, 1f);
        }else if (Card1 == false)
        {
            Card_1.color = new Color(1f, 1f, 1f, 0f);
        }

        if (Card2 == true)
        {
            Card_2.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (Card2 == false)
        {
            Card_2.color = new Color(1f, 1f, 1f, 0f);
        }

        if (Card3 == true)
        {
            Card_3.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (Card3 == false)
        {
            Card_3.color = new Color(1f, 1f, 1f, 0f);
        }

        if (Card4 == true)
        {
            Card_4.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (Card4 == false)
        {
            Card_4.color = new Color(1f, 1f, 1f, 0f);
        }

        if (Card5 == true)
        {
            Card_5.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (Card5 == false)
        {
            Card_5.color = new Color(1f, 1f, 1f, 0f);
        }
    }
    void CardPass()
    {
        // カードを配る関数
        if (Player_Card.Count < 5)
        {
            DrowBool = true;
        }
        else{
            DrowBool = false;
        }
        
        if(DrowBool == true)
        {
            if (CoroutineBool == true)
            {
                CoroutineBool = false;
                StartCoroutine("Drow");
            }
        }
    }

    public void CardDrow()                 // カードを引く関数
    {
        if (DrowBool == true)
        {
            int Card_No = Random.Range(0, Card_List.Count - 1);

            Destroy_Card.Add(Card_List[Card_No]);       // 墓地へ

            // ここで５枚まで配る
            // Card_List から Player_Card へ移す

            if (CardChangePos.Count >= 1) {
                Card_pos = CardChangePos[0];
                CardChangePos.RemoveAt(0);
            }
            GameObject Card_type = Instantiate(Resources.Load("Prefabs/Bar04/Card/" + Card_List[Card_No], typeof(GameObject)), new Vector2(Card_pos, 0), Quaternion.identity) as GameObject;
            Card_type.name = Card_List[Card_No];                                    // 生成時に名前を変えてる
            Player_Card.Add(Card_type);

            Card_pos += 10;                               // 次回生成時の座標変更
            Card_List.Remove(Card_List[Card_No]);       // デッキから削除
        }
    }

    void CardInput()
    {
        // カードの初期化変数
        Card_List.Clear();

        Card_List = new List<string>() {
            "H01","D01","S01","C01",
            "H02","D02","S02","C02",
            "H03","D03","S03","C03",
            "H04","D04","S04","C04",
            "H05","D05","S05","C05",
            "H06","D06","S06","C06",
            "H07","D07","S07","C07",
            "H08","D08","S08","C08",
            "H09","D09","S09","C09",
            "H10","D10","S10","C10",
            "H11","D11","S11","C11",
            "H12","D12","S12","C12",
            "H13","D13","S13","C13"
        };
    }
    #region 恥ずかしいプログラムゆえ隠す
    public void CardChangeButton()
        // カード交換する 押したときの処理
    {
        if (Card5 == true)
        {
            Player_Card.RemoveAt(4);
            CardChangePos.Add(20);
        }
        if (Card4 == true)
        {
            Player_Card.RemoveAt(3);
            CardChangePos.Add(10);
        }
        if (Card3 == true)
        {
            Player_Card.RemoveAt(2);
            CardChangePos.Add(0);
        }
        if (Card2 == true)
        {
            Player_Card.RemoveAt(1);
            CardChangePos.Add(-10);
        }
        if (Card1 == true)
        {
            Player_Card.RemoveAt(0);
            CardChangePos.Add(-20);
        }

        Card1 = false;
        Card2 = false;
        Card3 = false;
        Card4 = false;
        Card5 = false;

    }
    #region カード選択ボタン
    public void Card1_Bool()
    {
        Card1 = !Card1;
    }
    public void Card2_Bool()
    {
        Card2 = !Card2;
    }
    public void Card3_Bool()
    {
        Card3 = !Card3;
    }
    public void Card4_Bool()
    {
        Card4 = !Card4;
    }
    public void Card5_Bool()
    {
        Card5 = !Card5;
    }
    #endregion
    #endregion
    IEnumerator Drow()
    {
        yield return new WaitForSeconds(0.2f);
        CardDrow();
        CoroutineBool = true;
    }
    public void PlayerCardCheack()
    {/*
        Debug.Log("1:" + Player_Card[0]);
        Debug.Log("2:" + Player_Card[1]);
        Debug.Log("3:" + Player_Card[2]);
        Debug.Log("4:" + Player_Card[3]);
        Debug.Log("5:" + Player_Card[4]);
        */

        // 後ろの数字判定
        int num1 = int.Parse(Player_Card[0].name.Substring(1));
        // 前の記号判定
        string text1 = Player_Card[0].name.Substring(0,1);

        Debug.Log(num1 + text1);



    }
#region 別のスクリプトに手札
    public int PokerHand_Number1(){
        return int.Parse(Player_Card[0].name.Substring(1));
    }
    public int PokerHand_Number2()
    {
        return int.Parse(Player_Card[1].name.Substring(1));
    }
    public int PokerHand_Number3()
    {
        return int.Parse(Player_Card[2].name.Substring(1));
    }
    public int PokerHand_Number4()
    {
        return int.Parse(Player_Card[3].name.Substring(1));
    }
    public int PokerHand_Number5()
    {
        return int.Parse(Player_Card[4].name.Substring(1));
    }

    public string PokerHand_Symbol1()
    {
        return Player_Card[0].name.Substring(0, 1); ;
    }
    public string PokerHand_Symbol2()
    {
        return Player_Card[1].name.Substring(0, 1); ;
    }
    public string PokerHand_Symbol3()
    {
        return Player_Card[2].name.Substring(0, 1); ;
    }
    public string PokerHand_Symbol4()
    {
        return Player_Card[3].name.Substring(0, 1); ;
    }
    public string PokerHand_Symbol5()
    {
        return Player_Card[4].name.Substring(0, 1); ;
    }
    #endregion


}


// 次回、役の確認。