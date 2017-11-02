using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07 {
    public class GameController : MonoBehaviour {
        enum Days
        {
            Clover1, Clover2, Clover3, Clover4, Clover5, Clover6, Clover7, Clover8, Clover9, Clover10, Clover11, Clover12, Clover13,
            Diamond1, Diamond2, Diamond3, Diamond4, Diamond5, Diamond6, Diamond7, Diamond8, Diamond9, Diamond10, Diamond11, Diamond12, Diamond13,
            Heart1, Heart2, Heart3, Heart4, Heart5, Heart6, Heart7, Heart8, Heart9, Heart10, Heart11, Heart12, Heart13,
            Spade1, Spade2, Spade3, Spade4, Spade5, Spade6, Spade7, Spade8, Spade9, Spade10, Spade11, Spade12, Spade13
        }
                    
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
