using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar02
{
    public class GameController : MonoBehaviour
    {
        void Start()
        {
            MakeNumber();
        }
        public class cardy
        {
            public char mark;
            public int num;
        }
        public void MakeNumber()
        {
            cardy[] trump = new cardy[52];
            for (int k = 0; k < 52; k++)
            {
                trump[k] = new cardy();
            }
            
            for (int i = 0; i < 13; i++)
            {
                trump[i + 0].mark = 's';
                trump[i + 13].mark = 'd';
                trump[i + 26].mark = 'h';
                trump[i + 39].mark = 'c';

                trump[i + 0].num = i + 1;
                trump[i + 13].num = i + 1;
                trump[i + 26].num = i + 1;
                trump[i + 39].num = i + 1;
            }
            int[] values = new int[52];


            var counter = 0;
            //while (counter < 52)
            //{
            //    int index = Random.Range(counter, values.Length);
            //    var tmp = trump[counter];
            //    trump[counter] = trump[index];
            //    trump[index] = tmp;

            //    counter++;
            //}
             while (counter < 52)
             {
                 int index = Random.Range(counter, values.Length);
                 var tmp = trump[counter].mark;
                 trump[counter].mark = trump[index].mark;
                 trump[index].mark = tmp;

                 counter++;
             }
             counter = 0;
             while (counter < 52)
             {
                 int index = Random.Range(counter, values.Length);
                 var tmp = trump[counter].num;
                 trump[counter].num = trump[index].num;
                 trump[index].num = tmp;

                 counter++;
             }
            for (int y = 0; y < 52; y++)
            {
                Debug.Log(trump[y].mark);
            }
        }

      /*  public void MakeCards()
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
            var cardsObject = GameObject.Find("Cards");

            int count = 0;
            //関数取得
            int[] num = MakeRandomNumbers();

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < count + 1; y++)
                {
                    GameObject cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector3(
                        x * 1.27f - 3.87f,
                        y * 1.27f - 2.54f,
                        0);
                    //親参照
                    cardObject.transform.parent = cardsObject.transform;

                    //別スクリプト内の関数取得
                    var card = cardObject.GetComponent<Card>();
                    //CardスクリプトのNumberにMakeRandomの値代入
                    card.Number = num[count];
                    card.TurnCardFaceDown();
                    count++;
                }
            }
        }*/

        /* public void TransitionToResult()
         {
             SceneManager.LoadScene("Result");
         }*/
    }
}
