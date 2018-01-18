using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Bar04
{
    public class GameController : MonoBehaviour
    {
        private Card card;

        private Card.toranpucard toranpu;

        [SerializeField]
        private Sprite sprite;


        //プレイヤーカードの作成
        private void PlayerMakeCards()
        {
            //Resources.Load<GameObject>でPrefabsのBar04のCardPlayerの画像情報を読み込んでいる
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/CardPlayer");

            //for (関数の名前 = 関数ごとの要素; 関数の名前 < 要素の数; 関数の名前+(++or--))
            for (int i = 0; i < 5; i++)
            {


                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                //new Vector3(横軸の幅 - 横軸,縦軸,奥行き)となっている
                cardObject.transform.position = new Vector3(i * 2.6f - 6.2f,-1f, 0);

                cardObject.transform.parent = cardObject.transform;
            }
        }

        //エネミーカードの作成
        private void EnemyMakeCards()
        {

            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/CardEnemy");

            for (int j = 0; j < 5; j++)
            {

                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);

                cardObject.transform.position = new Vector3(j * 1.7f - 2.2f, 3.1f, 0);

                cardObject.transform.parent = cardObject.transform;
            }

        }

        private void Start()
        {
            card = new Card();

            card.MakeRandomNumbers();
            PlayerMakeCards();
            EnemyMakeCards();
            toranpu = this.GetComponent<Card.toranpucard>();
            // Card card = new Card(1, Card.PalayingCards.s);
        }

        //SceneManeger.LoadScene()でシーンを読み込む
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
