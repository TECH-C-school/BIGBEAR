using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar0404 {



    public class PokerHand : MonoBehaviour {

        int[] m_HundNumber;
        char[] m_HundMark;
        int m_Poker;


        public int[] Hund
        {
            get { return m_HundNumber; }
            set { m_HundNumber = value; }
        }

        public char[] HundM {
            get { return m_HundMark; }
            set { m_HundMark = value; }
        }

        void Start(){
            
        }

        public void PokerCheck() {
            if (RoyalStraightFlush(m_HundNumber,m_HundMark)){ 
                Debug.Log("ロイヤルストレートフラッシュ");
            }else if (FooCard(m_HundNumber)) {
                Debug.Log("フォーカード");
            } else if (FullHouse(m_HundNumber)) {
                Debug.Log("フルハウス");
            } else if(Flash(m_HundMark)){
                Debug.Log("フラッシュ");
            }else if (Straight(m_HundNumber)) {
                Debug.Log("ストレート");
            } else if (ThreeCard(m_HundNumber)) {
                Debug.Log("スリーカード");
            } else if (TwoPare(m_HundNumber)) {
                Debug.Log("ツーペア");
            } else if (Onepare(m_HundNumber)) {
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


        bool Flash(char[] xyz) {
            bool Answer = false;

            char setMark = xyz[0];
            for (int i = 0; i < xyz.Length; i++) {
                if (setMark != xyz[i]) { break; }
                if (i == xyz.Length - 1) { Answer = true; }
            }

            return Answer;
        }

        bool FullHouse(int[] xyz) {
            bool Answer = false;
            if (xyz[0]==xyz[1] && xyz[0]==xyz[2]){
                if (xyz[3] == xyz[4]) { Answer = true; }
            }else if (xyz[0] == xyz[1]){
                if (xyz[2] == xyz[3] && xyz[2] == xyz[4]){ Answer = true; }
            }
            return Answer;
        }

        bool FooCard(int[] xyz) {
            bool Answer =false;
            for (int i = 0; i < xyz.Length; i++)
            {
                for (int j = i + 1; j < xyz.Length; j++)
                {
                    if (xyz[i] == xyz[j])
                    {
                        for (int k = j + 1; k < xyz.Length; k++)
                        {
                            if (xyz[i] == xyz[k])
                            {
                                for (int l = k + 1; l < xyz.Length; l++)
                                {
                                    if (xyz[i] == xyz[l])
                                    {
                                        Answer = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Answer;
        }


        bool RoyalStraightFlush(int[] xyz,char[]abc) {
            if (Flash(abc) && xyz[0] == 10 && xyz[1] == 11 && xyz[2] == 12 && xyz[3] == 13 && xyz[4] == 14) { return true; }
            else { return false; }
        }

    }


}