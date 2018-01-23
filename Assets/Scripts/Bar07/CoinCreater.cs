using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07
{
    public class CoinCreater : MonoBehaviour
    {
        //カードフレームに付けてクリックでコイン生成

        CoinController CC;

        private void Start()
        {

            CC = GameObject.Find("CoinCounter(Clone)").GetComponent<CoinController>();
        }

        void OnMouseDown()
        {
            if (CC.mycoins > 0 && CC.createflag == true)
            {
                CC.coincreate(transform.position);
            }

        }



    }
}
