using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Bar04_06
{

    public class Card
    {

        // Use this for initialization
        private int _ary2;

        public int Number
        {
            get { return _ary2; }
            set { _ary2 = value; }
        }


        // Update is called once per frame
        public void ChangingCards()
        {
            TurnCard(true);
        }

        public void ChangedCards()
        {
            TurnCard(false);
        }
        public void TurnCardOnClick()
        {
            TurnCard(false);
        }
        private void TurnCard(bool faceUp)
        {
           
            if (faceUp)
            {
                Sprite cardSprite = null;
                Sprite numberSprite = null;
                cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/"+ _ary2);
            }
            

            /*
                    var spriteRenderer = transform.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = cardSprite;

                    var numberObject = transform.Find("Number");
                    var numberSpriteRenderer = numberObject.GetComponent<SpriteRenderer>();
                    numberSpriteRenderer.sprite = numberSprite;
                    
    */
        }
    }

}
