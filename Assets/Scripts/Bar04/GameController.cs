using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour
    {

        private void MakeCards()
        {

            int count = 0;

            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/CardPlayer");
            var cardsObject = GameObject.Find("Player");

            for(int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {


                    var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);

                    cardObject.transform.position = new Vector3(i * 1.5f - 3f,j * 1f - 2.5f, 0);

                    cardObject.transform.parent = cardsObject.transform;

                    var card = cardObject.GetComponent<Cards>();

                    count++;

                }

            }

        }

         private void Start()
         {
             Cards card = new Cards(1,Cards.PalayingCards.s);

            MakeCards();

             /*Debug.Log("カード生成");
             Debug.Log(card.Number);
             Debug.Log(card.CardType);*/

         }


        //SceneManeger.LoadScene()でシーンを読み込む
         public void TransitionToResult() {
             SceneManager.LoadScene("Result");

            
         }
       }

    }
