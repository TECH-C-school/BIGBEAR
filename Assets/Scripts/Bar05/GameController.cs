using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar05 {
    public class GameController : MonoBehaviour {

        private void Start()
        {
                MakeCards();
        }

        /// <summary>
        /// 自分と相手のカードを配置する
        /// iはプレイヤー人数によって変更(i = プレイヤー人数)
        /// いつか変数で管理したい
        /// </summary>
        public void MakeCards()
        {
            Debug.Log("Load to MakeCards");
            //PrefabをLoadする
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar05/Card");
            for (int i = 0; i < 2; i++)
            {
                //自分のカード生成
                if (i == 0)
                {
                    var cardsObject1 = GameObject.Find("Player1_Cards");
                    for (int x = 0; x < 2; x++)
                    {
                        //カードを表示
                        var cardObject = Instantiate(cardPrefab);
                        //カードの位置を指定
                        cardObject.transform.position = new Vector3((x * 2 - 1), -3.4f, 0);
                        //親を指定
                        cardObject.transform.parent = cardsObject1.transform;
                        Debug.Log("<color=green>自分のカード生成</color>" + (x + 1) + "枚目");
                    }
                    Debug.Log("<color=blue>自分のカード生成完了</color>");
                }
                //相手のカード生成
                else
                {
                    var cardsObject2 = GameObject.Find("Player2_Cards");
                    for (int x = 0; x < 2; x++)
                    {
                        var cardObject = Instantiate(cardPrefab);
                        cardObject.transform.position = new Vector3((x * 2 - 1), 3.4f, 0);
                        cardObject.transform.parent = cardsObject2.transform;
                        Debug.Log("<color=green>相手のカード生成</color>" + (x + 1) + "枚目");
                    }
                    Debug.Log("<color=red>相手のカード生成完了</color>");
                }
            }
        }
        /// <summary>
        /// カードのナンバー管理
        /// </summary>
        private enum CardsNum
        {
            c01 = 1, c02, c03, c04, c05, c06, c07, c08, c09, c10, c11, c12, c13,
            d01, d02, d03, d04, d05, d06, d07, d08, d09, d10, d11, d12, d13,
            h01, h02, h03, h04, h05, h06, h07, h08, h09, h10, h11, h12, h13,
            s01, s02, s03, s04, s05, s06, s07, s08, s09, s10, s11, s12, s13,
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}