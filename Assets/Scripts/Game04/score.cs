using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public GameObject player;

    public Text scoreText;

    private int scorepoint = 0;

    private Transform playerTrans;

	// Use this for initialization
	void Start () {
        playerTrans = player.GetComponent<Transform>();
        //********** 開始 **********//
        scoreText.text = "0"; //初期スコアを代入して画面に表示
                                     //********** 終了 **********//
    }

    // Update is called once per frame
    void Update () {
        float playerHeight = playerTrans.position.y;
        float currentCameraHeight = transform.position.y;
        float newHeight = Mathf.Lerp(currentCameraHeight, playerHeight, 0.5f);
        if (playerHeight > currentCameraHeight)
        {
            transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider.tag == "enemy1")
            {
                Debug.Log(hit.collider.name);
                Debug.Log("100");
                scorepoint += 100;
                scoreText.text = "" + scorepoint.ToString();

            }
            if (hit.collider.tag == "enemy2")
            {
                Debug.Log(hit.collider.name);
                Debug.Log("200");
                scorepoint += 200;
                scoreText.text = "" + scorepoint.ToString();
            }
            if (hit.collider.tag == "enemy3")
            {
                Debug.Log(hit.collider.name);
                Debug.Log("300");
                scorepoint += 300;
                scoreText.text = "" + scorepoint.ToString();
            }
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "enemy1")
        {
            Debug.Log("100");
            scorepoint += 100;
            scoreText.text = "" + scorepoint.ToString();
        }

        if (gameObject.tag == "enemy2")
        {
            Debug.Log("200");
            scorepoint += 200;
            scoreText.text = "" + scorepoint.ToString();
        }

        if (gameObject.tag == "enemy3")
        {
            Debug.Log("300");
            scorepoint += 300;
            scoreText.text = "" + scorepoint.ToString();
        }
    }*/
}
