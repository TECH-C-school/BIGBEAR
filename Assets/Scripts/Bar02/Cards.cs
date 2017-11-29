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

        /// <summary>
        /// GameControllerでも読み込める:表
        /// </summary>
        public void TurnCardFaceUp()
        {
            TurnCard(true);
        }
        /// <summary>
        /// GameControllerでも読み込める:裏
        /// </summary>
        public void TurnCardFaceDown()
        {
            TurnCard(false);
        }
        /// <summary>
        /// Card内のみで読み込める関数：カード裏表簡易化
        /// </summary>
        /// <param name="faceup"></param>
        private void TurnCard(bool faceup)
        {
            Sprite cardSprite = null;
            Sprite numberSprite = null;

            if (faceup)
            {
                cardSprite = Resources.Load<Sprite>("Images/card_frontside");
                numberSprite = Resources.Load<Sprite>("Images/" + _number);
            }
            else
            {
                cardSprite = Resources.Load<Sprite>("Images/card_backside");
            }

            //spriteの画像変換
            var spriteRenderer = transform.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = cardSprite;

            //Number参照
            var num = transform.Find("Number");
            var numberSpriteRenderer = num.GetComponent<SpriteRenderer>();
            numberSpriteRenderer.sprite = numberSprite;
        }
    }
}