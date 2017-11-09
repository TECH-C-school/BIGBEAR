using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UniRx.Triggers;
using UniRx;
using DG.Tweening;


namespace Assets.Scripts.Game02
{
    public class EnemyControll : MonoBehaviour
    {
        enum EnemyMode
        {
            //通常
            Normal,
            //怪しむ
            Doubt,
            //警戒する
            Alert
        }

        EnemyMode m_currentMode = EnemyMode.Normal;

        //階層座標
        private float[] m_floorPotision = new float[6]
        {
            -1.95f,
            -1.05f,
            -0.15f,
             0.75f,
             1.65f,
             2.55f
        };

        //部屋座標
        private float[] m_roomPosition = new float[4]
        {
             3.85f,
             1.25f,
            -1.32f,
            -3.90f
        };

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
