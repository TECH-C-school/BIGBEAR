﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Bar04
{
    public class MyCanvas : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            // Canvasコンポーネントを保持
            //_canvas = GetComponent<Canvas>();
        }

        /// 表示・非表示を設定する
        public static void SetActive(string name, bool b)
        {
            /*foreach (Transform child in _canvas.transform)
            {
                // 子の要素をたどる
                if (child.name == name)
                {
                    // 指定した名前と一致
                    // 表示フラグを設定
                    child.gameObject.SetActive(b);
                    // おしまい
                    return;
                }
            }*/
            // 指定したオブジェクト名が見つからなかった
            Debug.LogWarning("Not found objname:" + name);
        }
    }


}