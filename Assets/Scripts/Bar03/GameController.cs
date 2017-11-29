using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar03 {
    public class GameController : MonoBehaviour
    {
        
        private string[] cardMark = new string[104] 
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
        "Images/Bar/Cards/s12","Images/Bar/Cards/s13"} ;
        void Start()
        {
            MakeBackCards();
            BackGroundMake();
            
            
        }
        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
        private void MakeBackCards()
        {
            int count = 0;
            int[] randomNumbers = MakeRandomNumbers();

            Transform parentObject = GameObject.Find("Cards").transform;
            GameObject cardPrefabs = Resources.Load<GameObject>("Prefabs/Bar03/Back");
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 6; y++)
                {

                    var cardObject = Instantiate(cardPrefabs, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector3(
                        x * 1.76f - 7.97f,
                        y * 0.31f + 2.06f,
                        0);
                    cardObject.transform.parent = parentObject;

                    Cards cardSet = cardObject.GetComponent<Cards>();
                    
                    count++;
                }
            }
        }
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
    }
        
}
