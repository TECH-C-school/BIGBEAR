using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar01 {
    public class GameController : MonoBehaviour {

        private const float screenWidth = 1136;
        private const float screenHight = 640;

        private GameObject deck;
        private GameObject flame;

        public float marginTop = 0;
        public float marginside = 0;

        private float scrennRatio = 1;

        private void Awake()
        {
            //画面を横にする
            Screen.orientation = ScreenOrientation.Landscape;
            //使用端末解像度と設定解像度の比率計算

            //初期化
            Initialization();
            //カード生成
            CreateCard();
        }

        private void Start()
        {
            
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialization()
        {
            GameObject setObject;
            Vector3 setPosition;
            deck = Resources.Load<GameObject>("Prefabs/Bar01/Deck");
            flame = Resources.Load<GameObject>("Prefabs/Bar01/CardFlame");
            //背景の配置
            Sprite backImage = Resources.Load<Sprite>("Images/Bar/bg");
            setObject = new GameObject("BackGround");
            setObject.AddComponent<SpriteRenderer>();
            setObject.GetComponent<SpriteRenderer>().sprite = backImage;
            setObject.transform.localScale *= scrennRatio;
            //カードフレームの配置
            setObject = Instantiate(deck);
            //カードの保管場所の設置
            Vector3 centerPoint = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
            float space = 1.6f;
            char[] marks = new char[] { 'd', 'c', 'h', 's' };
            for(int i = 0; i < 4; i++)
            {
                setObject = Instantiate(flame);
                setPosition = setObject.transform.position;
                setPosition.x = centerPoint.x + space * i;
                setObject.transform.position = setPosition;
                Sprite mark = Resources.Load<Sprite>("Images/Bar/cardflame_" + marks[i]);
                GameObject setMark = new GameObject(marks[i].ToString());
                SpriteRenderer markRenderer = setMark.AddComponent<SpriteRenderer>();
                markRenderer.sprite = mark;
                markRenderer.sortingOrder = 2;
                setMark.transform.parent = setObject.transform;
                setMark.transform.localPosition = Vector2.zero;
                setMark.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        /// <summary>
        /// カードを生成します。
        /// </summary>
        private void CreateCard()
        {

        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
