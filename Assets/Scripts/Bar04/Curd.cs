using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curd : MonoBehaviour
{

    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private GameObject cardSelect;

    // Use this for initialization
    void Start()
    {
        MakeCards();

    }


    // Update is called once per frame
    void Update()
    {
        //画面をタッチ(選択)されたらカードが光る
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("hogehoge");

        }
    }

    //カード複製 or 配置
    private void MakeCards()
    {
        //カードを５枚複製する
        for (int i = 0; i < 5; i++)
        {
            //カードを並べる
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector2(
                    i * 1.8f - 3.84f, 0);
            //カード生成
            GameObject SelCard = Instantiate(cardSelect);
            //黄色い枠の位置の設定　　　　カードの位置　+　z軸を-1する。
            Vector3 setPosition = cardObject.transform.position + new Vector3(0, 0, -1);
            //SelCard.transform.positionの位置にsetPositionを持っていく。
            SelCard.transform.position = setPosition;

        }
        /*
            //スマホのタッチ判定
            //スマホ向け そのオブジェクトがタッチされていたらtrue（マルチタップ対応）
            bool OneTouchDown()
            {
                // タッチされているとき
                if (0 < Input.touchCount)
                {
                    // タッチされている指の数だけ処理
                    for (int i = 0; i < Input.touchCount; i++)
                    {
                        // タッチ情報をコピー
                        Touch t = Input.GetTouch(i);
                        // タッチしたときかどうか
                        if (t.phase == TouchPhase.Began)
                        {
                            //タッチした位置からRayを飛ばす
                            Ray ray = Camera.main.ScreenPointToRay(t.position);
                            RaycastHit hit = new RaycastHit();
                            if (Physics.Raycast(ray, out hit))
                            {
                                //Rayを飛ばしてあたったオブジェクトが自分自身だったら
                                if (hit.collider.gameObject == cardPrefab)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;//タッチされてなかったらfalse
            }
            */

    }
}

