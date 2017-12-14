using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bt2 : MonoBehaviour {

	void Start () {
        gameObject.SetActive(false);
    }

    public void OnClick()
    {
        canb.SetActive("Button",true );
        canb.SetActive("Button (1)", true);
        gameObject.SetActive(false);
    }
}
