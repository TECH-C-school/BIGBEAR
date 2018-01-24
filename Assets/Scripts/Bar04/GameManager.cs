using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>{
    public int coin = 0;

	// Use this for initialization
	void Start () {
        Debug.Log("GameManger.Start が読み込まれました");
        coin = 30;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
