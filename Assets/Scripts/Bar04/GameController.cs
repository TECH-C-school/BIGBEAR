using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar0404 {
    public class GameController : MonoBehaviour {

        int[] shuffulCards;

        public void TransitionToResult(){
            SceneManager.LoadScene("Result");
        }
             public void GameStart(){

            //山札をシャッフル
            shuffulCards = MakeRundumNumber();
            Debug.Log(shuffulCards[1]);
            

        }

        //山札をシャッフルするための乱数生成
        public int[] MakeRundumNumber(){
            int[] values = new int[53];
            for (int a = 0; a < 53; a++)
            {
                values[a] = a + 1;
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
    }


        
       
    }



