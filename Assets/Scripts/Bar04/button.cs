using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button : MonoBehaviour
{

    public Text betText;

    public void plusbutton()
    {
        Debug.Log('+');
    }

    public void minusbutton()
    {
        Debug.Log('-');
    }

    //SceneManager.LoadScene()でシーンを読み込む
    public void clickstartbutton()
    {
        SceneManager.LoadScene("Game Screen");
    }
}