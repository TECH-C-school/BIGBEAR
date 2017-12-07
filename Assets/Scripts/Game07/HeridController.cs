using UnityEngine;

namespace Assets.Scripts.Game07
{
    public class HeridController : MonoBehaviour
    {
        public static HeridController instance;

        [SerializeField, Header("2種類のヘリコプター")]
        private GameObject[] HeridS;
        [SerializeField, Header("生成速度")]
        private float Form_speed = 1.0f;
        private float Timer = 0;
        //生成時間間隔
        private float create_Time = 3;
        Canvas canvas;
        [SerializeField,Header("生成場所")]
        Transform AttachPoint;
        [HideInInspector]
        public bool IsTimeStart = false;//GameControllerとこのソースに使われている

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else { Destroy(gameObject); }
        }

        void Start()
        {
            canvas = FindObjectOfType<Canvas>();
        }

        void Update()
        {
            if (IsTimeStart)
            {
                // カウント
                Timer += Form_speed * Time.deltaTime;
                int random_Herid = Random.Range(0, HeridS.Length);
                if (Timer > create_Time)
                {
                    GameObject heri = Instantiate(HeridS[random_Herid], AttachPoint.position, HeridS[random_Herid].transform.rotation);
                    heri.name = HeridS[random_Herid].name;
                    heri.transform.SetParent(canvas.transform);
                    Timer = 0;
                }
                //Debug.Log(Timer);
            }
        }
        //生成間隔時間
        public float GetCreateTime
        {
            get { return create_Time; }
        }
    }

}
