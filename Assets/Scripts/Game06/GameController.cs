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

		void Start () 
		{
			Lottery ();
		}

		public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }

		void Lottery()
		{
			for (int i = 0; i < Lotteries; i++) 
			{
				passList.Add (Random.Range (0, 10));
			}
		}
    }
}
