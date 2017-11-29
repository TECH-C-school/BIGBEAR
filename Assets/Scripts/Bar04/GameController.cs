using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour {
        public enum Number{
           one,
           twe,
           three,
           four,
           five,
           six,
           seven,
           eigth,
           nighn,
           ten,
           J,
           Q,
           K,
           joker
        }
        public enum Mark{
            clover,
            diamond,
            heart,
            spade
        }
        
        



        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }

    }
}
