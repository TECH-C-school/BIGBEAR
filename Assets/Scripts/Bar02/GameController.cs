using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar02 {
    public class GameController : MonoBehaviour {
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
        private void Start()
        {
            CardSet();
        }

        //数値計算用int[]
        private int[] sumNum = new int[2];

        //クリック回数取得用enum
        private enum countClick
        {
            Noi=0,
            No1,
            No2
        }
        private countClick _countClick = countClick.Noi;

        //クリック時のオブジェクト保管
        private SpriteRenderer click1;
        private SpriteRenderer click2;

        private void Update()
        {
            checkCard();
        }

        /// <summary>
        /// カードを表示
        /// </summary>
        private void CardSet()
        {

            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar02/Cards");

            int countNumber = 6;
            int countCardNum = 52;
            string[] cardNum = MakeRandCard();
            SpriteRenderer sr = cardPrefab.GetComponent<SpriteRenderer>();

            

            //ピラミッド
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= countNumber; j++)
                {
                    Sprite card = Resources.Load<Sprite>("Images/Bar/Cards/" + cardNum[countCardNum]);
                    sr.sprite = card;
                    sr.sortingOrder = countCardNum;
                    countCardNum--;
                    var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector2(
                        j - (countNumber * 0.5f) - 0.5f ,
                        i * 0.5f - 1f);

                    
                }
                countNumber--;
            }

            //山札
            for (int k=countCardNum; k>0; k--)
            {
                Sprite card = Resources.Load<Sprite>("Images/Bar/Cards/back");
                sr.sprite = card;
                sr.sortingOrder = countCardNum;
                countCardNum--;
                var cardPlaceObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardPlaceObject.transform.position = new Vector2(4.5f,2.0f);
                
            }

        }
        
        
        /// <summary>
        /// ランダムなカード配置
        /// </summary>
        private string[] MakeRandCard()
        {
            //52枚のカード配列 0番は空欄
            string[] toranpu = new string[53];
            int count = 1;
            for(int i = 0; i <= 3; i++)
            {
                for (int j = 01; j <= 13; j++)
                {
                    string niketa = j.ToString().PadLeft(2,'0');

                    if (i == 0) { toranpu[count] = "c" + niketa; }else
                    if (i == 1) { toranpu[count] = "d" + niketa; }else
                    if (i == 2) { toranpu[count] = "h" + niketa; }else
                    if (i == 3) { toranpu[count] = "s" + niketa; }
                    
                    count++;
                }
            }

            //ランダム化
            for(int i =1; i < toranpu.Length; i++)
            {
                int rand = Random.Range(i, toranpu.Length);
                string temp = toranpu[i];
                toranpu[i] = toranpu[rand];
                toranpu[rand] = temp;
            }
            
            return toranpu;
        }


        

        /// <summary>
        /// クリック判定
        /// </summary>
        private void checkCard()
        {
            //クリック判定
            if (!Input.GetMouseButtonDown(0)) return;

            //クリック場所取得
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(tapPoint);

            //重なり合うオブジェクト取得
            Collider2D[] hitObjects = Physics2D.OverlapPointAll(tapPoint);
            if (hitObjects.Length <= 0) return;

            var maxCard = hitObjects[0].GetComponent<SpriteRenderer>();

            for (int i = 1; i < hitObjects.Length; i++)
            {
                var card = hitObjects[i].GetComponent<SpriteRenderer>();

                //1番手前のオブジェクト取得(oederInLayerの数値が一番大きいものを取得)
                if (maxCard.sortingOrder < card.sortingOrder) maxCard = card;
            }

            Debug.Log(maxCard.sprite);
            
            //表か裏か判断
            if (maxCard.sprite.ToString().Substring(0, 4) == "back")
            {
                //maxCardとは別に考える(maxCardの座標が変わるだけなので、もう一度山札押しても行動起きない)
                var placeCard = maxCard;
                //ピラミッドの裏返しをクリックしたらreturn
                Vector2 placeCardPosition = placeCard.transform.position;
                if (placeCardPosition != new Vector2(4.5f, 2.0f)) return;

                //山札のカードをとった場合、裏返して移動
                string[] cardNum = MakeRandCard();
                placeCard.transform.position = new Vector2(3.0f, 2.0f);
                placeCard.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + cardNum[placeCard.sortingOrder]);
            }
            else
            {
                //spriteのカード番号の数字取得 クリック回数取得
                int maxCardNum = int.Parse(maxCard.sprite.ToString().Substring(1, 2));

                if(_countClick == countClick.Noi)
                {
                    click1 = maxCard;
                    sumNum[0] = maxCardNum;
                    Debug.Log(sumNum[0]);
                    _countClick = countClick.No1;
                    if (sumNum[0] == 13)
                    {
                        Destroy(click1.gameObject);
                        _countClick = countClick.Noi;
                    }
                }
                else if (_countClick == countClick.No1)
                {
                    click2 = maxCard;
                    sumNum[1] = maxCardNum;
                    Debug.Log(sumNum[1]);
                    _countClick = countClick.No2;
                }

                Debug.Log(_countClick);
                if (_countClick != countClick.No2) return;

                int sum = sumNum[0] + sumNum[1];
                Debug.Log(sum);
                _countClick = countClick.Noi;
            }

            

        }
                
    }
}
