using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game07
{
    public class CatchObject : MonoBehaviour
    {
        public enum CatchObj { Obj, Bullet }
        public CatchObj catchObj;

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
                        break;
                }
            }
        }
    }
}

