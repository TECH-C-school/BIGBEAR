using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bt1 : MonoBehaviour {

    static  public void OnClick()
    {
        canb.SetActive("Button", false);
        canb.SetActive("Button (1)", false);
        canb.SetActive("Button (3)", false);
        canb.SetActive("Button (2)", true);
    }
    public void backOnClick()
    {
        canb.SetActive("Button", false);
        canb.SetActive("Button (1)", false);
        canb.SetActive("Button (3)", false);
        canb.SetActive("Button (2)", true);
    }
}
