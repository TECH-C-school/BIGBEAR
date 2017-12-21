using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        private int count = 2;
        private int Dcount = 0;
        private int DeckCount = 0;          //デッキのカウント
        private int MyNumCount = 0;         //自分の数値
        private int DNumCount = 0;          //相手の数値
        private int AMycount = 0;           //自分のAの枚数
        private int ADcount = 0;            //相手のAの枚数
        public Text MyText;                 //自分の数値のテキスト
        public Text DText;                  //相手の数値のテキスト
        public void Start()
        {
            deck.RondomNum();
            //自分の初期カード
            Sprite cardSprite = null;                       //変数にカードの画像格納
            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
            if (deck.randomnum[DeckCount] > 10){            //カードの数値計算
                MyNumCount += 10;
            }else if(deck.randomnum[DeckCount] == 1){
                MyNumCount += 11;
                AMycount++;
            }else{
                MyNumCount += deck.randomnum[DeckCount];
            }
            

            DeckCount++;                                    //デッキを次のカードへ
            var Mycard1 = Resources.Load<GameObject>("Prefabs/Bar06/card");         //画像表示
            var MycardObject1 = Instantiate(Mycard1, transform.position, Quaternion.identity);
            MycardObject1.transform.position = new Vector3(-1.5f,-1);             //位置
            var spriteRenderer = MycardObject1.transform.GetComponent<SpriteRenderer>();    //画像差し替え
            spriteRenderer.sprite = cardSprite;

            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
            if (deck.randomnum[DeckCount] > 10){
                MyNumCount += 10;
            }else if (deck.randomnum[DeckCount] == 1){
                MyNumCount += 11;
                AMycount++;              
            }else{
                MyNumCount += deck.randomnum[DeckCount];
            }
            while (MyNumCount > 21 && AMycount > 0)
            {
                MyNumCount -= 10;
                AMycount--;
            }


            DeckCount++;
            var Mycard2 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var MycardObject2 = Instantiate(Mycard2, transform.position, Quaternion.identity);
            MycardObject2.transform.position = new Vector3(-0.8f, -1,-1);
            spriteRenderer = MycardObject2.transform.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = cardSprite;

            //相手の初期カード
            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
            if (deck.randomnum[DeckCount] > 10){
                DNumCount += 10;
            }else if (deck.randomnum[DeckCount] == 1){
                DNumCount += 11;
                ADcount++;
            }else{
                DNumCount += deck.randomnum[DeckCount];
            }
            DeckCount++;
            var Dcard1 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var DcardObject1 = Instantiate(Dcard1, transform.position, Quaternion.identity);
            DcardObject1.transform.position = new Vector3(-1.5f, 2, 0);
            spriteRenderer = DcardObject1.transform.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = cardSprite;

           
            var Dcard2 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var DcardObject2 = Instantiate(Dcard2, transform.position, Quaternion.identity);
            DcardObject2.transform.position = new Vector3(-0.8f, 2, 0);
        }
        void Update()
        {
            MyText.text = MyNumCount.ToString();
            DText.text = DNumCount.ToString();
        }
        public void AddBottunClick()
        {
            Sprite AddcardSprite = null;
            AddcardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);

            var Addcard = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var AddcardObject = Instantiate(Addcard, transform.position, Quaternion.identity);
            AddcardObject.transform.position = new Vector3(-1.5f+0.7f*count, -1, -1);

            var AddspriteRenderer = AddcardObject.transform.GetComponent<SpriteRenderer>();
            AddspriteRenderer.sprite = AddcardSprite;

            if (deck.randomnum[DeckCount] > 10){
                MyNumCount += 10;
            }else if (deck.randomnum[DeckCount] == 1){
                MyNumCount += 11;
                AMycount++;              
            }else{
                MyNumCount += deck.randomnum[DeckCount];
            }
            while (MyNumCount > 21 && AMycount > 0){
                MyNumCount -= 10;
                AMycount--;
            }
            if(MyNumCount > 21){
                Debug.Log("バスト");
            }


            DeckCount++;
            count++;
        }
        public void BattleBottunClick()
        {
            //相手の2枚目オープン
            Sprite DcardSprite = null;
            DcardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
            if (deck.randomnum[DeckCount] > 10){
                DNumCount += 10;   
            }else if (deck.randomnum[DeckCount] == 1){
                DNumCount += 11;
                ADcount++;
            }else{
                DNumCount += deck.randomnum[DeckCount];
            }
            while (DNumCount > 21 && ADcount > 0){
                DNumCount -= 10;
                ADcount--;
            }

            DeckCount++;
            var Dcard2 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var DcardObject2 = Instantiate(Dcard2, transform.position, Quaternion.identity);
            DcardObject2.transform.position = new Vector3(-0.8f, 2, 0);
            var BattlespriteRenderer = DcardObject2.transform.GetComponent<SpriteRenderer>();
            BattlespriteRenderer.sprite = DcardSprite;
            
            //相手の数値が17より↓だった場合カードを引く
            while(DNumCount < 17){
                DcardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
                if (deck.randomnum[DeckCount] > 10){
                    DNumCount += 10;
                }else if (deck.randomnum[DeckCount] == 1){
                    DNumCount += 11;
                    ADcount++;
                }else{
                    DNumCount += deck.randomnum[DeckCount];
                }
                while (DNumCount > 21 && ADcount > 0){
                    DNumCount -= 10;
                    ADcount--;
                }
                DeckCount++;
                var DAddcard = Resources.Load<GameObject>("Prefabs/Bar06/card");
                var DAddcardObject = Instantiate(DAddcard, transform.position, Quaternion.identity);
                DAddcardObject.transform.position = new Vector3(0f + Dcount *0.7f, 2, -1-Dcount);
                Dcount++;
                var AddBattlespriteRenderer = DAddcardObject.transform.GetComponent<SpriteRenderer>();
                AddBattlespriteRenderer.sprite = DcardSprite;
            }

            //勝敗判定
            if(DNumCount > 21){
                Debug.Log("相手バスト");
            }else if(MyNumCount < DNumCount){
                Debug.Log("負け");
                /*LOSE a = new LOSE();
                a.Lose();*/
            }else{
                Debug.Log("勝ち");
            }

        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
