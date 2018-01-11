using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour {

    public Text text;

    public float speed = 5;

    bool mxPlus = true;

    public float timeOut;

    private Time deltaTime;

    bool move1;
    // Use this for initialization
    void Start () {
        move1 = true;

        StartCoroutine(FuncCoroutine());
    

}


    IEnumerator FuncCoroutine()
    {
        while (true)
        {
            // Do anything

            yield return new WaitForSeconds(3);
            move1 = false;
            yield return new WaitForSeconds(10);
            
            yield return new WaitForSeconds(15);
            
        }
    }
    // Update is called once per frame
    void Update () {
        if(move1 == true)
        {
            Debug.Log("true");
            this.transform.position += new Vector3(-0.5f * Time.deltaTime, 0f, 0f);
            if (Input.GetKey("k"))
            {
                Debug.Log("false");
                move1 = false;
            }
            
        }
        if(move1 == false)
        {
            this.transform.position += new Vector3(0f * Time.deltaTime, 0f, 0f);
        }

        if (Time.deltaTime == 3)
        {
            Debug.Log("false22");
            move1 = false;
        }
        //this.transform.position += new Vector3(-0.5f * Time.deltaTime, 0f, 0f);

       


    }
}
