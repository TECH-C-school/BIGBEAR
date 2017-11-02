using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game06 {
	public class CheckUnlock : MonoBehaviour {

		public GameController _gameCtl;
		public TapKey _tapKey;

		private bool isCheck = true;

		void Start () {
			
		}

		void Update () 
		{
			//CheckUnlockKey ();
		}

		void CheckUnlockKey()
		{
			if ( _gameCtl.PassList.Count == _tapKey.TapKeyList.Count) 
			{
				isCheck = false;
			}

			if ( isCheck && _tapKey.TapKeyList.Count >= 1 ) 
			{
				if (_gameCtl.PassList [_tapKey.TapKeyNum] == _tapKey.TapKeyList [_tapKey.TapKeyNum]) 
				{
					Debug.Log ("あってるで");
				} 
				else 
				{
					Debug.Log ("違うで");
				}
			}
		}
	}
}