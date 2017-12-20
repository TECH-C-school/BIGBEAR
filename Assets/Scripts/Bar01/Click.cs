using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ClickCard();
    }

    private void ClickCard()
    {
        var InputPosition = Input.mousePosition;

        if (!Input.GetMouseButton(0)) return;

        var TapPoint = Camera.main.ScreenToWorldPoint(InputPosition);
        Debug.Log(TapPoint);

        if (!Physics2D.OverlapPoint(TapPoint)) return;
        Debug.Log("hogehoge");

        var HitObject = Physics2D.Raycast(TapPoint, -Vector3.up);
        Debug.Log(HitObject.transform.name);

        TapPoint.z = -14;
        if (!HitObject) return;

        HitObject.transform.position = new Vector3(TapPoint.x, TapPoint.y, -14);
        Debug.Log(HitObject.transform.position);
    }
}
