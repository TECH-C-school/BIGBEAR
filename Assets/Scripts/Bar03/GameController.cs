using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar03 {
    public class GameController : MonoBehaviour
    {
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
    }
        
}
