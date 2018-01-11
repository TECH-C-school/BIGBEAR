using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

namespace Assets.Scripts.Game02 {
	public class EnemyContoroller : MonoBehaviour {
		[SerializeField] List<EnemyBase> enemys = new List<EnemyBase> ();
		[SerializeField] List<float> buildingHierarchy = new List<float>();
		[SerializeField] List<float> buildingColumns = new List<float>();
		[SerializeField] List<WaveInfo> _waveInfo = new List<WaveInfo>();
		IntReactiveProperty currentWave = new IntReactiveProperty();

		void Start() {
			EnemyGeneratePosSet ();
			currentWave.Value = 1;
		}

		void EnemyGeneratePosSet() {
			for(int i = 0; i < _waveInfo[currentWave.Value].enemyType.Count; i++) {
				var enemy = enemys.FirstOrDefault(e => e.gameObject.activeSelf == false);
				if (enemy == null)
					return;
				var rnd_h = UnityEngine.Random.Range (1, 6);
				var rnd_c = UnityEngine.Random.Range (1, 6);
				var genPos = new Vector3 (buildingColumns [rnd_c], buildingHierarchy [rnd_h], 0);
				enemy.Generate (genPos);
			}
		}
	}

	public enum EnemyType {
		normal = 0,
		move
	};

	[Serializable]
	public class WaveInfo {
		public List<EnemyType> enemyType = new List<EnemyType>();
	}
}
