using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {

        public enum Mark
        {
            Spade,
            Heart,
            Diamonds,
            Club,
        }

        public enum Card
        {
            Ace,
            two,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine,
            ten,
            eleven,
            twe
        }

        /// <summary>
        /// プレイヤーとディーラーにカードを2枚づつ生成
        /// </summary>
        private void MakeCard()
        {
            int count = 0;
            int[] randomNumbers = MakeRandomNumbers();
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/Card_back");
            
            for (var i = 0; i < 2; i++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(i * 1.27f - 2.54f, 0);
     
            }
        }
        private int[] MakeRandomNumbers()
        {
            int[] numbers = new int[52];
            fo
        }
          
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
