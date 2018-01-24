using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game02 {
	public abstract class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour{
		private static T instance;
		public static T Instance {
			get {
				if(instance == null){
					System.Type t = typeof(T);
					instance = (T)FindObjectOfType (t);
				}
				return instance;
			}
		}

		protected virtual void Awake() {
			if(this != Instance) {
				Destroy (this.gameObject);
				return;
			}
			DontDestroyOnLoad (this.gameObject);
		}
	}
}
