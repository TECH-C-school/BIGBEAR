using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar01
{
    public class ResetButton : MonoBehaviour
    {

        private GameController gameController;

        // Use this for initialization
        void Start()
        {
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }

        // Update is called once per frame
        void Update()
        {
            ResetButtonClick();
        }

        private void ResetButtonClick()
        {
            if (!Input.GetMouseButtonDown(0)) { return; }
            Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (!hit) { return; }
            if (hit.name == "b_r")
            {
                Debug.Log("シーンの読み込み");
                SceneManager.LoadScene("Bar01");
            }
        }
    }
}
