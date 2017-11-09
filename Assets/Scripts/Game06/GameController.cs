using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game06 {
    public class GameController : MonoBehaviour 
	{

		[SerializeField]
		List<int> passList = new List<int>();

		public List<int> PassList
		{
			get { return this.passList;}
			private set { this.passList = value; }
		}

		public int Lotteries = 0;

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

		// 解除パスの抽選
		void Lottery()
		{
			for (int i = 0; i < Lotteries; i++) 
			{
				passList.Add (Random.Range (0, 10));
			}
		}

		public void TransitionToResult() {
			SceneManager.LoadScene("Result");
		}

    }
}
