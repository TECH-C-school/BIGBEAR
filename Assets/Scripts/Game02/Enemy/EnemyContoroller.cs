using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Game02 {
	public class EnemyContoroller : MonoBehaviour {
		[SerializeField]
		List<EnemyBase> enemys = new List<EnemyBase> ();

		[SerializeField] List<float> buildingHierarchy = new List<float>();
		[SerializeField] List<float> buildingColumns = new List<float>();

		void Start() {
			EnemyGeneratePosSet ();
		}

		void EnemyGeneratePosSet() {
			var enemy = enemys.FirstOrDefault(e => e.gameObject.activeSelf == false);
			if (enemy == null)
				return;
			var rnd_h = Random.Range (1, 6);
			var rnd_c = Random.Range (1, 6);
			var genPos = new Vector3 (buildingColumns [rnd_c], buildingHierarchy [rnd_h], 0);
			enemy.Generate (genPos);
		}
	}
}
