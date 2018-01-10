using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Bar07
{
    public class CoinController : MonoBehaviour
    {
        //関数使用領域
        Sprite[] numberSprite = new Sprite[10];

        private GameObject counto;
        private GameObject countt;
        private GameObject counth;
        private GameObject counton;
        private GameObject countte;
        private GameObject bet;

        private GameObject coin;
        public GameObject[] coins = new GameObject[3];

        //所持コインの枚数
        public int mycoins;

        //ベットしたコインの枚数
        //桁数でベット先を管理
        //1桁…プレイヤー　10桁…ディーラー　100桁…ドロー
        public int betcoins;

        //計算用
        int timerx = 0;

        private void Start()
        {
            //子オブジェクトを取得
            counto = gameObject.transform.FindChild("counto").gameObject;
            countt = gameObject.transform.FindChild("countt").gameObject;
            counth = gameObject.transform.FindChild("counth").gameObject;
            counton = gameObject.transform.FindChild("counton").gameObject;
            countte = gameObject.transform.FindChild("countte").gameObject;
            bet = gameObject.transform.FindChild("bet").gameObject;


        }


        //コインカウントの表示部分の処理
        //０～９９９の数値を受け取って画像で表示する

        public void CoinSprite(int number)
        {
            if (number >= 100)
            {
                counto.SetActive(true);
                countt.SetActive(true);
                counth.SetActive(true);
                counton.SetActive(false);
                countte.SetActive(false);

                timerx = number / 100;
                counth.GetComponent<SpriteRenderer>().sprite = SpriteSearch(timerx);

                timerx = number / 10 % 10;
                countt.GetComponent<SpriteRenderer>().sprite = SpriteSearch(timerx);

                timerx = number % 10;
                countt.GetComponent<SpriteRenderer>().sprite = SpriteSearch(timerx);
            }
            else if (number >= 10)
            {
                counto.SetActive(false);
                countt.SetActive(false);
                counth.SetActive(false);
                counton.SetActive(true);
                countte.SetActive(true);

                timerx = number / 10;
                countte.GetComponent<SpriteRenderer>().sprite = SpriteSearch(timerx);

                timerx = number % 10;
                counton.GetComponent<SpriteRenderer>().sprite = SpriteSearch(timerx);

            }
            else if (number >= 0)
            {
                counto.SetActive(false);
                countt.SetActive(true);
                counth.SetActive(false);
                counton.SetActive(false);
                countte.SetActive(false);

                countt.GetComponent<SpriteRenderer>().sprite = SpriteSearch(number);
            }
            //負の値の時は非表示にする
            else
            {
                counto.SetActive(false);
                countt.SetActive(false);
                counth.SetActive(false);
                counton.SetActive(false);
                countte.SetActive(false);
            }

        }

        //ベットカウントの表示部分の処理
        public void BetController(int number)
        {
            bet.GetComponent<SpriteRenderer>().sprite = SpriteSearch(number);
        }



        //スクリプト:コインクリエイターから呼ばれてコインを生成する
        public void coincreate(Vector3 ins)
        {
            if (coin == null) { coin = Resources.Load<GameObject>("Prefabs/Bar07/coin"); }
            if(betcoins < 0) { betcoins = 0; }

            switch (betcoins)
            {

                case 0:

                    if (ins.x < 0)
                    {
                        if(coins[0] == null)
                        {
                            coins[0] = Instantiate(coin, transform.position, Quaternion.identity);
                        }
                        coins[0].SetActive(true);
                        coins[0].transform.position = ins + new Vector3(0, 0.35f, -1);

                        betcoins = 1;
                        BetController(1);
                    }
                    else if (ins.x > 0)
                    {
                        if (coins[0] == null)
                        {
                            coins[0] = Instantiate(coin, transform.position, Quaternion.identity);
                        }
                        coins[0].SetActive(true);
                        coins[0].transform.position = ins + new Vector3(0, 0.35f, -1);

                        betcoins = 10;
                        BetController(1);
                    }
                    else if (ins.x == 0)
                    {
                        if (coins[0] == null)
                        {
                            coins[0] = Instantiate(coin, transform.position, Quaternion.identity);
                        }
                        coins[0].SetActive(true);
                        coins[0].transform.position = ins + new Vector3(0, 0.35f, -1);

                        betcoins = 100;
                        BetController(1);
                    }
                    break;
                case 1:

                    if (ins.x < 0)
                    {
                        if (coins[1] == null)
                        {
                            coins[1] = Instantiate(coin, transform.position, Quaternion.identity);
                        }
                        coins[1].SetActive(true);
                        coins[1].transform.position = ins + new Vector3(0.48f, 0, -1);

                        betcoins = 2;
                        BetController(2);
                    }
                    break;
                case 2:

                    if (ins.x < 0)
                    {
                        if (coins[2] == null)
                        {
                            coins[2] = Instantiate(coin, transform.position, Quaternion.identity);
                        }
                        coins[2].SetActive(true);
                        coins[2].transform.position = ins + new Vector3(-0.4f, -0.34f, -1);

                        betcoins = 3;
                        BetController(3);
                    }
                    break;
                case 3:
                    //MAXBET
                    break;
                case 10:
                    if (ins.x > 0)
                    {
                        if (coins[1] == null)
                        {
                            coins[1] = Instantiate(coin, transform.position, Quaternion.identity);
                        }
                        coins[1].SetActive(true);
                        coins[1].transform.position = ins + new Vector3(0.48f, 0, -1);

                        betcoins = 20;
                        BetController(2);
                    }
                    break;
                case 20:
                    if (ins.x > 0)
                    {
                        if (coins[2] == null)
                        {
                            coins[2] = Instantiate(coin, transform.position, Quaternion.identity);
                        }
                        coins[2].SetActive(true);
                        coins[2].transform.position = ins + new Vector3(-0.4f, -0.34f, -1);

                        betcoins = 30;
                        BetController(3);
                    }
                    break;
                case 30:
                    //MAXBET
                    break;
                case 100:
                    if (ins.x == 0)
                    {
                        if (coins[1] == null)
                        {
                            coins[1] = Instantiate(coin, transform.position, Quaternion.identity);
                        }
                        coins[1].SetActive(true);
                        coins[1].transform.position = ins + new Vector3(0.19f, 0, -1);

                        betcoins = 200;
                        BetController(2);
                    }
                    break;
                case 200:
                    if (ins.x == 0)
                    {
                        if (coins[2] == null)
                        {
                            coins[2] = Instantiate(coin, transform.position, Quaternion.identity);
                        }
                        coins[2].SetActive(true);
                        coins[2].transform.position = ins + new Vector3(-0.21f, -0.34f, -1);

                        betcoins = 300;
                        BetController(3);
                    }
                    break;
                case 300:
                    //MAXBET
                    break;

            }

        }

        //リセットボタン押下時、コイン全てを非表示にする
        public void CoinReset()
        {
            CoinController CC = GameObject.Find("CoinCounter(Clone)").GetComponent<CoinController>();

            int number = (CC.betcoins / 100 + CC.betcoins / 10 + CC.betcoins) % 100 % 10;

            switch (number)
            {
                case 1:
                    CC.coins[0].SetActive(false);

                    CC.BetController(0);
                    //再配置用にbetcoinsは保持
                    CC.betcoins = CC.betcoins * -1;
                    break;
                case 2:
                    CC.coins[0].SetActive(false);
                    CC.coins[1].SetActive(false);

                    CC.BetController(0);
                    //再配置用にbetcoinsは保持
                    CC.betcoins = CC.betcoins * -1;
                    break;
                case 3:
                    CC.coins[0].SetActive(false);
                    CC.coins[1].SetActive(false);
                    CC.coins[2].SetActive(false);

                    CC.BetController(0);
                    //再配置用にbetcoinsは保持
                    CC.betcoins = CC.betcoins * -1;
                    break;
            }


        }

        //再配置ボタン押下時、リセットの状態を戻す
        public void CoinRelocation()
        {
            CoinController CC = GameObject.Find("CoinCounter(Clone)").GetComponent<CoinController>();

            //枚数算出
            int number = -1 * (CC.betcoins / 100 + CC.betcoins / 10 + CC.betcoins) % 100 % 10;

            switch (number)
            {
                case 1:
                    CC.coins[0].SetActive(true);
                    CC.BetController(number);
                    CC.betcoins = CC.betcoins * -1;
                    break;
                case 2:
                    CC.coins[0].SetActive(true);
                    CC.coins[1].SetActive(true);
                    CC.BetController(number);
                    CC.betcoins = CC.betcoins * -1;
                    break;
                case 3:
                    CC.coins[0].SetActive(true);
                    CC.coins[1].SetActive(true);
                    CC.coins[2].SetActive(true);
                    CC.BetController(number);
                    CC.betcoins = CC.betcoins * -1;
                    break;
            }



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
    }
}