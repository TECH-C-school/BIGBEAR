using UnityEngine; 
using System.Collections; 
using UnityEngine.SceneManagement; 
 
public class Pause : MonoBehaviour
{ 
    public GameObject OnPanel, OnUnPanel; 
    public bool pauseGame = false; 
      
    void Start()
    { 
        OnUnPause(); 
    } 
 
    public void Update()
    {

    } 

    public void PushButton()
    {
        pauseGame = !pauseGame;

        if (pauseGame == true)
        {
            OnPause();
        }
        else
        {
            OnUnPause();
        }
    }
 
    public void OnPause()
    { 
        OnPanel.SetActive(true);        // PanelMenuをtrueにする 
        OnUnPanel.SetActive(true);     // PanelEscをfalseにする 
        Time.timeScale = 0; 
        pauseGame = true; 
    } 
 
    public void OnUnPause()
    { 
        OnPanel.SetActive(false);       // PanelMenuをfalseにする 
        OnUnPanel.SetActive(false);      // PanelEscをtrueにする 
        Time.timeScale = 1; 
        pauseGame = false; 
    }
} 
