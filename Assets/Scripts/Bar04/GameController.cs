using System;
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
            var FightButton = GameObject.Find("b_s");
            FightButton.transform.position = new Vector3(6.5f,-3.5f,-1);
        }
        
        void Update()
        {
            ClickFight();
            
        }

        private int MakeRandomNumbers()
        {
            int Num = UnityEngine.Random.Range(0, 13);
            return Num;
        }
        private int MakeRandomMark()
        {
            int Num = UnityEngine.Random.Range(0, 4);
            return Num;
        }
        private void returnCard()
        {

        }
        private void ClickFight()
        {
            if (Input.GetMouseButtonUp(0)) return;

            var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (!Physics2D.OverlapPoint(tapPoint)) return;

            var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
            if (!hitObject) return;

        }



        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }

    }
}
