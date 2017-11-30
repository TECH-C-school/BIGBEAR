using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour {
        public enum Mark
        {
            Spade,
            Haert,
            Diamonds,
            Club,
            Joker
        }
        public enum Cards
        {
            one,
            twe,
            three,
            hour,
            five,
            six,
            seven,
            eight,
            nighn,
            ten,
            Jack,
            queen,
            king
        }
        void Start()
        {

            var cardPrefabs = Resources.Load<GameObject>("Prefabs/Bar04/card");
            for (var i = 0; i < 5; i++)
            {
                var cardObbject = Instantiate(cardPrefabs, transform.position, Quaternion.identity);
                cardObbject.transform.position = new Vector3(i * 2.5f - 5, 0.5f, 0);
            }
        }
        void Update()
        {
            MakeRandomCards();
        }

        private int MakeRandomCards()
        {
            int Num = UnityEngine.Random.Range(0, 13);
            return Num;
        }


        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }

    }
}
