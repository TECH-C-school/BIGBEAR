using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellControlle : MonoBehaviour {


    public GameObject shell;
    public GameObject Bear;

    

    public Button shot;

    //bool tanpatu = true;


    //Vector2 she;


    void Start () {
        
    }
	
	
	void Update() {
        
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {

        yield return new WaitForSeconds(waitTime);
        action();
    }

    public void onclick()
    {
        {
            StartCoroutine(DelayMethod(1f, () =>//1f後に実行
                {
                    shot.interactable = true;
                    Debug.Log(shot);
                }));
            shot.interactable = false;
            GameObject shelll = Instantiate(shell, new Vector2(Bear.transform.position.x, Bear.transform.position.y), Quaternion.identity);

            if (shelll)//弾がヘリに当たって消えた時。これが出来てない
            {
                shot.interactable = true;//ヘリに当たったら弾が消える。ボタンも再び押せるようになる。
                Debug.Log("papapapapa");
            }
            if (shelll)//弾が生成された時
            {
                Destroy(shelll, 1f);
                //GetComponent<ShellControlle>().shot.interactable = true;
            }
        }
    }

    //public void OnTriggerEnter2D(Collider2D shell)
    //{
    //    if (shell) {
    //        shot.interactable = true;
    //        Debug.Log("apppppppp");
    //    }
    //}
}
