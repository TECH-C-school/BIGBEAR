using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playershoot : MonoBehaviour {

    public GameObject _playertama;
    public GameObject _muzzle;

    float _Interval = 0;
    public float _IntervalMax = 0;


    void Start () {
		


	}
	
	
	void Update () {

        // 発射間隔設定
        _Interval += Time.deltaTime;


        if (Input.GetMouseButton(0)) {

            if(_Interval > _IntervalMax) {
                Instantiate(_playertama, _muzzle.transform.position, transform.rotation);
                _Interval = 0;
            }
            
        }

        
	}
}
