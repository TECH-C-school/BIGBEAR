using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar03 {
    public class GameController : MonoBehaviour
    {
        private string _nextCardString = "c01";
        /*private string[] cardMark = new string[104] 
        {"Images/Bar/Cards/c01","Images/Bar/Cards/c02","Images/Bar/Cards/c03",
        "Images/Bar/Cards/c04","Images/Bar/Cards/c05","Images/Bar/Cards/c06",
        "Images/Bar/Cards/c07","Images/Bar/Cards/c08","Images/Bar/Cards/c09",
        "Images/Bar/Cards/c10","Images/Bar/Cards/c11","Images/Bar/Cards/c12",
        "Images/Bar/Cards/c13","Images/Bar/Cards/c01","Images/Bar/Cards/c02",
        "Images/Bar/Cards/c03","Images/Bar/Cards/c04","Images/Bar/Cards/c05",
        "Images/Bar/Cards/c06","Images/Bar/Cards/c07","Images/Bar/Cards/c08",
        "Images/Bar/Cards/c09","Images/Bar/Cards/c10","Images/Bar/Cards/c11",
        "Images/Bar/Cards/c12","Images/Bar/Cards/c13",
        "Images/Bar/Cards/d01","Images/Bar/Cards/d02","Images/Bar/Cards/d03",
        "Images/Bar/Cards/d04","Images/Bar/Cards/d05","Images/Bar/Cards/d06",
        "Images/Bar/Cards/d07","Images/Bar/Cards/d08","Images/Bar/Cards/d09",
        "Images/Bar/Cards/d10","Images/Bar/Cards/d11","Images/Bar/Cards/d12",
        "Images/Bar/Cards/d13","Images/Bar/Cards/d01","Images/Bar/Cards/d02",
        "Images/Bar/Cards/d03","Images/Bar/Cards/d04","Images/Bar/Cards/d05",
        "Images/Bar/Cards/d06","Images/Bar/Cards/d07","Images/Bar/Cards/d08",
        "Images/Bar/Cards/d09","Images/Bar/Cards/d10","Images/Bar/Cards/d11",
        "Images/Bar/Cards/d12","Images/Bar/Cards/d13",                  
        "Images/Bar/Cards/h01","Images/Bar/Cards/h02","Images/Bar/Cards/h03",
        "Images/Bar/Cards/h04","Images/Bar/Cards/h05","Images/Bar/Cards/h06",
        "Images/Bar/Cards/h07","Images/Bar/Cards/h08","Images/Bar/Cards/h09",
        "Images/Bar/Cards/h10","Images/Bar/Cards/h11","Images/Bar/Cards/h12",
        "Images/Bar/Cards/h13","Images/Bar/Cards/h01","Images/Bar/Cards/h02",
        "Images/Bar/Cards/h03","Images/Bar/Cards/h04","Images/Bar/Cards/h05",
        "Images/Bar/Cards/h06","Images/Bar/Cards/h07","Images/Bar/Cards/h08",
        "Images/Bar/Cards/h09","Images/Bar/Cards/h10","Images/Bar/Cards/h11",
        "Images/Bar/Cards/h12","Images/Bar/Cards/h13",
        "Images/Bar/Cards/s01","Images/Bar/Cards/s02","Images/Bar/Cards/s03",
        "Images/Bar/Cards/s04","Images/Bar/Cards/s05","Images/Bar/Cards/s06",
        "Images/Bar/Cards/s07","Images/Bar/Cards/s08","Images/Bar/Cards/s09",
        "Images/Bar/Cards/s10","Images/Bar/Cards/s11","Images/Bar/Cards/s12",
        "Images/Bar/Cards/s13","Images/Bar/Cards/s01","Images/Bar/Cards/s02",
        "Images/Bar/Cards/s03","Images/Bar/Cards/s04","Images/Bar/Cards/s05",
        "Images/Bar/Cards/s06","Images/Bar/Cards/s07","Images/Bar/Cards/s08",
        "Images/Bar/Cards/s09","Images/Bar/Cards/s10","Images/Bar/Cards/s11",
        "Images/Bar/Cards/s12","Images/Bar/Cards/s13"} ;*/
        void Start()
        {
            MakeBackCards();
            BackGroundMake();
            ClickCard();
        }
        void Update()
        {
            ClickCard();
        }
        //多分リザルト
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }

        //裏面のカードをセットする関数
        private void MakeBackCards()
        {
            int count = 0;
            string[] cardMarkNumber = new string[52];
            cardSetMN(cardMarkNumber);
            int[] mergedArray = cardMarkNumber.Concat(cardMarkNumber).ToArray();

            Transform parentObject = GameObject.Find("Cards").transform;
            GameObject cardPrefabs = Resources.Load<GameObject>("Prefabs/Bar03/Back");
            for (int x = 0; x < 10; x++)
            {
                int n = 4;
                if( x < 4)
                {
                    n = 5;
                }
                
                for (int y = 0; y < n + 1; y++)
                {
                    if (y < n)
                    {
                        var cardObject = Instantiate(cardPrefabs, transform.position, Quaternion.identity);
                        cardObject.transform.position = new Vector3(
                            x * 1.76f - 7.97f,
                            -y * 0.31f + 3.66f,
                            -y * 0.1f);
                        cardObject.transform.parent = parentObject;
                        Cards cardSet = cardObject.GetComponent<Cards>();
                        cardSet.String = cardMarkNumber[count];
                        cardSet.TurnCardFaceDown();
                        count++;
                    }
                    else
                    {
                        var cardObject = Instantiate(cardPrefabs, transform.position, Quaternion.identity);
                        cardObject.transform.position = new Vector3(
                            x * 1.76f - 7.97f,
                            -y * 0.31f + 3.66f,
                            -y * 0.1f);
                        cardObject.transform.parent = parentObject;
                        Cards cardSet = cardObject.GetComponent<Cards>();
                        cardSet.String = cardMarkNumber[count];
                        cardSet.TurnCardFaceUp();
                        count++;
                    }
                }
            }
        }

        //randomにカードを配列にいれる関数
        private string[] cardSetMN(string[] values)
        {
            int[] card = new int[52];

            for (int i = 0; i < card.Length; i++)
            {

                card[i] = i;

            }

            Random random = new Random();

            for (int i = 0; i < card.Length; i++)

            {

                int ransu = Random.Range(1,52);


                int kari = card[i];

                card[i] = card[ransu];

                card[ransu] = kari;

            }

            int kazu = 0;
            
            string[] mark = new string[] { "h", "d", "s", "c" };

            for (int i = 0; i < card.Length; i++)

            {
        
                kazu = card[i] % 13 + 1;

                if (kazu < 10)
                {
                    values[i] += mark[card[i] / 13] + "0" + kazu.ToString();
                }
                else
                {
                    values[i] += mark[card[i] / 13] + kazu.ToString();
                }
            }
            return values;
            

        }

        //背景を作る関数
        private void BackGroundMake()
        {
            Transform parentObject1 = GameObject.Find("UpCardFlame").transform;
            Transform parentObject2 = GameObject.Find("DownCardFlame").transform;
            GameObject UpCardFlamePrefabs = Resources.Load<GameObject>("Prefabs/Bar03/UpCardFlame");
            GameObject DownCardFlamePrefabs = Resources.Load<GameObject>("Prefabs/Bar03/DownCardFlame");
            int y = 0;
            for (int x = 0; x < 10; x++)
            {
                var UpCardFlameObject = Instantiate(UpCardFlamePrefabs, transform.position, Quaternion.identity);
                UpCardFlameObject.transform.position = new Vector3(
                    x * 1.76f - 7.97f, 1.12f + 0.5724931f,
                    0);
                UpCardFlameObject.transform.parent = parentObject1;
                if (x != 1)
                {
                    var DownCardFlameObject = Instantiate(DownCardFlamePrefabs, transform.position, Quaternion.identity);
                    DownCardFlameObject.transform.position = new Vector3(
                        x * 1.76f - 7.97f, -3.47f + 0.5724931f,
                        0);
                    DownCardFlameObject.transform.parent = parentObject2;
                }
            }
        }
        //ランダムな数字の配列を作る関数
        private int[] MakeRandomNumbers()
        {
            int[] values = new int[104];
            for (int n = 0; n < 104; n++)
            {
                values[n] += n + 1;
            }
            var counter = 0;
            while (counter < 104)
            {
                var index = Random.Range(counter, values.Length);
                var tmp = values[counter];
                values[counter] = values[index];
                values[index] = tmp;

                counter++;
            }
            
            return values;
        }
        private void ClickCard()
        {
            //マウスクリックの判定
            if (!Input.GetMouseButtonDown(0)) return;

            //クリックされた位置を取得
            var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Collider2D上クリックの判定
            if (!Physics2D.OverlapPoint(tapPoint)) return;

            //クリックされた位置のオブジェクトを取得
            var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
            if (!hitObject) return;

            //クリックされたカードスクリプトを取得
            var card = hitObject.collider.gameObject.GetComponent<Cards>();
            Debug.Log("hit object is" + card.String);

            //次にクリックされるカードが判明
            //if (_nextCardString != card.String) return;

            //カードを反転する
            card.TurnCardFaceUp();
            


        }

    }

}
