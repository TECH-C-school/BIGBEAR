using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {

        private void MakeCards()
        {
            var cardPrefab = Resources.Load<GameObject>("Image/Bar/Cards/back");
            var cardsObject = GameObject.Find("back");

            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector2(1.27f, 1.27f);

            cardObject.transform.parent = cardObject.transform;

            var card = cardObject.GameObject<back>(); 
        }


        class randam 
        {
            static void Main()
            {
                const int max = 52;
                int r = 0;
                Debug.Log("l");
                foreach (int i in Enumerable.Range(1,max).OrderBy(x => Guid.NewGuid()))
                {
                    Debug.Log("{0,2}", i);
                    if (++r < 52) Debug.Log(",");
                }
                Debug.Log("l");
            }
        }
    
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
