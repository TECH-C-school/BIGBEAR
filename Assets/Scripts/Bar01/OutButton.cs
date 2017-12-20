using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar01
{
    public class OutButton : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!Input.GetMouseButtonDown(0)) { return; }
            Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (!hit) { return; }
            if (hit.name == "b_o")
            {
                Debug.Log("ゲームリタイア");
                GameObject.Find("GameController").GetComponent<GameController>().TransitionToResult();
            }
        }
    }
}
