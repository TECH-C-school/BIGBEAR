using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Game06 {
    public class GameController : MonoBehaviour 
	{

		public GameObject e_flame;
		public GameObject cover;
		public GameObject restObj;
		public GameObject scoreObj;

		public Sprite[] numSprite = new Sprite[4];
		public Sprite[] linesSprite = new Sprite[2];

		[HideInInspector]
		public Image restImg;
		[HideInInspector]
		public Image scoreImag;
		public Image[] linesImag = new Image[2];

		public Text resultText;

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
		private int restCount = 3;
		public int RestCount
		{
			get { return this.restCount;}
			set { this.restCount = value;}
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
            SELECTDIFFICULTY = 0,
			CUTIN,
			COUNTDOWN,
			DISPPASS,
			RELEASING,
			GAMEEND
		}

		public GAMESTATES GameStates;

		[HideInInspector]
		public bool lotteryOnce = true;
        [HideInInspector]
        public bool isResult = false;

		void Start()
		{
			restImg = restObj.GetComponent<Image> ();
			scoreImag = scoreObj.GetComponent<Image> ();
		}

		void Update()
		{
			if ((GameStates == GAMESTATES.CUTIN) && lotteryOnce)
			{
				lotteryOnce = false;
				Lottery ();
			}
				
			if (restCount == 0) 
			{
				resultText.enabled = true;
                // リザルトに行けるようにする
                isResult = true;
			}

            if(isResult && Input.GetMouseButtonDown(0))
            {
                TransitionToResult();
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
