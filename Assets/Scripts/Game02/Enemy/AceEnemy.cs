using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game02 {
	public class AceEnemy : EnemyBase {
		protected override void Init ()
		{
			Debug.Log ("Children!!");
			base.Init ();
		}
	}
}
