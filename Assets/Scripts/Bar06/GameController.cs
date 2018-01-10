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
        public Image image_Lose;            //負け画像
        public Image image_Win;             //勝ち画像
        public Image image_Draw;            //引き分け画像
        public Button AddB;                 //追加ボタン
        public Button BattleB;              //勝負ボタン
        public Button ReB;                  //再配置ボタン
        public void Start()
        {
            deck.RondomNum();
            image_Lose.fillAmount = 0;
            image_Win.fillAmount = 0;
            image_Draw.fillAmount = 0;

            //自分の初期カード
            var CardsObj = GameObject.Find("Cards");
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
            MycardObject1.transform.parent = CardsObj.transform;                    //Cardsに入れる
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
            MycardObject2.transform.parent = CardsObj.transform;
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
            DcardObject1.transform.parent = CardsObj.transform;
            spriteRenderer = DcardObject1.transform.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = cardSprite;

           
            var Dcard2 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var DcardObject2 = Instantiate(Dcard2, transform.position, Quaternion.identity);
            DcardObject2.transform.position = new Vector3(-0.8f, 2, 0);
            DcardObject2.transform.parent = CardsObj.transform;
        }
        void Update()
        {
            MyText.text = MyNumCount.ToString();
            DText.text = DNumCount.ToString();
        }
        public void AddBottunClick()
        {
            Sprite AddcardSprite = null;
            var CardsObj = GameObject.Find("Cards");
            AddcardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);

            var Addcard = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var AddcardObject = Instantiate(Addcard, transform.position, Quaternion.identity);
            AddcardObject.transform.position = new Vector3(-1.5f+0.7f*count, -1, -1);
            AddcardObject.transform.parent = CardsObj.transform;
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
                image_Lose.fillAmount = 1;
                EndButtun();
            }


            DeckCount++;
            count++;
        }
        public void BattleBottunClick()
        {
            //相手の2枚目オープン
            Sprite DcardSprite = null;
            var CardsObj = GameObject.Find("Cards");
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
            DcardObject2.transform.parent = CardsObj.transform;
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
                DAddcardObject.transform.parent = CardsObj.transform;
                Dcount++;
                var AddBattlespriteRenderer = DAddcardObject.transform.GetComponent<SpriteRenderer>();
                AddBattlespriteRenderer.sprite = DcardSprite;
            }

            //勝敗判定
            if(DNumCount > 21){
                image_Win.fillAmount = 1;
            }else if(MyNumCount < DNumCount){
                image_Lose.fillAmount = 1;
            }else if(MyNumCount == DNumCount){
                image_Draw.fillAmount = 1;
            }else{
                image_Win.fillAmount = 1;
            }
            EndButtun();
        }
        public void RestartBottunClick() {
            AddB.image.fillAmount = 1;
            AddB.enabled = true;
            ReB.image.fillAmount = 0;
            ReB.enabled = false;
            BattleB.image.fillAmount = 1;
            BattleB.enabled = true;
            image_Lose.fillAmount = 0;
            image_Win.fillAmount = 0;
            image_Draw.fillAmount = 0;

            var Cardsobj = GameObject.Find("Cards").transform;
            foreach(Transform CradObj in Cardsobj)
            {
                Destroy(Cardsobj.gameObject);
            }

            Start();
        }

        void EndButtun()
        {
            AddB.image.fillAmount = 0;
            AddB.enabled = false;
            ReB.image.fillAmount = 1;
            ReB.enabled = true;
            BattleB.image.fillAmount = 0;
            BattleB.enabled = false;
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
