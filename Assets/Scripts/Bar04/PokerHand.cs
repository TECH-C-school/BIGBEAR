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
            for (int i = 0; i < m_Hund.Length; i++) {
                Debug.Log(m_Hund[i]);
            }

            Onepare(m_Hund);

            switch (m_Poker) {
                case 1:
                    Debug.Log("ワンペア");
                    break;
            }

        }

        void Onepare(int[] xyz) {
            for (int i = 0; i < xyz.Length; i++){
                for (int j = i+ 1 ; j < xyz.Length; j++){
                    if (xyz[i] == xyz[j]) {
                        m_Poker = 1;
                    }
                }
            }
        }

    }


}