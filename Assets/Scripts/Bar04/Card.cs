using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Bar04_06
{

    public class Card
    {

        // Use this for initialization
        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
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
            Sprite cardSprite = null;
            Sprite numberSprite = null;
            if (faceUp)
            {
                cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/      ");
                numberSprite = Resources.Load<Sprite>("Images/" + _number);
            }
            else
            {
                cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/      ");
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
