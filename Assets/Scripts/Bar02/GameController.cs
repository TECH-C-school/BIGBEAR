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

        private void Update()
        {
            ClickCard();
        }

        /// <summary>
        /// カードを表示
        /// </summary>
        private void CardSet()
        {

            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar02/Cards");

            int countNumber = 6;
            int countCardNum = 20;
            string[] cardNum = MakeRandCard();
            SpriteRenderer sr = cardPrefab.GetComponent<SpriteRenderer>();
            sr.sortingOrder = 21;


            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= countNumber; j++)
                {
                    var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector2(
                        j - countNumber * 0.5f - 0.5f ,
                        i * 0.5f - 1f);
                    Sprite card = Resources.Load<Sprite>("Images/Bar/Cards/"+ cardNum[countCardNum] );
                    sr.sprite = card;
                    sr.sortingOrder = countCardNum;
                    countCardNum--;
                }
                countNumber--;
            }

        }
        
        
        /// <summary>
        /// ランダムなカード配置
        /// </summary>
        private string[] MakeRandCard()
        {
            //52枚のカード配列
            string[] toranpu = new string[52];
            int count = 0;
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
            for(int i =0; i < toranpu.Length; i++)
            {
                int rand = Random.Range(i, toranpu.Length);
                string temp = toranpu[i];
                toranpu[i] = toranpu[rand];
                toranpu[rand] = temp;
            }

            return toranpu;
        }


        private void ClickCard()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(tapPoint);

            //あたり判定があるか判断 prefabにあたり判定付ける。
            if (!Physics2D.OverlapPoint(tapPoint)) return;

            //クリックされた場所の画面にgameObjectがあるか判断
            var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
            if (!hitObject) return;

            var card = hitObject.collider.gameObject.GetComponent<SpriteRenderer>();
            Debug.Log("hit object is " + card.sprite);



            //Destroy(card.gameObject);
        }
                
    }
}
