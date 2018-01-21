using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureOfEight : MonoBehaviour {


    //移動速度
    public float m_moveSpeed = 2f;
    //円の半径
    public float m_radius = 4f;
	// Use this for initialization
	void Start ()
    {	
	}
	
	//毎フレーム更新処理
	void Update ()
    {
        //円移動
        // MoveToCircle();
        //８の字移動
//        MoveToFigureOfEight();
	}
    //円移動
    void MoveToCircle()
    {
        //経過時間の取得
        float time = Time.time;
        //円運動の座標演算
        float x = Mathf.Sin(time);
        float y = Mathf.Cos(time);
        float z = 0.0f;
        //オブジェクトに座標を代入
        transform.position = new Vector3(x, y, z);
    }
    //８の字移動
	public void MoveToFigureOfEight(Vector3 targetObjPos)
    {
        //時間経過の取得
        float time = Time.time;
        //８の字移動の座標演算
		float x = targetObjPos.x +  Mathf.Cos(Time.time * m_moveSpeed) * m_radius;
		float y = targetObjPos.y +  Mathf.Sin(Time.time * m_moveSpeed * 2) * m_radius / 2;
		float z = targetObjPos.z; 
        //オブジェクトに座標を代入
        transform.position = new Vector3(x, y, z);
    }
}
