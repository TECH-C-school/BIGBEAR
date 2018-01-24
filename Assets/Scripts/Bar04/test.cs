using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar04
{
    public class test : MonoBehaviour
    {

        // Use this for initialization
        public void pushbotton()
        {
         //   var clones = GameObject.FindGameObjectsWithTag("OffClicks");
         //  clones.tag = "OnClicks";
            var cardsObject = GameObject.Find("OnClicks").transform;
            foreach (Transform cardObject in cardsObject)
            {
                Destroy(cardObject.gameObject);
            }
        }

    }
}

