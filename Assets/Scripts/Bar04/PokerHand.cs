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

            if (TwoPare(m_Hund) == 2) {
                Debug.Log("ツーペア");
            }else if(Onepare(m_Hund) == 1) {
                Debug.Log("ワンペア");
            }

        }

        int Onepare(int[] xyz) {
            for (int i = 0; i < xyz.Length; i++){
                for (int j = i+ 1 ; j < xyz.Length; j++){
                    if (xyz[i] == xyz[j]) {
                        m_Poker = 1;
                    }
                }
            }
            return m_Poker;
        }

        int TwoPare(int[] xyz) {
            for (int i = 0; i < xyz.Length; i++){
                for (int j = i+ 1 ; j < xyz.Length; j++){
                    if (xyz[i] == xyz[j]) {
                        for (int k = j+1 ; k < xyz.Length; k++)
                        {
                            for (int l = k + 1; l < xyz.Length; l++)
                            {
                                if (xyz[k] == xyz[l])
                                {
                                    m_Poker = 2;
                                }
                            }
                        }
                    }
                }
            }
            return m_Poker;
        }

    }


}