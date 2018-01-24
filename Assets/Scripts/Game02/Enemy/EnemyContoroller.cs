using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

namespace Assets.Scripts.Game02 {
	public class EnemyContoroller : SingletonMono<EnemyContoroller> {
		[SerializeField] List<EnemyBase> enemys = new List<EnemyBase> ();
		[SerializeField] List<float> buildingHierarchy = new List<float>();
		[SerializeField] List<float> buildingColumns = new List<float>();
		[SerializeField] List<WaveInfo> _waveInfo = new List<WaveInfo>();
		IntReactiveProperty currentWave = new IntReactiveProperty();


		void Start() {
			EnemyGeneratePosSet ();
			currentWave.Value = 0;
		}

		void EnemyGeneratePosSet() {
//			var column = new List<int> {1, 2, 3, 4, 5};
//			var hierarchy = new List<int> {1, 2, 3, 4, 5};
			for(int i = 0; i < _waveInfo[currentWave.Value].enemyInfos.Count; i++) {
				var enemy = enemys.FirstOrDefault(e => e.gameObject.activeSelf == false);
				if (enemy == null)
					return;
//				var rnd_c = column.Count != 1 ? column [UnityEngine.Random.Range (0, hierarchy.Count-1)] : hierarchy[0];
//				column = column.Where (num => num != rnd_c).ToList ();
//				foreach(var num in column) {
//					Debug.Log ("numC:" + num);
//				}
//				var rnd_h = hierarchy.Count != 1 ? hierarchy [UnityEngine.Random.Range (0, hierarchy.Count-1)] : hierarchy[0];
//				hierarchy = hierarchy.Where (num => num != rnd_c).ToList ();
//				foreach(var num in hierarchy) {
//					Debug.Log ("numH:" + num);
//				}
				var genPos = new Vector3 (buildingColumns [_waveInfo[currentWave.Value].enemyInfos[i].column-1], buildingHierarchy [_waveInfo[currentWave.Value].enemyInfos[i].hierarchy-1], 0);
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
		public List<EnemyInfo> enemyInfos = new List<EnemyInfo>();
	}

	[Serializable]
	public class EnemyInfo {
		public EnemyType enemyType;
		public int column;
		public int hierarchy;
	}
}
