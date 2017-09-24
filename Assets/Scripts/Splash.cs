using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {
    private GameController gameController = null;

    void Start () {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        Observable.Timer(TimeSpan.FromSeconds(3)).Subscribe(_ => {
            gameController.TransitionToHome();
        }).AddTo(this);
    }

    void Update () {
	}
}
