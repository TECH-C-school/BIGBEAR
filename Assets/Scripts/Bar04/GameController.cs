using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar0404 {
    public class GameController : MonoBehaviour {

        //UI関係のGameObjectの設定
        public GameObject StartButton;
        public GameObject ChangeButton;

        //カード関係の変数
        public int[] shuffulCards;
        public List<GameObject> Card;
        int nextCard=0;


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
            for (int i = 0; i < 52; i++){
                values[i] = i;
            }
            for (int i = 0; i < 52; i++)
            {
                int abc = UnityEngine.Random.Range(0, values.Length);
                int xyz;
                xyz = values[i];
                values[i] = values[abc];
                values[abc] = xyz;
            }

            return values;
        }

        //スタートボタンを押したときの処理
        public void GameStart() {
            //山札をシャッフル
            shuffulCards = MakeRundumNumber();
            MakeFirstCards();
            StartButton.SetActive(false);
            ChangeButton.SetActive(true);
        }

        public void CardChange() {
            for (int i = 0; i < Card.Count; i++){
                var cardsprict = Card[i].GetComponent<Card>();
                if (cardsprict.Select){
                    cardsprict.Number = shuffulCards[nextCard];
                    cardsprict.TurnCardFlont();
                    nextCard++;
                    cardsprict.CardSelect();

                }
            }
        }

        //最初のカードを配る        
        public void MakeFirstCards(){

            for (int i = 0; i < Card.Count; i++){
                var cardsprict = Card[i].GetComponent<Card>();
                cardsprict.Number = shuffulCards[nextCard];
                cardsprict.TurnCardFlont();
                nextCard++;
            }

        }

    }


        
       
    }



