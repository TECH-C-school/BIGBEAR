using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar02
{
    public class Cards : MonoBehaviour
    {

        private int _number;

        public int Number
        {

            get { return _number; }
            set { _number = value; }
        }

        public void TurnCardFaceUp()
        {
            TurnCard(true);
        }
        public void TurnCardFaceDown()
        {
            TurnCard(false);
        }
        public void TurnCard(bool faceup)
        {
            Sprite cardSprite = null;
            //GameObject onField = null;
            var oncard = GameObject.Find("FieldCards");


            if (faceup)
            {
                var onField = oncard.transform.GetChild(_number);
                string Fieldcard = onField.ToString();
                string Subfield = Fieldcard.Substring(0, 3);
                cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + Subfield);
            }
            else
            {
                cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            }
            var spriteRenderer = transform.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = cardSprite;
        }
    }
}