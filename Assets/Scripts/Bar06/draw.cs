using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw : MonoBehaviour {

    void Start()
    {
        gameObject.SetActive(false);
    }

    static public void winhyou()
    {
        canb.SetActive("text_draw", true);
    }
    static public void winhihyou()
    {
        canb.SetActive("text_draw", false);
    }
}
