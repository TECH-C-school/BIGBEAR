using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game06{
	public class TapKey : MonoBehaviour 
	{
		public GameController _gameCtl;

		List<int> tapKeyList = new List<int>();
		
		int tapKeyNum = -1;

		bool isCheck = true;

		public void Push_A()
		{
			Debug.Log ("Akey");
			TapNumAddList (0);
			CheckUnlockKey ();
		}
		public void Push_B()
		{
			Debug.Log ("Bkey");
			TapNumAddList (1);
			CheckUnlockKey ();
		}
		public void Push_C()
		{
			Debug.Log ("Ckey");
			TapNumAddList (2);
			CheckUnlockKey ();
		}
		public void Push_D()
		{
			Debug.Log ("Dkey");
			TapNumAddList (3);
			CheckUnlockKey ();
		}
		public void Push_E()
		{
			Debug.Log ("Ekey");
			TapNumAddList (4);
			CheckUnlockKey ();
		}
		public void Push_F()
		{
			Debug.Log ("Fkey");
			TapNumAddList (5);
			CheckUnlockKey ();
		}
		public void Push_G()
		{
			Debug.Log ("Gkey");
			TapNumAddList (6);
			CheckUnlockKey ();
		}
		public void Push_H()
		{
			Debug.Log ("Hkey");
			TapNumAddList (7);
			CheckUnlockKey ();
		}
		public void Push_I()
		{
			Debug.Log ("Ikey");
			TapNumAddList (8);
			CheckUnlockKey ();
		}
		public void Push_J()
		{
			Debug.Log ("Jkey");
			TapNumAddList (9);
			CheckUnlockKey ();
		}

		void TapNumAddList(int num)
		{
			tapKeyList.Add (num);
			tapKeyNum++;
		}

		void CheckUnlockKey()
		{
			if ( _gameCtl.PassList.Count < tapKeyList.Count)
			{
				isCheck = false;
			}

			if ( isCheck && tapKeyList.Count >= 1 ) 
			{
				if (_gameCtl.PassList [tapKeyNum] == tapKeyList[tapKeyNum]) 
				{
					Debug.Log ("あってるで");
					// 最後まであってたら
					if (_gameCtl.PassList.Count == tapKeyList.Count) 
					{
						// GameStatesをCUTINに変える
						_gameCtl.GameStates = GameController.GAMESTATES.CUTIN;
						// 初期化
						tapKeyList.Clear ();
						tapKeyNum = -1;
						_gameCtl.PassList.Clear ();
						_gameCtl.lotteryOnce = true;
					}
				} 
				else 
				{
					Debug.Log ("違うで");
				}
			}
		}
	}
}