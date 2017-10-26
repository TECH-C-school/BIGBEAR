using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game07
{
    public class TimeCount : MonoBehaviour
    {

        float times = 60;

        void Start()
        {
            GetComponent<Text>().text = ((int)times).ToString();
        }


        void Update()
        {
             times -= Time.deltaTime;

            if (times == 0)
            {

            }
        }
    }
}
