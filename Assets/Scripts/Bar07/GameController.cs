using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar07
{
    public class GameController : MonoBehaviour
    {
        enum card

        {
            Clover1, Clover2, Clover3, Clover4, Clover5, Clover6, Clover7, Clover8, Clover9, Clover10, Clover11, Clover12, Clover13,
            Diamond1, Diamond2, Diamond3, Diamond4, Diamond5, Diamond6, Diamond7, Diamond8, Diamond9, Diamond10, Diamond11, Diamond12, Diamond13,
            Heart1, Heart2, Heart3, Heart4, Heart5, Heart6, Heart7, Heart8, Heart9, Heart10, Heart11, Heart12, Heart13,
            Spade1, Spade2, Spade3, Spade4, Spade5, Spade6, Spade7, Spade8, Spade9, Spade10, Spade11, Spade12, Spade13
        };
        List<card> outcard = new List<card>();
        List<card> dealercard = new List<card>();
        List<card> playercard = new List<card>();

        void distribution()
        {
            var _card = (card)Random.Range(0, 52);
            foreach (var oldc in outcard)
            {
                if (oldc == _card)
                {
                    distribution();
                    return;
                }
                else
                {

                   // Debug.Log(outcard.Count);
                }
            }
            outcard.Add(_card);
            Debug.Log(_card.ToString());
        }

        void Start()
        {
            bool natural;
            natural = false;
            for (int i = 0; i < 6; i++)
            {
                distribution();

            }
            playercard.Add(outcard[0]);
            playercard.Add(outcard[1]);
            playercard.Add(outcard[2]);
            dealercard.Add(outcard[3]);
            dealercard.Add(outcard[4]);
            dealercard.Add(outcard[5]);
            

            int playerPwer;
            int dealerPwer;
            playerPwer = Calculation(playercard[0]) + Calculation(playercard[1]);
            playerPwer = playerPwer % 10;
            if (playerPwer > 7)
            {
                Debug.Log("ナチュラル");
                natural = true;
            }
            dealerPwer = Calculation(dealercard[0]) + Calculation(dealercard[1]);
            dealerPwer = dealerPwer % 10;
            if (dealerPwer > 7)
            {
                Debug.Log("1ナチュラル1");
                natural = true;
            }
            if (natural)
            {
                if (playerPwer < dealerPwer)
                {
                    Debug.Log("バンカー");
                }
                else if (playerPwer > dealerPwer)
                {
                    Debug.Log("プレイヤー");
                }
                else
                {
                    Debug.Log("引き分け");
                }
            }

            if (!natural)
            {
                if (playerPwer < 6)
                {
                    playerPwer = playerPwer + Calculation(playercard[2]);
                    Debug.Log("びく");
                }
            }

            if (!natural)
            {
                if (dealerPwer < 3)
                {


                    {
                        dealerPwer = dealerPwer + Calculation(dealercard[2]);
                        Debug.Log("ひく");
                    }
                }
                else if(dealerPwer == )
            }
         
            Debug.Log(playerPwer);
            Debug.Log(dealerPwer);
        }

        int Calculation(card c)
        {
            int Powercard;
            Powercard = ((int)c % 13) + 1;
            if (Powercard > 9)
            {
                Powercard = 0;

            }
            return Powercard;
        }

        public void TransitionToResult()
        {
            SceneManager.LoadScene("Result");
        }
    }
}
