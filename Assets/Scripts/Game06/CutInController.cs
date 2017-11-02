using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game06
{
	public class CutInController : MonoBehaviour
	{
		/// <summary>
		/// 1文字の表示スピード(秒)
		/// </summary>
		[SerializeField]
		private float[] viewSpeed = { 2f, 1f, 0.5f };

		[SerializeField]
		private Sprite[] passSprite = new Sprite[10];

	}
}