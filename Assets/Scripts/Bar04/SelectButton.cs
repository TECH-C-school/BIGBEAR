using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



// Use this for initialization
public class SelectButton : MonoBehaviour
{

    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        Debug.Log("Button click!");
        for (var i = 5; i < 10; i++)

            //もしGameObject.Findの中のToggle1がisOnされたら
            if (GameObject.Find("Toggle1").GetComponent<Toggle>().isOn)
        {
            //Card1を消す
            Destroy(GameObject.Find("Card1"));
           //     var eachCard = cards[i];
        }

        if (GameObject.Find("Toggle2").GetComponent<Toggle>().isOn)
        {
            Destroy(GameObject.Find("Card2"));
        }

        if (GameObject.Find("Toggle3").GetComponent<Toggle>().isOn)
        {
            Destroy(GameObject.Find("Card3"));
        }

        if (GameObject.Find("Toggle4").GetComponent<Toggle>().isOn)
        {
            Destroy(GameObject.Find("Card4"));
        }

        if (GameObject.Find("Toggle5").GetComponent<Toggle>().isOn)
        {
            Destroy(GameObject.Find("Card5"));
        }


    }
}




