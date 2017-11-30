using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // 位置座標
    private Vector3 _position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 _screenPo;


	void Start () {
      
	}
	
	void Update () {
        // Vector3でマウス位置座標を取得する
        _position = Input.mousePosition;
        // Z軸修正
        _position.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        _screenPo = Camera.main.ScreenToWorldPoint(_position);
        // ワールド座標に変換されたマウス座標を代入
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, _screenPo.x, 0.1f), transform.position.y, transform.position.z);  
	}
}
