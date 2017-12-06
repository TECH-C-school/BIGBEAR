using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {


        public enum Mark
        {
            Clover,
            Spade,
            Heart,
            Diamond
        }

        public struct Card
        {
            public int number;
            public Mark mark;
        }

        public void Start()
        {
            //カードを2, 2枚表示する
            Card card1_1 = new Card();
            Card card1_2 = new Card();
            Card card2_1 = new Card();
            Card card2_2 = new Card();

            //ランダムでカードを決める
            int number = Random.Range(1, 14);
            int markValue = Random.Range(0, 4);
            Mark mark = (Mark)markValue;
            string str = mark.ToString();

            Debug.Log(str + number);



        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }    
    }
}
