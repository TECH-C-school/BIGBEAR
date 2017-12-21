using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour {

    public GameObject _EI;
    //GameObject Enemys;

	// Use this for initialization
	void Start () {

       

	}
	
	// Update is called once per frame
	void Update () {

    }

    void Generation()
    {
      if(_EI != null) {
         Instantiate(_EI, this.transform.position, Quaternion.identity);
      }   
    }
}
