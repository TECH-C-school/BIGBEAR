using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutekitime : MonoBehaviour {

	public GameObject _enemi;	// 敵の弾を入れる変数
	public bool _on_damage = false;	// ダメージフラグ
	private SpriteRenderer _renderer;

	// Use this for initialization
	void Start () {

		// 点滅処理の為に呼び出しておく
		_renderer = gameObject.GetComponent<SpriteRenderer>();
		//_enemi = GameObject.Find ("08_shell2"); // 変数にオブジェクト代入
	}
	
	// Update is called once per frame
	void Update () {
		// ダメージフラグがtrueで有れば点滅させる
		if (_on_damage) 
		{
			float _level = Mathf.Abs (Mathf.Sin (Time.time * 10));
			_renderer.color = new Color (1f, 1f, 1f, _level);
		}
	}

    // 敵とぶつかった際の処理
    private void OnCollisionEnter2D(Collision2D col)
    {
        //  敵とぶつかったかつダメージフラグがfalse
        if(!_on_damage && _enemi)
        {
            OnDamage();
        }
    }


    // ダメージを受けた際
    void OnDamage()
	{
		// ダメージフラグon
		_on_damage = true;

        // コルーチン開始
        StartCoroutine("WaitForIt");
    }

    IEnumerator WaitForIt()
    {
        // 3秒間処理を止める
        yield return new WaitForSeconds(3);

        // 1秒後ダメージフラグをfalseにして点滅を戻す
        _on_damage = false;
        _renderer.color = new Color(1f, 1f, 1f, 1f);
    }
	

}
