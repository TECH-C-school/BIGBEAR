using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        private int count = 1;
        public void Start()
        {
            var card = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var cardObject = Instantiate(card, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-1.5f,-1,0);

        }
        public void AddBottunClick()
        {
            
            var card = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var cardObject = Instantiate(card, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-1.5f+1.5f*count, -1, 0);
            count++;
        }




        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
