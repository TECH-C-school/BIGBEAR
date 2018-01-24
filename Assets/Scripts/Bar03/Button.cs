using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {


    public void OnClick()
    {
        /*
        if (Input.GetMouseButtonDown(0)) return;
        if (NextCard != 0)
        {
            for (var a = 0; a < 4; a++)
            {
            var CardPrefabf = Resources.Load<GameObject>("Prefabs/Bar03/Front/" + Card[m_Cards[NextCard]]);
            var cardObjectf = Instantiate(CardPrefabf, transform.position, Quaternion.identity);
            cardObjectf.transform.position = new Vector3(
                a * 1.7f + -7.9f,
                -a * -0.25f + 2.35f,
                0);
            cardObjectf.transform.parent = CardObjectf;
            NextCard++;
            }

             for (var b = 0; b < 6; b++)
             {
            var CardPrefabf = Resources.Load<GameObject>("Prefabs/Bar03/Front/" + Card[m_Cards[NextCard]]);
            var cardObject2f = Instantiate(CardPrefabf, transform.position, Quaternion.identity);
            cardObject2f.transform.position = new Vector3(
                b * 1.7f + -1.0f,
                -b * -0.25f + 2.65f,
                0
                );
            cardObject2f.transform.parent = CardObjectf;
            NextCard++;
         }

        
            for (var c = NextCard; c < m_Cards.Length - 54 - (c * 10); c++)
            {

            }

        }
        else
        {

            gameObject.SetActive(false);
        }*/
    }
}
