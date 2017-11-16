using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {
    public readonly int maxHP = 100;
    public int HP;
    public int EnemyATK = 10;

	// Use this for initialization
	void Start () {
        HP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
        if (HP == 0)
        {
            Debug.Log("死亡");
        }
	}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Bullet")){
            HP -= EnemyATK;
            Debug.Log(HP);
        }
    }
}
