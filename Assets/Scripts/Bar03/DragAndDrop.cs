using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draganddrop : MonoBehaviour
{
    public bool frag = true;
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
                Debug.Log(selfWidth);
                var selfHeight = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;

                if (tapPoint.x >= selfPoint.x - selfWidth / 2 && tapPoint.x <= selfPoint.x + selfWidth / 2 && tapPoint.y >= selfPoint.y - selfHeight / 2 && tapPoint.y <= selfPoint.y + selfHeight / 2)
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
            }
        }
    }
}
