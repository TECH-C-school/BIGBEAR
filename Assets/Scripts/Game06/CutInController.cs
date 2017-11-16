using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game06
{
	public class CutInController : MonoBehaviour
	{
		public GameController _gameCtl;

		/// <summary>
		/// 1文字の表示スピード(秒)
		/// </summary>
		[SerializeField]
		private float[] viewSpeed = { 2f, 1f, 0.5f };

		[SerializeField]
		private Sprite[] passSprite = new Sprite[10];
		[SerializeField]
		private Sprite[] countSprite = new Sprite[3];

		public GameObject cutInObj;
		public GameObject passObj;
		public GameObject cutInText;
		public GameObject countObj;

		private Image passImg;
		private Image countImag;

		private bool isDispPass = false;
		private bool dispOnce = true;
		private bool isDispCount = false;

		void Start()
		{
			passImg = passObj.GetComponent<Image> ();
			countImag = countObj.GetComponent<Image> ();
		}

		void Update()
		{
			CutIn ();
		}

		void CutIn()
		{
			// GameStatesがCUTINの時に
			if (_gameCtl.GameStates == GameController.GAMESTATES.CUTIN) 
			{
				// カットインに関する画像を表示する
				cutInObj.SetActive (true);

				// クリックされたら
				if (Input.GetMouseButtonDown (0)) 
				{
					// カットイン中のテキストを非表示にする
					cutInText.SetActive (false);
					isDispCount = true;
				}
			}
			// GameStatesが変わったら
			else if(_gameCtl.GameStates == GameController.GAMESTATES.RELEASING)
			{
				// 初期化
				cutInObj.SetActive (false);
				cutInText.SetActive (true);
			}

			if (isDispCount) 
			{
				_gameCtl.GameStates = GameController.GAMESTATES.COUNTDOWN;
				countObj.SetActive (true);
				StartCoroutine (CountDown ());
			}

			if (isDispPass) 
			{
				_gameCtl.GameStates = GameController.GAMESTATES.DISPPASS;
				// 解除コードを表示する
				StartCoroutine (DispPass ());
			}
		}

		// 解除コードを表示する処理
		IEnumerator DispPass()
		{
			if (dispOnce)
			{
				// 何回表示させるか
				for (int i = 0; i < _gameCtl.PassCount[(int)_gameCtl.Difficulty]; i++) 
				{
					dispOnce = false;
					// n秒時間を置いて
					yield return new WaitForSeconds (0.5f);
					// 解除コードの画像の差し替え
					passImg.sprite = passSprite [_gameCtl.PassList [i]];
					// 解除コードを表示させる
					passObj.SetActive (true);
					// n秒たったら
					yield return new WaitForSeconds (viewSpeed[(int)_gameCtl.Difficulty]);
					// 非表示にする
					passObj.SetActive (false);
					dispOnce = true;
					// 最後の解除キーまで表示したら
					if (i >= (_gameCtl.PassCount[(int)_gameCtl.Difficulty] - 1)) 
					{
						isDispPass = false;
						// GamestesをRELEASINGに変える
						_gameCtl.GameStates = GameController.GAMESTATES.RELEASING;
					}
				}
			}
		}

		// カウントダウンの処理
		IEnumerator CountDown()
		{
			if (dispOnce) 
			{
				dispOnce = false;
				for (int i = 0; i < countSprite.Length; i++) 
				{
					countImag.sprite = countSprite [i];
					yield return new WaitForSeconds (1);
					if (i >= (countSprite.Length - 1)) 
					{
						isDispCount = false;
						countObj.SetActive (false);
						dispOnce = true;
						isDispPass = true;
					}
				}
			}
		}
	}
}