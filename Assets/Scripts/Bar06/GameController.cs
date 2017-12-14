using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{
    public class GameController : MonoBehaviour
    {
        void Start()
        {
            MakeCard();

        }
        /// <summary>
        /// カードを生成する
        /// </summary>
        private void MakeCard()
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/back");
            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector2(i - 0.5f, j * 2.25f - 1.1f);
                    cardObject.transform.parent = transform;
                }
            }
        }
        /// <summary>
        /// クリックしたときカードを追加する
        /// </summary>
        private void Update()
        {

        }
        public void ClickCardplusButton()
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/c01");
            for (var x = 0; x < 1; x++) {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(0f,0f);
                cardObject.transform.parent = transform;
            }
        }
        /// <summary>
        /// クリックしたとき相手とのカードの大きさを比べる
        /// </summary>
        public void ClickBattleButton()
        {

        }
        /// <summary>
        /// クリックしたとき勝負をあきらめる
        /// </summary>
        public void ClickSalenderButton()
        {

        }
        /// <summary>
        /// クリックしたときベットを1づつ減らす
        /// </summary>
        public void ClickBetmainusButton()
        {

        }
        /// <summary>
        /// クリックしたときベットを1づつ増やす
        /// </summary>
        public void ClickBetplusButton()
        {

        }

        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
