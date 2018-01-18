using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

    //役を表示する文字列
    string m_resulttext;   

    public string resulttext {
        get { return m_resulttext; }
        set { m_resulttext = value; }
    }

    //チップ関係の変数
    public int HundChip;
    int m_BetChip;
    public int BetChip {
        get { return m_BetChip; }
        set { m_BetChip = value; }
    }

    string m_resultChip;
    public string resultChip {
        get { return m_resultChip; }
        set { m_resultChip = value; }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Payment() {
        HundChip -=BetChip;
    }

    public void Refund() {
        int NowHundChip = HundChip;
        HundChip += BetChip;
        resultChip = "" + NowHundChip + " + " + BetChip + " = " + HundChip;
    }
}
