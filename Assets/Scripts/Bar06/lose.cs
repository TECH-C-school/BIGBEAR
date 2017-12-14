using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lose : MonoBehaviour {

    void Start()
    {
        gameObject.SetActive(false);
    }

    static public void winhyou()
    {
        canb.SetActive("bakaralose", true);
    }
    static public void winhihyou()
    {
        canb.SetActive("bakaralose", false);
    }
}
