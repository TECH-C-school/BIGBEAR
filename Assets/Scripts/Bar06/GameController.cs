using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        private int count = 2;
        private int Dcount = 0;
        private int DeckCount = 0;          //デッキのカウント
        private int MyNumCount = 0;         //自分の数値
        private int DNumCount = 0;          //相手の数値
        private int AMycount = 0;           //自分のAの枚数
        private int ADcount = 0;           //相手のAの枚数
        public void Start()
        {
            deck.RondomNum();
            //自分の初期カード
            Sprite cardSprite = null;                       //変数にカードの画像格納
            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
            if (deck.randomnum[DeckCount] > 10){            //カードの数値計算
                MyNumCount += 10;
                Debug.Log(MyNumCount);
            }else if(deck.randomnum[DeckCount] == 1){
                MyNumCount += 11;
                AMycount++;
                Debug.Log(MyNumCount);
            }else{
                MyNumCount += deck.randomnum[DeckCount];
                Debug.Log(MyNumCount);
            }
            DeckCount++;                                    //デッキを次のカードへ
            var Mycard1 = Resources.Load<GameObject>("Prefabs/Bar06/card");         //画像表示
            var MycardObject1 = Instantiate(Mycard1, transform.position, Quaternion.identity);
            MycardObject1.transform.position = new Vector3(-1.5f,-1,0);             //位置
            var spriteRenderer = MycardObject1.transform.GetComponent<SpriteRenderer>();    //画像差し替え
            spriteRenderer.sprite = cardSprite;

            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
            if (deck.randomnum[DeckCount] > 10){
                MyNumCount += 10;
                Debug.Log(MyNumCount);
            }else if (deck.randomnum[DeckCount] == 1){
                MyNumCount += 11;
                AMycount++;
                Debug.Log(MyNumCount);
            }else{
                MyNumCount += deck.randomnum[DeckCount];
                Debug.Log(MyNumCount);
            }
            if (MyNumCount > 21){
                MyNumCount -= AMycount * 10;
            }
            DeckCount++;
            var Mycard2 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var MycardObject2 = Instantiate(Mycard2, transform.position, Quaternion.identity);
            MycardObject2.transform.position = new Vector3(0, -1, 0);
            spriteRenderer = MycardObject2.transform.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = cardSprite;

            //相手の初期カード
            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
            if (deck.randomnum[DeckCount] > 10){
                DNumCount += 10;
                Debug.Log(DNumCount);
            }else if (deck.randomnum[DeckCount] == 1){
                DNumCount += 11;
                ADcount++;
                Debug.Log(DNumCount);
            }else{
                DNumCount += deck.randomnum[DeckCount];
                Debug.Log(DNumCount);
            }
            DeckCount++;
            var Dcard1 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var DcardObject1 = Instantiate(Dcard1, transform.position, Quaternion.identity);
            DcardObject1.transform.position = new Vector3(-1.5f, 2, 0);
            spriteRenderer = DcardObject1.transform.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = cardSprite;

           
            var Dcard2 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var DcardObject2 = Instantiate(Dcard2, transform.position, Quaternion.identity);
            DcardObject2.transform.position = new Vector3(0, 2, 0);
        }
        void Update()
        {
            
            if (DNumCount > 21){
                DNumCount -= ADcount * 10;
            }
        }
        public void AddBottunClick()
        {
            Sprite AddcardSprite = null;
            AddcardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);

            var Addcard = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var AddcardObject = Instantiate(Addcard, transform.position, Quaternion.identity);
            AddcardObject.transform.position = new Vector3(-1.5f+1.5f*count, -1, 0);

            var AddspriteRenderer = AddcardObject.transform.GetComponent<SpriteRenderer>();
            AddspriteRenderer.sprite = AddcardSprite;

            if (deck.randomnum[DeckCount] > 10){
                MyNumCount += 10;
                Debug.Log(MyNumCount);
            }else if (deck.randomnum[DeckCount] == 1){
                MyNumCount += 11;
                AMycount++;
                Debug.Log(MyNumCount);
            }else{
                MyNumCount += deck.randomnum[DeckCount];
                Debug.Log(MyNumCount);
            }
            if (MyNumCount > 21){
                MyNumCount -= AMycount * 10;
            }

            DeckCount++;
            count++;
        }
        public void BattleBottunClick()
        {
            
            Sprite DcardSprite = null;
            DcardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
            if (deck.randomnum[DeckCount] > 10){
                DNumCount += 10;
                Debug.Log(DNumCount);
            }else if (deck.randomnum[DeckCount] == 1){
                DNumCount += 11;
                ADcount++;
                Debug.Log(DNumCount);
            }else{
                DNumCount += deck.randomnum[DeckCount];
                Debug.Log(DNumCount);
            }
            if (DNumCount > 21)
            {
                DNumCount -= ADcount * 10;
            }
            DeckCount++;
            var Dcard2 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var DcardObject2 = Instantiate(Dcard2, transform.position, Quaternion.identity);
            DcardObject2.transform.position = new Vector3(0, 2, 0);
            var BattlespriteRenderer = DcardObject2.transform.GetComponent<SpriteRenderer>();
            BattlespriteRenderer.sprite = DcardSprite;
            
            while(DNumCount < 17){
                DcardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
                if (deck.randomnum[DeckCount] > 10){
                    DNumCount += 10;
                    Debug.Log(DNumCount);
                }else if (deck.randomnum[DeckCount] == 1){
                    DNumCount += 11;
                    ADcount++;
                    Debug.Log(DNumCount);
                }else{
                    DNumCount += deck.randomnum[DeckCount];
                    Debug.Log(DNumCount);
                }
                if (DNumCount > 21){
                    DNumCount -= ADcount * 10;
                }
                DeckCount++;
                var DAddcard = Resources.Load<GameObject>("Prefabs/Bar06/card");
                var DAddcardObject = Instantiate(DAddcard, transform.position, Quaternion.identity);
                DAddcardObject.transform.position = new Vector3(1.5f + Dcount *1.5f, 2, 0);
                var AddBattlespriteRenderer = DAddcardObject.transform.GetComponent<SpriteRenderer>();
                AddBattlespriteRenderer.sprite = DcardSprite;
            }
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
