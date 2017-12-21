using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour {

    List<string> Card_List = new List<string>();
    List<string> Player_Card = new List<string>();

    [SerializeField][Range(1, 52)]
    public int aaa;
    int Card_pos = -20;
    int seiseiNo = 0;

    bool DrowBool = true;
    bool CoroutineBool = true;

    // Use this for initialization
    void Start () {
        CardInput();

        
    }
    // Update is called once per frame
    void Update () {
        CardPass();
        if(Card_pos > 20)
        {
            Card_pos = -20;
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

            Player_Card.Add(Card_List[Card_No]);        // 手札へ

            // ここで５枚まで配る
            // Card_List から Player_Card へ移す


            GameObject Card_type = Instantiate(Resources.Load("Prefabs/Bar04/Card/" + Card_List[Card_No], typeof(GameObject)), new Vector2(Card_pos, 0), Quaternion.identity) as GameObject;
            Card_type.name = Card_List[Card_No];                                    // 生成時に名前を変えてる
            Card_pos += 10;                               // 次回生成時の座標変更
            Card_List.Remove(Card_List[Card_No]);       // デッキから削除
        }

    }

    void CardInput()
    {
        // カードの初期化変数
        Card_List.Clear();
        /*
        for(int i = 1; i < 14; i++)
        {
            Card_List.Add("H" + i.ToString());
            Card_List.Add("D" + i.ToString());
            Card_List.Add("S" + i.ToString());
            Card_List.Add("C" + i.ToString());
        }
        */
        Card_List = new List<string>() {
            "H1","D1","S1","C1",
            "H2","D2","S2","C2",
            "H3","D3","S3","C3",
            "H4","D4","S4","C4",
            "H5","D5","S5","C5",
            "H6","D6","S6","C6",
            "H7","D7","S7","C7",
            "H8","D8","S8","C8",
            "H9","D9","S9","C9",
            "H10","D10","S10","C10",
            "H11","D11","S11","C11",
            "H12","D12","S12","C12",
            "H13","D13","S13","C13"
        };
    }
    
    public void CardChangeButton()
    {
        Player_Card.Clear();
    }
    

    IEnumerator Drow()
    {
        yield return new WaitForSeconds(0.5f);
        CardDrow();
        CoroutineBool = true;
    }

    public void PlayerCardCheack()
    {
        Debug.Log("1:" + Player_Card[0]);
        Debug.Log("2:" + Player_Card[1]);
        Debug.Log("3:" + Player_Card[2]);
        Debug.Log("4:" + Player_Card[3]);
        Debug.Log("5:" + Player_Card[4]);
    }

}


// 次回、カード交換と選択、役の確認。