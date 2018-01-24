using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Bar04
{
    public class Faze : MonoBehaviour
    {
       public int destroy = 0;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public int OnClicked()
        {
            var clones = GameObject.FindGameObjectsWithTag("OnClicks");
            
            foreach (var clone in clones)
            {
                destroy++;
                Destroy(clone);

            }

            return destroy;
        }
    }
}
