using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.Bar0404 {



    public class PokerHand : SingletonMonoBehaviour<PokerHand> {

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
                ScoreManager.Instance.resulttext = "ロイヤルストレートフラッシュ";
                ScoreManager.Instance.BetChip *= 5;
            }else if (FooCard(m_HundNumber)) {
                ScoreManager.Instance.resulttext = "フォーカード";
                ScoreManager.Instance.BetChip *= 3;
            } else if (FullHouse(m_HundNumber)) {
                ScoreManager.Instance.resulttext = "フルハウス";
                ScoreManager.Instance.BetChip *= 2;
            } else if(Flash(m_HundMark)){
                ScoreManager.Instance.resulttext = "フラッシュ";
                ScoreManager.Instance.BetChip = (int)Math.Floor(ScoreManager.Instance.BetChip * 1.7);
            } else if (Straight(m_HundNumber)) {
                ScoreManager.Instance.resulttext = "ストレート";
                ScoreManager.Instance.BetChip = (int)Math.Floor(ScoreManager.Instance.BetChip * 1.6);
            } else if (ThreeCard(m_HundNumber)) {
                ScoreManager.Instance.resulttext = "スリーカード";
                ScoreManager.Instance.BetChip = (int)Math.Floor(ScoreManager.Instance.BetChip * 1.5);
            } else if (TwoPare(m_HundNumber)) {
                ScoreManager.Instance.resulttext = "ツーペア";
                ScoreManager.Instance.BetChip = (int)Math.Floor(ScoreManager.Instance.BetChip*1.3);
            } else if (Onepare(m_HundNumber)) {
                ScoreManager.Instance.resulttext = "ワンペア";
            } else {
                ScoreManager.Instance.resulttext = "ノーペア";
                ScoreManager.Instance.BetChip = 0;
            }
            ScoreManager.Instance.Refund();
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
            int SameCard;
            for (int i = 0; i < xyz.Length; i++){
                SameCard = 0;
                for (int j = i+ 1 ; j < xyz.Length; j++){
                    if (xyz[i] == xyz[j]) {
                        SameCard++;
                    }
                }
                if (SameCard == 2) {
                    Answer = true;
                    break;
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
        bool Answer = false;
            int SameCard;
            for (int i = 0; i < xyz.Length; i++){
                SameCard = 0;
                for (int j = i+ 1 ; j < xyz.Length; j++){
                    if (xyz[i] == xyz[j]) {
                        SameCard++;
                    }
                }
                if (SameCard == 3) {
                    Answer = true;
                    break;
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