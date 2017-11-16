using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game06 {
    public class GameController : MonoBehaviour 
	{

		[SerializeField]
		private List<int> passList = new List<int>();

		public List<int> PassList
		{
			get { return this.passList;}
			private set { this.passList = value; }
		}
			
		/// <summary>
		/// 解除キーの数
		/// </summary>
		[SerializeField]
		private int[] passCount = { 3, 5, 7 };
		public int[] PassCount
		{
			get{ return this.passCount;}
		}

		public enum DIFFICULTY
		{
			AMATEUR = 0,
			PROFESSIONAL,
			LEGEND
		}

		public DIFFICULTY Difficulty; 

		public enum GAMESTATES
		{
			CUTIN = 0,
			COUNTDOWN,
			DISPPASS,
			RELEASING,
		}

		public GAMESTATES GameStates;

		[SerializeField]
		public bool lotteryOnce = true;

		void Update()
		{
			if ((GameStates == GAMESTATES.CUTIN) && lotteryOnce)
			{
				lotteryOnce = false;
				Lottery ();
			}
		}

		// 解除パスの抽選(難易度によって回数変動)
		void Lottery()
		{
			for (int i = 0; i < passCount[(int)Difficulty]; i++) 
			{
				passList.Add (Random.Range (0, 10));
			}
		}

		public void TransitionToResult() {
			SceneManager.LoadScene("Result");
		}

    }
}
