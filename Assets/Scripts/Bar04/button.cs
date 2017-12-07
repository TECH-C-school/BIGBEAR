using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{

    //SceneManager.LoadScene()でシーンを読み込む
    public void clickstartbutton()
    {
        SceneManager.LoadScene("Game Screen");
    }
}