using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Game08 {
    public class GameController : MonoBehaviour {



        
        bool click = true;
        


        void Start() {
            
            
        }

        void Update()
        {
            //if (GetComponent<TimeCount>().timeCounter == 0)
            //{
            //    onclick();
                
            //}
        }

        void onclick() {
            click = false;
            return;
        }




        public void TransitionToResult() {

            //SceneManager.LoadScene("Result");
            Debug.Log("あああ");
        }
    }
}
