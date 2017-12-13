using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        private int count = 1;
        public enum Mark
        {
            Clover,
            Diamond,
            Heart,
            Spade,
        }

        public struct Cards
        {
            public int number;
            public Mark mark;
        }

        //カード生成
        public void Start()
        {
            Cards card1_1 = new Cards();
            Cards card1_2 = new Cards();
            Cards card2_1 = new Cards();
            Cards card2_2 = new Cards();

            var counter = 0;
            while (counter <= 3)
            {
                int number = Random.Range(1, 14);
                int markV = Random.Range(0, 4);
                Mark mark = (Mark)markV;
                string str = mark.ToString();
                Debug.Log(str + number);
                counter++;
            }
            //自分??
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            for (int y = 0; y <= 1; y++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(0 - y, 1.5f, 0);
            }
            //相手??
            for (int y = 0; y <= 1; y++)
            {
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(0 - y, -1.5f, 0);
            }

        }

        public void Addcard()
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(count, -1.5f, 0);
            count++;
        }
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
        private void RemoveCards()
        {
            var cardsObject = GameObject.Find("Cards").transform;
            foreach (Transform cardObject in cardsObject)
            {
                Destroy(cardObject.gameObject);
            }
        }
    }
}
