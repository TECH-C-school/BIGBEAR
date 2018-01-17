using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





namespace Assets.Scripts.Bar04
{
    public class GameController : MonoBehaviour
    {
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }




        [SerializeField]
        private GameObject cardPrefab;
        [SerializeField]
        private GameObject cardSelect;

        [SerializeField]
        private int[] cards;



        void Start()
        {
            //カード生成
            MakeCards();
            
        }


        //数値に名前を付ける(カードの名前)
        [SerializeField]
        private string[] str =
            {"s01","s02","s03","s04","s05","s06","s07","s08","s09","s10","s11","s12","s13",
             "h01","h02","h03","h04","h05","h06","h07","h08","h09","h10","h11","h12","h13",
             "c01","c02","c03","c04","c05","c06","c07","c08","c09","c10","c11","c12","c13",
             "d01","d02","d03","d04","d05","d06","d07","d08","d09","d10","d11","d12","d13"};
          
         

        //カード複製 or 配置
        private void MakeCards()
        {
  
            //52枚の数値をランダムに生成
            cards = new int[52];
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = i;
            }

            var counter = 0;
            while (counter < cards.Length)
            {
                var index = Random.Range(counter, cards.Length);
                var tmp = cards[counter];
                cards[counter] = cards[index];
                cards[index] = tmp;

                counter++;
            }



            //カードを５枚複製する
            for (int i = 0; i < 5; i++)
            {
                //デッキの上から5枚取り出す
                 //while (cards.Length < 41)
                 //{
                 // /*   decud*/
                 //}


                //カードを並べる
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);

                cardObject.transform.position = new Vector2(i * 1.8f - 3.84f, 0);

                var spriteRenderer = cardObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + str[cards[i]]);
                

                //カードを反転する

                //Card.TuranCardFaceDown();



                //SpriteRenderer

                GameObject SelCard = Instantiate(cardSelect);


                //配置時のSelcardの透明度の設定
                var image = SelCard.GetComponent<SpriteRenderer>();
                image.color = new Color(255, 255, 255, 0);

                //親子付け
                SelCard.transform.parent = cardObject.transform;




                //黄色い枠の位置の設定　　　　カードの位置　+　z軸を-1する。
                Vector3 setPosition = cardObject.transform.position + new Vector3(0, 0, -1);
                //SelCard.transform.positionの位置にsetPositionを持っていく。
                SelCard.transform.position = setPosition;

            }
        }

        //役作成




    }
}
