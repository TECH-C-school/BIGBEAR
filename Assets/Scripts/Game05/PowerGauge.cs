using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace Assets.Scripts.Game05 {
	public class PowerGauge : MonoBehaviour {
		private Slider slider;
		public Slider Slider {
			get { return slider; }
		}
		private float upValue = 0;
		public float UpValue {
			get { return upValue; }
			set { upValue = value; }
		}
		private GameController gc;
		void OnEnable() {
			if(slider == null) return;
			slider.value = 0;
		}

		void Start () {
			gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
			slider = transform.FindChild("PowerBar").gameObject.GetComponent<Slider>();
		}
		// Update is called once per frame
		void Update () {
			if (!gc.isPause && !gc.IsFinished) {
				slider.value += upValue;
                if (slider.value >= slider.maxValue)
                    slider.value = 0;
			}
		}
	}
}
