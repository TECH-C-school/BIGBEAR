using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using System;


namespace Assets.Scripts.Bar04
{    

    public class StartBTN: MonoBehaviour
    {
        [SerializeField]
        private static RectTransform rectStartBTN;
        
        public static void MakeStartButton()
        {
            rectStartBTN.DOMoveY(1, 5).OnComplete(() =>
             {
                 Debug.Log("startbutton生成");
             }
            );
        }
        //internal void PusStartButton()
        internal void OnClick()
        {
            Debug.Log("PushButton");

       //   new  GameController().CreateCards();

        }
    }
}