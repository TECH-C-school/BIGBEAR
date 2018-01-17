using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07
{
    public class ResultController : MonoBehaviour
    {
        private SpriteRenderer player;
        private SpriteRenderer dealer;
        private GameObject playermessage;
        private GameObject dealermessage;

        //0…lose 1…win
        private Sprite[] resultsprite = new Sprite[2];

        private Sprite[] numberSprite = new Sprite[10];
        private Sprite[] cardSprite = new Sprite[52];
        private int playerscore = 0;
        private int dealerscore = 0;
        public int count = 0;
        public  int[] randomarray;

        private string[] cardstr = new string[52];

        HistoryController HC;
        CoinController CC;

        private void Start()
        {
            resultsprite[0] = Resources.Load<Sprite>("Images/Bar/bakaralose");
            resultsprite[1] = Resources.Load<Sprite>("Images/Bar/bakarawin");
            player = gameObject.transform.FindChild("number_player").gameObject.GetComponent<SpriteRenderer>();
            dealer = gameObject.transform.FindChild("number_dealer").gameObject.GetComponent<SpriteRenderer>();
            playermessage = gameObject.transform.FindChild("message_player").gameObject;
            dealermessage = gameObject.transform.FindChild("message_dealer").gameObject;
            randomarray = new int[5];
            randomarray[0] = -1;

            HC = GameObject.Find("historytext(Clone)").GetComponent<HistoryController>();
            CC = GameObject.Find("CoinCounter(Clone)").GetComponent<CoinController>();

            cardstr[0] = "c01";
            cardstr[1] = "c02";
            cardstr[2] = "c03";
            cardstr[3] = "c04";
            cardstr[4] = "c05";
            cardstr[5] = "c06";
            cardstr[6] = "c07";
            cardstr[7] = "c08";
            cardstr[8] = "c09";
            cardstr[9] = "c10";
            cardstr[10] = "c11";
            cardstr[11] = "c12";
            cardstr[12] = "c13";
            cardstr[13] = "d01";
            cardstr[14] = "d02";
            cardstr[15] = "d03";
            cardstr[16] = "d04";
            cardstr[17] = "d05";
            cardstr[18] = "d06";
            cardstr[19] = "d07";
            cardstr[20] = "d08";
            cardstr[21] = "d09";
            cardstr[22] = "d10";
            cardstr[23] = "d11";
            cardstr[24] = "d12";
            cardstr[25] = "d13";
            cardstr[26] = "h01";
            cardstr[27] = "h02";
            cardstr[28] = "h03";
            cardstr[29] = "h04";
            cardstr[30] = "h05";
            cardstr[31] = "h06";
            cardstr[32] = "h07";
            cardstr[33] = "h08";
            cardstr[34] = "h09";
            cardstr[35] = "h10";
            cardstr[36] = "h11";
            cardstr[37] = "h12";
            cardstr[38] = "h13";
            cardstr[39] = "s01";
            cardstr[40] = "s02";
            cardstr[41] = "s03";
            cardstr[42] = "s04";
            cardstr[43] = "s05";
            cardstr[44] = "s06";
            cardstr[45] = "s07";
            cardstr[46] = "s08";
            cardstr[47] = "s09";
            cardstr[48] = "s10";
            cardstr[49] = "s11";
            cardstr[50] = "s12";
            cardstr[51] = "s13";

        }


        //勝者を決定して反映する
        public void DesideWinner()
        {
            if (playerscore < dealerscore)
            {
                playermessage.GetComponent<SpriteRenderer>().sprite = resultsprite[0];
                dealermessage.GetComponent<SpriteRenderer>().sprite = resultsprite[1];

                HC.ChangeHistory("D");

                //持ちコインを増やす　倍率は2,2,10
                //要修正
                //betcoinsではリセット時も存在する扱いになり、結果不正にコインが増えてしまう
                CC.CoinResult(CC.betcoins  % 100 / 10 * 2);

            }
            else if(playerscore > dealerscore)
            {
                playermessage.GetComponent<SpriteRenderer>().sprite = resultsprite[1];
                dealermessage.GetComponent<SpriteRenderer>().sprite = resultsprite[0];

                HC.ChangeHistory("P");

                CC.CoinResult(CC.betcoins  % 10 * 2);
            }
            else if(playerscore == dealerscore)
            {
                playermessage.GetComponent<SpriteRenderer>().sprite = resultsprite[0];
                dealermessage.GetComponent<SpriteRenderer>().sprite = resultsprite[0];
                HC.ChangeHistory((playerscore).ToString());

                CC.CoinResult(CC.betcoins  / 100 * 10);
            }
            playermessage.SetActive(true);
            dealermessage.SetActive(true);

        }

        //数値を受け取ってスコアとして反映する
        //真でプレイヤー、偽でディーラーに入れる
        public void ChangeScore(int number,bool side)
        {
            if(side == true)
            {
                playerscore = (playerscore + number) % 10;
                player.sprite = SpriteSearch(playerscore);

            }else if(side == false)
            {
                dealerscore = (dealerscore + number) % 10;
                dealer.sprite = SpriteSearch(dealerscore);

            }
        }





        //ランダムなカードのスプライトを返す
        //4枚ずつの乱数配列を用いており、その中で被ることはないが
        //枚数を変更する際はここを変更しないと同じカードが2枚存在してしまうため注意
        public Sprite CardChange()
        {
            if(randomarray[0] < 0) { randomarray = MakeRandomNumbers(4); }

            Sprite result = CardSearch(randomarray[count]);
            count += 1;
            if(count == 4) { randomarray[0] = -1; }
            return result;
        }

        //指定したナンバーの数字スプライトを渡す
        private Sprite SpriteSearch(int number)
        {
            Sprite result;
            if (numberSprite[number] == null)
            {
                switch (number)
                {
                    case 0:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_0");
                        break;
                    case 1:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_1");
                        break;
                    case 2:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_2");
                        break;
                    case 3:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_3");
                        break;
                    case 4:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_4");
                        break;
                    case 5:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_5");
                        break;
                    case 6:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_6");
                        break;
                    case 7:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_7");
                        break;
                    case 8:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_8");
                        break;
                    case 9:
                        numberSprite[number] = Resources.Load<Sprite>("Images/Bar/t_9");
                        break;
                    default:
                        result = null;
                        break;

                }
            }

            result = numberSprite[number];


            return result;
        }

        //乱数を配列で返す
        private int[] MakeRandomNumbers(int number)
        {
            int[] values = new int[52];
            int[] returns = new int[number];
            int X = Random.Range(0, values.Length);
            int C = 0;
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = i + 1;
            }
            for (int i = 0; i < values.Length; i++)
            {
                C = values[i];
                values[i] = values[X];
                values[X] = C;
                X = Random.Range(i, values.Length);

            }

            for (int i = 0; i < number; i++)
            {
                returns[i] = values[i];
            }

            return returns;
        }

        //指定したナンバーのカードスプライトを渡す
        private Sprite CardSearch(int number)
        {
            Sprite result;

            if (cardSprite[number] == null)
            {
                cardSprite[number] = Resources.Load<Sprite>("Images/Bar/Cards/" + cardstr[number]);

            }

            result = cardSprite[number];


            return result;
        }



    }
}
