using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game02 {
	public enum EffectType {
		hit = 0,
		none
	};

	public class EffectController : SingletonMono<EffectController> {
		[SerializeField] List<EffectList> _effectList = new List<EffectList>();

		public void GenerateEffect(EffectType effectType, Vector3 generatePos) {
			var effect = _effectList [(int)effectType].effects.FirstOrDefault (e => e.gameObject.activeSelf == false);
			if (effect == null)
				return;
			effect.transform.position = generatePos;
			effect.SetActive (true);
			StartCoroutine (DeleteEffect (effect));
		}

		IEnumerator DeleteEffect(GameObject effect) {
			yield return new WaitForSeconds (1.0f);
			effect.SetActive (false);
		}
	}

	[Serializable]
	class EffectList {
		public List<GameObject> effects = new List<GameObject>();
	}
}
