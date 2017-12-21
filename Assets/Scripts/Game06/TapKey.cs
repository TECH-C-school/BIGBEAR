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

			if ( isCheck && tapKeyList.Count >= 1 && _gameCtl.GameStates != GameController.GAMESTATES.GAMEEND) 
			{
				if (_gameCtl.PassList [tapKeyNum] == tapKeyList[tapKeyNum]) 
				{
					Debug.Log ("あってるで");
					// 最後まであってたら
					if (_gameCtl.PassList.Count == tapKeyList.Count) 
					{
						_gameCtl.RestCount--;
						//-------------------------------------------------------------------
						// クリアしていくごとに画面を変化させる
						switch (_gameCtl.RestCount) 
						{
						case 2:
							// カバーを外す
							_gameCtl.cover.SetActive (false);
							// 残りのカウント表示を減らす
							_gameCtl.restImg.sprite = _gameCtl.numSprite [2];
							// スコア表示を増やす
							_gameCtl.scoreImag.sprite = _gameCtl.numSprite [1];
							break;
						case 1:
							// コードを切る
							_gameCtl.linesImag [0].sprite = _gameCtl.linesSprite [0];
							// 残りのカウント表示を減らす
							_gameCtl.restImg.sprite = _gameCtl.numSprite [1];
							// スコア表示を増やす
							_gameCtl.scoreImag.sprite = _gameCtl.numSprite [2];
							break;
						case 0:
							// コードを外す
							_gameCtl.restImg.sprite = _gameCtl.numSprite [0];
							// 残りのカウント表示を減らす
							_gameCtl.scoreImag.sprite = _gameCtl.numSprite [3];
							// スコア表示を増やす
							_gameCtl.linesImag [1].sprite = _gameCtl.linesSprite [1];
							break;
						default:
							break;
						}
						//-------------------------------------------------------------------

						StartCoroutine (NextLottery ());

					}
				} 
				else 
				{
					Debug.Log ("違うで");
					_gameCtl.e_flame.SetActive (true);
					_gameCtl.GameStates = GameController.GAMESTATES.GAMEEND;
					StartCoroutine (DispGameOver());
				}
			}
		}

		IEnumerator DispGameOver()
		{
			yield return new WaitForSeconds (2);
			_gameCtl.resultText.text = "GAME OVER";
			_gameCtl.resultText.enabled = true;
            // リザルトに行けるようにする
            _gameCtl.isResult = true;
        }

		IEnumerator NextLottery()
		{
			yield return new WaitForSeconds (0.5f);
			// RestCountを見てゲームを繰り返すか判断
			if (_gameCtl.RestCount > 0) 
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
	}
}