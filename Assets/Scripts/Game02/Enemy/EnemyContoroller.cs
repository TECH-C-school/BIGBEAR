using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Game02 {
	public class EnemyContoroller : MonoBehaviour {
		List<EnemyBase> enemys = new List<EnemyBase> ();

//		List<float> buildingColumns = new List<float> ();
//		List<float> buildingRow = new List<float>();

//		float[][] genPos = {
//			{}
//		};


		void EnemyGeneratePosSet() {
			var enemy = enemys.FirstOrDefault(e => e.gameObject.activeSelf == false);
			if (enemy == null)
				return;
		}
	}
}
