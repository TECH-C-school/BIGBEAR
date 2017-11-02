using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game07
{
    public class Effect : MonoBehaviour
    {
        [SerializeField, Header("破壊される時間")]
        private float destroy_time = 1;
        private void Start()
        {
            Invoke("CreateAfterDestory", destroy_time);
        }

        public void CreateAfterDestory()
        {
            Destroy(gameObject);
        }
        

    }
}
