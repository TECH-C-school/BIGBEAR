using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.Scripts {
    public class Splash : MonoBehaviour {
        private GameController _gameController = null;

        void Start() {
            _gameController = GameObject.Find("GameController").GetComponent<GameController>();

            Observable.Timer(TimeSpan.FromSeconds(3)).Subscribe(_ => {
                _gameController.TransitionToHome();
            }).AddTo(this);
        }
    }
}
