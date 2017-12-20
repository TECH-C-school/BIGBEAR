using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bar0404
{
    

    public class Card : MonoBehaviour
    {

        GameObject mainCamera;
        Camera main;
        
        public GameObject SelectFlame;
        bool m_select;

        string[] m_Cards = {
            "c01","c02","c03","c04","c05","c06","c07","c08","c09","c10","c11","c12","c13",
            "h01","h02","h03","h04","h05","h06","h07","h08","h09","h10","h11","h12","h13",
            "d01","d02","d03","d04","d05","d06","d07","d08","d09","d10","d11","d12","d13",
            "s01","s02","s03","s04","s05","s06","s07","s08","s09","s10","s11","s12","s13",
            "joker"
        };

        int[] m_CardsNumber = {
            1,2,3,4,5,6,7,8,9,10,11,12,13,
            1,2,3,4,5,6,7,8,9,10,11,12,13,
            1,2,3,4,5,6,7,8,9,10,11,12,13,
            1,2,3,4,5,6,7,8,9,10,11,12,13,
            0
        };

        char[] m_CardsMark = {
           'c','c','c','c','c','c','c','c','c','c','c','c','c',
           'h','h','h','h','h','h','h','h','h','h','h','h','h',
           'd','d','d','d','d','d','d','d','d','d','d','d','d',
           's','s','s','s','s','s','s','s','s','s','s','s','s',
        };

        int m_Number;

        public int Number{
            get { return m_Number; }
            set { m_Number = value; }
        }

        public bool Select {
            get { return m_select; }
            set { m_select = value; }
        }

        public int[] CardNumber{
            get { return m_CardsNumber; }
            set { m_CardsNumber = value; }
        }

        void Start(){
            mainCamera = GameObject.Find("Main Camera");
        }

        void Update(){
            
        }


        public void TurnCardFlont() {
            TurnCard(true);
        }

        public void TurnCardBack() {
            TurnCard(false);
        }


        private void TurnCard(bool FaceUp){
            Sprite Cardsprite = null;

            if (FaceUp){
                Cardsprite = Resources.Load<Sprite>("Images/Bar/Cards/" + m_Cards[m_Number]);
            }else {
                Cardsprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
            }
            var spriteRenderer = transform.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Cardsprite;
        }

        public void CardSelect(){
            if (!m_select){

                m_select = true;
                SelectFlame.SetActive(true);

            }
            else if(m_select){
                m_select = false;
                SelectFlame.SetActive(false);
            }
        }

       
    }

}