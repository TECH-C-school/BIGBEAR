using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Bar04_06
{

    public class Card : MonoBehaviour
    {
        internal object mark;
        internal int number;

        public void HoldCardFaceUp()
        {
            HoldCard(true);
        }

        public void HoldCardFaceDown()
        {
            HoldCard(false);
        }
        private void HoldCard(bool facedown)
        {
            Sprite cardSprite = null;

            if (facedown)
            {
                
            }
           
        }
    }

}
