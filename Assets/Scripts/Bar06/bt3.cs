using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bt3 : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(true);
    }

    public void OnClick()
    {
        canb.SetActive("Button (3)", false);

    }
}