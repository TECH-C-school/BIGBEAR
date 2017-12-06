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
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
        public void Start()
        {
            MakeRandomNumbers();
            
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/bj_flame");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(1.35f, -1.8f, 0);
            
            makecard();
            makecard();
            tmakecard(1);
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
            if (tgou < 17) { tmakecard(0); }
        }
        private void makecard()
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/back");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-0.3f*zmai, -1, -1*zmai);

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

            gou += num2;
            zmai++;
            mai++;



        }
        private void tmakecard(int n)
        {
            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar06/back");
            var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardObject.transform.position = new Vector3(-0.3f * tmai, 1.8f, -1 * tmai);

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
            tgou += num2;
            tmai++;
            mai++;



        }
    }
}
