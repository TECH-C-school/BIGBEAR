using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeText : MonoBehaviour
{
    [SerializeField]
    Sprite[] Time_font;

    [SerializeField]
    Image Time_image;

    public Image Time_Fonts;

    List<int> Sprite_num_Time = new List<int>();

    void Start ()
    {
        // タイマー初期イメージ
        RectTransform t_image = (RectTransform)Instantiate(Time_image).transform;
        t_image.SetParent(this.transform, false);
        t_image.localPosition = new Vector2(
            // 中央揃え
            t_image.localPosition.x, 0);
        t_image.GetComponent<Image>().sprite = Time_font[0];
	}

    /// <summary>
    /// タイマー表示用関数
    /// </summary>
    /// <param name="value">タイマー</param>
    void _TimeImage (int value)
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
        Sprite_num_Time = new List<int>();
        while (digit != 0)
        {
            value = digit % 10;
            digit = digit / 10;
            Sprite_num_Time.Add(value);
        }
        var division = 0f;
        //センタリングのため桁数で位置を判断
        if (Sprite_num_Time.Count % 2 == 0) division = 3.6f;
        else if (Sprite_num_Time.Count == 1) division = 100f;
        else if (Sprite_num_Time.Count % 2 != 0) division = 2.85f;

        for (int i = 0; i < Sprite_num_Time.Count; ++i)
        {
            //複製
            RectTransform s_image = (RectTransform)Instantiate(Time_image).transform;
            s_image.SetParent(Time_Fonts.transform, false);
            s_image.localPosition = new Vector2(
                 //中央揃え
                 s_image.localPosition.x - (s_image.sizeDelta.x - 13.5f) * (i - Sprite_num_Time.Count / division),
                s_image.localPosition.y);
            s_image.localScale = new Vector3(0.7f, 0.7f, 0f);
            s_image.GetComponent<Image>().sprite = Time_font[Sprite_num_Time[i]];

        }
    }
}
