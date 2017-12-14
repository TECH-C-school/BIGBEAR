using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {
        private int count = 2;
        private int DeckCount = 0;          //デッキのカウント
        private int flag = 0;
        public void Start()
        {
            deck.RondomNum();
            //自分の初期カード
            Sprite cardSprite = null;
            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
            DeckCount++;
            var Mycard1 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var MycardObject1 = Instantiate(Mycard1, transform.position, Quaternion.identity);
            MycardObject1.transform.position = new Vector3(-1.5f,-1,0);
            var spriteRenderer = MycardObject1.transform.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = cardSprite;

            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
            DeckCount++;
            var Mycard2 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var MycardObject2 = Instantiate(Mycard2, transform.position, Quaternion.identity);
            MycardObject2.transform.position = new Vector3(0, -1, 0);
            spriteRenderer = MycardObject2.transform.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = cardSprite;

            //相手の初期カード
            cardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
            DeckCount++;
            var Dcard1 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var DcardObject1 = Instantiate(Dcard1, transform.position, Quaternion.identity);
            DcardObject1.transform.position = new Vector3(-1.5f, 2, 0);
            spriteRenderer = DcardObject1.transform.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = cardSprite;

            Sprite DcardSprite = null;
            DcardSprite = Resources.Load<Sprite>("Images/Bar/Cards/" + deck.randommark[DeckCount] + deck.randomnum[DeckCount]);
            DeckCount++;
            var Dcard2 = Resources.Load<GameObject>("Prefabs/Bar06/card");
            var DcardObject2 = Instantiate(Dcard2, transform.position, Quaternion.identity);
            DcardObject2.transform.position = new Vector3(0, 2, 0);
            /*var BattlespriteRenderer = DcardObject2.transform.GetComponent<SpriteRenderer>();
            BattlespriteRenderer.sprite = DcardSprite;*/
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

            DeckCount++;
            count++;
        }
        public void BattleBottunClick()
        {
            
        }

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }
}
