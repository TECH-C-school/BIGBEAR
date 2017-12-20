using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar01
{
    public class MenuController : MonoBehaviour
    {

        private bool menuSelect;
        private GameObject menuBack;
        private Vector3 closePosition;
        private Vector3 openPosition;

        // Use this for initialization
        void Start()
        {
            menuBack = transform.GetChild(0).gameObject;
            menuSelect = false;
            closePosition = transform.position;
            openPosition = closePosition + new Vector3(-1.537f, 0, 0);
            MenuOpen(false);
        }

        // Update is called once per frame
        void Update()
        {
            MenuClick();
        }

        private void MenuClick()
        {
            if (!Input.GetMouseButtonDown(0)) { return; }
            Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (!hit) { return; }
            if (hit.name == "b_menu")
            {
                menuSelect = !menuSelect;
                MenuOpen(menuSelect);
            }
        }

        private void MenuOpen(bool open)
        {
            if (open)
            {
                transform.position = openPosition;
                menuBack.SetActive(true);
            }
            else
            {
                transform.position = closePosition;
                menuBack.SetActive(false);
            }
        }
    }
}
