using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelect : MonoBehaviour
{
         ///     カードがクリックされたときの処理
         /// </summary>
     void Update()
    {
        //マウスクリックの判定
        if (!Input.GetMouseButtonDown(0)) return;

        //クリックされた位置を取得
        var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Collider2D上クリックの判定
        if (!Physics2D.OverlapPoint(tapPoint)) return;

        //クリックした位置のオブジェクトを取得
        var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
        if (!hitObject) return;

        //prefabを呼び出す
        var prefab = Resources.Load<GameObject>("Prefabs/Bar04/cardselect");
        //kurikkushitabashiniyobidasu 
        Instantiate(prefab, tapPoint, Quaternion.identity);
    }
}
    
