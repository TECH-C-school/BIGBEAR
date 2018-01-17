using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar02
{
    public class Cards : MonoBehaviour
    {

        private int _number;
        private int _cardnumber;
        //private string _cardmark;

        public int Number
        {

            get { return _number; }
            set { _number = value; }
        }
        public int CardNumber
        {

            get { return _cardnumber; }
            set { _cardnumber = value; }
        }
        //public string CardMark
        //{

        //    get { return _cardmark; }
        //    set { _cardmark = value; }
        //}

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
            //Sprite cardSprite = null;
            //GameObject onField = null;
            var oncard = GameObject.Find("FieldCards");
            var backprefabs = GameObject.Find("BackCards");
            var onField = oncard.transform.GetChild(_number);
            var backfield = backprefabs.transform.GetChild(_number);

            if (faceup)
            {
                onField.GetComponent<Renderer>().sortingOrder = _number + 2;
            }
            else
            {
                backfield.GetComponent<Renderer>().sortingOrder = _number + 2;
            }

        }
        //public void StringNumber(int a)
        //{
        //    int number = 0; 
        //    return number;
        //}
    }
}