using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar02
{
    public class RemainCards : MonoBehaviour
    {
        private int clicknum = 0;
        private int sortnum = 5;
        //private GameObject saveRemain;

        void Start()
        {
            SetUpCard();
        }
        public void OnClick()
        {
            if (clicknum == 24)
            {
                SetUpCard();
                clicknum = 0;
            }

            var remain = GameObject.Find("RemainCards");
            var remainOnfield = remain.transform.GetChild(clicknum).gameObject;

            while (true)
            {
                if (remainOnfield.activeSelf == false)
                {
                    clicknum++;
                    remainOnfield = remain.transform.GetChild(clicknum).gameObject;
                }
                else
                {
                    break;
                }
            }

            remainOnfield.transform.position = new Vector3(
                5.5f,
                2.7f,
                0);
            //if (clicknum != 0)
            //{
            //    saveRemain.transform.position = new Vector3(
            //    20.5f,
            //    2.7f,
            //    0);
            //}

            remainOnfield.GetComponent<Renderer>().sortingOrder = sortnum;
            //saveRemain = remainOnfield;
            clicknum++; sortnum++;

        }
        public void SetUpCard()
        {
            var remain = GameObject.Find("RemainCards");
            for (int i = 0; i < 24; i++)
            {
                var remainOnfield = remain.transform.GetChild(i);

                remainOnfield.transform.position = new Vector3(
                    20.0f,
                    2.7f,
                    0);
            }
        }
    }
}
