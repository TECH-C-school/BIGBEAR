using System;
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
            //StartCoroutine(DelayMethod(1f, () =>
            //{
            //    click = true;
            //    Debug.Log(click);
            //}));
            
        }


        public void buttonclick() {
            StartCoroutine(DelayMethod(1f, () =>
            {
                click = true;
                Debug.Log(click);
            }));
            //if (GetComponent<TimeCount>().timeCounter == 0)
            //{
            //    onclick();

            //}
        }





        private IEnumerator DelayMethod(float waitTime, Action action)
        {
            
            yield return new WaitForSeconds(waitTime);
            action();
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
