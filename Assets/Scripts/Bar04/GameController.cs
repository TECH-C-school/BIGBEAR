using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour
    {



         private void Start()
         {
             Cards card = new Cards(1,Cards.PalayingCards.s);

             Debug.Log("カード生成");
             Debug.Log(card.Number);
             Debug.Log(card.CardType);
         }
         public void TransitionToResult() {
             SceneManager.LoadScene("Result");
         }
     }

    }
