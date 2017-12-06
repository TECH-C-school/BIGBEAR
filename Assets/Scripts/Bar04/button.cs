using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public void clickstartbutton()
    {
        SceneManager.LoadScene("Bar04");
    }
}