using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Assets.Scripts.Bar04
{

    public class Card : MonoBehaviour
    {

        private LayerMask mask;
        private int alpha;
        private Queue<int> hogehoge;
        // Use this for initialization






        //Alpha = 透明度 
        void OnMouseDown()
        {
            var image = gameObject.GetComponent<SpriteRenderer>();

            //alphaが0の場合、カードのalpha値は0になる。
            if (alpha == 0)
            {
                //alpha値を1にする。
                alpha = 1;

                image.color = new Color(255, 255, 255, alpha);

                //alphaが1の場合、カードのalpha値は1になる。
            }
            else if (alpha == 1)
            {
                //alpha値を0にする。
                alpha = 0;
                
                image.color = new Color(255, 255, 255, alpha);

            }

        }

        //作成したデッキの上からカードを5枚出す

            

      

        //ランダムに出した5つの数値を、カードの画像に当てはめる
       
        public enum Suit
        {
            SPADE,
            HEART,
            CLUB,
            DIA
        }

        public Suit suit;

        void Start()
        {
            
        }

        //void Update()
        //{
        //    if (hogehoge < 12) ;

        //}
        //SPADE(s01~s13)
        //HEART(h01~h13)
        //CLUB(c01~c13)
        //DIA(d01~d13)









        /*
        void Ray()
        {
            var Sel = gameObject.transform.FindChild("SelCard").gameObject;
            // Rayの作成
            Ray ray = new Ray(transform.position, transform.forward);
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Rayが衝突したコライダーの情報を得る
            RaycastHit hit;

            // Rayが衝突したかどうか

            if (Physics.Raycast(ray, out hit, 10.0f, mask))
            {

                var hitCard = hit.collider.GetComponentInChildren<GameObject>();
                hitCard.SetActive(true);
            }
            else if (Physics.Raycast(ray, out hit, 10.0f, mask))
            {

                var hitCard = hit.collider.GetComponentInChildren<GameObject>();
                hitCard.SetActive(false);
            }
            //出来なかったから諦め！
            */








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