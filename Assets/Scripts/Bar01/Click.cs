using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    private GameObject selectCred;
    private Vector3 RecordPosition;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {/*
        ClickCard();
        if (selectCred)
        {
            Vector3 setPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            setPosition.z = -14;
            selectCred.transform.position = setPosition;
        }
        ReturnCard();
        */
    }
    /// <summary>
    ///クリック中にオブジェクトを移動するスクリプト
    /// </summary>
    private void ClickCard()
    {/*
        var InputPosition = Input.mousePosition;

        if (!Input.GetMouseButtonDown(0)) return;

        var TapPoint = Camera.main.ScreenToWorldPoint(InputPosition);
        Debug.Log(TapPoint);

        if (!Physics2D.OverlapPoint(TapPoint)) return;
        Debug.Log("hogehoge");

        var HitObject = Physics2D.Raycast(TapPoint, -Vector3.up);
        Debug.Log(HitObject.transform.name);

        TapPoint.z = -14;
        if (!HitObject) return;
        RecordPosition = HitObject.transform.position;
        selectCred = HitObject.transform.gameObject;
*/
    }

    /// <summary>
    /// クリックボタンを離したときにオブジェクトを元に戻すスクリプト
    /// </summary>
    private void ReturnCard()
    {/*
        if (!Input.GetMouseButtonUp(0)) return;

        selectCred.transform.position = RecordPosition;

        selectCred = null;
        */
    }
}
