using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour {

    // Use this for initialization
    public void OnClickButton()
    {
        {
            // Textコンポーネント郡を取得します。
            var components = this.gameObject.GetComponentsInChildren<Text>();
            // テキストを文字の状態によって変更するようにします。
            components[0].text = components[0].text == "ホールド" ? "チェンジ" : "Button";
        }
        /* Debug.Log("Button click!");
         // 非表示にする
         gameObject.SetActive(false);
         // Button2を表示する
         transform.position = new Vector2(100, 1000);
         //MyCanvas.SetActive("Button2", true);*/
    }
}

