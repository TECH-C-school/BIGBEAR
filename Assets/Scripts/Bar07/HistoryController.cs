using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07
{
    public class HistoryController : MonoBehaviour
    {
        public GameObject[] htext = new GameObject[7];

        private void Start()
        {
            for (int i = 0; i < 7; i++)
            {
                htext[i] = gameObject.transform.FindChild("Text" + (i+1).ToString()).gameObject;

            }
        }


        public void ChangeHistory(string text) {
            for (int i = 1; i < 7; i++)
            {
                htext[7-i].GetComponent<UnityEngine.UI.Text>().text = htext[6-i].GetComponent<UnityEngine.UI.Text>().text;
            }
            htext[0].GetComponent<UnityEngine.UI.Text>().text = text;
        }
    }
}