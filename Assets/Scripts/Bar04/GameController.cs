using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
namespace Assets.Scripts.Bar04
{
    public class GameController : MonoBehaviour
    {
        /// <summary>
        /// 自分のカードと相手のカードの生成するPrefabを指定(Inspector)
        /// </summary>

            private enum Gamestate
        {
            ini,
            Start,
            FirstFaze,
            SecondFaze,
            EndFaze,
            Finish
        }
        private Gamestate _gameState = Gamestate.ini;
        public GameObject MyCard, YouCard;
        /// <summary>
        /// FadeTime指定(Inspector)
        /// </summary>
        [SerializeField]
        private float FadeIn, FadeOut;
        [SerializeField]
        RectTransform RectStartButton;
       
        
        private string _number;
        public int[] CPUDeck;
        public int[] PlayerDeck;
        public int coin;
        private string[] Carddeck01;
        private string[] CardDecks;
        //
        private int destroy;
        //string[] CardDeckini = new string[53];

        //  public List<string> CardDeckini = new List<string>();


        private void Awake()
        {
            Debug.LogWarning("Initialization.Awake が読み込まれました");
            GMAL.LoadManagerScene();
            GMAL.SceneManagerAutoLoader();
            Debug.ClearDeveloperConsole();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            Debug.Log("GameController.Start が読み込まれました");
            Carddeck01 = new string[53];
            CardRandom();
            StartBTN.MakeStartButton();
            CreateCards();

            /// <summary>
            /// startButton押された時の作動(DG有)
            /// </summary>S
            ///
            /*
            internal void StartBTN()
            {
              /*  RectStartButton.DOMoveY
                    (

                    );
                CreateCards();

            }
            */

        }
            /// <summary>
            /// カードの生成
            /// </summary>
            void CreateCards()
            {
                Debug.Log("GameController.CreateCards が読み込まれました");
                //Sequence mySequence = DOTween.Sequence();
                var myCardPrefab = MyCard;
                var youCardPrefab = YouCard;
            var cardfase = Instantiate(Resources.Load<GameObject>("Prefabs/Bar04/f_word1"), Resources.Load<GameObject>("Prefabs/Bar04/f_word1").transform.position, Quaternion.identity);
            for (int cardCounter = 0; cardCounter < 5; cardCounter++)
                {
                Debug.Log(CardDecks[cardCounter]);
                var CardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/cards/"+ CardDecks[cardCounter]);
                string[] mycards = new string[5];
                mycards[cardCounter] = CardDecks[cardCounter];
                var cardObject = Instantiate(CardPrefab, transform.position, Quaternion.identity);

                    cardObject.name = myCardPrefab.name + cardCounter;
                    cardObject.transform.position = new Vector3(-4.7f + cardCounter * 1.7f, -0.4f, 0f);
                    //cardObject.
                }
                for (var cardCounter = 0; cardCounter < 5; cardCounter++)
                {
                    var cardObject = Instantiate(youCardPrefab, transform.position, Quaternion.Euler(0, 0, 180));
                    cardObject.name = youCardPrefab.name + cardCounter;
                    cardObject.transform.position = new Vector3(-0.91f + cardCounter * 1.2f, 2.17f, 0f);

                    //var Initialization = cardObject.GetComponent<CardBox>();
                    //  Number = CardDeckini[cardCounter];// CardDecks[cardCounter];
                    /*
                    if (Carddecks[cardCounter] == null)
                    {
                        Debug.LogError("Initialization is ERROR(Carddeck is null)");
                        Debug.Break();
                        break;

                    }

                    else
                    {
                        Debug.Log(Carddecks);
                        //   Initialization.Number = Initialization.CardDecks[cardCounter];
                    }*/
                }
            }
        /// <summary>
        /// DOTweenFade(未完)
        /// </summary>

        void SecondCreateCards()
        {
            Debug.Log("GameController.CreateCards が読み込まれました");
            //Sequence mySequence = DOTween.Sequence();
            var myCardPrefab = MyCard;
            var youCardPrefab = YouCard;
           
            // var cardfase = Instantiate(Resources.Load<GameObject>("Prefabs/Bar04/f_word1"), Resources.Load<GameObject>("Prefabs/Bar04/f_word1").transform.position, Quaternion.identity);
            for (int cardCounter = 6; cardCounter < cardCounter+destroy; cardCounter++)
            {
                Debug.Log(CardDecks[cardCounter]);
                var CardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/cards/" + CardDecks[cardCounter]);
                string[] mycards = new string[5];
                mycards[cardCounter] = CardDecks[cardCounter];
                var cardObject = Instantiate(CardPrefab, transform.position, Quaternion.identity);

                cardObject.name = myCardPrefab.name + cardCounter;
                cardObject.transform.position = new Vector3(-4.7f + cardCounter * 1.7f, -0.4f, 0f);
                //cardObject.
            }
            for (var cardCounter = 0; cardCounter < 5; cardCounter++)
            {
                var cardObject = Instantiate(youCardPrefab, transform.position, Quaternion.Euler(0, 0, 180));
                cardObject.name = youCardPrefab.name + cardCounter;
                cardObject.transform.position = new Vector3(-0.91f + cardCounter * 1.2f, 2.17f, 0f);

                //var Initialization = cardObject.GetComponent<CardBox>();
                //  Number = CardDeckini[cardCounter];// CardDecks[cardCounter];
                /*
                if (Carddecks[cardCounter] == null)
                {
                    Debug.LogError("Initialization is ERROR(Carddeck is null)");
                    Debug.Break();
                    break;

                }

                else
                {
                    Debug.Log(Carddecks);
                    //   Initialization.Number = Initialization.CardDecks[cardCounter];
                }*/
            }
        }

        void CardRandom()
        {
            Debug.Log("Initialization.CardRandomが読み込まれました");
            //public List<Bar04.GameController> CardDeckini = new List<string>();
            var CardDeckini = new List<string>();
            // var CardDecks = new List<string>()
            ;            //シャッフルする配列
            for (int i = 1; i <= 13; i++)
            {
                if (i <= 9)
                {
                    CardDeckini.Add("s0" + i);
                    CardDeckini.Add("d0" + i);
                    CardDeckini.Add("h0" + i);
                    CardDeckini.Add("c0" + i);

                }
                else
                {
                    CardDeckini.Add("s" + i);
                    CardDeckini.Add("d" + i);
                    CardDeckini.Add("h" + i);
                    CardDeckini.Add("c" + i);
                }
            }
            string[] carddecks09 = CardDeckini.ToArray();
            //シャッフルする
            CardDecks = carddecks09.OrderBy(i => System.Guid.NewGuid()).ToArray();

            for (int j = 0; j < CardDeckini.Count; j++)
            {
                // Debug.Log(CardDeckini[j]);
            }

            //debuglog
            //Debug.Log("");




            //debug.log

            for (int j = 0; j < CardDeckini.Count; j++)
            {
                Debug.Log(CardDecks[j]);
            }

        }

        


    }
       
}


