using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar02
{
    public class RemainCards : MonoBehaviour
    {
        private int clicknum = 0;
        private int sortnum = 5;
        // Use this for initialization
        
        public void OnClick()
        {
            var remain = GameObject.Find("RemainCards");
            var remainOnfield = remain.transform.GetChild(clicknum);

            remainOnfield.transform.position = new Vector3(
                5.5f,
                2.7f,
                0);
            remainOnfield.GetComponent<Renderer>().sortingOrder = sortnum;
            clicknum++; sortnum++;
            if (clicknum == 24)
            {
                clicknum = 0;
            }
        }
    }
}
