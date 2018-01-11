using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scop : MonoBehaviour {

    //円の半径
    public float m_radius = 4f;
    //軸の移動速度
    public float m_moveSpeed = 2f;
    //軸の回転速度
    public float m_angleSpeed = 0.1f;
	void Start ()
    {
		
	}
	
    //毎フレーム更新処理
	void Update ()
    {
        //軸の回転処理
        RotateAxis();
        //軸の移動処理
        MovePos();
	}

    //軸の回転処理
    void RotateAxis()
    {
        //回転処理
        transform.Rotate(0, m_angleSpeed, 0);
    }
    //軸の移動処理
    void MovePos()
    {
        ////経過時間の取得
        //float time = Time.time;
        //振幅
        //flot amplitude = 5;
        ////円運動の座標演算
        //float x = Mathf.Sin(time * m_moveSpeed) * amplitude;
        //float y = 0.0f;
        //float z = 0f;
        ////オブジェクトに座標を代入
        //transform.position = new Vector3(x, y, z);
        //オブジェクトの座標に加算
        transform.Translate(0f, 0f, 0.01f);
    }

    //8の字移動
    void MoveToFigureOfEight()
    {
        //経過時間の取得
        float time = Time.time;
        //8の字移動の座標演算
        float x = Mathf.Cos(time * m_moveSpeed) * m_radius;
        float y = 0.0f;
        float z = Mathf.Sin(time * m_moveSpeed * 2) * m_radius / 3;
        //オブジェクトに座標を代入
        transform.position = new Vector3(x, y, z);
        //オブジェクトにローカル座標で代入
        transform.localPosition = new Vector3(x, y, z);

    }
}
