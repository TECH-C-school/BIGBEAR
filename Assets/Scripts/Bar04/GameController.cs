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

        private Queue<int> hogehoge;
        private Queue<int> decks;



        void Start()
        {
            //カード生成
            MakeCards();
            
        }


        




        //カード複製 or 配置
        private void MakeCards()
        {
  
            //52枚のカードをランダムに生成
            int[] cards = new int[51];
            for (var i = 0; i < 51; i++)
            {
                cards[i] = i + 1;
            }

            var counter = 0;
            while (counter < 51)
            {
                var index = Random.Range(counter, cards.Length);
                var tmp = cards[counter];
                cards[counter] = cards[index];
                cards[index] = tmp;

                counter++;
            }

            //ランダム作成したものを順番に入れる
            Queue<int> decks = new Queue<int>() { };
            for (var i = 0; i < 51; i++)
            {
                decks.Enqueue(cards[i]);
            }
            

            //カードを５枚複製する
            for (int i = 0; i < 5; i++)
            {
                //デッキの上から5枚取り出す
                while (decks.Count < 41)
                {
                 /*   decud*/
                }


                //カードを並べる
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector2(i * 1.8f - 3.84f, 0);

                //手札を反転する
                
                //SpriteRenderer

                GameObject SelCard = Instantiate(cardSelect);
                SelCard.SetActive(false);


                //Selcard(選択したときに光る)生成
                 SelCard = Instantiate(cardSelect);

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



    }
}
