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
        [SerializeField]
        SpriteRenderer m_bullet;

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

        public void CreateBullet(Vector3 pos, int layerNum = 0)
        {
            m_bullet.sortingOrder = layerNum;
            m_bullet.transform.DOLocalRotate(new Vector3(0, 0, 180), 0.05f).SetLoops(-1);
            m_bullet.transform.DOPunchScale(new Vector3(0.1f,0.1f,1), 1f).SetLoops(-1);
            m_bullet.transform.DOScale(Vector3.one * 0.1f, 0.5f).SetLoops(-1);
        }

    }
}
