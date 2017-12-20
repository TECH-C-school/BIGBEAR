using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Bar06 {
    public class GameController : MonoBehaviour {

        private int[] num = new int[52];
        private int mai = 0;
        public int gou = 0;
        private int zmai = 0;
        private int tmai = 0;
        public int tgou = 0;
        public int syotop = 0;
        public int Amine = 0;
        public int Atmine = 0;
        private int[] tekki = new int[20];
        private int tekkicon = 0;
        private int tekkifl = 0;

        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
        public void Start()
        {
            MakeRandomNumbers();
            
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/bj_flame");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(1.35f, -3.5f, 0);

            var cardPrefab2 = Resources.Load<GameObject>("Prefabs/Bar06/bj_flame");
            var cardObjec2t = Instantiate(cardPrefab2, transform.position, Quaternion.identity);
            cardObjec2t.transform.position = new Vector3(1.35f, 1.22f, 0);

            makecard();
            tmakecard(1);
            texttoku();
            makecard();
            tmakecard(0);



        }

        private void MakeRandomNumbers()
        {
            int value, j, k;
            System.Random r = new System.Random();

            for (int i = 0; i < num.Length; i++)
            {
                num[i] = i + 1;
            }
            for (int i = 0; i < 52; i++)
            {
                j = r.Next(52);
                k = r.Next(52);
                value = num[j];
                num[j] = num[k];
                num[k] = value;
            }
        }

        public void OnClick()
        {
            makecard();
            
        }
        private void makecard()
        {
            var cardsObject = GameObject.Find("Cards");
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/back");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-0.4f*zmai, -2.7f, -1*zmai);
            cardObject.transform.parent = cardsObject.transform;

            int mark;
            if (num[mai] % 13 == 0) { mark = (num[mai] / 13); } else { mark = (num[mai] / 13) + 1; }
            int num2 = num[mai] - ((mark - 1) * 13);
            string mark2 = "";
            if (mark == 1) { mark2 = "c"; }
            else if (mark == 2) { mark2 = "s"; }
            else if (mark == 3) { mark2 = "h"; }
            else if (mark == 4) { mark2 = "d"; }
            else { mark2 = ""; }

            var card = cardObject.GetComponent<Card>();
            card.Number = num2;
            card.mark = mark2;
            card.Mark();

            if (num2 ==1) { gou += 11;Amine += 1; }else if (num2 < 10) { gou += num2; }else { gou += 10; }
            if (gou > 21&&Amine!=0) { gou -= 10;Amine -= 1; }
            zmai++;
            mai++;
            textoku();

            if (gou > 21) { lose.winhyou(); bt1.OnClick();syouritu.syouri(0); }

        }
        private void tmakecard(int n)
        {
            var cardsObject = GameObject.Find("Cards2");
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/back");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-0.4f * tmai, 2f, -1 * tmai);
            cardObject.transform.parent = cardsObject.transform;

            if (tekkifl == 0)
            {
                tekki[tekkicon] = mai;
                tekkicon++;
            }

            int mark;
            if (num[mai] % 13 == 0) { mark = (num[mai] / 13); } else { mark = (num[mai] / 13) + 1; }
            int num2 = num[mai] - ((mark - 1) * 13);
            string mark2 = "";
            if (mark == 1) { mark2 = "c"; }
            else if (mark == 2) { mark2 = "s"; }
            else if (mark == 3) { mark2 = "h"; }
            else if (mark == 4) { mark2 = "d"; }
            else { mark2 = ""; }

            var card = cardObject.GetComponent<Card>();
            card.Number = num2;
            card.mark = mark2;
            card.Mark();
            if (n == 0) { card.nMark(); }
            
            if (num2 == 1) { tgou += 11; Atmine += 1; } else if (num2 < 10) { tgou += num2; } else { tgou += 10; }
            if (tgou > 21 && Atmine != 0) { tgou -= 10; Atmine -= 1; }
            tmai++;
            mai++;
            textoku();

            
        }

        

        public void clClick()
        {
            while (tgou < 17) {
                
           timei = 0; tmakecard(0);
            
            }
            Debug.Log(tgou);
            var cardsObject = GameObject.Find("Cards2").transform;

            foreach (Transform cardObject in cardsObject)
            {
                Destroy(cardObject.gameObject);
            }

            int maimai = tmai;
            int maimaimai = mai;
            mai = syotop+1;
            tmai = 0;
            tgou = 0;
            tekkifl = 1;
            for (int i = 0; tekki[i]!=0; i++)
            {
                mai = tekki[i];
                tmakecard(1);
            }
            tekkifl = 0;
            mai = maimaimai;
            texttoku();
            if (tgou < 22) {
                if (gou==tgou) { draw.winhyou();
                } else if (gou > tgou) {
                    win.winhyou(); syouritu.syouri(1);
                } else {
                    lose.winhyou(); syouritu.syouri(0);
                }
            }else { win.winhyou(); syouritu.syouri(1); }





        }


        private void textoku (){
            text.textupt(gou);
        }
        private void texttoku()
        {
            textt.textupt(tgou);
        }


        public void saiClick()
        {

            var cardsObject = GameObject.Find("Cards2").transform;
            foreach (Transform cardObject in cardsObject)
            {
                Destroy(cardObject.gameObject);
            }
            cardsObject = GameObject.Find("Cards").transform;
            foreach (Transform cardObject in cardsObject)
            {
                Destroy(cardObject.gameObject);
            }
            rireki.rirekii(gou);
            gou = 0;
            tgou = 0;
            zmai = 0;
            tmai = 0;
            tekkicon = 0;
            Amine = 0;
            Atmine = 0;
            mai = 0;
            syotop = 0;
            MakeRandomNumbers();

            for (int i = 0; i < tekki.Length; i++)
            {
                tekki[i] = 0;
            }

            makecard();
            tmakecard(1);
            texttoku();
            makecard();
            tmakecard(0);
            win.winhihyou();
            lose.winhihyou();
            draw.winhihyou();
        }

    }
}
