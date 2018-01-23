using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.Bar03
{
    public class Draganddrop : MonoBehaviour
    {

        public int _number = 0;

        private bool flg = false;
        // Use this for initialization
        void Start()
        {
            flg = false;
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }


        // Update is called once per frame
        void Update()
        {

            if (Input.GetMouseButton(0))
            {
                var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var selfPoint = gameObject.transform.position;
                var selfWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
                var selfHeight = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;


                if (GameController.flag == false && _number==1)
                {
                    if (tapPoint.x >= selfPoint.x - selfWidth / 2 && tapPoint.x <= selfPoint.x + selfWidth / 2 && tapPoint.y >= selfPoint.y - selfHeight / 2 && tapPoint.y <= selfPoint.y + selfHeight / 2)
                    {
                        flg = true;
                        Vector3 objectPointInScreen
                          = Camera.main.WorldToScreenPoint(this.transform.position);

                        Vector3 mousePointInScreen
                            = new Vector3(Input.mousePosition.x,
                                          Input.mousePosition.y,
                                          objectPointInScreen.z);

                        Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
                        this.transform.position = mousePointInWorld;

                        GameController.flag = true;
                    }
                }
                else
                {
                    // (flg) と(flg == true)は一緒
                    if (flg)
                    {
                        Vector3 inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        inputPosition.z += 10;
                        transform.position = inputPosition;

                    }
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                GameController.flag = false;
                flg = false;
            }
        }
    }
}