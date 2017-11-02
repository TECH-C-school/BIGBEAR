using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gistfile1 : MonoBehaviour
{
		//スワイプ判定の最低距離
		public float minSwipeDistX;
		public float minSwipeDistY;
		//実際にスワイプした距離
		private float swipeDistX;
		private float swipeDistY;
		//方向判定に使うSign値
		float SignValueX;
		float SignValueY;
		//タッチしたポジション
		private Vector2 startPos;
		//タッチを離したポジション
		private Vector2 endPos;
		//表示するテキスト
		public Text text;

		void Start ()
		{
				if (minSwipeDistX == 0) {
						minSwipeDistX = 50;
				}
				if (minSwipeDistY == 0) {
						minSwipeDistY = 50;
				}
		}

		void Update ()
		{
				//タッチされたら
				if (Input.touchCount > 0) {

						//タッチを取得
						Touch touch = Input.touches [0];

						//タッチフェーズによって場合分け
						switch (touch.phase) {

						//タッチ開始時
						case TouchPhase.Began:

								//タッチのポジションを取得してstartPosに代入
								startPos = touch.position;

								break;



						//タッチ終了時
						case TouchPhase.Ended:

				
								//タッチ終了のポジションをendPosに代入
								endPos = new Vector2 (touch.position.x, touch.position.y);

								//横方向判定
								//X方向にスワイプした距離を算出
								swipeDistX = (new Vector3 (endPos.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;
								print ("X" + swipeDistX.ToString ());
								if (swipeDistX > minSwipeDistX) {

										//x座標の差分のサインを計算
										//xの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
										SignValueX = Mathf.Sign (endPos.x - startPos.x);

										if (SignValueX > 0) {
												//右方向にスワイプしたとき
												//ここに処理を書いてください
												print ("RIGHT" + "swipeX is" + SignValueX.ToString ());
												text.text = "RightSwipe";
										} else if (SignValueX < 0) {
												//左方向にスワイプしたとき
												//ここに処理を書いてください
												print ("LEFT" + "swipeX is" + SignValueX.ToString ());
												text.text = "LEFTSwipe";
										}
								}

								//縦方向判定
								//Y方向にスワイプした距離を算出
								swipeDistY = (new Vector3 (0, endPos.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;
								//差分が最低スワイプ分を超えていた場合
								if (swipeDistY > minSwipeDistY) {

										//y座標の差分のサインを計算
										//yの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
										SignValueY = Mathf.Sign (endPos.y - startPos.y);

										if (SignValueY > 0) {
												//sin = 1
												print ("UP" + "swipeY is" + SignValueY.ToString ());
												//上方向にスワイプしたとき
												//ここに処理を書いてください
												text.text = "UPSwipe";
										} else if (SignValueY < 0) {
												//sin = -1
												print ("DOWN" + "swipeY is" + SignValueY.ToString ());
												//下方向にスワイプしたとき
												//ここに処理を書いてください
												text.text = "DownSwipe";
										}
								}
								break;
						}

				}
		}
}