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
		private float upValue;
		public float UpValue {
			get { return upValue; }
			set { upValue = value; }
		}
		void OnEnable() {
			if(slider == null) return;
			slider.value = 0;
		}

		void Start () {
			slider = transform.FindChild("PowerBar").gameObject.GetComponent<Slider>();
		}
		// Update is called once per frame
		void Update () {
			slider.value += upValue;
			if(slider.value >= slider.maxValue || slider.value <= slider.minValue)
				upValue *= -1;
		}
	}
}
