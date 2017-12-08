using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Game07
{
    public class WindEffecter : MonoBehaviour
    {
        AreaEffector2D areaEffector2D;
        [SerializeField,Header("力の角度")]
        private float Force_Angle = 0;
        [SerializeField, Header("力の大きさ")]
        private float Force_Power = -10;
        [SerializeField, Header("力の加減")]
        private float Force_Variation = 0;

        void Start()
        {
            //風の初期化
            areaEffector2D = GetComponent<AreaEffector2D>();
            areaEffector2D.forceAngle = Force_Angle;
            areaEffector2D.forceMagnitude = Force_Power;
            areaEffector2D.forceVariation = Force_Variation;
            //DOTween.Init();
        }

        void Update()
        {
            //タイマーが動いたら風の力を変化
            if (TimeCount.isCount)
            {
                DOTween.To(() => areaEffector2D.forceMagnitude,
                Force_Power => areaEffector2D.forceMagnitude = Mathf.Repeat(Force_Power, 10) * Time.deltaTime,
                -10,
                3f);
            }
        }
    }

}
