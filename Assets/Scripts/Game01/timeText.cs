using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class timeText : MonoBehaviour
{
    [SerializeField]
    Sprite[] Time_imageR;
    [SerializeField]
    Sprite[] Time_imageL;

    //表示用
    [SerializeField]
    Image spr_timeR;
    [SerializeField]
    Image spr_timeL;

    //親
    public Image Time_ParentsR;
    public Image Time_ParentsL;

    List<int> Sprite_num_TimeR = new List<int>();
    List<int> Sprite_num_TimeL = new List<int>();

    void Start()
    {

    }
    
    /// <summary>
    /// 時間表示用関数
    /// </summary>
    /// <param name="value">時間</param>
    public void _SprTime(int value)
    {
        if (value >= 999)
        {
            Debug.Log("999秒以上です");
            return;
        }

        var objs = GameObject.FindGameObjectsWithTag("Time_number");
        foreach (var obj in objs)
        {
            if (0 <= obj.name.LastIndexOf("Clone"))
            {
                Destroy(obj);
            }
        }

        var digit = value;
        Sprite_num_TimeR = new List<int>();
        Sprite_num_TimeL = new List<int>();
        while (digit != 0)
        {
            value = digit % 10;
            digit = digit / 10;
            Sprite_num_TimeR.Add(value);
            Sprite_num_TimeL.Add(value);
        }
        var division = 0f;
        //センタリングのため桁数で位置を判断
        if (Sprite_num_TimeR.Count % 2 == 0) division = 3.6f;
        else if (Sprite_num_TimeR.Count == 1) division = 100f;
        else if (Sprite_num_TimeR.Count % 2 != 0) division = 2.85f;

        if (Sprite_num_TimeL.Count % 2 == 0) division = 3.6f;
        else if (Sprite_num_TimeL.Count == 1) division = 100f;
        else if (Sprite_num_TimeL.Count % 2 != 0) division = 2.85f;

        for (int i = 0; i < Sprite_num_TimeR.Count; ++i)
        {
            //複製
            RectTransform s_image = (RectTransform)Instantiate(spr_timeR).transform;
            s_image.SetParent(Time_ParentsR.transform, false);
            s_image.localPosition = new Vector2(
                 //中央揃え
                 s_image.localPosition.x - (s_image.sizeDelta.x - 13.5f) * (i - Sprite_num_TimeR.Count / division),
                s_image.localPosition.y);
            s_image.localScale = new Vector3(0.7f, 0.7f, 0f);
            s_image.GetComponent<Image>().sprite = Time_imageR[Sprite_num_TimeR[i]];
        }
        for (int j = 0; j < Sprite_num_TimeL.Count; ++j)
        {
            //複製
            RectTransform s_image = (RectTransform)Instantiate(spr_timeL).transform;
            s_image.SetParent(Time_ParentsL.transform, false);
            s_image.localPosition = new Vector2(
                 //中央揃え
                 s_image.localPosition.x - (s_image.sizeDelta.x - 13.5f) * (j - Sprite_num_TimeL.Count / division),
                s_image.localPosition.y);
            s_image.localScale = new Vector3(0.7f, 0.7f, 0f);
            s_image.GetComponent<Image>().sprite = Time_imageL[Sprite_num_TimeL[j]];
        }
    }
}
