using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour {

    List<string> Card_List = new List<string>();
    List<string> Player_Card = new List<string>();

    [SerializeField][Range(1, 52)]
    public int aaa;
    int Card_pos = -20;

    // Use this for initialization
    void Start () {
        CardInput();


    }

    // Update is called once per frame
    void Update () {
        CardPass();
    }

    public void kakunin()
    {
        Debug.Log(Card_List[aaa - 1]);
    }

    void CardPass()
    {
        // カードを配る関数
        if (Player_Card.Count < 5)
        {
            Card_pos += 10;
        
            // GameObjectとしてPrefabからInstantiateして
            // 交換動作の時、 押すとフラグが切り替わる     詳しくはノート書いてある
        }
        
    }

    public void CardDrow()                 // カードを引く関数
    {
        Debug.Log(Card_List.Count);

        int Card_No = Random.Range(0, Card_List.Count - 1);

        Player_Card.Add(Card_List[Card_No]);        // 手札へ
        Card_List.Remove(Card_List[Card_No]);       // デッキから削除
        Debug.Log(Card_List.Count);
        Debug.Log("NO:" + Card_No);
        Debug.Log("中身:" + Card_List[Card_No]);
        // ここで５枚まで配る
        // Card_List から Player_Card へ移す

        GameObject Card_type = Instantiate(Resources.Load("Prefabs/Bar04/Card/" + Card_List[Card_No], typeof(GameObject)), new Vector2(0, 0), Quaternion.identity) as GameObject;
        Card_type.name = Card_List[Card_No];                                    // 生成時に名前を変えてる

    }

    void CardInput()
    {
        // カードの初期化変数
        Card_List.Clear();

        for(int i = 1; i < 14; i++)
        {
            Card_List.Add("H" + i.ToString());
            Card_List.Add("D" + i.ToString());
            Card_List.Add("S" + i.ToString());
            Card_List.Add("C" + i.ToString());
        }
    }
    
}
