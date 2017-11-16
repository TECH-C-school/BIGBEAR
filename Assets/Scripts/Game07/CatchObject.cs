using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game07
{
    public class CatchObject : MonoBehaviour
    {
        public enum CatchObj { Obj, Bullet }
        public CatchObj catchObj;
        public GameObject bom;
        GameObject boms;
        Canvas can;
        public Rigidbody m_rb;

        void Start()
        {
            m_rb = GetComponent<Rigidbody>();
            can = GameObject.FindObjectOfType<Canvas>();//Canvas初期化
        }

        void Update()
        {
            Debug.Log(Player.isMove);
            if (!Player.isMove)
            {
                StartCoroutine("Stopber");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                ///Herib.isCreate = false;
                //荷物か弾丸によって処理分け
                switch (catchObj)
                {
                    case CatchObj.Obj:
                        GameController.instance.AddScore();
                        break;
                    case CatchObj.Bullet:
                        GameController.instance.RemoveScore();
                        boms = Instantiate(bom, transform.position, Quaternion.identity);
                        boms.transform.SetParent(can.transform);//bomの生成位置指定
                        Player.isMove = false;
                        break;
                }
            }
        }
        IEnumerator Stopber()
        {
            yield return new WaitForSeconds(1f);
            Player.isMove = true;
        }
    }
}

