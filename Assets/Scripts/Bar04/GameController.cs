using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace Assets.Scripts.Bar04
{
    public class GameController : MonoBehaviour
    {
        /// <summary>
        /// 自分のカードと相手のカードの生成するPrefabを指定(Inspector)
        /// </summary>
        [SerializeField]
        private GameObject MyCard, YouCard;
        /// <summary>
        /// FadeTime指定(Inspector)
        /// </summary>
        [SerializeField]
        private float FadeIn, FadeOut;
        [SerializeField]
        RectTransform RectStartButton;
               


        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            new StartBTN().MakeStartButton();

        }
        /// <summary>
        /// startButton押された時の作動(DG有)
        /// </summary>S
        ///
        /*
        internal void StartBTN()
        {
          /*  RectStartButton.DOMoveY
                (

                );
            CreateCards();

        }
        */


        /// <summary>
        /// カードの生成
        /// </summary>
        private void CreateCards()
        {
            Sequence mySequence = DOTween.Sequence();
            var myCardPrefab = MyCard;
            var youCardPrefab = YouCard;
            for (int cardCounter = 0; cardCounter < 5; cardCounter++)
            {
                var cardObject = Instantiate(myCardPrefab, transform.position, Quaternion.identity);

                cardObject.name = myCardPrefab.name+cardCounter;
                cardObject.transform.position = new Vector3(-4.7f + cardCounter * 1.7f, -0.4f, 0f);
                //cardObject.
            }
            for (var cardCounter = 0; cardCounter < 5; cardCounter++)
            {
                var cardObject = Instantiate(youCardPrefab, transform.position, Quaternion.Euler(0, 0, 180));
                cardObject.name = youCardPrefab.name + cardCounter;
                cardObject.transform.position = new Vector3(-0.91f + cardCounter * 1.2f, 2.17f, 0f);
            
            }
        }
        /// <summary>
        /// DOTweenFade(未完)
        /// </summary>
        internal void DOTweenFade()
        {

        }


    }
}
