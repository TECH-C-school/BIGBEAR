using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game02 {
	public class MoveEnemy : EnemyBase {
		protected override void Init ()
		{
			base.Init ();
			Debug.Log ("Child!!");
		}
	}
}
