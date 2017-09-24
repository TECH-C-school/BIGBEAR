using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	void Start () {
    }
	
	void Update () {
	}

    public void TransitionToHome() {
        SceneManager.LoadScene("Home");
    }

    public void TransitionToCredit() {
        SceneManager.LoadScene("Credit");
    }

    public void TransitionToRoom() {
        SceneManager.LoadScene("Room");
    }

    public void TransitionToBar() {
        SceneManager.LoadScene("Bar");
    }

    public void TransitionToResult() {
        SceneManager.LoadScene("Result");
    }

    public void TransitionToSample() {
        SceneManager.LoadScene("SampleGame");
    }
}
