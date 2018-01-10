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
            GameObject onField = null;
            var oncard = GameObject.Find("FieldCards").gameObject;


            if (faceup)
            {
                onField = oncard.transform.GetChild(_number).gameObject;
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