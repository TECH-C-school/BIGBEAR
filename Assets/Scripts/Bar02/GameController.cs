using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar02 {
    public class GameController : MonoBehaviour {
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
        private void Start()
        {
            CardSet();
        }

        /// <summary>
        /// カードを表示
        /// </summary>
        private void CardSet()
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar02/Cards");


            int countNumber = 6;

            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= countNumber; j++)
                {
                    var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector3(
                        j - countNumber * 0.5f - 0.5f,
                        i * 0.5f - 1f,
                        0);
                }
                countNumber--;
            }

        }

        /// <summary>
        /// 裏面表示
        /// </summary>
        private void TurnCardFaceDown()
        {
            Sprite cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            var spriteRenderer = transform.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = cardSprite;
        }
    }
}
