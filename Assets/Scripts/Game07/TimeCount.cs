using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game07
{
    public class TimeCount : MonoBehaviour
    {
        [SerializeField, Header("タイマーのスピード")]
        private float TimerSpeed = 1;
        float times = 60;

        void Start()
        {
            GetComponent<Text>().text = ((int)times).ToString();
        }

        void Update()
        {
             times -= TimerSpeed * Time.deltaTime;
            if (times == 0)
            {
                times = 0;
            }
            GetComponent<Text>().text = ((int)times).ToString();
        }
    }
}
