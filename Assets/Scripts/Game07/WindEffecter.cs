using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Game07
{
    public class WindEffecter : MonoBehaviour
    {
        AreaEffector2D areaEffector2D;
        BoxCollider2D boxCollider2D;
        [SerializeField,Header("力の角度")]
        private float Force_Angle = 0;
        [SerializeField, Header("力の大きさ")]
        private float Force_Power = 0;
        [SerializeField, Header("力の加減")]
        private float Force_Variation = 0;
        [SerializeField, Header("風の力の時間長さ")]
        private float Wind_Length = 30f;

        void Start()
        {
            //風の初期化
            areaEffector2D = GetComponent<AreaEffector2D>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;
            areaEffector2D.enabled = false;
            areaEffector2D.forceAngle = Force_Angle;
            areaEffector2D.forceMagnitude = Force_Power;
            areaEffector2D.forceVariation = Force_Variation;
            //DOTween.Init();
        }

        void Update()
        {
            //タイマーが動いたら風の力を変化 ハードの時だけ
            if (TimeController.instance.isCount && GameController.instance.m_gameLevel == GameController.GameLevel.Hard)
            {
                areaEffector2D.enabled = true;
                boxCollider2D.enabled = true;
                DOTween.To(() => areaEffector2D.forceMagnitude,
                Force_Power => areaEffector2D.forceMagnitude = Mathf.Repeat(Force_Power, 10),
                -10,
                Wind_Length);
            }
        }
    }

}
