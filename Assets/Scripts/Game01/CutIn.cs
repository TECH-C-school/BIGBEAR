using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CutIn : MonoBehaviour
{
    [SerializeField] GameManager gamemanager;

    void Start ()
    {
        CutInNow();
	}
	
	void Update ()
    {
	}

    void CutInNow()
    {
        if(transform.gameObject.CompareTag("playerCutIn"))
        {
            transform.DOMoveX(30, 1f)
                .OnComplete(() => { StartCoroutine("PlayerCutIn"); });
        }
        if (transform.gameObject.CompareTag("enemyCutIn"))
        {
            transform.DOMoveX(200f, 1f)
                .OnComplete(() => { StartCoroutine("EnemyCutIn"); });

        }
    }

    IEnumerator PlayerCutIn()
    {
        yield return  new WaitForSeconds(1f);
        gamemanager.playerCutIn.transform.DOMoveX(355, 1.5f).SetEase(Ease.Linear)
                            .OnComplete(() => { gamemanager.playerCutIn.SetActive(false);

                                gamemanager.TimerCount();
                            });

    }

    IEnumerator EnemyCutIn()
    {
        yield return new WaitForSeconds(1f);
        gamemanager.enemyCutIn.transform.DOMoveX(-120, 1.5f).SetEase(Ease.Linear)
                            .OnComplete(() => { gamemanager.enemyCutIn.SetActive(false); });
    }
}
