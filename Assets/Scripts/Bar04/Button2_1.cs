using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Bar04
{
    public class Button2_1 : MonoBehaviour
    {


        public void OnClick()
        {
            Debug.Log("Button2 click!");
            // 非表示にする
            gameObject.SetActive(false);
            // Buttonを表示する
            MyCanvas.SetActive("Button", true);
        }
    }
}