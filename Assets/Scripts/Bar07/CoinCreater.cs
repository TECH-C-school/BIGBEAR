using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07
{
    public class CoinCreater : MonoBehaviour
    {
        public GameObject coin;

        private void OnMouseDown()
        {
            GameObject coins = Instantiate(coin, transform.position, Quaternion.identity);
        }
    }
}
