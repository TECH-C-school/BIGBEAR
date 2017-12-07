using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour {

        public GameObject Startbutton;
       
        public void TransitionToResult() {


  
            SceneManager.LoadScene("Result");
        }

        public void GameStart(){
            Debug.Log("ゲームスタートです");
            Startbutton.SetActive(false);
        }
    }
}