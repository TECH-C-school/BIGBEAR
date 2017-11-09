using UnityEngine;

namespace Assets.Scripts.Game07
{
    public class HeridController : MonoBehaviour
    {
        [SerializeField, Header("2種類のヘリコプター")]
        private GameObject[] HeridS;
        [SerializeField, Header("生成速度")]
        private float Form_speed = 1.0f;
        private float Timer = 0;
        //生成時間間隔
        private float create_Time = 3;
        Canvas canvas;

        void Start()
        {
            canvas = FindObjectOfType<Canvas>();
        }

        void Update()
        {
            //カウント
            Timer += Form_speed * Time.deltaTime;
            int random_Herid = Random.Range(0, HeridS.Length);
            if(Timer > create_Time)
            {
                Timer = 0;
                GameObject heri =  Instantiate(HeridS[random_Herid], transform.position, HeridS[random_Herid].transform.rotation);
                heri.transform.SetParent(canvas.transform);
            }
            Debug.Log(Timer);
        }
    }

}
