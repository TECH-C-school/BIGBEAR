using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draganddrop : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetMouseButton(0))
            {
                var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var selfPoint = gameObject.transform.position;
                var selfWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
                var selfHeight = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;

                if (tapPoint.x <= -selfWidth / 2 || tapPoint.x >= selfWidth / 2 || tapPoint.y <= -selfHeight / 2 || tapPoint.y >= selfHeight / 2)
                {
                    Vector3 objectPointInScreen
                      = Camera.main.WorldToScreenPoint(this.transform.position);

                    Vector3 mousePointInScreen
                        = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      objectPointInScreen.z);

                    Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
                    this.transform.position = mousePointInWorld;
                }
                else
                {
                    return;
                }

                ////Collider2D上クリックの判定
                //if (!Physics2D.OverlapPoint(tapPoint)) return;

                ////クリックした位置のオブジェクトを取得
                //var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
                //if (!hitObject) return;

                //Vector3 mousePointInScreen
                //   = new Vector3(Input.mousePosition.x,
                //                  Input.mousePosition.y,
                //                  tapPoint.z);

                //Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
                //mousePointInWorld.z = this.transform.position.z;

            }
        }
    }
}
