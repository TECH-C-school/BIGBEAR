using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07 {
    public class GameController : MonoBehaviour {
        public GameObject bgset;
        private GameObject Card;
/*
        public Sprite f_flame;
        public Sprite betflame;
        public Sprite coinflame;
        public Sprite cardflame;
        public Sprite history;
        public Sprite numberflame;
        public Sprite text_draw;
        public Sprite text_player;
        public Sprite text_dealer;
        public Sprite b_r;
        public Sprite b_s2;
        public Sprite coin2;
        public Sprite f_word2;
        public Sprite f_word4;
        public Sprite bakarawin;
        public Sprite bakaralose;
        public Sprite b_menu;
        */

        private void Start()
        {
            //スタートの時点で定位置に設置する
            GameObject backgroundset = Instantiate(bgset, transform.position = new Vector3(0, 0, 0), Quaternion.identity);


            Card = Resources.Load<GameObject>("Resources/Prefabs/Bar07/Card");
            Debug.Log(Card);
            GameObject damy = Instantiate(Card, transform.position = new Vector3(0, 0, 0), Quaternion.identity);

        }
        private void Update()
        {
            
        }





        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
