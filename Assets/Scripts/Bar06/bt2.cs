using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bt2 : MonoBehaviour {

	void Start () {
        gameObject.SetActive(true);
    }

    public void OnClick()
    {
        canb.SetActive("Button",true );
        canb.SetActive("Button (1)", true);
        canb.SetActive("Button (4)", false);
        canb.SetActive("Button (5)", false);
        canb.SetActive("Text (4)", false);
        gameObject.SetActive(false);
        canb.SetActive("Image", false);
        canb.SetActive("Text (5)", false);
    }
}
