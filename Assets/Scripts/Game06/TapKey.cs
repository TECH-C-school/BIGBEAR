using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game06{
	public class TapKey : MonoBehaviour 
	{
		public GameController _gameCtl;

		List<int> tapKeyList = new List<int>();

		public List<int> TapKeyList
		{
			get { return this.tapKeyList; }
			private set { this.tapKeyList = value; }
		}

		int tapKeyNum = -1;

		bool isCheck = true;

		public int TapKeyNum
		{
			get { return this.tapKeyNum; }
			private set { this.tapKeyNum = value; }
		}

		void Start () 
		{
			
		}

		void Update () 
		{


		}

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
			if ( _gameCtl.PassList.Count == tapKeyList.Count)
			{
				isCheck = false;
			}

			if ( isCheck && tapKeyList.Count >= 1 ) 
			{
				if (_gameCtl.PassList [TapKeyNum] == tapKeyList[TapKeyNum]) 
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