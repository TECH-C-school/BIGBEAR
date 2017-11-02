using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour {

        Dictionary<string, int> Card_List;
        Dictionary<string, int> Dust_List;

        public int markk;
        public int numm;


        void Start(){
            
            Card_List = new Dictionary<string, int>();
            Dust_List = new Dictionary<string, int>();

            // カードを 名前つけて Dictionary に 入れている
            for(int i = 1; i < 5; i++)      // マーク 4種
            {
                for(int j = 1; j < 14; j++) // 数字   1～13
                {
                    Card_List.Add(i.ToString() + j.ToString(), j);
                    // 保存は「11」「12」.......「113」のように前にマーク数字が付き、後ろに数字が付く
                }
            }
            /*
            // Dictionary から削除
            Card_List.Remove(1.ToString() + 1.ToString());

            // 入っている key と value を表示してる
            foreach (KeyValuePair<string,int> pair in Card_List) {
                Debug.Log(pair.Key + ":" + pair.Value);
            }
            // かず
            Debug.Log("Count:" + Card_List.Count);

           */

        }

        void Update(){
            // カードを配る
            // 配列からランダムに５枚ずつプレイヤーとディーラーに渡す  配列から取り出す
        }

        public void check()
        {
            int mark = Random.Range(1, 4);      // マーク
            int num = Random.Range(1, 13);      // 数字
            int used = -1;
            Debug.Log("mark :" + mark + "=======" + "num :" + num);             // key 確認
            //Debug.Log(Card_List[mark.ToString() + num.ToString()]);     // 中身確認
            
/*///   ここ、考えなければ。
 *      一度出た Key は出ないようにしなければならない
 *      一度出た Key を保存して、そのKeyの数字が出たら・・・ってやろうと思ったけど
 *      うまくいかない。かんがえよう。
 *      
 *      
            // もしDust_List(場か墓地)にあるKeyだったら Randomしなおす。
            if (Dust_List[mark.ToString() + num.ToString()] < 0) { // まずkeyがないので判定時エラーでる
                Debug.Log("かぶった");
            }
 
///*/

            Dust_List.Add(mark.ToString() + num.ToString(), used);   // Dust_Listに追加
            Debug.Log(Dust_List[mark.ToString() + num.ToString()]);
            Card_List.Remove(mark.ToString() + num.ToString());         // Card_List(山札)から削除   
        }

        public void DustCheck()
        {
            Debug.Log("そのKEYには" + Dust_List[markk.ToString() + numm.ToString()] + "が入ってる");
        }

        public void CardCreate()
        {
            
        }



        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }
    }

}
