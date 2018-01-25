using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject _D;
    public GameObject _tama;

    void Start () {
		
	}
	
	
	void Update () {

        //_D.transform.parent = null; // 親と子の切り離し
    }

    void OnTriggerEnter2D(Collider2D _col)
    {
        Instantiate(_tama);
    }

}
