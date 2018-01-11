using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{
    public class GameController : MonoBehaviour
    {
        public GameObject canvas;//キャンバス
        public GameObject cards_bg;

        void Start()
        {
            // プレハブを取得
            GameObject prefab = (GameObject)Resources.Load("Prefabs/Bar06/cards_bg");
            // プレハブからインスタンスを生成
            Instantiate(prefab);


        }
    }
}