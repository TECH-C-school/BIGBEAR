using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour {

    List<string> Card_List = new List<string>();
    List<string> Player_Card = new List<string>();

    [SerializeField][Range(1, 52)]
    public int aaa;

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
            int Card_No = Random.Range(1, Card_List.Count);
            Debug.Log("CARD:" + Card_No);

            Player_Card.Add(Card_List[Card_No]);
            Debug.Log(Player_Card[Player_Card.Count -1]);
            // ここで５枚まで配る
            // Card_List から Player_Card へ移す
            // GameObjectとしてPrefabからInstantiateして
            // 交換動作の時、 押すとフラグが切り替わる     詳しくはノート書いてある
        }
        
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
