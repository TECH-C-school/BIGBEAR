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
        float times = 10;//これが制限時間
        [SerializeField]
        GameObject backimage;
        [SerializeField]
        GameObject backtext;
        [SerializeField]
        GameObject[] items; 


        void Start()
        {
            GetComponent<Text>().text = ((int)times).ToString();
        }

        void Update()
        {
             times -= TimerSpeed * Time.deltaTime;
            if (times < 0)
            {
                times = 0;
            }
            GetComponent<Text>().text = ((int)times).ToString();

            if (times == 0)
            {
                backimage.SetActive(true);
                backtext.SetActive(true);
                backtext.GetComponent<Text>().text =  "Score" + ((int)GameController.m_score).ToString();

                if (GameController.m_score > 0 && GameController.m_score < 10)
                {
                    items[0].SetActive(true);
                }

                CatchObject[] catchObj = FindObjectsOfType<CatchObject>();
                foreach(var s_catchObj in catchObj)
                {
                    Destroy(s_catchObj.gameObject);
                }

            }
        }

    }
}
