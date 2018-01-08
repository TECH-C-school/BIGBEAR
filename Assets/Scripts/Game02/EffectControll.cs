using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Assets.Scripts.Game02
{
    public class EffectControll : MonoBehaviour
    {

        [SerializeField]
        SpriteRenderer m_spark;

        public void CreateSpark(Vector3 pos, int layerNum)
        {
            m_spark.transform.position = pos;
            m_spark.sortingOrder = layerNum;
            m_spark.gameObject.SetActive(true);

            m_spark.transform.DOScale(new Vector2(0.6f, 0.6f), 0.25f)
                .SetDelay((Game02.PlayerControll.HIT_TIME))
                .OnStart(() => { m_spark.DOFade(0, 0.15f); })
                .OnComplete(() =>
                {
                    m_spark.transform.localScale = new Vector2(0.4f, 0.4f);
                    m_spark.gameObject.SetActive(false);
                    m_spark.color = new Color(255, 255, 255, 255);
                });
        }

    }
}
