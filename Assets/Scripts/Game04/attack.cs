using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{

    public Camera maincamera;

    // Use this for initialization
    void Start()
    {

        

    }

    void FixedUpdate()
    {
        
    }
        // Update is called once per frame
        void Update()
     {
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider.tag == "enemy1")
            {
                
                Debug.Log("hit1");
               
            }
            if (hit.collider.tag == "enemy2")
            {
                
                Debug.Log("hit2");
            }
            if (hit.collider.tag == "enemy3")
            {
                
                Debug.Log("hit3");
            }
        }

     }

    
}  

    

