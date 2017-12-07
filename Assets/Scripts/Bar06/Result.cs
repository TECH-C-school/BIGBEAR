using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06
{
    public class Result : MonoBehaviour
    {
        public void Surrender()
        {
            SceneManager.LoadScene("ResultGo");
        }
    }
}