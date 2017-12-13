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
        //カードを生成する
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
        public void ClickCardplusButton()
        {

        }
        public void ClickBattleButton()
        {

        }
        public void ClickSalenderButton()
        {

        }
        public void ClickBetmainusButton()
        {

        }
        public void ClickBetplusButton()
        {

        }

        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
