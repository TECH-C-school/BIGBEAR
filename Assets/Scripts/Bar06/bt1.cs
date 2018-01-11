using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bt1 : MonoBehaviour {
    void Start()
    {
        gameObject.SetActive(false);
    }
    static  public void OnClick()
    {
        canb.SetActive("Button", false);
        canb.SetActive("Button (1)", false);
        canb.SetActive("Button (2)", true);
        canb.SetActive("Button (4)", true);
        canb.SetActive("Button (5)", true);
        canb.SetActive("Text (4)", true);
        canb.SetActive("Image", false);
    }
    public void backOnClick()
    {
        canb.SetActive("Button", false);
        canb.SetActive("Button (1)", false);
        canb.SetActive("Button (2)", true);
        canb.SetActive("Button (4)", true);
        canb.SetActive("Button (5)", true);
        canb.SetActive("Text (4)", true);
        canb.SetActive("Image", false);
    }
}
