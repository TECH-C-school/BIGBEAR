using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar06{
	public class DisplayPath : MonoBehaviour {

		[SerializeField]
		List<int> passList = new List<int>();

		public int Lotteries = 0;

		void Start () 
		{
			
		}

		void Update () 
		{
			if (Input.anyKeyDown) 
			{
				Lottery ();
			}
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
