﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Bar04
{
    public class GameController : MonoBehaviour
    {

        

        //プレイヤーカードの作成
        private void PlayerMakeCards()
        {
            //Resources.Load<GameObject>でPrefabsのBar04のCardPlayerの画像情報を読み込んでいる
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/CardPlayer");

            var cardsObject = GameObject.Find("Player");

            //for (関数の名前 = 関数ごとの要素; 関数の名前 < 要素の数; 関数の名前+(++or--))
            for (int i = 0; i < 5; i++)
            {

                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                //new Vector3(横軸の幅 - 横軸,縦軸,奥行き)となっている
                cardObject.transform.position = new Vector3(i * 2.6f - 6.2f,-1f, 0);

                cardObject.transform.parent = cardObject.transform;

                var card = cardObject.GetComponent<Card>();

            }

        }

        //エネミーカードの作成
        private void EnemyMakeCards()
        {

            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/CardEnemy");
            var cardsObject = GameObject.Find("Enemy");

            for (int j = 0; j < 5; j++)
            {

                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);

                cardObject.transform.position = new Vector3(j * 1.7f - 2.2f, 3.1f, 0);

                cardObject.transform.parent = cardObject.transform;

                var cards = cardObject.GetComponent<Card>();

            }

        }

        private void Start()
        {
           // Card card = new Card(1, Card.PalayingCards.s);

            PlayerMakeCards();
            EnemyMakeCards();
            
            //Debug.Log("カード生成");
            //Debug.Log(card.Number);
            //Debug.Log(card.CardType);
        }


        //SceneManeger.LoadScene()でシーンを読み込む
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
