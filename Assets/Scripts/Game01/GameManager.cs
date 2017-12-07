using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PlayerCutIn;
    public GameObject playerCutIn
    {
        get { return PlayerCutIn; }
        set { PlayerCutIn = value; }
    }
    [SerializeField] GameObject EnemyCutIn;
    public GameObject enemyCutIn
    {
        get { return EnemyCutIn; }
        set { EnemyCutIn = value; }
    }
    [SerializeField] GameObject AttackMark;

    public float Time = 0;

    void Start ()
    {
        AttackMark.SetActive(false);
        
    }
	
	void Update ()
    {
    }


    public void TimerCount()
    {
        Observable.Timer(System.TimeSpan.FromSeconds(Random.Range(5.0f, 13.0f))).Subscribe(_ => {
            AttackMark.transform.DOJump(AttackMark.transform.position, 1, 1, 0.5f)
            .OnStart(() => { AttackMark.SetActive(true); });
        }).AddTo(this);

    }
}
