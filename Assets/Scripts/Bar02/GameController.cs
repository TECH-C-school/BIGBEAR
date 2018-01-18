using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Bar02 {
    public class GameController : MonoBehaviour {
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
        private void Start()
        {
            CardSet();
        }
        
        private void Update()
        {
            turnCard();
            checkCard();
            addFlame();
            if (deletedPyramid == clearPyramid && clearNum==0)
            {
                Cleared();
                clearNum++;
            }
        }

        public int clearNum = 0;

        //数値計算用int[]
        private int[] sumNum = new int[2];

        //クリック回数取得用enum
        private enum countClick
        {
            Noi = 0,
            No1,
            No2
        }
        private countClick _countClick = countClick.Noi;

        //クリック時のオブジェクト保管
        private SpriteRenderer click1;
        private SpriteRenderer click2;

        //トランプの配置格納
        private string[] cardNum = new string[53];

        //トランプのobject格納
        private GameObject[] _AllObject = new GameObject[53];

        //消えたピラミッドのカードの枚数取得
        private int deletedPyramid = 0;

        //消えたピラミッドのカードの枚数計算int
        private int clearPyramid = 21;

        //cardselectの格納
        private SpriteRenderer cardSelect1;

        //flameカード格納
        private SpriteRenderer flameRenserer;

        //winカード格納
        private SpriteRenderer winCardRenserer;

        //6段7段変更時のy座標補正値格納 6=1f 7=1.5f
        private float pyramidY = 1f;

        //6段7段変更時の段計算
        private int countPyra = 6;


        /// <summary>
        /// カードを表示
        /// </summary>
        private void CardSet()
        {

            var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar02/Cards");

            int countNumber = countPyra;
            int countCardNum = 52;
            cardNum = MakeRandCard();
            SpriteRenderer sr = cardPrefab.GetComponent<SpriteRenderer>();

            

            //ピラミッド
            for (int i = 1; i <= countPyra; i++)
            {
                for (int j = 1; j <= countNumber; j++)
                {
                    Sprite card = Resources.Load<Sprite>("Images/Bar/Cards/back");
                    sr.sprite = card;
                    sr.sortingOrder = countCardNum;
                    var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                    cardObject.transform.position = new Vector2(
                        j - (countNumber * 0.5f) - 0.5f ,
                        i * 0.5f - pyramidY);
                    _AllObject[countCardNum] = cardObject;

                    countCardNum--;
                }
                countNumber--;
            }

            //山札
            for (int k=countCardNum; k>0; k--)
            {
                Sprite card = Resources.Load<Sprite>("Images/Bar/Cards/back");
                sr.sprite = card;
                sr.sortingOrder = countCardNum;
                var cardPlaceObject = Instantiate(cardPrefab, new Vector2(4.5f, 2.0f), Quaternion.identity);
                _AllObject[countCardNum] = cardPlaceObject;
                countCardNum--;
            }
        }
        
        
        /// <summary>
        /// ランダムなカード配置
        /// </summary>
        private string[] MakeRandCard()
        {
            //52枚のカード配列 0番は空欄
            string[] toranpu = new string[53];
            int count = 1;
            for(int i = 0; i <= 3; i++)
            {
                for (int j = 01; j <= 13; j++)
                {
                    string niketa = j.ToString().PadLeft(2,'0');

                    if (i == 0) { toranpu[count] = "c" + niketa; }else
                    if (i == 1) { toranpu[count] = "d" + niketa; }else
                    if (i == 2) { toranpu[count] = "h" + niketa; }else
                    if (i == 3) { toranpu[count] = "s" + niketa; }
                    
                    count++;
                }
            }

            //ランダム化
            for(int i =1; i < toranpu.Length; i++)
            {
                int rand = Random.Range(i, toranpu.Length);
                string temp = toranpu[i];
                toranpu[i] = toranpu[rand];
                toranpu[rand] = temp;
            }
            
            return toranpu;
        }
        


        /// <summary>
        /// クリック判定
        /// </summary>
        private void checkCard()
        {
            //クリック判定
            if (!Input.GetMouseButtonDown(0)) return;

            //クリック場所取得
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //重なり合うオブジェクト取得
            Collider2D[] hitObjects = Physics2D.OverlapPointAll(tapPoint);
            if (hitObjects.Length <= 0)
            {
                selectCard(0);
                return;
            } 

            var maxCard = hitObjects[0].GetComponent<SpriteRenderer>();

            for (int i = 1; i < hitObjects.Length; i++)
            {
                var card = hitObjects[i].GetComponent<SpriteRenderer>();

                //1番手前のオブジェクト取得(oederInLayerの数値が一番大きいものを取得)
                if (maxCard.sortingOrder < card.sortingOrder) maxCard = card;
            }
            

            //表か裏かcardflameか判断
            if (maxCard.sprite.ToString().Substring(0, 4) == "back")
            {
                //山場の1番下のオブジェクト取得(クリックしていけばどんどん積みあがるようにする)
                //1番上のを取ると次のがレイヤーのせいで下に行くため
                SpriteRenderer placeCard = hitObjects[0].GetComponent<SpriteRenderer>();
                for (int i = 1; i < hitObjects.Length; i++)
                {
                    var card = hitObjects[i].GetComponent<SpriteRenderer>();
                    
                    //1番下のオブジェクト取得(oederInLayerの数値が一番小さいものを取得)
                    if (placeCard.sortingOrder > card.sortingOrder) placeCard = card;
                }
                //ピラミッドの裏返しをクリックしたらreturn
                Vector2 placeCardPosition = placeCard.transform.position;
                if (placeCardPosition != new Vector2(4.5f, 2.0f))
                {
                    selectCard(0);
                    return;
                }


                //山札のカードをとった場合、裏返して移動
                placeCard.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + cardNum[placeCard.sortingOrder]);
                placeCard.transform.position = new Vector2(3.0f, 2.0f);
                
                selectCard(0);
                return;
                
            }
            else if (maxCard.sprite.ToString().Substring(0, 9) == "cardflame")
            {
                //cardflame(山札の枠)をクリックした場合、山札を戻す
                //最後まで山札めくらないと発動せず
                ReturnPlaceCard();
                selectCard(0);
            }
            else
            {
                //spriteのカード番号の数字取得 クリック回数取得
                int maxCardNum = int.Parse(maxCard.sprite.ToString().Substring(1, 2));

                //1回目のクリック
                if(_countClick == countClick.Noi)
                {
                    //クリックしたobject収納
                    click1 = maxCard;
                    sumNum[0] = maxCardNum;
                    selectCard(1);

                    //13をクリックしたらその場で消去、クリック回数初期化
                    if (sumNum[0] == 13)
                    {
                        if (click1.transform.position != new Vector3(3, 2, 0))
                        {
                            deletedPyramid++;
                        }
                        Destroy(click1.gameObject);
                        selectCard(0);
                    }
                }
                //2回目のクリック
                else if (_countClick == countClick.No1)
                {
                    //クリックしたobject収納
                    click2 = maxCard;
                    sumNum[1] = maxCardNum;
                    selectCard(2);
                }

                //2このobjectを選択したかどうか判断
                if (_countClick != countClick.No2) return;

                //カード番号の足し算
                int sum = sumNum[0] + sumNum[1];

                //関数sumが13だったらobject消去
                if (sum == 13)
                {
                    //場のカードが消えた場合、deletedPyramidを1追加
                    if (click1.transform.position != new Vector3(3, 2, 0))
                    {
                        deletedPyramid++;
                    }
                    if (click2.transform.position != new Vector3(3, 2, 0))
                    {
                        deletedPyramid++;
                    }
                    Destroy(click1.gameObject);
                    Destroy(click2.gameObject);
                }



                //すべて終了 初期化
                selectCard(0);
            }
            
        }



        /// <summary>
        /// 山札をもとに戻す
        /// </summary>
        private void ReturnPlaceCard()
        {
            //場所returnPlaceにあるobject取得
            Collider2D[] place = Physics2D.OverlapPointAll(new Vector2(3.0f, 2.0f));
            //全部裏返して山札へ
            for (int i = 0; i < place.Length; i++)
            {
                SpriteRenderer plaCard = place[i].GetComponent<SpriteRenderer>();
                plaCard.sprite = Resources.Load<Sprite>("Images/Bar/Cards/back");
                plaCard.transform.position = new Vector2(4.5f, 2.0f);
            }
        }



        /// <summary>
        /// ピラミッドカードの自動めくり
        /// </summary>
        private void turnCard()
        {
            int countParagraph = countPyra;
            for(int i = 1; i <= countPyra; i++)
            {
                for(int j = 1; j <= countParagraph; j++)
                {
                    Vector2 checkPosition = new Vector2(j - (countParagraph * 0.5f) - 0.5f, i * 0.5f - pyramidY);
                    
                    //checkPositionのところにあるobject取得
                    Collider2D[] checkCard = Physics2D.OverlapPointAll(checkPosition);

                    //positionがcheckPositionと一致するobject取得
                    SpriteRenderer standardCard = null;
                    for (int k = 0; k < checkCard.Length; k++)
                    {
                        var card = checkCard[k].GetComponent<SpriteRenderer>();
                        Vector2 cardPosition = card.transform.position;
                        if(cardPosition == checkPosition)
                        {
                            standardCard = card;
                        }
                    }

                    //なかったら次のobjectへ
                    if (!standardCard) continue;
                    
                    //standardCardが裏か表か取得
                    if (standardCard.sprite.ToString().Substring(0, 4) == "back")
                    {
                        //i-1段のjにobjectがあるか判断
                        Vector2 checkUnderPos = new Vector2(checkPosition.x - 0.5f, checkPosition.y - 0.5f);

                        //positionがcheckUnderPosと一致するobject取得
                        SpriteRenderer UnderCard1 = null;
                        SpriteRenderer UnderCard2 = null;
                        for (int h = 0; h <= 1; h++)
                        {
                            Collider2D[] checkUnderCard = Physics2D.OverlapPointAll(checkUnderPos);
                            for (int k = 0; k < checkUnderCard.Length; k++)
                            {
                                var card = checkUnderCard[k].GetComponent<SpriteRenderer>();
                                Vector2 cardPosition = card.transform.position;
                                if (cardPosition == checkUnderPos)
                                {
                                    if(h==0) UnderCard1 = card;
                                    if(h==1) UnderCard2 = card;
                                }
                            }
                            //i-1段のj-1にobjectがあるか判断
                            checkUnderPos = new Vector2(checkPosition.x + 0.5f, checkPosition.y - 0.5f);
                        }

                        

                        //どちらもない場合にのみ処理が続く
                        if(!UnderCard1 && !UnderCard2)
                        {
                            //表にする
                            standardCard.sprite= Resources.Load<Sprite>("Images/Bar/Cards/" + cardNum[standardCard.sortingOrder]);
                        }
                    }
                    
                }
                
                countParagraph--;
            }
        }



        /// <summary>
        /// 山札の枠生成(山札のカードが無くなった場合)
        /// </summary>
        private void addFlame()
        {
            //場所取得
            Collider2D[] placeSheets = Physics2D.OverlapPointAll(new Vector2(4.5f, 2.0f));
            if (placeSheets.Length == 0)
            {
                //何もなかったらflame表示
                var flamePrefab = Resources.Load<GameObject>("Prefabs/Bar02/cardflame");
                var flameObject = Instantiate(flamePrefab, transform.position, Quaternion.identity);
                flameObject.transform.position = new Vector2(4.5f, 2.0f);
                flameRenserer = flameObject.GetComponent<SpriteRenderer>();
            }
            else if (placeSheets.Length == 1 && flameRenserer != null)
            {
                //placePocにcardflameのみ描画されている場合、return
                return;
            }
            else
            {
                //カードがあったらflame消去

                if(flameRenserer != null)
                {
                    //flame消去
                    Destroy(flameRenserer.gameObject);
                }

                
            }
        }



        /// <summary>
        /// リセットボタン処理
        /// </summary>
        public void onClickResetButton()
        {
            resetCard();
            clearReset();
            CardSet();
            deletedPyramid = 0;
            clearNum = 0;
        }



        /// <summary>
        /// リセット処理
        /// </summary>
        private void resetCard()
        {
            for (int i = 1; i < _AllObject.Length; i++)
            {
                if (!_AllObject[i]) continue;
                Destroy(_AllObject[i].gameObject);
            }
        }



        /// <summary>
        /// クリア処理
        /// </summary>
        private void Cleared()
        {
            resetCard();
            var winObject = Resources.Load<GameObject>("Prefabs/Bar02/win");
            var winCard = Instantiate(winObject, transform.position, Quaternion.identity);
            winCard.transform.position = new Vector2(0, 2);
            winCardRenserer = winCard.GetComponent<SpriteRenderer>();
        }



        /// <summary>
        /// winカードの消去
        /// </summary>
        private void clearReset()
        {
            if (winCardRenserer != null)
            {
                DestroyImmediate(winCardRenserer.gameObject, true);
            }

        }



        /// <summary>
        /// cardselect表示 countClickが変わるたびに呼び出す
        /// 0=No.i 1=no.1 2=No.2
        /// </summary>
        private void selectCard(int number)
        {
            //countClickが変わるたびに呼び出す=countClickを同時に変えてしまう(スリム化)
            if (number == 0){ _countClick = countClick.Noi; }else 
            if (number == 1){ _countClick = countClick.No1; }else
            if (number == 2){ _countClick = countClick.No2; }else return;

            //order in layer は100
            var selectPrefab = Resources.Load<GameObject>("Prefabs/Bar02/cardselect");
            SpriteRenderer selectRenderer = selectPrefab.GetComponent<SpriteRenderer>();

            if (_countClick == countClick.Noi)
            {
                //何も選択されていない時の処理
                if (cardSelect1 != null)
                {
                    DestroyImmediate(cardSelect1.gameObject, true);
                }

            }
            else if (_countClick==countClick.No1)
            {
                //1個目のcardが選択された時
                if (click1 != null)
                {
                    Vector2 click1Pos = click1.transform.position;
                    selectRenderer.sortingOrder = 100;

                    var Select1 = Instantiate(selectPrefab, transform.position, Quaternion.identity);
                    Select1.transform.position = click1Pos;
                    cardSelect1 = Select1.GetComponent<SpriteRenderer>();
                }

            }

        }
        


        /// <summary>
        /// 6段変更
        /// </summary>
        public void turn6()
        {
            resetCard();
            clearReset();

            pyramidY = 1f;
            countPyra = 6;
            clearPyramid = 21;

            CardSet();
            deletedPyramid = 0;
            clearNum = 0;
        }



        /// <summary>
        /// 7段変更
        /// </summary>
        public void turn7()
        {
            resetCard();
            clearReset();

            pyramidY = 1.5f;
            countPyra = 7;
            clearPyramid = 28;

            CardSet();
            deletedPyramid = 0;
            clearNum = 0;
        }
    }
}
