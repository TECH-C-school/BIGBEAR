using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar0404 {



    public class PokerHand : MonoBehaviour {

        int[] m_Hund;
        int m_Poker;


        public int[] Hund
        {
            get { return m_Hund; }
            set { m_Hund = value; }
        }

        void Start(){
            
        }

        public void PokerCheck() {

            if (FullHouse(m_Hund)) {
                Debug.Log("フルハウス");
            }else if (Straight(m_Hund)) {
                Debug.Log("ストレート");
            } else if (ThreeCard(m_Hund)) {
                Debug.Log("スリーカード");
            }else if (TwoPare(m_Hund)) {
                Debug.Log("ツーペア");
            }else if(Onepare(m_Hund)) {
                Debug.Log("ワンペア");
            }

        }

        bool Onepare(int[] xyz) {
            bool Answer = false;
            for (int i = 0; i < xyz.Length; i++){
                for (int j = i+ 1 ; j < xyz.Length; j++){
                    if (xyz[i] == xyz[j]) {
                        Answer = true;
                    }
                }
            }
            return Answer;
        }

        bool TwoPare(int[] xyz) {
            bool Answer = false;
            for (int i = 0; i < xyz.Length; i++){
                for (int j = i+ 1 ; j < xyz.Length; j++){
                    if (xyz[i] == xyz[j]) {
                        for (int k = j+1 ; k < xyz.Length; k++)
                        {
                            for (int l = k + 1; l < xyz.Length; l++)
                            {
                                if (xyz[k] == xyz[l])
                                {
                                    Answer =true;
                                }
                            }
                        }
                    }
                }
            }
            return Answer;
        }

        bool ThreeCard(int[] xyz){
            bool Answer = false;
            for (int i = 0; i < xyz.Length; i++){
                for (int j = i+ 1 ; j < xyz.Length; j++){
                    if (xyz[i] == xyz[j]) {
                        for (int k = j + 1; k < xyz.Length; k++)
                            {
                            if (xyz[i] == xyz[k])
                            {
                                Answer = true;
                            }
                }
                    }
                }
            }
            return Answer;
        }

        bool Straight(int[] xyz) {
            bool Answer = false;
            for (int i = 0; i < xyz.Length; i++) {
                if (i == xyz.Length-1) { Answer = true; }
                else if (xyz[i + 1] != xyz[i]+1) { break; }
                
            }
            return Answer;
        }

        bool FullHouse(int[] xyz) {
            bool Answer = false;


            return Answer;
           
        }



    }


}