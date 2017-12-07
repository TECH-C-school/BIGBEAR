using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Timer : MonoBehaviour
{
    private float Time = 0;
    [SerializeField] GameObject AttackMark;

    void Start ()
    {
        TimerCount();
	}
	
	void Update ()
    {
		
	}

    void TimerCount()
    {
        Time += 0.1f;
        transform.DOJump(Vector3.zero, 10,1, Random.Range(5.0f, 13.0f))
            .OnStart(() => { AttackMark.SetActive(true); });

    }
}
