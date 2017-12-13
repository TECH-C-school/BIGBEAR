using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07
{
    public class CoinCreater : MonoBehaviour
    {
        //カードフレームに付けてクリックでコイン生成


        public GameObject coin;
        private GameObject[] coins;


        void OnMouseDown()
        {
            //要追加：回数を重ねる度コインの生成個所をずらす処理
            GameObject coins = Instantiate(coin, transform.position+new Vector3(0,0,-1), Quaternion.identity);

            if (transform.name == "draw_cardflame(Clone)")
            {
                //名前付け
                coins.name = "drawcoin";
            }
            else if(transform.name == "player_cardflame")
            {
                //名前付け
                coins.name = "playercoin";
            }else if(transform.name == "dealer_cardflame")
            {
                //名前付け
                coins.name = "dealercoin";
            }

        }


        public void CoinReset()
        {
            Debug.Log("Reset");
           
        }
    }
}
