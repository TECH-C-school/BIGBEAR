using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





namespace Assets.Scripts.Bar04 {
    public class GameController : MonoBehaviour {
        public void TransitionToResult() {
            SceneManager.LoadScene("Result");
        }




      [SerializeField]
      private GameObject cardPrefab;
      [SerializeField]
      private GameObject cardSelect;




        void Start()
{
    MakeCards();

}
//カード複製 or 配置
private void MakeCards()
{
    //カードを５枚複製する
    for (int i = 0; i < 5; i++)
    {
        //カードを並べる
        var cardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
        cardObject.transform.position = new Vector2(
                i * 1.8f - 3.84f, 0);

        //カード生成
        GameObject SelCard = Instantiate(cardSelect);
        SelCard.SetActive(false);

        //親子付け
        SelCard.transform.parent = cardObject.transform;


        //黄色い枠の位置の設定　　　　カードの位置　+　z軸を-1する。
        Vector3 setPosition = cardObject.transform.position + new Vector3(0, 0, -1);
        //SelCard.transform.positionの位置にsetPositionを持っていく。
        SelCard.transform.position = setPosition;

         }
      }


  }
}
