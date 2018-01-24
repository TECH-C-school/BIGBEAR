using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public SpriteRenderer spr_Player;//自己的结果
    public SpriteRenderer spr_Match;//对手的结果

    public List<Card> cards;//桌面上的扑克牌

    public Button button_start;//分牌按钮
    public Button button_compare;//胜负按钮

    public Sprite sp_win;
    public Sprite sp_lose;
    public List<Sprite> Card_List = new List<Sprite>();

    void Start()
    {
        //初始化界面
        spr_Match.sprite = null;
        spr_Player.sprite = null;
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].gameObject.SetActive(false);
        }
        button_compare.interactable = false;
        button_start.interactable = true;
    }

    //按下分配按钮
    public void btn_start()
    {
        spr_Match.sprite = null;
        spr_Player.sprite = null;
        //牌的序号
        List<int> indexes = new List<int>();

        //产生随机的15张牌 不重复
        for (int i = 0; i < 15; i++)
        {
            //产生0到51之间的数字
            int index = Random.Range(0, 52);
            while (indexes.Contains(index))
            {
                //如果已包含此数字 重新随机
                index = Random.Range(0, 52);
            }
            indexes.Add(index);
        }

        //根据随机产生的数字生成扑克牌
        for (int i = 0; i < 15; i++)
        {
            cards[i].gameObject.SetActive(true);
            cards[i].suit = indexes[i] / 13;
            cards[i].number = indexes[i];
            if (i >= 5 && i <= 9)
            {
                cards[i].spr.sprite = Card_List[52];
            }
            else
            {
                cards[i].spr.sprite = Card_List[cards[i].number];
            }
        }
        button_compare.interactable = true;
        button_start.interactable = false;
    }


    //按下胜负按钮
    public void btn_compare()
    {
        button_start.interactable = true;
        button_compare.interactable = false;

        //显示对面的牌
        for (int i = 5; i < 10; i++)
        {
            cards[i].spr.sprite = Card_List[cards[i].number];
        }

        //开始比较大小
        int[] a = Value(new Card[] { cards[0], cards[1], cards[2], cards[3], cards[4] });
        int[] b = Value(new Card[] { cards[5], cards[6], cards[7], cards[8], cards[9] });

        for (int i = 0; i < 9; i++)
        {
            if (a[i] > b[i])
            {
                //玩家胜利
                spr_Player.sprite = sp_win;
                spr_Match.sprite = sp_lose;
                break;
            }
            else if (a[i] < b[i])
            {
                //玩家失败
                spr_Player.sprite = sp_lose;
                spr_Match.sprite = sp_win;
                break;
            }
        }
    }



    //手牌评分 牌型
    public static int xZilch            = 8;//散牌
    public static int xOnePair          = 7;//一对
    public static int xTwoPair          = 6;//两对
    public static int xThreeOfaKind     = 5;//三条
    public static int xStraight         = 4;//顺子
    public static int xFlush            = 3;//同花
    public static int xFullhouse        = 2;//葫芦 一对+三条
    public static int xFourOfaKind      = 1;//四条
    public static int xStraightFlush    = 0;//同花顺  同花+顺子

    //传入五张牌 返回评分
    private int[] Value(Card[] theCards)
    {
        int[] result = new int[9];

        //排序
        for (int i = 0; i < 4; i++)
        {
            for (int j = i; j < 5; j++)
            {
                if (theCards[i].number < theCards[j].number 
                    ||(theCards[i].number == theCards[j].number && theCards[i].suit> theCards[j].suit))
                {
                    int suit = theCards[i].suit;
                    int number = theCards[i].number;
                    theCards[i].suit = theCards[j].suit;
                    theCards[i].number = theCards[j].number;
                    theCards[j].suit = suit;
                    theCards[j].number = number;
                }
            }

            //让A为最大
            if (theCards[i].number == 0)
                theCards[i].number = 13;
        }

        //顺子
        if (theCards[0].number - theCards[1].number == 1
            && theCards[1].number - theCards[2].number == 1
            && theCards[2].number - theCards[3].number == 1
            && theCards[3].number - theCards[4].number == 1)
        {
            result[xStraight] = theCards[0].number * 4 + theCards[0].suit;
            Debug.Log("顺子 "+theCards[0].number);
        }
        //同花
        if (theCards[0].suit == theCards[1].suit
                && theCards[0].suit == theCards[2].suit
                && theCards[0].suit == theCards[3].suit
                && theCards[0].suit == theCards[4].suit)
        {
            result[xFlush] = theCards[0].number * 4 + theCards[0].suit;
            Debug.Log("同花 " + (theCards[0].number + 1));
        }
        //同花顺
        if (result[xFlush] > 0 && result[xStraight] > 0)
        {
            result[xStraightFlush] = theCards[0].number * 4 + theCards[0].suit;
            Debug.Log("同花顺 " + (theCards[0].number + 1));
        }
        else
        {
            //判断多张
            int[] count = new int[4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = i; j < 5; j++)
                {
                    if (theCards[i].number == theCards[j].number)
                    {
                        count[i]++;
                    }
                }
            }

            int theTwo = 0;//一对
            for (int i = 0; i < 4; i++)
            {
                if (count[i] == 4)
                {
                    //发现四条
                    result[xFourOfaKind] = theCards[i].number;
                    Debug.Log("四条 " + (theCards[i].number + 1));
                    break;
                }
                else if (count[i] == 3)
                {
                    //发现三条 
                    result[xThreeOfaKind] = theCards[i].number;
                    Debug.Log("三条 " + (theCards[i].number + 1));
                    continue;
                }
                else if (count[i] == 2)
                {
                    //发现一对 
                    if (theTwo == 0 || theTwo == theCards[i].number)
                    {
                        theTwo = theCards[i].number;
                        result[xOnePair] = theCards[i].number * 4 +
                            Mathf.Max(result[xOnePair] % 10, theCards[i].suit);
                        Debug.Log("一对 " + (theCards[i].number+1));
                    }
                    else
                    {
                        //发现两对
                        result[xTwoPair] =
                            Mathf.Max(theTwo, theCards[i].number) * 13
                            + Mathf.Min(theTwo, theCards[i].number);
                        Debug.Log("两对");
                    }
                    continue;
                }
            }
           // Debug.Log("" + count[0] + " " + count[1] + " " + count[2] + " " + count[3]);
            if (result[xThreeOfaKind] > 0 && result[xOnePair] > 0)
            {
                //发现葫芦
                result[xFullhouse] = result[xThreeOfaKind];
                Debug.Log("葫芦 ");
            }
            else if (count[0] * count[1] * count[2] * count[3] == 1)
            {
                //散牌
                result[xZilch] = theCards[0].number * 4 + theCards[0].suit;
                Debug.Log("散牌 " + (theCards[0].number + 1));
            }
        }

        return result;
    }


}
