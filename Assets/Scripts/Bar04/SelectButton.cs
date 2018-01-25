using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



// Use this for initialization
namespace Assets.Scripts.Bar04
{
    public class SelectButton : MonoBehaviour
    {
        /// ボタンをクリックした時の処理
        public void OnClick()
        {
           

            Debug.Log("Button click!");
            var cardArrangement = GameObject.Find("GameController").GetComponent<CardArrangement>();
                //もしGameObject.Findの中のToggle1がisOnされたら
            if (GameObject.Find("Toggle1").GetComponent<Toggle>().isOn)
            {
                //Card1を消す
                Destroy(GameObject.Find("Card1"));
                var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/Card");
                var changCard = cardArrangement.cards[cardArrangement.cardCount + 1];
                
                //Instantiate(生成するオブジェクト、場所、回転)；　回転がそのままなら↓ -5から2.5を5間になるまで足していく
                var cardObject = Instantiate(cardPrefab, new Vector3(-5 , 1.5f, 0), Quaternion.identity);
                cardObject.name = "Card1";
                var spriteRenderer = cardObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + changCard.CardString());
                cardArrangement.cardCount += 1;
                //     var eachCard = cards[i];
                gameObject.SetActive(false);
            }

            if (GameObject.Find("Toggle2").GetComponent<Toggle>().isOn)
            {
                Destroy(GameObject.Find("Card2"));
                var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/Card");
                var changCard = cardArrangement.cards[cardArrangement.cardCount + 1];

                //Instantiate(生成するオブジェクト、場所、回転)；　回転がそのままなら↓ -5から2.5を5間になるまで足していく
                var cardObject = Instantiate(cardPrefab, new Vector3(-2.5f, 1.5f, 0), Quaternion.identity);
                cardObject.name = "Card2";
                var spriteRenderer = cardObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + changCard.CardString());
                cardArrangement.cardCount += 1;
            }

            if (GameObject.Find("Toggle3").GetComponent<Toggle>().isOn)
            {
                Destroy(GameObject.Find("Card3"));
                var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/Card");
                var changCard = cardArrangement.cards[cardArrangement.cardCount + 1];

                //Instantiate(生成するオブジェクト、場所、回転)；　回転がそのままなら↓ -5から2.5を5間になるまで足していく
                var cardObject = Instantiate(cardPrefab, new Vector3(0, 1.5f, 0), Quaternion.identity);
                cardObject.name = "Card3";
                var spriteRenderer = cardObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + changCard.CardString());
                cardArrangement.cardCount += 1;
            }

            if (GameObject.Find("Toggle4").GetComponent<Toggle>().isOn)
            {
                Destroy(GameObject.Find("Card4"));
                var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/Card");
                var changCard = cardArrangement.cards[cardArrangement.cardCount + 1];

                //Instantiate(生成するオブジェクト、場所、回転)；　回転がそのままなら↓ -5から2.5を5間になるまで足していく
                var cardObject = Instantiate(cardPrefab, new Vector3(2.5f, 1.5f, 0), Quaternion.identity);
                cardObject.name = "Card4";
                var spriteRenderer = cardObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + changCard.CardString());
                cardArrangement.cardCount += 1;
            }

            if (GameObject.Find("Toggle5").GetComponent<Toggle>().isOn)
            {
                Destroy(GameObject.Find("Card5"));
                var cardPrefab = Resources.Load<GameObject>("Prefabs/Bar04/Card");
                var changCard = cardArrangement.cards[cardArrangement.cardCount + 1];

                //Instantiate(生成するオブジェクト、場所、回転)；　回転がそのままなら↓ -5から2.5を5間になるまで足していく
                var cardObject = Instantiate(cardPrefab, new Vector3(5, 1.5f, 0), Quaternion.identity);
                cardObject.name = "Card5";
                var spriteRenderer = cardObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Images/Bar/Cards/" + changCard.CardString());
                cardArrangement.cardCount += 1;
            }

            gameObject.SetActive(false);
        }
    }
}






        