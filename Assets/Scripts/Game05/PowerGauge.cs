using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class PowerGauge : MonoBehaviour {
	private Slider _slider;
	public Slider slider {
		get { return _slider; }
	}
	private float _upValue;
	public float upValue {
		get { return _upValue; }
		set { _upValue = value; }
	}
	void OnEnable() {
		if(_slider == null) return;
		_slider.value = 0;
	}

	void Start () {
		_slider = transform.FindChild("PowerBar").gameObject.GetComponent<Slider>();
	}
	// Update is called once per frame
	void Update () {
		_slider.value += _upValue;
		if(_slider.value >= _slider.maxValue || _slider.value <= _slider.minValue)
			_upValue *= -1;
	}
}
