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

		public GameObject cutInObj;
		public GameObject passObj;
		public GameObject cutInText;
		private Image passImg;

		private bool isDsipPass = false;
		private bool dispOnce = true;

		void Start()
		{
			passImg = passObj.GetComponent<Image> ();
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
					isDsipPass = true;
				}

				if (isDsipPass) 
				{
					// 解除コードを表示する
					StartCoroutine (DispPass ());
				}
			}
			// GameStatesが変わったら
			else 
			{
				// 初期化
				cutInObj.SetActive (false);
				cutInText.SetActive (true);
			}
		}

		// 解除コードを表示する処理
		IEnumerator DispPass()
		{
			if (dispOnce)
			{
				// 何回表示させるか
				for (int i = 0; i < 3; i++) 
				{
					dispOnce = false;
					// １秒時間を置いて
					yield return new WaitForSeconds (0.5f);
					// 解除コードの画像の差し替え
					passImg.sprite = passSprite [_gameCtl.PassList [i]];
					// 解除コードを表示させる
					passObj.SetActive (true);
					// n秒たったら
					yield return new WaitForSeconds (1);
					// 非表示にする
					passObj.SetActive (false);
					dispOnce = true;
					// 最後の解除キーまで表示したら
					if (i >= 2) 
					{
						isDsipPass = false;
						// GamestesをRELEASINGに変える
						_gameCtl.GameStates = GameController.GAMESTATES.RELEASING;
					}
				}
			}
		}
	}
}