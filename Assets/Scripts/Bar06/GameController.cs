using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Text;



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
        public int coin = 10;
        public int bet = 1;
        public string guitxt = "";
        private int strt = 0;


        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
        public void Start()
        {
            MakeRandomNumbers();
            ReadFile();

            coin = int.Parse(guitxt);
            coin--;
            mais.rirekii(coin);
            bett.rirekii(bet);
            //makec();






            /*
            makecard();
            tmakecard(1);
            texttoku();
            makecard();
            tmakecard(0);
            */
            //saiClick();


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

        public void betClick()
        {
            if (bet < 5) {
                bet += 1;
                coin--;
                bett.rirekii(bet);
                mais.rirekii(coin);
                betg.textupt(bet);
                //makec();
            }             
        }
        public void betClickm()
        {
            if (bet > 1)
            {
                bet -= 1;
                coin++;
                bett.rirekii(bet);
                mais.rirekii(coin);
                betg.textupt(bet);
                //makec();
            }
        }


        public void makec(int bet2)
        {
            var cardsObject = GameObject.Find("coin");
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/coin1");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-5.68f + (-0.25f * bet2), -4.2f, -1 * bet2);
            cardObject.transform.parent = cardsObject.transform;
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

            if (gou > 21) {

                textSave(coin.ToString());
                mais.rirekii(coin);
                lose.winhyou();
                bt1.OnClick();
                syouritu.syouri(0);
                bett.rirekii(bet);
                cderi();
            }

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
                
           tmakecard(0);
            
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
                if (gou==tgou) {
                    draw.winhyou();
                    coin += bet;
                } else if (gou > tgou) {
                    win.winhyou(); syouritu.syouri(1);
                    coin += bet*2;
                    textSave(coin.ToString());
                    mais.rirekii(coin);
                    bett.rirekii(bet);
                    cderi();
                } else {
                    lose.winhyou(); syouritu.syouri(0);
                    textSave(coin.ToString());
                    mais.rirekii(coin);
                    bett.rirekii(bet);
                    cderi();
                }
            }else {
                win.winhyou(); syouritu.syouri(1);
                coin += bet*2;
                textSave(coin.ToString());
                mais.rirekii(coin);
                bett.rirekii(bet);
                cderi();
            }





        }

        private void cderi()
        {

        var cardsObject = GameObject.Find("coin").transform;
            foreach (Transform cardObject in cardsObject)
            {
                Destroy(cardObject.gameObject);
            }
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
            if (strt == 0)
            {
                var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/bj_flame");
                var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                cardObject.transform.position = new Vector3(1.35f, -3.5f, 0);

                var cardPrefab2 = Resources.Load<GameObject>("Prefabs/Bar06/bj_flame");
                var cardObjec2t = Instantiate(cardPrefab2, transform.position, Quaternion.identity);
                cardObjec2t.transform.position = new Vector3(1.35f, 1.22f, 0);
                strt += 1;
            }else { strt += 1; }

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
            if (strt != 1)
            {
                rireki.rirekii(gou);
            }
            gou = 0;
            tgou = 0;
            zmai = 0;
            tmai = 0;
            tekkicon = 0;
            Amine = 0;
            Atmine = 0;
            mai = 0;
            syotop = 0;
            coin-=bet;
            //makec();
            bett.rirekii(bet);
            mais.rirekii(coin);
            MakeRandomNumbers();

            for (int i = 0; i < tekki.Length; i++)
            {
                tekki[i] = 0;
            }

            for(int j = 0; j < bet; j++)
            {
                makec(j+1);
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


        void ReadFile()
        {

            // FileReadTest.txtファイルを読み込む
            FileInfo fi = new FileInfo(Application.dataPath + "/" + "Test.txt");

            try
            {
                // 一行毎読み込み
                using (StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8))
                {
                    guitxt = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {

            }



        }

        public void textSave(string txt)
        {
            StreamWriter sw = new StreamWriter(Application.dataPath + "/" + "Test.txt", false);
            //true=追記 false=上書き
            sw.WriteLine(txt);
            sw.Flush();
            sw.Close();
        }

    }
}
