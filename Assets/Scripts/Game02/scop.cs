using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scop : MonoBehaviour {
    enum Dir
    {
        XPLUS=0,
        XMINUS,
        YMINUS,
        XYPLUS,
        XMINUSYPLUS,
    };
    Dir m_dir = Dir.XPLUS;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(-4f, -4f, 0f);
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (m_dir)
        {
            case Dir.XPLUS:
                transform.position += new Vector3(2f * Time.deltaTime, 2f * Time.deltaTime, 0f);
                if (transform.position.x >= 4f)
                {
                    m_dir = Dir.XYPLUS;
                }
                break;

            case Dir.XYPLUS:
                transform.position += new Vector3(0f, -2f * Time.deltaTime, 0f);
                if (transform.position.y <= -4f)
                {
                    m_dir = Dir.YMINUS;
                }
                break;

            case Dir.YMINUS:
                transform.position += new Vector3(-2f * Time.deltaTime, 2f * Time.deltaTime, 0f);
                if (transform.position.x <= -4f)
                {
                    m_dir = Dir.XMINUSYPLUS;
                }
                break;

            case Dir.XMINUSYPLUS:
                transform.position += new Vector3(0f, - 2f * Time.deltaTime, 0f);
                if (transform.position.y <= -4f)
                {
                    m_dir = Dir.XPLUS;
                }
                break;
        }
        //var x = 2 * Mathf.Sin(Time.time);
        //var y = 2 * Mathf.Cos(Time.time);
        

	}
}
