using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar06{
	public class LevelSelect : MonoBehaviour {

		[HideInInspector]
		public bool isEasy,isNormal,isHard = false;

		//----------------------
		// どれかの難易度が選択されたらそれに応じたフラグを立てる
		public void TapEasy()
		{
			isEasy = true;
		}

		public void TapNormal()
		{
			isNormal = true;
		}

		public void TapHard()
		{
			isHard = true;
		}
		//----------------------
	}
}
