using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {}

    void OnMouseDrag()
    {
        Vector3 objectPointInScreen
            = Camera.main.WorldToScreenPoint(this.transform.position);

        Vector3 mousePointInScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPointInScreen.z);

        Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
        mousePointInWorld.z = this.transform.position.z;
        this.transform.position = mousePointInWorld;
    }


}
