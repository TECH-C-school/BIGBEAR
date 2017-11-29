using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar0404 {
    public class GameController : MonoBehaviour {

        int[] shuffulCards;

        string[] Cards =
        {
            "c01",
            "c02",
            "c03",
            "c04",
            "c05",
            "c06",
            "c07",
            "c08",
            "c09",
            "c10",
            "c11",
            "c12",
            "c13",
            "h01",
            "h02",
            "h03",
            "h04",
            "h05",
            "h06",
            "h07",
            "h08",
            "h09",
            "h10",
            "h11",
            "h12",
            "h13",
            "d01",
            "d02",
            "d03",
            "d04",
            "d05",
            "d06",
            "d07",
            "d08",
            "d09",
            "d10",
            "d11",
            "d12",
            "d13",
            "s01",
            "s02",
            "s03",
            "s04",
            "s05",
            "s06",
            "s07",
            "s08",
            "s09",
            "s10",
            "s11",
            "s12",
            "s13",
        };


        public void TransitionToResult(){
            SceneManager.LoadScene("Result");
        }



        public void Start(){
        
 
        }



        public void Update() {
          

        }

        //山札をシャッフルするための乱数生成
        public int[] MakeRundumNumber(){
            int[] values = new int[53];
            for (int i = 0; i < 53; i++){
                values[i] = i;
            }
            for (int i = 0; i < 53; i++)
            {
                int abc = UnityEngine.Random.Range(0, values.Length);
                int xyz;
                xyz = values[i];
                values[i] = values[abc];
                values[abc] = xyz;
            }

            return values;
        }

        public void GameStart() {
            //山札をシャッフル
            shuffulCards = MakeRundumNumber();
            Debug.Log(Cards[(shuffulCards[1])]);
            MakeCards();

        }

        public void MakeCards(){
            GameObject card = (GameObject)Resources.Load("Prefabs/Bar04/Card");
            Instantiate(card, new Vector3(0,0,0), transform.rotation);
        }

    }


        
       
    }



